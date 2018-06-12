using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Data.SqlTypes;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using FrbaHotel.Clases;

namespace FrbaHotel
{
    public class Database
    {
        #region Atributos

        private static String configuracionConexion = ConfigurationManager.AppSettings["conexionSQL"];
        private static SqlConnection conexion = new SqlConnection(configuracionConexion);

        #endregion

        #region Conexion

        public static SqlConnection conexionObtener()
        {
            return conexion;
        }

        public static void conexionAbrir()
        {
            conexion.Open();
        }

        public static void conexionCerrar()
        {
            conexion.Close();
        }

        #endregion

        #region Consulta

        public static SqlCommand consultaCrear(string consulta)
        {
            return new SqlCommand(consulta, conexionObtener());
        }

        public static int consultaEjecutar(SqlCommand consulta)
        {
            int resultado = 0;
            conexionAbrir();           
            try
            {
                resultado = consulta.ExecuteNonQuery();
            }
            catch (Exception excepcion)
            {
                ventanaInformarErrorDatabase(excepcion);
            }
            conexionCerrar();
            return resultado;
        }

        public static DataSet consultaObtenerDatos(SqlCommand consulta)
        {
            DataSet dataSet = new DataSet();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta);
                dataAdapter.Fill(dataSet);
            }
            catch(Exception excepcion)
            {
                ventanaInformarErrorDatabase(excepcion);
            }
            return dataSet;
        }

        public static DataTable consultaObtenerTabla(SqlCommand consulta)
        {
            DataSet dataSet = consultaObtenerDatos(consulta);
            DataTable tabla = dataSet.Tables[0];
            return tabla;
        }

        public static List<string> consultaObtenerLista(SqlCommand consulta)
        {
            DataTable tabla = consultaObtenerTabla(consulta);
            List<string> columna = new List<string>();
            if (tabla.Rows.Count > 0)
                foreach (DataRow fila in tabla.Rows)
                    columna.Add(fila[0].ToString());
            return columna;
        }

        public static string consultaObtenerValor(SqlCommand consulta)
        {
            List<string> columna = consultaObtenerLista(consulta);
            if(columna.Count > 0)
                return columna[0];
            else
                return "";
        }

        public static DataRow consultaObtenerFila(SqlCommand consulta)
        {
            DataTable tabla = consultaObtenerTabla(consulta);
            if (tabla.Rows.Count > 0)
                return tabla.Rows[0];
            else
                return null;
        }

        public static bool consultaValorEsIgualA(string valor, int numero)
        {
            int resultado = Convert.ToInt32(valor);
            return resultado == numero;
        }

        public static bool consultaValorEsMayorA(string valor, int numero)
        {
            int resultado = Convert.ToInt32(valor);
            return resultado > numero;
        }

        public static bool consultaValorEsMenorA(string valor, int numero)
        {
            int resultado = Convert.ToInt32(valor);
            return resultado < numero;
        }

        public static bool consultaValorNoExiste(string valor)
        {
            return valor == "";
        }

        public static bool consultaValorExiste(string valor)
        {
            return valor != "";
        }

        #endregion

        #region Ventana

        public static void ventanaInformarErrorDatabase(Exception excepcion)
        {
            VentanaBase.ventanaInformarErrorDatabase(excepcion);
        }

        public static void ventanaInformarError(string mensaje)
        {
            VentanaBase.ventanaInformarError(mensaje);
        }

        public static void ventanaInformarExito(string mensaje)
        {
            VentanaBase.ventanaInformarExito(mensaje);
        }

        #endregion

        #region Login

        public static byte[] loginEncriptarContraseña(string contrasenia)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding encoder = Encoding.UTF8;
                return hash.ComputeHash(encoder.GetBytes(contrasenia));
            }
        }

        public static bool loginContraseniaEsCorrecta(string contrasenia, byte[] contraseniaReal)
        {
            byte[] contraseniaEncriptada = loginEncriptarContraseña(contrasenia);
            return contraseniaEncriptada.SequenceEqual(contraseniaReal);
        }

        public static LogueoDTO loginExitoso(string nombreUsuario)
        {
            loginActualizarIntentos(nombreUsuario, 0);
            LogueoDTO logueo = new LogueoDTO();
            return logueo.informarExito(nombreUsuario);
        }

        public static LogueoDTO loginFallido(string usuario, int intentosFallidos)
        {
            intentosFallidos++;
            loginActualizarIntentos(usuario, intentosFallidos);
            LogueoDTO logueo = new LogueoDTO();
            if (intentosFallidos >= 3)
                return logueo.informarBloqueo();
            else
                return logueo.informarContraseniaIncorrecta();
        }

        public static LogueoDTO loginVerificarContrasenia(string nombreUsuario, string contrasenia, byte[] contraseniaReal, int intentosFallidos)
        {
            if (loginContraseniaEsCorrecta(contrasenia, contraseniaReal))
                return loginExitoso(nombreUsuario);
            else
                return loginFallido(nombreUsuario, intentosFallidos);
        }

        public static LogueoDTO loginCuentaBloqueada()
        {
            LogueoDTO logueo = new LogueoDTO();
            return logueo.informarBloqueo();
        }

        public static LogueoDTO loginVerificarCuenta(DataRow fila, string contrasenia)
        {
            string nombreUsuario = (string)fila["Usuario_Nombre"];
            byte[] contraseniaReal = (byte[])fila["Usuario_Contrasenia"];
            int intentosFallidos = (int)fila["Usuario_IntentosFallidos"];
            Usuario usuario = new Usuario(nombreUsuario);
            if (intentosFallidos >= 3 || usuarioBloqueado(usuario))
                return loginCuentaBloqueada();
            else
                return loginVerificarContrasenia(nombreUsuario, contrasenia, contraseniaReal, intentosFallidos);
        }

        public static bool loginUsuarioExiste(DataRow fila)
        {
            return fila != null;
        }

        public static LogueoDTO loginUsuarioInexistente()
        {
            LogueoDTO logueo = new LogueoDTO();
            return logueo.informarUsuarioInexistente();
        }

        public static LogueoDTO loginAutenticar(string nombreUsuario, string contrasenia)
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_Nombre, Usuario_Contrasenia, Usuario_IntentosFallidos FROM RIP.Usuarios WHERE Usuario_Nombre = @username");
            consulta.Parameters.AddWithValue("@username", nombreUsuario);            
            DataRow fila = consultaObtenerFila(consulta);         
            if(loginUsuarioExiste(fila))
                return loginVerificarCuenta(fila, contrasenia);
            else 
                return loginUsuarioInexistente();
        }

        public static void loginActualizarIntentos(string username, int cantidad)
        {
            SqlCommand query = consultaCrear("UPDATE RIP.Usuarios SET Usuario_IntentosFallidos = @cantidad WHERE Usuario_Nombre = @username");
            query.Parameters.AddWithValue("@username", username);
            query.Parameters.AddWithValue("@cantidad", cantidad);
            consultaEjecutar(query);
        }

        #endregion

        #region Sesion


        public static void sesionModificarContrasenia(Sesion sesion)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Usuarios SET Usuario_Contrasenia = @Contrasenia WHERE Usuario_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", sesion.usuario.nombre);
            consulta.Parameters.AddWithValue("@Contrasenia", loginEncriptarContraseña(sesion.usuario.contrasenia));
            consultaEjecutar(consulta);
            ventanaInformarExito("La contraseña fue cambiada exitosamente");
        }

        #endregion

        #region Funcionalidad

        public static string funcionalidadObtenerID(string funcionalidad)
        {
            SqlCommand consulta = consultaCrear("SELECT Funcionalidad_ID FROM RIP.Funcionalidades WHERE Funcionalidad_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", funcionalidad);
            return consultaObtenerValor(consulta);
        }
        
        public static List<string> funcionalidadObtenerTodasEnLista()
        {
            SqlCommand consulta = consultaCrear("SELECT Funcionalidad_Nombre FROM RIP.Funcionalidades");
            return consultaObtenerLista(consulta);
        }

        #endregion

        #region Rol

        public static bool rolAgregadoConExito(Rol rol)
        {
            if (rolExiste(rol))
            {
                ventanaInformarError("Ya existe un rol registrado con ese nombre");
                return false;
            }
            else
            {
                rolAgregar(rol);
                rolAgregarFuncionalidades(rol);
                ventanaInformarExito("El rol fue creado con exito");
                return true;
            }
        }

        public static bool rolModificadoConExito(Rol rol)
        {
            if (rolExiste(rol) && rolEsDistinto(rol))
            {
                ventanaInformarError("Ya existe un rol registrado con ese nombre");
                return false;
            }
            else
            {
                rolEliminarFuncionalidades(rol);
                rolModificar(rol);
                rolAgregarFuncionalidades(rol);
                ventanaInformarExito("El rol fue modificado con exito");
                return true;
            }
        }

        public static void rolEliminadoConExito(Rol rol)
        {
            rolEliminar(rol);
            ventanaInformarExito("El rol fue eliminado con exito");
        }
        
        public static void rolAgregar(Rol rol)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Roles (Rol_Nombre) VALUES (@Nombre)");
            consulta.Parameters.AddWithValue("@Nombre", rol.nombre);
            consultaEjecutar(consulta);
        }

        public static void rolModificar(Rol rol)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Roles SET Rol_Nombre = @NuevoNombre, Rol_Estado = @NuevoEstado WHERE Rol_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", rol.id);
            consulta.Parameters.AddWithValue("@Nombre", rol.nombre);
            consulta.Parameters.AddWithValue("@NuevoNombre", rol.nombre);
            consulta.Parameters.AddWithValue("@NuevoEstado", rol.estado);
            consultaEjecutar(consulta);
        }

        public static int rolEliminar(Rol rol)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Roles SET Rol_Estado = 0 WHERE Rol_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", rol.id);
            return consultaEjecutar(consulta);
        }

        public static string rolObtenerID(Rol rol)
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_ID FROM RIP.Roles WHERE Rol_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", rol.nombre);
            return consultaObtenerValor(consulta);
        }

        public static void rolAgregarFuncionalidad(Rol rol, string funcionalidad)
        { 
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Roles_Funcionalidades (RolFuncionalidad_RolID, RolFuncionalidad_FuncionalidadID) VALUES (@RolID, @FuncionalidadID)");
            consulta.Parameters.AddWithValue("@RolID", rolObtenerID(rol));
            consulta.Parameters.AddWithValue("@FuncionalidadID", funcionalidadObtenerID(funcionalidad));
            consultaEjecutar(consulta);
        }

        public static void rolAgregarFuncionalidades(Rol rol)
        {
            foreach (string funcionalidad in rol.funcionalidades)
                rolAgregarFuncionalidad(rol, funcionalidad);
        }

        public static int rolEliminarFuncionalidades(Rol rol)
        {
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Roles_Funcionalidades WHERE RolFuncionalidad_RolID = @RolID");
            consulta.Parameters.AddWithValue("@RolID", rolObtenerID(rol));
            return consultaEjecutar(consulta);
        }

        public static bool rolExiste(Rol rol)
        {
            SqlCommand consulta = consultaCrear("SELECT COUNT(*) FROM RIP.Roles WHERE Rol_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", rol.nombre);            
            return consultaValorEsMayorA(consultaObtenerValor(consulta), 0);
        }

        public static bool rolEsDistinto(Rol rol)
        {
           return rol.id != rolObtenerID(rol);
        }

        public static bool rolEstaHabilitado(Rol rol)
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_Estado FROM RIP.Roles WHERE Rol_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", rol.nombre);
            return Boolean.Parse(consultaObtenerValor(consulta));
        }

        public static bool rolNoTieneEsaFuncionalidad(Rol rol, string funcionalidad)
        {
            SqlCommand consulta = consultaCrear("SELECT COUNT(*) FROM RIP.Roles_Funcionalidades WHERE RolFuncionalidad_RolID = @RolID AND RolFuncionalidad_FuncionalidadID = @FuncionalidadID");
            consulta.Parameters.AddWithValue("@RolID", rolObtenerID(rol));
            consulta.Parameters.AddWithValue("@FuncionalidadID", funcionalidadObtenerID(funcionalidad));
            return consultaValorEsIgualA(consultaObtenerValor(consulta), 0);
        }

        public static List<string> rolObtenerFuncionalidades(Rol rol)
        {
            SqlCommand consulta = consultaCrear("SELECT Funcionalidad_Nombre FROM RIP.Funcionalidades JOIN RIP.Roles_Funcionalidades ON Funcionalidad_ID = RolFuncionalidad_FuncionalidadID JOIN RIP.Roles ON RolFuncionalidad_RolID = Rol_ID WHERE Rol_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", rol.nombre);
            return consultaObtenerLista(consulta);
        }

        public static List<string> rolObtenerFuncionalidadesFaltantes(Rol rol)
        {
            SqlCommand consulta = consultaCrear("SELECT Funcionalidad_Nombre FROM RIP.Funcionalidades WHERE Funcionalidad_ID NOT IN (SELECT RolFuncionalidad_FuncionalidadID FROM RIP.Roles_Funcionalidades JOIN RIP.Roles ON RolFuncionalidad_RolID = Rol_ID WHERE Rol_Nombre = @Nombre)");
            consulta.Parameters.AddWithValue("@Nombre", rol.nombre);
            return consultaObtenerLista(consulta);
        }
         
        public static DataTable rolObtenerTodosEnTabla()
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_ID, Rol_Nombre FROM RIP.Roles ORDER BY Rol_ID");
            return consultaObtenerTabla(consulta);
        }

       public static DataTable rolObtenerHabilitadosEnTabla()
       {
           SqlCommand consulta = consultaCrear("SELECT Rol_ID, Rol_Nombre FROM RIP.Roles WHERE Rol_Estado = 1 ORDER BY Rol_ID");
           return consultaObtenerTabla(consulta);
       }

        public static List<string> rolObtenerTodosEnLista()
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_Nombre FROM RIP.Roles");
            return consultaObtenerLista(consulta);
        }

        #endregion

        #region Usuario

        public static bool usuarioAgregadoConExito(Usuario usuario)
        {
            if (usuarioExiste(usuario))
            {
                ventanaInformarError("Ya existe un usuario registrado con ese nombre");
                return false;
            }
            if (personaEmailExiste(usuario.persona))
            {
                ventanaInformarError("Ya existe un usuario registrado con ese email");
                return false;
            }
            if (personaDocumentoExiste(usuario.persona))
            {
                ventanaInformarError("Ya existe un usuario registrado con ese documento");
                return false;
            }
            domicilioPersonaAgregar(usuario.persona.domicilio);
            personaAgregar(usuario.persona);
            usuarioAgregar(usuario);
            usuarioAgregarHoteles(usuario);
            usuarioAgregarRoles(usuario);
            ventanaInformarExito("El usuario fue creado con exito");
            return true;
        }

        public static bool usuarioModificadoConExito(Usuario usuario)
        {

            if (usuarioExiste(usuario) && usuarioDistinto(usuario))
            {
                ventanaInformarError("Ya existe un usuario registrado con ese nombre");
                return false;
            }

            if (personaEmailExiste(usuario.persona) && personaDistinta(usuario.persona))
            {
                ventanaInformarError("Ya existe un usuario registrado con ese email");
                return false;
            }
            if (personaDocumentoExiste(usuario.persona) && personaDistinta(usuario.persona))
            {
                ventanaInformarError("Ya existe un usuario registrado con ese documento");
                return false;
            }
 
            usuarioEliminarHoteles(usuario);
            usuarioEliminarRoles(usuario);
            domicilioPersonaModificar(usuario.persona.domicilio);
            personaModificar(usuario.persona);
            usuarioModificar(usuario);
            usuarioAgregarHoteles(usuario);
            usuarioAgregarRoles(usuario);
            ventanaInformarExito("El usuario fue modificado con exito");
            return true;

        }

        public static void usuarioEliminadoConExito(Usuario usuario)
        {
            usuarioEliminar(usuario);
            ventanaInformarExito("El rol fue eliminado con exito");
        }

        public static void usuarioAgregar(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Usuarios (Usuario_Nombre, Usuario_Contrasenia, Usuario_PersonaID) VALUES (@Nombre, @Contrasenia, @PersonaID)");
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            consulta.Parameters.AddWithValue("@Contrasenia", loginEncriptarContraseña(usuario.contrasenia));
            consulta.Parameters.AddWithValue("@PersonaID", personaObtenerID(usuario.persona));
            consultaEjecutar(consulta);
        }

        public static void usuarioModificar(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Usuarios SET Usuario_Nombre = @Nombre, Usuario_Contrasenia = @Contrasenia, Usuario_Estado = @Estado WHERE Usuario_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", usuario.id);
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            consulta.Parameters.AddWithValue("@Contrasenia", loginEncriptarContraseña(usuario.contrasenia));
            consulta.Parameters.AddWithValue("@Estado", usuario.estado);
            consultaEjecutar(consulta);
        }

        public static void usuarioEliminar(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Usuarios SET Usuario_Estado = 0 WHERE Usuario_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", usuario.id);
            consultaEjecutar(consulta);
        }

        public static string usuarioObtenerID(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_ID FROM RIP.Usuarios WHERE Usuario_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            return consultaObtenerValor(consulta);
        }

        public static bool usuarioExiste(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_Nombre FROM RIP.Usuarios WHERE Usuario_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            return consultaValorExiste(consultaObtenerValor(consulta));
        }

        public static bool usuarioDistinto(Usuario usuario)
        {
            return usuario.id != usuarioObtenerID(usuario);
        }

        public static void usuarioAgregarRol(Usuario usuario, Rol rol)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Usuarios_Roles (UsuarioRol_UsuarioID, UsuarioRol_RolID) VALUES (@UsuarioID, @RolID)");
            consulta.Parameters.AddWithValue("@UsuarioID", usuarioObtenerID(usuario));
            consulta.Parameters.AddWithValue("@RolID", rolObtenerID(rol));
            consultaEjecutar(consulta);
        }

        public static void usuarioAgregarHotel(Usuario usuario, Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Usuarios_Hoteles (UsuarioHotel_UsuarioID, UsuarioHotel_HotelID) VALUES (@UsuarioID, @HotelID)");
            consulta.Parameters.AddWithValue("@UsuarioID", usuarioObtenerID(usuario));
            consulta.Parameters.AddWithValue("@HotelID", hotelObtenerID(hotel));
            consultaEjecutar(consulta);
        }

        public static void usuarioAgregarHoteles(Usuario usuario)
        {
            foreach (Hotel hotel in usuario.hoteles)
                usuarioAgregarHotel(usuario, hotel);
        }

        public static void usuarioAgregarRoles(Usuario usuario)
        {
            foreach (Rol rol in usuario.roles)
                usuarioAgregarRol(usuario, rol);
        }

        public static void usuarioEliminarHoteles(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Usuarios_Hoteles WHERE UsuarioHotel_UsuarioID = @UsuarioID");
            consulta.Parameters.AddWithValue("@UsuarioID", usuarioObtenerID(usuario));
            consultaEjecutar(consulta);
        }

        public static void usuarioEliminarRoles(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Usuarios_Roles WHERE UsuarioRol_UsuarioID = @UsuarioID");
            consulta.Parameters.AddWithValue("@UsuarioID", usuarioObtenerID(usuario));
            consultaEjecutar(consulta);
        }

        public static List<string> usuarioObtenerHotelesEnLista(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT CONCAT(Domicilio_Pais, '-', Domicilio_Ciudad, '-', Domicilio_Calle, '-', Domicilio_NumeroCalle) FROM RIP.Hoteles JOIN RIP.Usuarios_Hoteles ON UsuarioHotel_HotelID = Hotel_ID JOIN RIP.Usuarios ON UsuarioHotel_UsuarioID = Usuario_ID JOIN RIP.Domicilios ON Hotel_DomicilioID = Domicilio_ID WHERE Usuario_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            return consultaObtenerLista(consulta);
        }

        public static List<string> usuarioObtenerRolesEnLista(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_Nombre FROM RIP.Roles JOIN RIP.Usuarios_Roles ON Rol_ID = UsuarioRol_RolID JOIN RIP.Usuarios ON UsuarioRol_UsuarioID = Usuario_ID WHERE Usuario_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            return consultaObtenerLista(consulta);
        }

        public static List<string> usuarioObtenerRolesHabilitadosLista(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_Nombre FROM RIP.Roles JOIN RIP.Usuarios_Roles ON Rol_ID = UsuarioRol_RolID JOIN RIP.Usuarios ON UsuarioRol_UsuarioID = Usuario_ID WHERE Usuario_Nombre = @Nombre AND Rol_Estado = 1");
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            return consultaObtenerLista(consulta);
        }

        public static List<string> usuarioObtenerHotelesFaltantesEnLista(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT CONCAT(Domicilio_Pais, '-', Domicilio_Ciudad, '-', Domicilio_Calle, '-', Domicilio_NumeroCalle) FROM RIP.Domicilios JOIN RIP.Hoteles ON Domicilio_ID = Hotel_DomicilioID WHERE Hotel_ID NOT IN (SELECT UsuarioHotel_HotelID FROM RIP.Usuarios_Hoteles WHERE UsuarioHotel_UsuarioID = @ID)");
            consulta.Parameters.AddWithValue("@ID", usuario.id);
            return consultaObtenerLista(consulta);
        }

        public static List<string> usuarioObtenerRolesFaltantesEnLista(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_Nombre FROM RIP.Roles WHERE Rol_ID NOT IN (SELECT UsuarioRol_RolID FROM RIP.Usuarios_Roles WHERE UsuarioRol_UsuarioID = @ID)");
            consulta.Parameters.AddWithValue("@ID", usuario.id);
            return consultaObtenerLista(consulta);
        }

        public static DataTable usuarioObtenerTodosEnTabla()
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_ID, Usuario_Nombre, Persona_ID, Persona_Nombre, Persona_Apellido, TipoDocumento_Descripcion, Persona_NumeroDocumento, Persona_Nacionalidad, Persona_FechaNacimiento, Persona_Telefono, Persona_Email, Domicilio_ID, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, Domicilio_NumeroCalle, Domicilio_Piso, Domicilio_Departamento FROM RIP.Usuarios JOIN RIP.Personas ON Usuario_PersonaID = Persona_ID JOIN RIP.TiposDocumentos ON Persona_TipoDocumentoID = TipoDocumento_ID JOIN RIP.Domicilios ON Persona_DomicilioID = Domicilio_ID");
            return consultaObtenerTabla(consulta);
        }

        public static DataTable usuarioObtenerHabilitadosEnTabla()
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_ID, Usuario_Nombre, Persona_ID, Persona_Nombre, Persona_Apellido, TipoDocumento_Descripcion, Persona_NumeroDocumento, Persona_Nacionalidad, Persona_FechaNacimiento, Persona_Telefono, Persona_Email, Domicilio_ID, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, Domicilio_NumeroCalle, Domicilio_Piso, Domicilio_Departamento FROM RIP.Usuarios JOIN RIP.Personas ON Usuario_PersonaID = Persona_ID JOIN RIP.TiposDocumentos ON Persona_TipoDocumentoID = TipoDocumento_ID JOIN RIP.Domicilios ON Persona_DomicilioID = Domicilio_ID WHERE Usuario_Estado = 1");
            return consultaObtenerTabla(consulta);
        }

        public static string usuarioObtenerContrasenia(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_Contrasenia FROM RIP.Usuarios WHERE Usuario_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            return consultaObtenerValor(consulta);
        }

        public static bool usuarioHabilitado(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_Estado FROM RIP.Usuarios WHERE Usuario_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            return bool.Parse(consultaObtenerValor(consulta));
        }

        public static bool usuarioBloqueado(Usuario usuario)
        {
            return !usuarioHabilitado(usuario);
        }

        #endregion

        #region Cliente

        public static bool clienteAgregadoConExito(Cliente cliente)
        {
            if (personaEmailExiste(cliente.persona))
            {
                ventanaInformarError("Ya existe un cliente registrado con ese email");
                return false;
            }
            if (personaDocumentoExiste(cliente.persona))
            {
                ventanaInformarError("Ya existe un cliente registrado con ese documento");
                return false;
            }
            domicilioPersonaAgregar(cliente.persona.domicilio);
            personaAgregar(cliente.persona);
            clienteAgregar(cliente);
            ventanaInformarExito("El cliente fue creado con exito");
            return true;
        }

        public static bool clienteModificadoConExito(Cliente cliente)
        {
            if (personaEmailExiste(cliente.persona) && personaDistinta(cliente.persona))
            {
                ventanaInformarError("Ya existe un cliente registrado con ese email");
                return false;
            }
            if (personaDocumentoExiste(cliente.persona) && personaDistinta(cliente.persona))
            {
                ventanaInformarError("Ya existe un cliente registrado con ese documento");
                return false;
            }

            domicilioPersonaModificar(cliente.persona.domicilio);
            personaModificar(cliente.persona);
            clienteModificar(cliente);
            ventanaInformarExito("El cliente fue modificado con exito");
            return true;

        }

        public static void clienteEliminadoConExito(Cliente cliente)
        {
            clienteEliminar(cliente);
            ventanaInformarExito("El cliente fue eliminado con exito");
        }

        public static void clienteAgregar(Cliente cliente)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Clientes (Cliente_PersonaID) VALUES (@PersonaID)");
            consulta.Parameters.AddWithValue("@PersonaID", personaObtenerID(cliente.persona));
            consultaEjecutar(consulta);
        }

        public static void clienteModificar(Cliente cliente)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Clientes SET Cliente_Estado = @Estado WHERE Cliente_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", cliente.id);
            consulta.Parameters.AddWithValue("@Estado", cliente.estado);
            consultaEjecutar(consulta);
        }

        public static void clienteEliminar(Cliente cliente)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Clientes SET Cliente_Estado = 0 WHERE Cliente_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", cliente.id);
            consultaEjecutar(consulta);
        }

        public static string clienteObtenerID(Cliente cliente)
        {
            SqlCommand consulta = consultaCrear("SELECT Cliente_ID FROM RIP.Clientes WHERE Cliente_PersonaID = @PersonaID");
            consulta.Parameters.AddWithValue("@PersonaID", personaObtenerID(cliente.persona));
            return consultaObtenerValor(consulta);
        }

        public static bool clienteExiste(Cliente cliente)
        {
            SqlCommand consulta = consultaCrear("SELECT Cliente_ID FROM RIP.Clientes WHERE Cliente_PersonaID = @PersonaID");
            consulta.Parameters.AddWithValue("@PersonaID", personaObtenerID(cliente.persona));
            return consultaValorExiste(consultaObtenerValor(consulta));
        }

        public static DataTable clienteFiltrarParaModificar(Cliente cliente)
        {
            string filtroNombre = string.IsNullOrEmpty(cliente.persona.nombre)? "" : cliente.persona.nombre;
            string filtroApellido = string.IsNullOrEmpty(cliente.persona.apellido)? "" : cliente.persona.apellido;
            string filtroEmail = string.IsNullOrEmpty(cliente.persona.email)? "" : cliente.persona.email;
            string filtroTipoDocumento = string.IsNullOrEmpty(cliente.persona.tipoDocumento) || cliente.persona.tipoDocumento == "Todos"? "" : " AND Persona_TipoDocumentoID = " + tipoDocumentoObtenerID(cliente.persona.tipoDocumento);
            string filtroNumeroDocumento = string.IsNullOrEmpty(cliente.persona.numeroDocumento)? "" : " AND CONVERT(nvarchar(50), Persona_NumeroDocumento) LIKE '" + cliente.persona.numeroDocumento + "%'";
            string query = "SELECT TOP 50 Cliente_ID, Persona_ID, Persona_Nombre, Persona_Apellido, TipoDocumento_Descripcion, " + 
            "Persona_NumeroDocumento, Persona_Nacionalidad, Persona_FechaNacimiento, Persona_Telefono, Persona_Email, " + 
            "Domicilio_ID, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, Domicilio_NumeroCalle, " +
            "Domicilio_Piso, Domicilio_Departamento FROM RIP.Clientes " + 
            "JOIN RIP.Personas ON Cliente_PersonaID = Persona_ID " +
            "JOIN RIP.TiposDocumentos ON Persona_TipoDocumentoID = TipoDocumento_ID " + 
            "JOIN RIP.Domicilios ON Persona_DomicilioID = Domicilio_ID WHERE " +          
            "Persona_Nombre LIKE '" + cliente.persona.nombre + "%' AND " +
            "Persona_Apellido LIKE '" + cliente.persona.apellido + "%' AND " +
            "Persona_Email LIKE '" + cliente.persona.email + "%'" +
            filtroTipoDocumento + filtroNumeroDocumento;
            SqlCommand consulta = consultaCrear(query);
            return consultaObtenerTabla(consulta);
        }

        public static DataTable clienteFiltrarParaEliminar(Cliente cliente)
        {
            string filtroNombre = string.IsNullOrEmpty(cliente.persona.nombre) ? "" : cliente.persona.nombre;
            string filtroApellido = string.IsNullOrEmpty(cliente.persona.apellido) ? "" : cliente.persona.apellido;
            string filtroEmail = string.IsNullOrEmpty(cliente.persona.email) ? "" : cliente.persona.email;
            string filtroTipoDocumento = string.IsNullOrEmpty(cliente.persona.tipoDocumento) || cliente.persona.tipoDocumento == "Todos" ? "" : " AND Persona_TipoDocumentoID = " + tipoDocumentoObtenerID(cliente.persona.tipoDocumento);
            string filtroNumeroDocumento = string.IsNullOrEmpty(cliente.persona.numeroDocumento) ? "" : " AND CONVERT(nvarchar(50), Persona_NumeroDocumento) LIKE '" + cliente.persona.numeroDocumento + "%'";
            string query = "SELECT TOP 50 Cliente_ID, Persona_ID, Persona_Nombre, Persona_Apellido, TipoDocumento_Descripcion, " +
            "Persona_NumeroDocumento, Persona_Nacionalidad, Persona_FechaNacimiento, Persona_Telefono, Persona_Email, " +
            "Domicilio_ID, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, Domicilio_NumeroCalle, " +
            "Domicilio_Piso, Domicilio_Departamento FROM RIP.Clientes " +
            "JOIN RIP.Personas ON Cliente_PersonaID = Persona_ID " +
            "JOIN RIP.TiposDocumentos ON Persona_TipoDocumentoID = TipoDocumento_ID " +
            "JOIN RIP.Domicilios ON Persona_DomicilioID = Domicilio_ID WHERE Cliente_Estado = 1 AND " +
            "Persona_Nombre LIKE '" + cliente.persona.nombre + "%' AND " +
            "Persona_Apellido LIKE '" + cliente.persona.apellido + "%' AND " +
            "Persona_Email LIKE '" + cliente.persona.email + "%'" +
            filtroTipoDocumento + filtroNumeroDocumento;
            SqlCommand consulta = consultaCrear(query);
            return consultaObtenerTabla(consulta);
        }

        public static bool clienteDistinto(Cliente cliente)
        {
            return cliente.id != clienteObtenerID(cliente);
        }

        public static bool clienteHabilitado(Cliente cliente)
        {
            SqlCommand consulta = consultaCrear("SELECT Cliente_Estado FROM RIP.Clientes WHERE Cliente_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", cliente.id);
            return bool.Parse(consultaObtenerValor(consulta));
        }


        public static DataTable clienteObtenerTodosEnTabla()
        {
            SqlCommand consulta = consultaCrear("SELECT TOP 100 Cliente_ID, Persona_ID, Persona_Nombre, Persona_Apellido, TipoDocumento_Descripcion, Persona_NumeroDocumento, Persona_Nacionalidad, Persona_FechaNacimiento, Persona_Telefono, Persona_Email, Domicilio_ID, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, Domicilio_NumeroCalle, Domicilio_Piso, Domicilio_Departamento FROM RIP.Clientes JOIN RIP.Personas ON Cliente_PersonaID = Persona_ID JOIN RIP.TiposDocumentos ON Persona_TipoDocumentoID = TipoDocumento_ID JOIN RIP.Domicilios ON Persona_DomicilioID = Domicilio_ID");
            return consultaObtenerTabla(consulta);
        }

        public static DataTable clienteObtenerHabilitadosEnTabla()
        {
            SqlCommand consulta = consultaCrear("SELECT TOP 100 Cliente_ID, Persona_ID, Persona_Nombre, Persona_Apellido, TipoDocumento_Descripcion, Persona_NumeroDocumento, Persona_Nacionalidad, Persona_FechaNacimiento, Persona_Telefono, Persona_Email, Domicilio_ID, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, Domicilio_NumeroCalle, Domicilio_Piso, Domicilio_Departamento FROM RIP.Clientes JOIN RIP.Personas ON Cliente_PersonaID = Persona_ID JOIN RIP.TiposDocumentos ON Persona_TipoDocumentoID = TipoDocumento_ID JOIN RIP.Domicilios ON Persona_DomicilioID = Domicilio_ID WHERE Cliente_Estado = 1");
            return consultaObtenerTabla(consulta);
        }

        #endregion

        #region Persona

        public static void personaAgregar(Persona persona)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Personas (Persona_Nombre, Persona_Apellido, Persona_TipoDocumentoID, Persona_NumeroDocumento, Persona_FechaNacimiento, Persona_Nacionalidad, Persona_DomicilioID, Persona_Telefono, Persona_Email) VALUES (@Nombre, @Apellido, @TipoDocumentoID, @NumeroDocumento, @FechaNacimiento, @Nacionalidad, @DomicilioID, @Telefono, @Email)");
            consulta.Parameters.AddWithValue("@Nombre", persona.nombre);
            consulta.Parameters.AddWithValue("@Apellido", persona.apellido);
            consulta.Parameters.AddWithValue("@TipoDocumentoID", tipoDocumentoObtenerID(persona.tipoDocumento));
            consulta.Parameters.AddWithValue("@NumeroDocumento", persona.numeroDocumento);
            consulta.Parameters.AddWithValue("@FechaNacimiento", persona.fechaNacimiento);
            consulta.Parameters.AddWithValue("@Nacionalidad", persona.nacionalidad);
            consulta.Parameters.AddWithValue("@DomicilioID", domicilioPersonaObtenerID(persona.domicilio));
            consulta.Parameters.AddWithValue("@Telefono", persona.telefono);
            consulta.Parameters.AddWithValue("@Email", persona.email);
            consultaEjecutar(consulta);
        }

        public static void personaModificar(Persona persona)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Personas SET Persona_Nombre = @Nombre, Persona_Apellido = @Apellido, Persona_TipoDocumentoID = @TipoDocumentoID, Persona_NumeroDocumento = @NumeroDocumento, Persona_FechaNacimiento = @FechaNacimiento, Persona_Nacionalidad = @Nacionalidad, Persona_DomicilioID = @DomicilioID, Persona_Telefono = @Telefono, Persona_Email = @Email WHERE Persona_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", persona.id);
            consulta.Parameters.AddWithValue("@Nombre", persona.nombre);
            consulta.Parameters.AddWithValue("@Apellido", persona.apellido);
            consulta.Parameters.AddWithValue("@TipoDocumentoID", tipoDocumentoObtenerID(persona.tipoDocumento));
            consulta.Parameters.AddWithValue("@NumeroDocumento", persona.numeroDocumento);
            consulta.Parameters.AddWithValue("@FechaNacimiento", persona.fechaNacimiento);
            consulta.Parameters.AddWithValue("@Nacionalidad", persona.nacionalidad);
            consulta.Parameters.AddWithValue("@DomicilioID", domicilioPersonaObtenerID(persona.domicilio));
            consulta.Parameters.AddWithValue("@Telefono", persona.telefono);
            consulta.Parameters.AddWithValue("@Email", persona.email);
            consultaEjecutar(consulta);
        }

        public static string personaObtenerID(Persona persona)
        {
            SqlCommand consulta = consultaCrear("SELECT Persona_ID FROM RIP.Personas WHERE Persona_TipoDocumentoID = @TipoDocumentoID AND Persona_NumeroDocumento = @NumeroDocumento AND Persona_Email = @Email");
            consulta.Parameters.AddWithValue("@TipoDocumentoID", tipoDocumentoObtenerID(persona.tipoDocumento));
            consulta.Parameters.AddWithValue("@NumeroDocumento", persona.numeroDocumento);
            consulta.Parameters.AddWithValue("@Email", persona.email);
            return consultaObtenerValor(consulta);
        }

        public static bool personaDistinta(Persona persona)
        {
            return persona.id != personaObtenerID(persona);
        }

        public static bool personaEmailExiste(Persona persona)
        {
            SqlCommand consulta = consultaCrear("SELECT Persona_Email FROM RIP.Personas WHERE Persona_Email = @Email");
            consulta.Parameters.AddWithValue("@Email", persona.email);
            return consultaValorExiste(consultaObtenerValor(consulta));
        }

        public static bool personaDocumentoExiste(Persona persona)
        {
            SqlCommand consulta = consultaCrear("SELECT Persona_Email FROM RIP.Personas WHERE Persona_TipoDocumentoID = @TipoDocumentoID AND Persona_NumeroDocumento = @NumeroDocumento");
            consulta.Parameters.AddWithValue("@TipoDocumentoID", tipoDocumentoObtenerID(persona.tipoDocumento));
            consulta.Parameters.AddWithValue("@NumeroDocumento", persona.numeroDocumento);
            return consultaValorExiste(consultaObtenerValor(consulta));
        }

        #endregion

        #region Domicilio

        public static void domicilioPersonaAgregar(Domicilio domicilio)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Domicilios (Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, Domicilio_NumeroCalle, Domicilio_Piso, Domicilio_Departamento) VALUES (@Pais, @Ciudad, @Calle, @NumeroCalle, @Piso, @Departamento)");
            consulta.Parameters.AddWithValue("@Pais", domicilio.pais);
            consulta.Parameters.AddWithValue("@Ciudad", domicilio.ciudad);
            consulta.Parameters.AddWithValue("@Calle", domicilio.calle);
            consulta.Parameters.AddWithValue("@NumeroCalle", domicilio.numeroCalle);
            consulta.Parameters.AddWithValue("@Piso", domicilio.piso);
            consulta.Parameters.AddWithValue("@Departamento", domicilio.departamento);
            consultaEjecutar(consulta);
        }

        public static void domicilioPersonaModificar(Domicilio domicilio)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Domicilios SET Domicilio_Pais = @Pais, Domicilio_Ciudad = @Ciudad, Domicilio_Calle = @Calle, Domicilio_NumeroCalle = @NumeroCalle, Domicilio_Piso = @Piso, Domicilio_Departamento = @Departamento WHERE Domicilio_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", domicilio.id);
            consulta.Parameters.AddWithValue("@Pais", domicilio.pais);
            consulta.Parameters.AddWithValue("@Ciudad", domicilio.ciudad);
            consulta.Parameters.AddWithValue("@Calle", domicilio.calle);
            consulta.Parameters.AddWithValue("@NumeroCalle", domicilio.numeroCalle);
            consulta.Parameters.AddWithValue("@Piso", domicilio.piso);
            consulta.Parameters.AddWithValue("@Departamento", domicilio.departamento);
            consultaEjecutar(consulta);
        }

        public static string domicilioPersonaObtenerID(Domicilio domicilio)
        {
            SqlCommand consulta = consultaCrear("SELECT Domicilio_ID FROM RIP.Domicilios WHERE Domicilio_Pais = @Pais AND Domicilio_Ciudad = @Ciudad AND Domicilio_Calle = @Calle AND Domicilio_NumeroCalle = @NumeroCalle AND Domicilio_Piso = @Piso AND Domicilio_Departamento = @Departamento");
            consulta.Parameters.AddWithValue("@Pais", (domicilio.pais));
            consulta.Parameters.AddWithValue("@Ciudad", domicilio.ciudad);
            consulta.Parameters.AddWithValue("@Calle", domicilio.calle);
            consulta.Parameters.AddWithValue("@NumeroCalle", domicilio.numeroCalle);
            consulta.Parameters.AddWithValue("@Piso", domicilio.piso);
            consulta.Parameters.AddWithValue("@Departamento", domicilio.departamento);
            return consultaObtenerValor(consulta);
        }

        public static void domicilioHotelAgregar(Domicilio domicilio)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Domicilios (Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, Domicilio_NumeroCalle) VALUES (@Pais, @Ciudad, @Calle, @NumeroCalle)");
            consulta.Parameters.AddWithValue("@Pais", domicilio.pais);
            consulta.Parameters.AddWithValue("@Ciudad", domicilio.ciudad);
            consulta.Parameters.AddWithValue("@Calle", domicilio.calle);
            consulta.Parameters.AddWithValue("@NumeroCalle", domicilio.numeroCalle);
            consultaEjecutar(consulta);
        }

        public static void domicilioHotelModificar(Domicilio domicilio)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Domicilios SET Domicilio_Pais = @Pais, Domicilio_Ciudad = @Ciudad, Domicilio_Calle = @Calle, Domicilio_NumeroCalle = @NumeroCalle WHERE Domicilio_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", domicilio.id);
            consulta.Parameters.AddWithValue("@Pais", domicilio.pais);
            consulta.Parameters.AddWithValue("@Ciudad", domicilio.ciudad);
            consulta.Parameters.AddWithValue("@Calle", domicilio.calle);
            consulta.Parameters.AddWithValue("@NumeroCalle", domicilio.numeroCalle);
            consultaEjecutar(consulta);
        }

        public static string domicilioHotelObtenerID(Domicilio domicilio)
        {
            SqlCommand consulta = consultaCrear("SELECT Domicilio_ID FROM RIP.Domicilios WHERE Domicilio_Pais = @Pais AND Domicilio_Ciudad = @Ciudad AND Domicilio_Calle = @Calle AND Domicilio_NumeroCalle = @NumeroCalle");
            consulta.Parameters.AddWithValue("@Pais", (domicilio.pais));
            consulta.Parameters.AddWithValue("@Ciudad", domicilio.ciudad);
            consulta.Parameters.AddWithValue("@Calle", domicilio.calle);
            consulta.Parameters.AddWithValue("@NumeroCalle", domicilio.numeroCalle);
            return consultaObtenerValor(consulta);
        }

        #endregion

        #region Hotel

        public static bool hotelAgregadoConExito(Hotel hotel)
        {
            return true;
        }

        public static bool hotelModificadoConExito(Hotel hotel)
        {
            return true;
        }

        public static bool hotelEliminadoConExito(Hotel hotel)
        {
            return true;
        }

        public static List<string> hotelObtenerRegimenesEnLista(Hotel hotel)
        {
            return null;
        }

        public static List<string> hotelObtenerRegimenesFaltantesEnLista(Hotel hotel)
        {
            return null;
        }

        public static void hotelAgregar(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Hoteles (Hotel_Nombre, Hotel_CantidadEstrellas, Hotel_DomicilioID, Hotel_Telefono, Hotel_Email, Hotel_FechaCreacion) VALUES (@Nombre, @CantidadEstrellas, @DomicilioID, @Telefono, @Email, @FechaCreacion)");
            consulta.Parameters.AddWithValue("@Nombre", hotel.nombre);
            consulta.Parameters.AddWithValue("@CantidadEstrellas", hotel.cantidadEstrellas);
            consulta.Parameters.AddWithValue("@DomicilioID", domicilioHotelObtenerID(hotel.domicilio));
            consulta.Parameters.AddWithValue("@Telefono", hotel.telefono);
            consulta.Parameters.AddWithValue("@Hotel", hotel.email);
            consulta.Parameters.AddWithValue("@FechaCreacion", hotel.fechaCreacion);
            consultaEjecutar(consulta);
        }

        public static void hotelModificar(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Hoteles SET Hotel_Nombre = @Nombre, Hotel_CantidadEstrellas = @CantidadEstrellas, Hotel_DomicilioID = @DomicilioID, Hotel_Telefono = @Telefono, Hotel_Email = @Email, Hotel_FechaCreacion = @FechaCreacion, Hotel_Estado = @Estado WHERE Hotel_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", hotel.id);
            consulta.Parameters.AddWithValue("@Nombre", hotel.nombre);
            consulta.Parameters.AddWithValue("@CantidadEstrellas", hotel.cantidadEstrellas);
            consulta.Parameters.AddWithValue("@DomicilioID", domicilioHotelObtenerID(hotel.domicilio));
            consulta.Parameters.AddWithValue("@Telefono", hotel.telefono);
            consulta.Parameters.AddWithValue("@Hotel", hotel.email);
            consulta.Parameters.AddWithValue("@FechaCreacion", hotel.fechaCreacion);
            consultaEjecutar(consulta);
        }

        public static void hotelEliminar(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Hoteles SET Hotel_Estado = 0 WHERE Hotel_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", hotel.id);
            consultaEjecutar(consulta);
        }

        public static string hotelObtenerID(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("SELECT Hotel_ID FROM RIP.Hoteles WHERE Hotel_DomicilioID = @DomicilioID");
            consulta.Parameters.AddWithValue("@DomicilioID", domicilioHotelObtenerID(hotel.domicilio));
            return consultaObtenerValor(consulta);
        }

        public static bool hotelYaExiste(Hotel hotel)
        {
            return consultaValorExiste(hotelObtenerID(hotel));
        }

        public static bool hotelEsDistinto(Hotel hotel)
        {
            return hotel.id != hotelObtenerID(hotel);
        }

        public static void hotelAgregarRegimen(Hotel hotel, string regimen)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Hoteles_Regimenes (HotelRegimen_HotelID, HotelRegimen_RegimenID) VALUES (@HotelID, @RegimenID)");
            consulta.Parameters.AddWithValue("@HotelID", hotelObtenerID(hotel));
            consulta.Parameters.AddWithValue("@RegimenID", regimenObtenerID(regimen));
        }

        public static void hotelAgregarRegimenes(Hotel hotel, List<string> regimenes)
        {
            foreach (string regimen in regimenes)
                hotelAgregarRegimen(hotel, regimen);
        }

        public static void hotelEliminarRegimenes(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Hoteles_Regimenes WHERE HotelRegimen_HotelID = @HotelID");
            consulta.Parameters.AddWithValue("@HotelID", hotel.id);
            consultaEjecutar(consulta);
        }

        public static List<string> hotelObtenerListaHabitaciones(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("SELECT Habitacion_Numero FROM RIP.Habitaciones WHERE Habitacion_HotelID = @hotelID");
            consulta.Parameters.AddWithValue("@hotelID", hotelObtenerID(hotel));
            return consultaObtenerLista(consulta);
        }

        public static DataTable hotelObtenerTablaHabitaciones(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("SELECT Habitacion_Numero FROM RIP.Habitaciones WHERE Habitacion_HotelID = @hotelID");
            consulta.Parameters.AddWithValue("@hotelID", hotelObtenerID(hotel));
            return consultaObtenerTabla(consulta);
        }

        public static void hotelCerradoAgregar(HotelCerrado hotelCerrado)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.HotelesCerrados (HotelCerrado_HotelID, HotelCerrado_FechaInicio, HotelCerrado_FechaFin, HotelCerrado_Motivo) VALUES (@HotelID, @FechaInicio, @FechaFin, @Motivo)");
            consulta.Parameters.AddWithValue("@HotelID", hotelObtenerID(hotelCerrado.hotel));
            consulta.Parameters.AddWithValue("@FechaInicio", hotelCerrado.fechaInicio);
            consulta.Parameters.AddWithValue("@FechaFin", hotelCerrado.fechaFin);
            consulta.Parameters.AddWithValue("@Motivo", hotelCerrado.motivo);
        }

        public static List<string> hotelObtenerTodosLista()
        {
            SqlCommand consulta = consultaCrear("SELECT CONCAT(Domicilio_Pais, '-', Domicilio_Ciudad, '-', Domicilio_Calle, '-', Domicilio_NumeroCalle) FROM RIP.Domicilios JOIN RIP.Hoteles ON Domicilio_ID = Hotel_DomicilioID");
            return consultaObtenerLista(consulta);
        }

        public static DataTable hotelFiltrarParaModificar(Hotel hotel)
        {
            string filtroNombre = string.IsNullOrEmpty(hotel.nombre) ? "" : hotel.nombre;
            string filtroEstrellas = string.IsNullOrEmpty(hotel.cantidadEstrellas) ? "" : hotel.cantidadEstrellas;
            string filtroPais = string.IsNullOrEmpty(hotel.domicilio.pais) ? "" : hotel.domicilio.pais;
            string filtroCiudad = string.IsNullOrEmpty(hotel.domicilio.ciudad)? "" : hotel.domicilio.pais;
            string query = "SELECT TOP 50 Hotel_ID, Hotel_Nombre, Hotel_CantidadEstrellas, Hotel_FechaCreacion, " +
            "Hotel_Email, Hotel_Telefono, Domicilio_ID, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle" +
            "Domicilio_NumeroCalle FROM RIP.Hoteles JOIN RIP.Domicilios ON Hotel_DomicilioID = Domicilio_ID WHERE " +
            "Hotel_Nombre LIKE '" + hotel.nombre + "%' AND " +
            "Domicilio_Pais LIKE '" + hotel.domicilio.pais+ "%' AND " +
            "Persona_Ciudad LIKE '" + hotel.domicilio.ciudad + "%' AND " +
            "CONVERT(nvarchar(50), Hotel_CantidadEstrellas) LIKE '" + hotel.cantidadEstrellas + "%'";
            SqlCommand consulta = consultaCrear(query);
            return consultaObtenerTabla(consulta);
        }

        public static DataTable hotelFiltrarParaEliminar(Hotel hotel)
        {
            string filtroNombre = string.IsNullOrEmpty(hotel.nombre) ? "" : hotel.nombre;
            string filtroEstrellas = string.IsNullOrEmpty(hotel.cantidadEstrellas) ? "" : hotel.cantidadEstrellas;
            string filtroPais = string.IsNullOrEmpty(hotel.domicilio.pais) ? "" : hotel.domicilio.pais;
            string filtroCiudad = string.IsNullOrEmpty(hotel.domicilio.ciudad) ? "" : hotel.domicilio.pais;
            string query = "SELECT TOP 50 Hotel_ID, Hotel_Nombre, Hotel_CantidadEstrellas, Hotel_FechaCreacion, " +
            "Hotel_Email, Hotel_Telefono, Domicilio_ID, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle" +
            "Domicilio_NumeroCalle FROM RIP.Hoteles JOIN RIP.Domicilios ON Hotel_DomicilioID = Domicilio_ID WHERE Hotel_Estado = 1 AND " +
            "Hotel_Nombre LIKE '" + hotel.nombre + "%' AND " +
            "Domicilio_Pais LIKE '" + hotel.domicilio.pais + "%' AND " +
            "Persona_Ciudad LIKE '" + hotel.domicilio.ciudad + "%' AND " +
            "CONVERT(nvarchar(50), Hotel_CantidadEstrellas) LIKE '" + hotel.cantidadEstrellas + "%'";
            SqlCommand consulta = consultaCrear(query);
            return consultaObtenerTabla(consulta);
        }

        #endregion

        #region Habitacion

        public static string habitacionObtenerID(Habitacion habitacion)
        {
            SqlCommand consulta = consultaCrear("SELECT Habitacion_ID FROM RIP.Habitaciones WHERE Habitacion_HotelID = @hotelID AND Habitacion_Numero = @numero");
            consulta.Parameters.AddWithValue("@hotelID", hotelObtenerID(habitacion.hotel));
            consulta.Parameters.AddWithValue("@numero", habitacion.numero);
            return consultaObtenerValor(consulta);        
        }

        public static bool habitacionYaExiste(Habitacion habitacion)
        {
            return consultaValorExiste(habitacionObtenerID(habitacion));
        }

        public static void habitacionAgregar(Habitacion habitacion)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Habitaciones (Habitacion_HotelID, Habitacion_Numero, Habitacion_Piso, Habitacion_Frente, Habitacion_TipoHabitacionID, Habitacion_Descripcion) VALUES (@HotelID, @Numero, @Piso, @Frente, @TipoHabitacionID, @Descripcion)");
            consulta.Parameters.AddWithValue("@HotelID", hotelObtenerID(habitacion.hotel));
            consulta.Parameters.AddWithValue("@Numero", habitacion.numero);
            consulta.Parameters.AddWithValue("@Piso", habitacion.piso);
            consulta.Parameters.AddWithValue("@Frente", habitacion.frente);
            consulta.Parameters.AddWithValue("@TipoHabitacionID", tipoHabitacionObtenerID(habitacion.tipoHabitacion));
            consulta.Parameters.AddWithValue("@Descripcion", habitacion.descripcion);
            consultaEjecutar(consulta);
        }

        public static void habitacionModificar(Habitacion habitacion, Habitacion nuevaHabitacion)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Habitaciones SET Habitacion_HotelID = @NuevoHotelID, Habitacion_Numero = @NuevoNumero, Habitacion_Piso = @NuevoPiso, Habitacion_Frente = @NuevoFrente, Habitacion_TipoHabitacionID = @NuevoTipoHabitacionID, Habitacion_Descripcion = @NuevaDescripcion WHERE Habitacion_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", habitacionObtenerID(habitacion));
            consulta.Parameters.AddWithValue("@NuevoHotelID", hotelObtenerID(nuevaHabitacion.hotel));
            consulta.Parameters.AddWithValue("@NuevoNumero", nuevaHabitacion.numero);
            consulta.Parameters.AddWithValue("@NuevoPiso", nuevaHabitacion.piso);
            consulta.Parameters.AddWithValue("@NuevoFrente", nuevaHabitacion.frente);
            consulta.Parameters.AddWithValue("@NuevoTipoHabitacionID", tipoHabitacionObtenerID(nuevaHabitacion.tipoHabitacion));
            consulta.Parameters.AddWithValue("@NuevaDescripcion", nuevaHabitacion.descripcion);
            consultaEjecutar(consulta);
        }

        public static void habitacionEliminar(Habitacion habitacion)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Habitaciones SET Habitacion_Estado = 0 WHERE Habitacion_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", habitacionObtenerID(habitacion));
            consultaEjecutar(consulta);
        }

        #endregion

        #region TipoDocumento

        public static string tipoDocumentoObtenerID(string tipoDocumento)
        {
            SqlCommand consulta = consultaCrear("SELECT TipoDocumento_ID FROM RIP.TiposDocumentos WHERE TipoDocumento_Descripcion = @TipoDocumento");
            consulta.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);
            return consultaObtenerValor(consulta);            
        }

        public static List<string> tipoDocumentoObtenerTodosEnLista()
        {
            SqlCommand consulta = consultaCrear("SELECT TipoDocumento_Descripcion FROM RIP.TiposDocumentos");
            return consultaObtenerLista(consulta);
        }

        public static List<string> tipoDocumentoFiltroObtenerTodosEnLista()
        {
            SqlCommand consulta = consultaCrear("SELECT TipoDocumento_Descripcion FROM RIP.TiposDocumentos");
            List<string> tiposDocumentos = consultaObtenerLista(consulta);
            tiposDocumentos.Insert(0, "Todos");
            return tiposDocumentos;
        }

        #endregion

        #region TipoHabitacion

        public static string tipoHabitacionObtenerID(string tipoHabitacion)
        {
            SqlCommand consulta = consultaCrear("SELECT TipoHabitacion_ID FROM RIP.TiposHabitaciones WHERE TipoHabitacion_Descripcion = @Descripcion");
            consulta.Parameters.AddWithValue("@Descripcion", tipoHabitacion);
            return consultaObtenerValor(consulta);
        }

        #endregion

        #region TipoRegimen

        public static string regimenObtenerID(string regimen)
        {
            SqlCommand consulta = consultaCrear("SELECT Regimen_Descripcion FROM RIP.Regimenes WHERE Regimen_Descripcion = @Descripcion");
            consulta.Parameters.AddWithValue("@Descripcion", regimen);
            return consultaObtenerValor(consulta);
        }

        #endregion

        #region Reserva

        public static List<string> tipoHabitacionObtenerTodas()
        {
            SqlCommand consulta = consultaCrear("SELECT TipoHabitacion_Descripcion FROM RIP.TiposHabitaciones");
            return consultaObtenerLista(consulta);
        }

        public static List<string> DescripcionRegimenObtenerTodos()
        {
            SqlCommand consulta = consultaCrear("SELECT Regimen_Descripcion FROM RIP.Regimenes");
            return consultaObtenerLista(consulta);
        }

        internal static bool HayReservasEntreFechas(DateTime dateTime1, DateTime dateTime2)
        {
            return true;
        }

        #endregion
    }
}