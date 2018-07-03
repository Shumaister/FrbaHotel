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
            {
                usuarioBloquear(new Usuario(usuario));
                return logueo.informarBloqueo();
            }
                
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

        public static LogueoDTO loginCuentaBloqueada(Usuario usuario, int intentosFallidos)
        {
            return new LogueoDTO().informarBloqueo();
        }

        public static LogueoDTO loginVerificarCuenta(DataRow fila, string contrasenia)
        {
            string nombreUsuario = (string)fila["Usuario_Nombre"];
            byte[] contraseniaReal = (byte[])fila["Usuario_Contrasenia"];
            int intentosFallidos = (int)fila["Usuario_IntentosFallidos"];
            Usuario usuario = new Usuario(nombreUsuario);
            if (intentosFallidos >= 3 || usuarioBloqueado(usuario))
                return loginCuentaBloqueada(usuario, intentosFallidos);
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
                rol.id = rolObtenerID(rol);
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
            SqlCommand consulta = consultaCrear("UPDATE RIP.Roles SET Rol_Nombre = @Nombre, Rol_Estado = @Estado WHERE Rol_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", rol.id);
            consulta.Parameters.AddWithValue("@Nombre", rol.nombre);
            consulta.Parameters.AddWithValue("@Estado", rol.estado);
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
            consulta.Parameters.AddWithValue("@RolID", rol.id);
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
            consulta.Parameters.AddWithValue("@RolID", rol.id);
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
            SqlCommand consulta = consultaCrear("SELECT Rol_ID, Rol_Nombre, Rol_Estado FROM RIP.Roles ORDER BY Rol_ID");
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

            if (personaEmailExiste(usuario.persona) && personaDistintaEmail(usuario.persona))
            {
                ventanaInformarError("Ya existe un usuario registrado con ese email");
                return false;
            }
            if (personaDocumentoExiste(usuario.persona) && personaDistintaDocumento(usuario.persona))
            {
                ventanaInformarError("Ya existe un usuario registrado con ese documento");
                return false;
            }
            usuarioEliminarHoteles(usuario);
            usuarioEliminarRoles(usuario);
            domicilioPersonaModificar(usuario.persona.domicilio);
            personaModificar(usuario.persona);
            if (usuarioContraseniaIguales(usuario))
                usuarioModificarSinContrasenia(usuario);
            else
                usuarioModificar(usuario);
            usuarioAgregarHoteles(usuario);
            usuarioAgregarRoles(usuario);
            usuarioVerificarIntentosFallidos(usuario);
            ventanaInformarExito("El usuario fue modificado con exito");
            return true;
        }

        public static void usuarioEliminadoConExito(Usuario usuario)
        {
            usuarioEliminar(usuario);
            ventanaInformarExito("El usuario fue eliminado con exito");
        }

        public static void usuarioAgregar(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Usuarios (Usuario_Nombre, Usuario_Contrasenia, Usuario_PersonaID) VALUES (@Nombre, @Contrasenia, @PersonaID)");
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            consulta.Parameters.AddWithValue("@Contrasenia", loginEncriptarContraseña(usuario.contrasenia));
            consulta.Parameters.AddWithValue("@PersonaID", personaObtenerIDPorEmail(usuario.persona));
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

        public static string usuarioObtenerNombreByID(string id)
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_Nombre FROM RIP.Usuarios WHERE Usuario_ID = @id");
            consulta.Parameters.AddWithValue("@id", id);
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

        public static bool usuarioContraseniaIguales(Usuario usuario)
        {
            return usuario.contrasenia == usuarioObtenerContrasenia(usuario);
        }

        public static void usuarioModificarSinContrasenia(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Usuarios SET Usuario_Nombre = @Nombre, Usuario_Estado = @Estado WHERE Usuario_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", usuario.id);
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            consulta.Parameters.AddWithValue("@Estado", usuario.estado);
            consultaEjecutar(consulta);
        }

        public static void usuarioAgregarHotel(Usuario usuario, Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Usuarios_Hoteles (UsuarioHotel_UsuarioID, UsuarioHotel_HotelID) VALUES (@UsuarioID, @HotelID)");
            consulta.Parameters.AddWithValue("@UsuarioID", usuarioObtenerID(usuario));
            consulta.Parameters.AddWithValue("@HotelID", hotelObtenerIDPorDomicilio(hotel));
            consultaEjecutar(consulta);
        }

        public static void usuarioAgregarHoteles(Usuario usuario)
        {
            foreach (Hotel hotel in usuario.hoteles)
                usuarioAgregarHotel(usuario, hotel);
        }

        public static void usuarioEliminarHoteles(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Usuarios_Hoteles WHERE UsuarioHotel_UsuarioID = @UsuarioID");
            consulta.Parameters.AddWithValue("@UsuarioID", usuarioObtenerID(usuario));
            consultaEjecutar(consulta);
        }

        public static void usuarioAgregarRol(Usuario usuario, Rol rol)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Usuarios_Roles (UsuarioRol_UsuarioID, UsuarioRol_RolID) VALUES (@UsuarioID, @RolID)");
            consulta.Parameters.AddWithValue("@UsuarioID", usuarioObtenerID(usuario));
            consulta.Parameters.AddWithValue("@RolID", rolObtenerID(rol));
            consultaEjecutar(consulta);
        }

        public static void usuarioAgregarRoles(Usuario usuario)
        {
            foreach (Rol rol in usuario.roles)
                usuarioAgregarRol(usuario, rol);
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

        public static List<string> usuarioObtenerHotelesFaltantesEnLista(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT CONCAT(Domicilio_Pais, '-', Domicilio_Ciudad, '-', Domicilio_Calle, '-', Domicilio_NumeroCalle) FROM RIP.Domicilios JOIN RIP.Hoteles ON Domicilio_ID = Hotel_DomicilioID WHERE Hotel_ID NOT IN (SELECT UsuarioHotel_HotelID FROM RIP.Usuarios_Hoteles WHERE UsuarioHotel_UsuarioID = @ID)");
            consulta.Parameters.AddWithValue("@ID", usuario.id);
            return consultaObtenerLista(consulta);
        }

        public static List<string> usuarioObtenerRolesEnLista(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_Nombre FROM RIP.Roles JOIN RIP.Usuarios_Roles ON Rol_ID = UsuarioRol_RolID JOIN RIP.Usuarios ON UsuarioRol_UsuarioID = Usuario_ID WHERE Usuario_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            return consultaObtenerLista(consulta);
        }

        public static List<string> usuarioObtenerRolesFaltantesEnLista(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_Nombre FROM RIP.Roles WHERE Rol_ID NOT IN (SELECT UsuarioRol_RolID FROM RIP.Usuarios_Roles WHERE UsuarioRol_UsuarioID = @ID)");
            consulta.Parameters.AddWithValue("@ID", usuario.id);
            return consultaObtenerLista(consulta);
        }

        public static List<string> usuarioObtenerRolesHabilitadosLista(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_Nombre FROM RIP.Roles JOIN RIP.Usuarios_Roles ON Rol_ID = UsuarioRol_RolID JOIN RIP.Usuarios ON UsuarioRol_UsuarioID = Usuario_ID WHERE Usuario_Nombre = @Nombre AND Rol_Estado = 1");
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            return consultaObtenerLista(consulta);
        }

        public static DataTable usuarioObtenerTodosEnTabla()
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_ID, Usuario_Nombre, Usuario_Estado, Persona_ID, Persona_Nombre, Persona_Apellido, TipoDocumento_Descripcion, Persona_NumeroDocumento, Persona_Nacionalidad, Persona_FechaNacimiento, Persona_Telefono, Persona_Email, Domicilio_ID, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, Domicilio_NumeroCalle, Domicilio_Piso, Domicilio_Departamento FROM RIP.Usuarios JOIN RIP.Personas ON Usuario_PersonaID = Persona_ID JOIN RIP.TiposDocumentos ON Persona_TipoDocumentoID = TipoDocumento_ID JOIN RIP.Domicilios ON Persona_DomicilioID = Domicilio_ID");
            return consultaObtenerTabla(consulta);
        }

        public static DataTable usuarioObtenerHabilitadosEnTabla()
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_ID, Usuario_Nombre, Persona_ID, Persona_Nombre, Persona_Apellido, TipoDocumento_Descripcion, Persona_NumeroDocumento, Persona_Nacionalidad, Persona_FechaNacimiento, Persona_Telefono, Persona_Email, Domicilio_ID, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, Domicilio_NumeroCalle, Domicilio_Piso, Domicilio_Departamento FROM RIP.Usuarios JOIN RIP.Personas ON Usuario_PersonaID = Persona_ID JOIN RIP.TiposDocumentos ON Persona_TipoDocumentoID = TipoDocumento_ID JOIN RIP.Domicilios ON Persona_DomicilioID = Domicilio_ID WHERE Usuario_Estado = 1");
            return consultaObtenerTabla(consulta);
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

        public static void usuarioVerificarIntentosFallidos(Usuario usuario)
        {
            if (usuario.estado == "1")
            {
                SqlCommand consulta = consultaCrear("UPDATE RIP.Usuarios SET Usuario_IntentosFallidos = 0 WHERE Usuario_ID = @ID");
                consulta.Parameters.AddWithValue("@ID", usuario.id);
                consultaEjecutar(consulta);
            }
        }

        public static void usuarioBloquear(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Usuarios SET Usuario_Estado = 0 WHERE Usuario_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", usuarioObtenerID(usuario));
            consultaEjecutar(consulta);
        }

        public static string usuarioObtenerContrasenia(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_Contrasenia FROM RIP.Usuarios WHERE Usuario_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", usuario.id);
            return consultaObtenerValor(consulta);
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
            if (personaEmailExiste(cliente.persona) && personaDistintaEmail(cliente.persona))
            {
                ventanaInformarError("Ya existe un cliente registrado con ese email");
                return false;
            }
            if (personaDocumentoExiste(cliente.persona) && personaDistintaDocumento(cliente.persona))
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
            consulta.Parameters.AddWithValue("@PersonaID", personaObtenerIDPorEmail(cliente.persona));
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
        
        public static string clienteObtenerIDPersona(string p)
        {
            SqlCommand consulta = consultaCrear("SELECT Cliente_ID FROM RIP.Clientes WHERE Cliente_PersonaID = @PersonaID");
            consulta.Parameters.AddWithValue("@PersonaID", p);
            return consultaObtenerValor(consulta);
        }

        public static string clienteObtenerID(Cliente cliente)
        {
            SqlCommand consulta = consultaCrear("SELECT Cliente_ID FROM RIP.Clientes WHERE Cliente_PersonaID = @PersonaID");
            consulta.Parameters.AddWithValue("@PersonaID", personaObtenerIDPorEmail(cliente.persona));
            return consultaObtenerValor(consulta);
        }

        public static bool clienteExiste(Cliente cliente)
        {
            SqlCommand consulta = consultaCrear("SELECT Cliente_ID FROM RIP.Clientes WHERE Cliente_PersonaID = @PersonaID");
            consulta.Parameters.AddWithValue("@PersonaID", personaObtenerIDPorEmail(cliente.persona));
            return consultaValorExiste(consultaObtenerValor(consulta));
        }

        public static DataTable clienteFiltrarParaModificar(Cliente cliente)
        {
            string filtroNombre = string.IsNullOrEmpty(cliente.persona.nombre)? "" : cliente.persona.nombre;
            string filtroApellido = string.IsNullOrEmpty(cliente.persona.apellido)? "" : cliente.persona.apellido;
            string filtroEmail = string.IsNullOrEmpty(cliente.persona.email)? "" : cliente.persona.email;
            string filtroTipoDocumento = string.IsNullOrEmpty(cliente.persona.tipoDocumento) || cliente.persona.tipoDocumento == "Todos"? "" : " AND Persona_TipoDocumentoID = " + tipoDocumentoObtenerID(cliente.persona.tipoDocumento);
            string filtroNumeroDocumento = string.IsNullOrEmpty(cliente.persona.numeroDocumento)? "" : " AND CONVERT(nvarchar(50), Persona_NumeroDocumento) LIKE '" + cliente.persona.numeroDocumento + "%'";
            string query = "SELECT TOP 50 Cliente_ID, Cliente_Estado, Persona_ID, Persona_Nombre, Persona_Apellido, TipoDocumento_Descripcion, " + 
            "Persona_NumeroDocumento, Persona_Nacionalidad, Persona_FechaNacimiento, Persona_Telefono, Persona_Email, " + 
            "Domicilio_ID, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, Domicilio_NumeroCalle, " +
            "Domicilio_Piso, Domicilio_Departamento FROM RIP.Clientes " + 
            "JOIN RIP.Personas ON Cliente_PersonaID = Persona_ID " +
            "JOIN RIP.TiposDocumentos ON Persona_TipoDocumentoID = TipoDocumento_ID " + 
            "JOIN RIP.Domicilios ON Persona_DomicilioID = Domicilio_ID WHERE " +  
            "Cliente_Estado = 1 AND "+
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
            SqlCommand consulta = consultaCrear("SELECT TOP 100 Cliente_ID, Cliente_Estado, Persona_ID, Persona_Nombre, Persona_Apellido, TipoDocumento_Descripcion, Persona_NumeroDocumento, Persona_Nacionalidad, Persona_FechaNacimiento, Persona_Telefono, Persona_Email, Domicilio_ID, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, Domicilio_NumeroCalle, Domicilio_Piso, Domicilio_Departamento FROM RIP.Clientes JOIN RIP.Personas ON Cliente_PersonaID = Persona_ID JOIN RIP.TiposDocumentos ON Persona_TipoDocumentoID = TipoDocumento_ID JOIN RIP.Domicilios ON Persona_DomicilioID = Domicilio_ID");
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
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Personas (Persona_Nombre, Persona_Apellido, Persona_TipoDocumentoID, Persona_NumeroDocumento, Persona_FechaNacimiento, Persona_Nacionalidad, Persona_DomicilioID, Persona_Telefono, Persona_Email) VALUES (@Nombre, @Apellido, @TipoDocumentoID, @NumeroDocumento, CONVERT(datetime,@FechaNacimiento,121), @Nacionalidad, @DomicilioID, @Telefono, @Email)");
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
            SqlCommand consulta = consultaCrear("UPDATE RIP.Personas SET Persona_Nombre = @Nombre, Persona_Apellido = @Apellido, Persona_TipoDocumentoID = @TipoDocumentoID, Persona_NumeroDocumento = @NumeroDocumento, Persona_FechaNacimiento = CONVERT(datetime,@FechaNacimiento,121), Persona_Nacionalidad = @Nacionalidad, Persona_DomicilioID = @DomicilioID, Persona_Telefono = @Telefono, Persona_Email = @Email WHERE Persona_ID = @ID");
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

        public static string personaObtenerIDPorEmail(Persona persona)
        {
            SqlCommand consulta = consultaCrear("SELECT Persona_ID FROM RIP.Personas WHERE Persona_Email = @Email");
            consulta.Parameters.AddWithValue("@Email", persona.email);
            return consultaObtenerValor(consulta);
        }

        public static string personaObtenerIDPorDocumento(Persona persona)
        {
            SqlCommand consulta = consultaCrear("SELECT Persona_ID FROM RIP.Personas WHERE Persona_NumeroDocumento = @NumeroDocumento AND Persona_TipoDocumentoID = @TipoDocumentoID");
            consulta.Parameters.AddWithValue("@NumeroDocumento", persona.numeroDocumento);
            consulta.Parameters.AddWithValue("@TipoDocumentoID", tipoDocumentoObtenerID(persona.tipoDocumento));
            return consultaObtenerValor(consulta);
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

        public static bool personaDistintaEmail(Persona persona)
        {
            return persona.id != personaObtenerIDPorEmail(persona);
        }

        public static bool personaDistintaDocumento(Persona persona)
        {
            return persona.id != personaObtenerIDPorDocumento(persona);
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
            if (hotelNombreExiste(hotel))
            {
                ventanaInformarError("Ya existe un hotel registrado con ese nombre");
                return false;
            }
            if (hotelDomicilioExiste(hotel))
            {
                ventanaInformarError("Ya existe un hotel registrado con esa direccion");
                return false;
            }
            if (hotelEmailExiste(hotel))
            {
                ventanaInformarError("Ya existe un hotel registrado con ese E-mail");
                return false;
            }
            domicilioHotelAgregar(hotel.domicilio);
            hotelAgregar(hotel);
            hotelAgregarRegimenes(hotel);
            ventanaInformarExito("El hotel fue creado con exito");
            return true;
        }

        public static bool hotelModificadoConExito(Hotel hotel)
        {
            if (hotelNombreExiste(hotel) && hotelDistintoPorNombre(hotel))
            {
                ventanaInformarError("Ya existe un hotel registrado con ese nombre");
                return false;
            }
            if (hotelDomicilioExiste(hotel) && hotelDistintoPorDomicilio(hotel))
            {
                ventanaInformarError("Ya existe un hotel registrado con esa direccion");
                return false;
            }
            if (hotelEmailExiste(hotel) && hotelDistintoPorEmail(hotel))
            {
                ventanaInformarError("Ya existe un hotel registrado con ese E-mail");
                return false;
            }
            domicilioHotelModificar(hotel.domicilio);
            hotelEliminarRegimenes(hotel);
            hotelModificar(hotel);
            hotelAgregarRegimenes(hotel);
            ventanaInformarExito("El Hotel fue modificado con exito");
            return true;
        }

        public static void hotelEliminadoConExito(Hotel hotel)
        {
            hotelEliminar(hotel);
            ventanaInformarExito("El Hotel fue eliminado con exito");
        }

        public static void hotelAgregar(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Hoteles (Hotel_Nombre, Hotel_CantidadEstrellas, Hotel_DomicilioID, Hotel_Telefono, Hotel_Email, Hotel_FechaCreacion) VALUES (@Nombre, @CantidadEstrellas, @DomicilioID, @Telefono, @Email, CONVERT(datetime,@FechaCreacion,121))");
            consulta.Parameters.AddWithValue("@Nombre", hotel.nombre);
            consulta.Parameters.AddWithValue("@CantidadEstrellas", hotel.cantidadEstrellas);
            consulta.Parameters.AddWithValue("@DomicilioID", domicilioHotelObtenerID(hotel.domicilio));
            consulta.Parameters.AddWithValue("@Telefono", hotel.telefono);
            consulta.Parameters.AddWithValue("@Email", hotel.email);
            consulta.Parameters.AddWithValue("@FechaCreacion", hotel.fechaCreacion);
            consultaEjecutar(consulta);
        }

        public static void hotelModificar(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Hoteles SET Hotel_Nombre = @Nombre, Hotel_CantidadEstrellas = @CantidadEstrellas, Hotel_DomicilioID = @DomicilioID, Hotel_Telefono = @Telefono, Hotel_Email = @Email, Hotel_FechaCreacion = CONVERT(datetime,@FechaCreacion,121), Hotel_Estado = @Estado WHERE Hotel_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", hotel.id);
            consulta.Parameters.AddWithValue("@Nombre", hotel.nombre);
            consulta.Parameters.AddWithValue("@CantidadEstrellas", hotel.cantidadEstrellas);
            consulta.Parameters.AddWithValue("@DomicilioID", domicilioHotelObtenerID(hotel.domicilio));
            consulta.Parameters.AddWithValue("@Telefono", hotel.telefono);
            consulta.Parameters.AddWithValue("@Email", hotel.email);
            consulta.Parameters.AddWithValue("@FechaCreacion", hotel.fechaCreacion);
            consulta.Parameters.AddWithValue("@Estado", hotel.estado);
            consultaEjecutar(consulta);
        }

        public static void hotelEliminar(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Hoteles SET Hotel_Estado = 0 WHERE Hotel_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", hotel.id);
            consultaEjecutar(consulta);
        }

        public static string hotelObtenerIDPorNombre(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("SELECT Hotel_ID FROM RIP.Hoteles WHERE Hotel_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", hotel.nombre);
            return consultaObtenerValor(consulta);
        }

        public static string hotelObtenerIDPorDomicilio(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("SELECT Hotel_ID FROM RIP.Hoteles WHERE Hotel_DomicilioID = @DomicilioID");
            consulta.Parameters.AddWithValue("@DomicilioID", domicilioHotelObtenerID(hotel.domicilio));
            return consultaObtenerValor(consulta);
        }

        public static double HotelObtenerCantidadEstrellasHotelPorID(string p)
        {
            SqlCommand consulta = consultaCrear("SELECT Hotel_CantidadEstrellas FROM RIP.Hoteles WHERE Hotel_DomicilioID = @id");
            consulta.Parameters.AddWithValue("@id", p);
            return double.Parse(consultaObtenerValor(consulta));
        }

        public static string hotelObtenerIDPorEmail(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("SELECT Hotel_ID FROM RIP.Hoteles WHERE Hotel_Email = @Email");
            consulta.Parameters.AddWithValue("@Email", hotel.email);
            return consultaObtenerValor(consulta);
        }

        public static bool hotelNombreExiste(Hotel hotel)
        {
            string id = hotelObtenerIDPorNombre(hotel);
            return consultaValorExiste(hotelObtenerIDPorNombre(hotel));
        }

        public static bool hotelDomicilioExiste(Hotel hotel)
        {
            return consultaValorExiste(domicilioHotelObtenerID(hotel.domicilio));
        }

        public static bool hotelEmailExiste(Hotel hotel)
        {
            return consultaValorExiste(hotelObtenerIDPorEmail(hotel));
        }

        public static bool hotelDistintoPorNombre(Hotel hotel)
        {
            return hotel.id != hotelObtenerIDPorNombre(hotel);
        }

        public static bool hotelDistintoPorDomicilio(Hotel hotel)
        {
            return hotel.id != hotelObtenerIDPorDomicilio(hotel);
        }

        public static bool hotelDistintoPorEmail(Hotel hotel)
        {
            return hotel.id != hotelObtenerIDPorEmail(hotel);
        }

        public static void hotelAgregarRegimen(Hotel hotel, string regimen)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Hoteles_Regimenes (HotelRegimen_HotelID, HotelRegimen_RegimenID) VALUES (@HotelID, @RegimenID)");
            string idh = hotelObtenerIDPorDomicilio(hotel);
            string idreg = regimenObtenerID(regimen);
            consulta.Parameters.AddWithValue("@HotelID", idh);
            consulta.Parameters.AddWithValue("@RegimenID", idreg);
            consultaEjecutar(consulta);
        }

        public static void hotelAgregarRegimenes(Hotel hotel)
        {
            foreach (string regimen in hotel.regimenes)
                hotelAgregarRegimen(hotel, regimen);
        }

        public static void hotelEliminarRegimenes(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Hoteles_Regimenes WHERE HotelRegimen_HotelID = @HotelID");
            consulta.Parameters.AddWithValue("@HotelID", hotel.id);
            consultaEjecutar(consulta);
        }

        public static List<string> hotelObtenerRegimenesEnLista(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("SELECT Regimen_Descripcion FROM RIP.Regimenes JOIN RIP.Hoteles_Regimenes ON Regimen_ID = HotelRegimen_RegimenID WHERE HotelRegimen_HotelID = @ID");
            consulta.Parameters.AddWithValue("@ID", hotel.id);
            return consultaObtenerLista(consulta);
        }

        public static List<string> hotelObtenerRegimenesFaltantesEnLista(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("SELECT Regimen_Descripcion FROM RIP.Regimenes WHERE Regimen_ID NOT IN (SELECT HotelRegimen_RegimenID FROM RIP.Hoteles_Regimenes WHERE HotelRegimen_HotelID = @ID)");
            consulta.Parameters.AddWithValue("@ID", hotel.id);
            return consultaObtenerLista(consulta);
        }

        public static DataTable hotelObtenerUsuariosEnTabla(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_ID, Usuario_Nombre, Usuario_Estado, Persona_ID, Persona_Nombre, Persona_Apellido, TipoDocumento_Descripcion, Persona_NumeroDocumento, Persona_Nacionalidad, Persona_FechaNacimiento, Persona_Telefono, Persona_Email, Domicilio_ID, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, Domicilio_NumeroCalle, Domicilio_Piso, Domicilio_Departamento FROM RIP.Usuarios JOIN RIP.Personas ON Usuario_PersonaID = Persona_ID JOIN RIP.TiposDocumentos ON Persona_TipoDocumentoID = TipoDocumento_ID JOIN RIP.Domicilios ON Persona_DomicilioID = Domicilio_ID JOIN RIP.Usuarios_Hoteles ON Usuario_ID = UsuarioHotel_UsuarioID WHERE UsuarioHotel_HotelID = @HotelID");
            consulta.Parameters.AddWithValue("@HotelID", hotel.id);
            return consultaObtenerTabla(consulta);
        }

        public static DataTable hotelObtenerUsuariosHabilitadosEnTabla(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_ID, Usuario_Nombre, Persona_ID, Persona_Nombre, Persona_Apellido, TipoDocumento_Descripcion, Persona_NumeroDocumento, Persona_Nacionalidad, Persona_FechaNacimiento, Persona_Telefono, Persona_Email, Domicilio_ID, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, Domicilio_NumeroCalle, Domicilio_Piso, Domicilio_Departamento FROM RIP.Usuarios JOIN RIP.Personas ON Usuario_PersonaID = Persona_ID JOIN RIP.TiposDocumentos ON Persona_TipoDocumentoID = TipoDocumento_ID JOIN RIP.Domicilios ON Persona_DomicilioID = Domicilio_ID JOIN RIP.Usuarios_Hoteles ON Usuario_ID = UsuarioHotel_UsuarioID WHERE UsuarioHotel_HotelID = @HotelID AND Usuario_Estado = 1");
            consulta.Parameters.AddWithValue("@HotelID", hotel.id);
            return consultaObtenerTabla(consulta);
        }

        public static DataTable hotelObtenerHabitacionesEnTabla(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("SELECT Habitacion_ID, Habitacion_Numero, Habitacion_Piso, Habitacion_Frente, Habitacion_Estado, TipoHabitacion_Descripcion, Habitacion_Descripcion,  Habitacion_HotelID FROM RIP.Habitaciones JOIN RIP.TiposHabitaciones ON Habitacion_TipoHabitacionID = TipoHabitacion_ID WHERE Habitacion_HotelID = @HotelID ORDER BY 2");
            consulta.Parameters.AddWithValue("@HotelID", hotel.id);
            return consultaObtenerTabla(consulta);
        }

        public static DataTable hotelObtenerHabitacionesHabilitadasEnTabla(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("SELECT Habitacion_ID, Habitacion_Numero, Habitacion_Piso, Habitacion_Frente, TipoHabitacion_Descripcion, Habitacion_Descripcion,  Habitacion_HotelID FROM RIP.Habitaciones JOIN RIP.TiposHabitaciones ON Habitacion_TipoHabitacionID = TipoHabitacion_ID WHERE Habitacion_HotelID = @HotelID AND Habitacion_Estado = 1 ORDER BY 2");
            consulta.Parameters.AddWithValue("@HotelID", hotel.id);
            return consultaObtenerTabla(consulta);
        }

        public static List<string> hotelObtenerTodosEnLista()
        {
            SqlCommand consulta = consultaCrear("SELECT CONCAT(Domicilio_Pais, '-', Domicilio_Ciudad, '-', Domicilio_Calle, '-', Domicilio_NumeroCalle) FROM RIP.Domicilios JOIN RIP.Hoteles ON Domicilio_ID = Hotel_DomicilioID");
            return consultaObtenerLista(consulta);
        }

        public static Hotel hotelObtenerDesdeNombre(string nombreHotel)
        {
            string[] direccion = nombreHotel.Split('-');
            Domicilio domicilio = new Domicilio("", direccion[0], direccion[1], direccion[2], direccion[3]);
            Hotel hotel = new Hotel(domicilio);
            hotel.id = hotelObtenerIDPorDomicilio(hotel);
            return hotel;
        }

        public static bool hotelHabilitado(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("SELECT Hotel_Estado FROM RIP.Hoteles WHERE Hotel_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", hotel.id);
            return Boolean.Parse(consultaObtenerValor(consulta));
        }

        public static DataTable hotelFiltrarParaModificar(Hotel hotel)
        {
            string filtroNombre = string.IsNullOrEmpty(hotel.nombre) ? "" : hotel.nombre;
            string filtroEstrellas = string.IsNullOrEmpty(hotel.cantidadEstrellas) ? "" : hotel.cantidadEstrellas;
            string filtroPais = string.IsNullOrEmpty(hotel.domicilio.pais) ? "" : hotel.domicilio.pais;
            string filtroCiudad = string.IsNullOrEmpty(hotel.domicilio.ciudad)? "" : hotel.domicilio.pais;
            string query = "SELECT Hotel_ID, Hotel_Estado, Hotel_Nombre, Hotel_CantidadEstrellas, Hotel_FechaCreacion, " +
            "Hotel_Email, Hotel_Telefono, Domicilio_ID, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, " +
            "Domicilio_NumeroCalle FROM RIP.Hoteles JOIN RIP.Domicilios ON Hotel_DomicilioID = Domicilio_ID WHERE " +
            "ISNULL(Hotel_Nombre, '') LIKE '" + hotel.nombre + "%' AND " +
            "Domicilio_Pais LIKE '" + hotel.domicilio.pais+ "%' AND " +
            "Domicilio_Ciudad LIKE '" + hotel.domicilio.ciudad + "%' AND " +
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
            string query = "SELECT Hotel_ID, Hotel_Nombre, Hotel_Estado, Hotel_CantidadEstrellas, Hotel_FechaCreacion, " +
            "Hotel_Email, Hotel_Telefono, Domicilio_ID, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, " +
            "Domicilio_NumeroCalle FROM RIP.Hoteles JOIN RIP.Domicilios ON Hotel_DomicilioID = Domicilio_ID WHERE Hotel_Estado = 1 AND " +
            "ISNULL(Hotel_Nombre, '') LIKE '" + hotel.nombre + "%' AND " +
            "Domicilio_Pais LIKE '" + hotel.domicilio.pais + "%' AND " +
            "Domicilio_Ciudad LIKE '" + hotel.domicilio.ciudad + "%' AND " +
            "CONVERT(nvarchar(50), Hotel_CantidadEstrellas) LIKE '" + hotel.cantidadEstrellas + "%'";
            SqlCommand consulta = consultaCrear(query);
            return consultaObtenerTabla(consulta);
        }

        public static bool hotelHayReservasActivasConEseRegimen(Hotel hotel, string regimen)
        {
            SqlCommand consulta = consultaCrear("SELECT Reserva_ID FROM RIP.Reservas JOIN RIP.Estadias ON Reserva_ID = Estadia_ReservaID WHERE Reserva_HotelID = @HotelID AND Reserva_RegimenID = @RegimenID AND (Reserva_FechaInicio >= CONVERT(datetime,@FechaInicio,121) OR Estadia_FechaFin IS NULL)");
            consulta.Parameters.AddWithValue("@HotelID", hotel.id);
            consulta.Parameters.AddWithValue("@RegimenID", regimenObtenerID(regimen));
            consulta.Parameters.AddWithValue("@FechaInicio", ConfigurationManager.AppSettings["fechaSistema"]);
            return consultaValorExiste(consultaObtenerValor(consulta));
        }

        #endregion

        #region HotelCerrado

        public static bool hotelCerradoHayReservasActivasEnElPeriodo(HotelCerrado hotelCerrado)
        {
            SqlCommand consulta = consultaCrear("SELECT Reserva_ID FROM RIP.Reservas JOIN RIP.Estadias ON Reserva_ID= Estadia_ReservaID WHERE Reserva_HotelID = @ID AND ((Reserva_FechaInicio BETWEEN CONVERT(datetime,@FechaInicio,121) AND CONVERT(datetime,@FechaFin,121)) OR Estadia_FechaFin IS NULL)");
            consulta.Parameters.AddWithValue("@ID", hotelCerrado.hotel.id);
            consulta.Parameters.AddWithValue("@FechaInicio", hotelCerrado.fechaInicio);
            consulta.Parameters.AddWithValue("@FechaFin", hotelCerrado.fechaFin);
            return consultaValorExiste(consultaObtenerValor(consulta));
        }

        public static bool hotelCerradoAgregadoConExito(HotelCerrado hotelCerrado)
        {
            if (hotelCerradoHayReservasActivasEnElPeriodo(hotelCerrado))
            {
                ventanaInformarError("No se puede eliminar el hotel ya que posee reservas o huespedes alojados dentro del periodo elegido.");
                return false;
            }
            hotelCerradoAgregar(hotelCerrado);
            hotelEliminar(hotelCerrado.hotel);
            ventanaInformarExito("El hotel fue eliminado con exito");
            return true;
        }

        public static void hotelCerradoAgregar(HotelCerrado hotelCerrado)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.HotelesCerrados (HotelCerrado_HotelID, HotelCerrado_FechaInicio, HotelCerrado_FechaFin, HotelCerrado_Motivo) VALUES (@HotelID, CONVERT(datetime, @FechaInicio, 121), CONVERT(datetime, @FechaFin, 121), @Motivo)");
            consulta.Parameters.AddWithValue("@HotelID", hotelCerrado.hotel.id);
            consulta.Parameters.AddWithValue("@FechaInicio", hotelCerrado.fechaInicio);
            consulta.Parameters.AddWithValue("@FechaFin", hotelCerrado.fechaFin);
            consulta.Parameters.AddWithValue("@Motivo", hotelCerrado.motivo);
        }

        #endregion

        #region Habitacion

        public static bool habitacionAgregadaConExito(Habitacion habitacion)
        {
            if (habitacionExiste(habitacion))
            {
                ventanaInformarError("El numero de habitacion ya existe en el hotel");
                return false;
            }
            habitacionAgregar(habitacion);
            ventanaInformarExito("La habitacion fue creada con exito");
            return true;
        }

        public static double HabitacionObtenerPrecioBaseByTipo(string p)
        {
            SqlCommand consulta = consultaCrear("select TipoHabitacion_Porcentual from rip.TiposHabitaciones where TipoHabitacion_ID = @tipo");
            consulta.Parameters.AddWithValue("@tipo", p);
            return double.Parse(consultaObtenerValor(consulta));
        }

        public static bool habitacionModificadaConExito(Habitacion habitacion)
        {
            if (habitacionExiste(habitacion) && habitacionDistinta(habitacion))
            {
                ventanaInformarError("El numero de habitacion ya existe en el hotel");
                return false;
            }
            habitacionModificar(habitacion);
            ventanaInformarExito("La habitacion fue modificada con exito");
            return true;
        }

        public static void habitacionEliminadaConExito(Habitacion habitacion)
        {
            habitacionEliminar(habitacion);
            ventanaInformarExito("La habitacion fue eliminada con exito");
        }

        public static void habitacionAgregar(Habitacion habitacion)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Habitaciones (Habitacion_HotelID, Habitacion_Numero, Habitacion_Piso, Habitacion_Frente, Habitacion_TipoHabitacionID, Habitacion_Descripcion) VALUES (@HotelID, @Numero, @Piso, @Frente, @TipoHabitacionID, @Descripcion)");
            consulta.Parameters.AddWithValue("@HotelID", habitacion.hotel.id);
            consulta.Parameters.AddWithValue("@Numero", habitacion.numero);
            consulta.Parameters.AddWithValue("@Piso", habitacion.piso);
            consulta.Parameters.AddWithValue("@Frente", habitacion.frente);
            consulta.Parameters.AddWithValue("@TipoHabitacionID", tipoHabitacionObtenerID(habitacion.tipoHabitacion));
            consulta.Parameters.AddWithValue("@Descripcion", habitacion.descripcion);
            consultaEjecutar(consulta);
        }

        public static string HabitacionTipobyDescripcion(string p)
        {
            SqlCommand consulta = consultaCrear("select TipoHabitacion_ID from rip.TiposHabitaciones where TipoHabitacion_Descripcion = @tipo");
            consulta.Parameters.AddWithValue("@tipo", p);
            return consultaObtenerValor(consulta);
        }

        public static string HabitacionTipobyID(string p)
        {
            SqlCommand consulta = consultaCrear("select TipoHabitacion_Descripcion from rip.TiposHabitaciones where TipoHabitacion_ID = @tipo");
            consulta.Parameters.AddWithValue("@tipo", p);
            return consultaObtenerValor(consulta);
        }

        public static void habitacionModificar(Habitacion habitacion)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Habitaciones SET Habitacion_Numero = @Numero, Habitacion_Piso = @Piso, Habitacion_Frente = @Frente, Habitacion_Descripcion = @Descripcion, Habitacion_Estado = @Estado WHERE Habitacion_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", habitacion.id);
            consulta.Parameters.AddWithValue("@Numero", habitacion.numero);
            consulta.Parameters.AddWithValue("@Piso", habitacion.piso);
            consulta.Parameters.AddWithValue("@Frente", habitacion.frente);
            consulta.Parameters.AddWithValue("@Descripcion", habitacion.descripcion);
            consulta.Parameters.AddWithValue("@Estado", habitacion.estado);
            consultaEjecutar(consulta);
        }

        public static void habitacionEliminar(Habitacion habitacion)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Habitaciones SET Habitacion_Estado = 0 WHERE Habitacion_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", habitacion.id);
            consultaEjecutar(consulta);
        }

        public static string habitacionObtenerID(Habitacion habitacion)
        {
            SqlCommand consulta = consultaCrear("SELECT Habitacion_ID FROM RIP.Habitaciones WHERE Habitacion_HotelID = @HotelID AND Habitacion_Numero = @Numero");
            consulta.Parameters.AddWithValue("@HotelID", habitacion.hotel.id);
            consulta.Parameters.AddWithValue("@Numero", habitacion.numero);
            return consultaObtenerValor(consulta);
        }

        public static bool habitacionExiste(Habitacion habitacion)
        {
            return consultaValorExiste(habitacionObtenerID(habitacion));
        }

        public static bool habitacionDistinta(Habitacion habitacion)
        {
            return habitacion.id != habitacionObtenerID(habitacion);
        }

        public static List<string> habitacionObtenerFrentes()
        {
            List<string> frentes = new List<string>();
            frentes.Add("Interna");
            frentes.Add("Externa");
            return frentes;
        }

        public static List<string> habitacionObtenerTodasEnLista()
        {
            SqlCommand consulta = consultaCrear("SELECT Habitacion_ID, Habitacion_Numero, Habitacion_Piso, Habitacion_Frente, TipoHabitacion_Descripcion, Habitacion_Descripcion,  Habitacion_HotelID FROM RIP.Habitaciones JOIN RIP.TiposHabitaciones ON Habitacion_TipoHabitacionID = TipoHabitacion_ID");
            return consultaObtenerLista(consulta); 
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

        public static List<string> tipoHabitacionObtenerTodasEnLista()
        {
            SqlCommand consulta = consultaCrear("SELECT TipoHabitacion_Descripcion FROM RIP.TiposHabitaciones");
            return consultaObtenerLista(consulta);
        }

        #endregion

        #region Regimen

        public static string regimenObtenerID(string regimen)
        {
            SqlCommand consulta = consultaCrear("SELECT Regimen_ID FROM RIP.Regimenes WHERE Regimen_Descripcion = @Descripcion");
            consulta.Parameters.AddWithValue("@Descripcion", regimen);
            return consultaObtenerValor(consulta);
        }

        public static List<string> regimenObtenerTodosEnLista()
        {
            SqlCommand consulta = consultaCrear("SELECT Regimen_Descripcion FROM RIP.Regimenes");
            return consultaObtenerLista(consulta);
        }

        public static string regimenObtenerDescripcion(string a)
        {
            SqlCommand consulta = consultaCrear("SELECT Regimen_Descripcion FROM RIP.Regimenes where Regimen_ID=@cod");
            consulta.Parameters.AddWithValue("@cod", a);
            return consultaObtenerValor(consulta);
        }

        public static bool RegimenAgregadoConExito(Regimen regimen)
        {

            if (RegimenExiste(regimen))
            {
                ventanaInformarError("Ya existe un regimen registrado con ese nombre");
                return false;
            }
            else
            {
                RegimenAgregar(regimen);
                regimen.id = regimenObtenerID(regimen.descripcion);
                ventanaInformarExito("El regimen fue creado con exito");
                return true;
            }
        }

        public static bool RegimenExiste(Regimen regimen)
        {
            SqlCommand consulta = consultaCrear("SELECT COUNT(*) FROM RIP.Regimenes WHERE Regimen_Descripcion = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", regimen.descripcion);            
            return consultaValorEsMayorA(consultaObtenerValor(consulta), 0);
        }

                
        public static void RegimenAgregar(Regimen regimen)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Regimenes (Regimen_Descripcion, Regimen_Precio) VALUES (@Desc, @Precio)");
            consulta.Parameters.AddWithValue("@Desc", regimen.descripcion);
            consulta.Parameters.AddWithValue("@Precio", regimen.precio);
            consultaEjecutar(consulta);
        }

        public static DataTable RegimenesObtenerTodosEnTabla()
        {
            SqlCommand consulta = consultaCrear("SELECT * FROM RIP.Regimenes ORDER BY Regimen_ID");
            return consultaObtenerTabla(consulta);
        }

        public static DataTable RegimenesObtenerHabilitadosEnTabla()
        {
            SqlCommand consulta = consultaCrear("SELECT * FROM RIP.Regimenes WHERE Regimen_Estado = 1 ORDER BY Regimen_ID");
            return consultaObtenerTabla(consulta);
        }

        public static void RegimenEliminadoConExito(Regimen regimen)
        {
            try
            {
                RegimenEliminar(regimen);
                ventanaInformarExito("El regimen ha sido eliminado con exito");
            }
            catch (Exception e)
            {
                ventanaInformarError("Se ha producido un error al intentar eliminar el Regimen seleccionado. (" + regimen.id + ").");            
            }
        }

        public static void RegimenEliminar(Regimen regimen)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Regimenes SET Regimen_Estado = 0 WHERE Regimen_ID = @id");
            consulta.Parameters.AddWithValue("@id",regimen.id);
            consultaEjecutar(consulta);
        }

        #endregion
    
        #region Reserva

        public static List<string> reservaObtenerHoteles()
        {
            SqlCommand consulta = consultaCrear("SELECT CONCAT(Domicilio_Pais, '-', Domicilio_Ciudad, '-', Domicilio_Calle, '-', Domicilio_NumeroCalle) FROM RIP.Hoteles JOIN RIP.Domicilios ON Hotel_DomicilioID = Domicilio_ID");
            return consultaObtenerLista(consulta);
        }

        public static string reservaObtenerHotelbyID(string id)
        {
            SqlCommand consulta = consultaCrear("SELECT CONCAT(Domicilio_Pais, '-', Domicilio_Ciudad, '-', Domicilio_Calle, '-', Domicilio_NumeroCalle) FROM RIP.Hoteles JOIN RIP.Domicilios ON Hotel_DomicilioID = Domicilio_ID WHERE Hotel_ID = @id");
            consulta.Parameters.AddWithValue("@id", id);
            return consultaObtenerValor(consulta);
        }

        public static List<string> ReservaObtenerEstadiasDeHotel(string p)
        {
            SqlCommand consulta = consultaCrear("select r.Regimen_Descripcion from rip.Regimenes r  JOIN rip.Hoteles_Regimenes rh on r.Regimen_ID = rh.HotelRegimen_RegimenID JOIN rip.Hoteles h on h.Hotel_ID = rh.HotelRegimen_HotelID where h.Hotel_ID = @HotelID");
            consulta.Parameters.AddWithValue("@HotelID", p);
            return consultaObtenerLista(consulta);
        }

        public static List<string> ReservaHabitacionesDisponiblesEntre(DateTime fechainicio, DateTime fechafin, string idHotel, string tipohab)
        {
            string esto = "select Habitacion_ID from rip.Habitaciones habitaciones where habitaciones.Habitacion_HotelID = @hid and habitaciones.Habitacion_TipoHabitacionID = @tipoH and Habitacion_ID not in  ( select distinct hnd.HabitacionNoDisponible_HabitacionID from rip.HabitacionesNoDisponibles hnd join rip.Habitaciones hab on hab.Habitacion_ID = hnd.HabitacionNoDisponible_HabitacionID join rip.Hoteles hot on hot.Hotel_ID = hab.Habitacion_HotelID where hot.Hotel_ID = @hid and hnd.HabitacionNoDisponible_Finalizada = 0 and	( ( CONVERT(datetime,@fi,121) > hnd.HabitacionNoDisponible_FechaInicio AND CONVERT(datetime,@fi,121) < hnd.HabitacionNoDisponible_FechaFin ) OR ( CONVERT(datetime,@ff,121) > hnd.HabitacionNoDisponible_FechaInicio AND CONVERT(datetime,@ff,121) < hnd.HabitacionNoDisponible_FechaFin) ) )";
            SqlCommand consulta = consultaCrear(esto);


            string newDate = fechainicio.ToString("yyyy-MM-dd h:mm:ss.fff");
            string newDate2 = fechafin.ToString("yyyy-MM-dd h:mm:ss.fff");

            consulta.Parameters.AddWithValue("@fi", newDate);
            consulta.Parameters.AddWithValue("@ff", newDate2);
            consulta.Parameters.AddWithValue("@hid", idHotel);
            consulta.Parameters.AddWithValue("@tipoH", tipohab);

            return consultaObtenerLista(consulta);
        }

        public static double ReservaObtenerPrecioBase(string p)
        {
            SqlCommand consulta = consultaCrear("SELECT Regimen_Precio FROM rip.Regimenes WHERE Regimen_Descripcion = @precio");
            consulta.Parameters.AddWithValue("@precio", p);

            string precio = consultaObtenerValor(consulta);

            return double.Parse(precio);
        }

        public static void ReservaSaveReserva(Reserva R)
        {
            // estas lineas sirven en cado de la modificacion, borro los registros y los creo de nuevo
            SqlCommand borrahab = consultaCrear("DELETE rip.HabitacionesNoDisponibles where HabitacionNoDisponible_ReservaID = @codr");
            borrahab.Parameters.AddWithValue("@codr", int.Parse(R.Codigo));
            consultaEjecutar(borrahab);

            SqlCommand borrare = consultaCrear("DELETE rip.Reservas where Reserva_ID = @codr");
            borrare.Parameters.AddWithValue("@codr", int.Parse(R.Codigo));
            consultaEjecutar(borrare);

            // creacion de la estadia
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Reservas (Reserva_ID, Reserva_ClienteID, Reserva_HotelID, Reserva_CantidadHuespedes, Reserva_FechaCreacion, Reserva_FechaInicio, Reserva_FechaFin, Reserva_TipoHabitacionID, Reserva_RegimenID, Reserva_EstadoReservaID, Reserva_UsuarioID) VALUES (@reservacod,@clienteid,@hotelid,@rch,CONVERT(datetime,@fechacreacion,121),CONVERT(datetime,@fi,121),CONVERT(datetime,@ff,121),@tipohabitacion,@regimenid,@estadoReserva,@userid)");
            consulta.Parameters.AddWithValue("@reservacod", R.Codigo);
            consulta.Parameters.AddWithValue("@clienteid", R.Cliente.id);
            consulta.Parameters.AddWithValue("@hotelid", R.Hotel.id);
            consulta.Parameters.AddWithValue("@rch", R.CantidadHuespedes);
            consulta.Parameters.AddWithValue("@fechacreacion", DateTime.Parse(ConfigurationManager.AppSettings["fechaSistema"]));
            consulta.Parameters.AddWithValue("@fi", R.FechaInicio);
            consulta.Parameters.AddWithValue("@ff", R.FechaFin);
            consulta.Parameters.AddWithValue("@tipohabitacion", R.Habitaciones[0].tipoHabitacion);
            consulta.Parameters.AddWithValue("@regimenid", regimenObtenerID(R.Regimen));
            consulta.Parameters.AddWithValue("@estadoReserva", reservaGetIDEstadoReservabyNombre("Reserva correcta"));
            consulta.Parameters.AddWithValue("@userid", R.Usuario.id);

            consultaEjecutar(consulta);
            
            // creacion de hab reservadas en no disponible
            for (int i = 0; i < R.Habitaciones.Count; i++)
            {
                SqlCommand consulta2 = consultaCrear("INSERT INTO RIP.HabitacionesNoDisponibles (HabitacionNoDisponible_ReservaID, HabitacionNoDisponible_HabitacionID, HabitacionNoDisponible_FechaInicio, HabitacionNoDisponible_FechaFin) VALUES (@codreserva, @idh, CONVERT(datetime,@fi,121), CONVERT(datetime,@ff,121))");
                consulta2.Parameters.AddWithValue("@codreserva", int.Parse(R.Codigo));
                consulta2.Parameters.AddWithValue("@idh", R.Habitaciones[i].id);
                consulta2.Parameters.AddWithValue("@fi", R.FechaInicio);
                consulta2.Parameters.AddWithValue("@ff", R.FechaFin);
                consultaEjecutar(consulta2);
            }

            ReservaActualizarReservasVencidas();
        }

        private static void ReservaActualizarReservasVencidas()
        {
            SqlCommand updateReservas = consultaCrear("UPDATE rip.Reservas set Reserva_EstadoReservaID = 5 where Reserva_ID not in (select Estadia_ReservaID from rip.Estadias) and Reserva_FechaInicio < CONVERT(datetime,@fecha,121)");
            updateReservas.Parameters.AddWithValue("@fecha", ConfigurationManager.AppSettings["fechaSistema"]);
            consultaEjecutar(updateReservas);

            SqlCommand liberarHabitaciones = consultaCrear("update rip.HabitacionesNoDisponibles set HabitacionNoDisponible_Finalizada = 1 where HabitacionNoDisponible_ReservaID in ( select r.Reserva_ID from rip.Reservas r where r.Reserva_ID not in (select Estadia_ReservaID from rip.Estadias) and Reserva_FechaInicio <  CONVERT(datetime,@fecha,121) )");
            liberarHabitaciones.Parameters.AddWithValue("@fecha", ConfigurationManager.AppSettings["fechaSistema"]);
            consultaEjecutar(liberarHabitaciones);
        }

        public static string reservaGetIDEstadoReservabyNombre(string nombre)
        {
            SqlCommand consulta = consultaCrear("select EstadoReserva_ID from rip.EstadosReservas where EstadoReserva_Descripcion = @des");
            consulta.Parameters.AddWithValue("@des", nombre);
            return consultaObtenerValor(consulta);
        }
        
        public static string ReservaGenerarCodigo()
        {
            SqlCommand consulta = consultaCrear("select MAX(Reserva_ID) from rip.Reservas");
            return (long.Parse(consultaObtenerValor(consulta)) + 1).ToString();
        }

        public static bool ReservaExiste(string nroReserva)
        {
            SqlCommand consulta = consultaCrear("select * from rip.Reservas where Reserva_ID = @IdReserva");
            consulta.Parameters.AddWithValue("@IdReserva", nroReserva);
            return (consultaObtenerValor(consulta) != "");
        }

        public static bool ReservaEsFechaMenor(string p, DateTime hoy)
        {
            SqlCommand consulta = consultaCrear("select * from rip.Reservas where Reserva_ID = @IdReserva and Reserva_FechaInicio > CONVERT(datetime,@dia,121)");
            consulta.Parameters.AddWithValue("@IdReserva", p);
            consulta.Parameters.AddWithValue("@dia", hoy);
            return (consultaObtenerValor(consulta) != "");
        }

        public static Reserva ReservaObtenerById(string numeroReserva)
        {
            SqlCommand consulta = consultaCrear("select * from rip.Reservas where Reserva_ID = @IdReserva");
            consulta.Parameters.AddWithValue("@IdReserva", numeroReserva);
            DataRow linea = consultaObtenerFila(consulta);

            Reserva R = new Reserva();
            R.Cliente = new Cliente();

            R.Codigo = linea.ItemArray[0].ToString();
            R.Cliente.id = linea.ItemArray[1].ToString();
            R.Hotel = new Hotel(linea.ItemArray[2].ToString());
            R.CantidadHuespedes = int.Parse(linea.ItemArray[3].ToString());
            R.FechaCreacion = DateTime.Parse(linea.ItemArray[4].ToString());
            R.FechaInicio = DateTime.Parse(linea.ItemArray[5].ToString());
            R.FechaFin = DateTime.Parse(linea.ItemArray[6].ToString());
            
            SqlCommand ledezma = consultaCrear("select HabitacionNoDisponible_HabitacionID from rip.HabitacionesNoDisponibles where HabitacionNoDisponible_ReservaID = @IdReserva");
            ledezma.Parameters.AddWithValue("@IdReserva", numeroReserva);
            List<string> idHABs = consultaObtenerLista(ledezma);
            
            List<Habitacion> habitaciones = new List<Habitacion>();
            for (int i = 0; i < idHABs.Count; i++)
            {
                Habitacion h = new Habitacion(idHABs[i], linea.ItemArray[7].ToString());
                habitaciones.Add(h);
            }

            R.Habitaciones = habitaciones;

            R.Regimen = regimenObtenerDescripcion(linea.ItemArray[8].ToString());
            R.Usuario = new Usuario(usuarioObtenerNombreByID(linea.ItemArray[10].ToString()));

            return R;
        }

        public static void ReservaCancelar(Reserva r, string motivo, string usuario, int estadoReserva)
        {
            SqlCommand query = new SqlCommand();
            if (motivo == "Ingrese un motivo...")
            {
                query = consultaCrear("INSERT INTO RIP.ReservasCanceladas (ReservaCancelada_RerservaID, ReservaCancelada_Fecha, ReservaCancelada_UsuarioID) VALUES (@codigo,CONVERT(datetime,@fecha,121),@usuario)");
            }
            else
            {
                query = consultaCrear("INSERT INTO RIP.ReservasCanceladas (ReservaCancelada_RerservaID, ReservaCancelada_Fecha, ReservaCancelada_UsuarioID, ReservaCancelada_Motivo) VALUES (@codigo,CONVERT(datetime,@fecha,121),@usuario,@motivo)");
                query.Parameters.AddWithValue("@motivo", motivo);
            }

            query.Parameters.AddWithValue("@codigo", r.Codigo);
            query.Parameters.AddWithValue("@fecha", DateTime.Parse(ConfigurationManager.AppSettings["fechaSistema"]));
            query.Parameters.AddWithValue("@usuario", usuario);

            consultaEjecutar(query);

            //actualizo hab no disponibles
            SqlCommand quer2 = new SqlCommand();
            quer2 = consultaCrear("UPDATE rip.HabitacionesNoDisponibles set HabitacionNoDisponible_FechaFin = CONVERT(datetime,@fe,121), HabitacionNoDisponible_Finalizada = 1  where HabitacionNoDisponible_ReservaID = @codr ");
            quer2.Parameters.AddWithValue("@codr", r.Codigo);
            quer2.Parameters.AddWithValue("@fe", DateTime.Parse(ConfigurationManager.AppSettings["fechaSistema"]));

            consultaEjecutar(quer2);

            // actualizar reserva
            SqlCommand Alsamendi = new SqlCommand();
            Alsamendi = consultaCrear("UPDATE RIP.Reservas set Reserva_EstadoReservaID = @aaaa where Reserva_ID = @codr");
            Alsamendi.Parameters.AddWithValue("@codr", r.Codigo);
            Alsamendi.Parameters.AddWithValue("@aaaa", estadoReserva);


            consultaEjecutar(Alsamendi);

        }

        public static bool ReservaEstadoValidoParaCancelarModificar(string numeroReserva)
        {
            SqlCommand consulta = consultaCrear("select * from rip.Reservas r inner join rip.EstadosReservas e on e.EstadoReserva_ID = r.Reserva_EstadoReservaID where r.Reserva_ID = @idr AND (e.EstadoReserva_Descripcion = 'Reserva correcta' OR e.EstadoReserva_Descripcion = 'Reserva modificada')");
            consulta.Parameters.AddWithValue("@idr", numeroReserva);
            return (consultaObtenerValor(consulta) != "");
        }
        
        public static string reservaObtenerHotel(string reservaID, string hotelID)
        {
            SqlCommand consulta = Database.consultaCrear("SELECT CONCAT(Domicilio_Pais, '-', Domicilio_Ciudad, '-', Domicilio_Calle, '-', Domicilio_NumeroCalle) FROM RIP.Reservas JOIN RIP.Hoteles ON Reserva_HotelID = Hotel_ID JOIN RIP.Domicilios ON Hotel_DomicilioID = Domicilio_ID WHERE Reserva_ID = @ID AND Reserva_HotelID = @HotelID");
            consulta.Parameters.AddWithValue("@ID", reservaID);
            consulta.Parameters.AddWithValue("@HotelID", hotelID);
            return Database.consultaObtenerValor(consulta);
        }

        public static string reservaObtenerRegimen(string reservaID)
        {
            SqlCommand consulta = Database.consultaCrear("SELECT Regimen_Descripcion FROM RIP.Reservas JOIN RIP.Regimenes ON Reserva_RegimenID = Regimen_ID WHERE Reserva_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", reservaID);
            return Database.consultaObtenerValor(consulta);
        }

        public static Reserva reservaObtener(string reservaID, string hotelID)
        {
            SqlCommand consulta = Database.consultaCrear("SELECT Reserva_ID, Reserva_ClienteID, Reserva_HotelID, Reserva_FechaInicio, Reserva_FechaFin, Reserva_CantidadHuespedes, TipoHabitacion_Descripcion, Regimen_Descripcion, Persona_Nombre, Persona_Apellido, TipoDocumento_Descripcion, Persona_NumeroDocumento, Persona_Email, Domicilio_Pais, Domicilio_Ciudad, Domicilio_Calle, Domicilio_NumeroCalle FROM RIP.Reservas JOIN RIP.Clientes ON Reserva_ClienteID = Cliente_ID JOIN RIP.Personas ON Cliente_PersonaID = Persona_ID JOIN RIP.TiposDocumentos ON Persona_TipoDocumentoID = TipoDocumento_ID JOIN RIP.Hoteles ON Reserva_HotelID = Hotel_ID JOIN RIP.Domicilios ON Hotel_DomicilioID = Domicilio_ID JOIN RIP.Regimenes ON Reserva_RegimenID = Regimen_ID JOIN RIP.TiposHabitaciones ON Reserva_TipoHabitacionID = TipoHabitacion_ID WHERE Reserva_ID = @ID AND Reserva_HotelID = @HotelID");
            consulta.Parameters.AddWithValue("@ID", reservaID);
            consulta.Parameters.AddWithValue("@HotelID", hotelID);
            DataRow fila = Database.consultaObtenerFila(consulta);
            Reserva reserva = new Reserva();
            if (fila != null)
            {
                reserva.Codigo = ((Decimal)fila["Reserva_ID"]).ToString();
                reserva.FechaInicio = (DateTime)fila["Reserva_FechaInicio"];
                reserva.FechaFin = (DateTime)fila["Reserva_FechaFin"];
                reserva.Regimen = (string)fila["Regimen_Descripcion"];
                reserva.TipoHabitacion = (string)fila["TipoHabitacion_Descripcion"];
                reserva.CantidadHuespedes = fila["Reserva_CantidadHuespedes"] == DBNull.Value ? 0 : Decimal.ToInt32((Decimal)fila["Reserva_CantidadHuespedes"]);
                reserva.Hotel = new Hotel();
                reserva.Hotel.id = ((Decimal)fila["Reserva_HotelID"]).ToString();
                reserva.Hotel.domicilio = new Domicilio();
                reserva.Hotel.domicilio.pais = (string)fila["Domicilio_Pais"];
                reserva.Hotel.domicilio.ciudad = (string)fila["Domicilio_Ciudad"];
                reserva.Hotel.domicilio.calle = (string)fila["Domicilio_Calle"];
                reserva.Hotel.domicilio.numeroCalle = ((Decimal)fila["Domicilio_NumeroCalle"]).ToString();
                reserva.Cliente = new Cliente();
                reserva.Cliente.id = ((Decimal)fila["Reserva_ClienteID"]).ToString();
                reserva.Cliente.persona = new Persona();
                reserva.Cliente.persona.nombre = (string)fila["Persona_Nombre"];
                reserva.Cliente.persona.apellido = (string)fila["Persona_Apellido"];
                reserva.Cliente.persona.tipoDocumento = (string)fila["TipoDocumento_Descripcion"];
                reserva.Cliente.persona.numeroDocumento = ((Decimal)fila["Persona_NumeroDocumento"]).ToString();
                reserva.Cliente.persona.email = (string)fila["Persona_Email"];
            }
            else
                reserva = null;
            return reserva;
        }

        public static List<string> ReservaHabitacionesModificacionDisponiblesEntre(DateTime fi, DateTime ff, string IdHotel, string codReserva)
        {
            SqlCommand consulta = consultaCrear("select Habitacion_ID from rip.Habitaciones habitaciones where habitaciones.Habitacion_HotelID = @hid and Habitacion_ID not in (select hnd.HabitacionNoDisponible_HabitacionID from rip.HabitacionesNoDisponibles hnd join rip.Habitaciones hab on hab.Habitacion_ID = hnd.HabitacionNoDisponible_HabitacionID join rip.Hoteles hot on hot.Hotel_ID = hab.Habitacion_HotelID where hot.Hotel_ID = @hid and hnd.HabitacionNoDisponible_ReservaID != @cod and hnd.HabitacionNoDisponible_Finalizada = 0 and (CONVERT(datetime,@fi,121) > hnd.HabitacionNoDisponible_FechaInicio AND CONVERT(datetime,@fi,121) < hnd.HabitacionNoDisponible_FechaFin) OR  (CONVERT(datetime,@ff,121) > hnd.HabitacionNoDisponible_FechaInicio AND CONVERT(datetime,@ff,121) < hnd.HabitacionNoDisponible_FechaFin))");

            consulta.Parameters.AddWithValue("@fi", fi);
            consulta.Parameters.AddWithValue("@ff", fi);
            consulta.Parameters.AddWithValue("@hid", IdHotel);
            consulta.Parameters.AddWithValue("@cod", codReserva);

            return consultaObtenerLista(consulta);
        }

        internal static Cliente ReservaObtenerClienteByIdReserva(string p)
        {
            SqlCommand consulta = consultaCrear("select * from rip.Personas p join rip.Clientes c on c.Cliente_PersonaID = p.Persona_ID join rip.Reservas r on r.Reserva_ClienteID = c.Cliente_ID where r.Reserva_ID = @codr ");
            consulta.Parameters.AddWithValue("@codr", p);
            DataRow linea = consultaObtenerFila(consulta);

            Cliente C = new Cliente();

            C.persona = new Persona();

            C.persona.id =  linea.ItemArray[0].ToString();
            C.persona.nombre = linea.ItemArray[1].ToString();

            return C;
        }

        public static bool ReservaEsDeMiHotel(string numeroReserva, string idhotel)
        {
            SqlCommand consulta = consultaCrear("SELECT * FROM RIP.Reservas WHERE Reserva_ID = @idr AND Reserva_HotelID = @hid");
            consulta.Parameters.AddWithValue("@idr", numeroReserva);
            consulta.Parameters.AddWithValue("@hid", idhotel);
            return consultaValorExiste(consultaObtenerValor(consulta));
        }

        #endregion

        #region Estadia

        public static string estadiaObtenerID(Estadia estadia)
        {
            SqlCommand consulta = consultaCrear("SELECT Estadia_ID FROM RIP.Estadias WHERE Estadia_ReservaID = @ReservaID");
            consulta.Parameters.AddWithValue("@ReservaID", estadia.reserva.Codigo);
            return consultaObtenerValor(consulta);
        }

        public static void estadiaAgregarIngreso(Estadia estadia)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Estadias (Estadia_ReservaID, Estadia_FechaInicio, Estadia_CheckInUsuarioID) VALUES (@ReservaID, CONVERT(datetime,@FechaInicio,121), @UsuarioID)");
            consulta.Parameters.AddWithValue("@UsuarioID", estadia.checkInUsuarioID);
            consulta.Parameters.AddWithValue("@ReservaID", estadia.reserva.Codigo);
            consulta.Parameters.AddWithValue("@FechaInicio", ConfigurationManager.AppSettings["fechaSistema"]);
            consultaEjecutar(consulta);
        }

        public static void estadiaAgregarReservaConIngreso(Estadia estadia)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Reservas SET Reserva_EstadoReservaID = 6 WHERE Reserva_ID = @ReservaID");
            consulta.Parameters.AddWithValue("@ReservaID", estadia.reserva.Codigo);
            consultaEjecutar(consulta);
        }

        public static void estadiaIngresoExitoso(Estadia estadia)
        {
            estadiaAgregarIngreso(estadia);
            estadiaAgregarReservaConIngreso(estadia);
            estadiaAgregarHuespedes(estadia);
            ventanaInformarExito("El ingreso de la estadia fue registrado con exito");
        }

        public static bool estadiaIngresoPermitido(Estadia estadia)
        {
            return estadia.reserva.FechaInicio.Date == DateTime.Parse(ConfigurationManager.AppSettings["fechaSistema"]).Date;
        }

        public static bool estadiaIngresoEstaRegistrado(Estadia estadia)
        {
            SqlCommand consulta = consultaCrear("SELECT Estadia_ReservaID FROM RIP.Estadias WHERE Estadia_ReservaID = @ReservaID AND Estadia_FechaInicio IS NOT NULL");
            consulta.Parameters.AddWithValue("@ReservaID", estadia.reserva.Codigo);
            return consultaValorExiste(consultaObtenerValor(consulta));
        }

        public static bool estadiaIngresoValidar(Estadia estadia)
        {
            if (estadiaIngresoEstaRegistrado(estadia))
            {
                ventanaInformarError("El ingreso de la estadia ya fue registrado");
                return false;
            }
            if (!estadiaIngresoPermitido(estadia))
            {
                ventanaInformarError("No se puede realizar el ingreso antes o despues de la fecha de inicio de la reserva");
                return false;
            }
            return true;
        }

        public static void estadiaAgregarEgreso(Estadia estadia)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Estadias SET Estadia_FechaFin = CONVERT(datetime,@FechaFin,121), Estadia_CheckOutUsuarioID = @UsuarioID WHERE Estadia_ReservaID = @ReservaID");
            consulta.Parameters.AddWithValue("@UsuarioID", estadia.checkOutUsuarioID);
            consulta.Parameters.AddWithValue("@ReservaID", estadia.reserva.Codigo);
            consulta.Parameters.AddWithValue("@FechaFin", ConfigurationManager.AppSettings["fechaSistema"]);
            consultaEjecutar(consulta);
        }

        public static void estadiaEgresoExitoso(Estadia estadia)
        {
            estadiaAgregarEgreso(estadia);
            estadiaEgresoHuespedes(estadia);
            estadiaLiberarHabitaciones(estadia);
            ventanaInformarExito("El egreso de la estadia fue registrado con exito");
        }

        private static void estadiaLiberarHabitaciones(Estadia estadia)
        {
            SqlCommand liberarHabitaciones = consultaCrear("update rip.HabitacionesNoDisponibles set HabitacionNoDisponible_Finalizada = 1 where HabitacionNoDisponible_ReservaID = (select top 1 r.Reserva_ID from rip.Estadias e join rip.Reservas r on e.Estadia_ReservaID = r.Reserva_ID where e.Estadia_ID = @eid)");
            liberarHabitaciones.Parameters.AddWithValue("@eid", estadiaObtenerID(estadia));
            consultaEjecutar(liberarHabitaciones);
        }

        public static bool estadiaEgresoPermitido(Estadia estadia)
        {
            return DateTime.Parse(ConfigurationManager.AppSettings["fechaSistema"]).Date >= estadia.reserva.FechaInicio.Date && DateTime.Parse(ConfigurationManager.AppSettings["fechaSistema"]).Date <= estadia.reserva.FechaFin.Date;
        }

        public static bool estadiaEgresoEstaRegistrado(Estadia estadia)
        {
            SqlCommand consulta = consultaCrear("SELECT Estadia_ReservaID FROM RIP.Estadias WHERE Estadia_ReservaID = @ReservaID AND Estadia_FechaFin IS NOT NULL");
            consulta.Parameters.AddWithValue("@ReservaID", estadia.reserva.Codigo);
            return consultaValorExiste(consultaObtenerValor(consulta));
        }

        public static bool estadiaEgresoValidar(Estadia estadia)
        {
            if (!estadiaIngresoEstaRegistrado(estadia))
            {
                ventanaInformarError("El ingreso de la estadia aun no fue registrada");
                return false;
            }
            if (estadiaEgresoEstaRegistrado(estadia))
            {
                ventanaInformarError("El egreso de la estadia ya fue registrado");
                return false;
            }
            if (!estadiaEgresoPermitido(estadia))
            {
                ventanaInformarError("El egreso debe realizarse entre la fecha de inicio y la fecha de fin de la reserva");
                return false;
            }
            return true;
        }
    
        public static void estadiaAgregarHuesped(string clienteID, string estadiaID)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Huespedes (Huesped_ClienteID, Huesped_EstadiaID, Huesped_Presente) VALUES (@ClienteID, @EstadiaID, 1)");
            consulta.Parameters.AddWithValue("@ClienteID", clienteID);
            consulta.Parameters.AddWithValue("@EstadiaID", estadiaID);
            consultaEjecutar(consulta);
        }

        public static void estadiaAgregarHuespedes(Estadia estadia)
        {
            string estadiaID = estadiaObtenerID(estadia); 
            estadiaAgregarHuesped(estadia.reserva.Cliente.id, estadiaObtenerID(estadia));
            foreach (string clienteID in estadia.huespedes)
                estadiaAgregarHuesped(clienteID, estadiaObtenerID(estadia));
        }

        public static void estadiaEgresoHuespedes(Estadia estadia)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Huespedes SET Huesped_Presente = 0 WHERE Huesped_EstadiaID = @ID");
            consulta.Parameters.AddWithValue("@ID", estadiaObtenerID(estadia));
            consultaEjecutar(consulta);
        }

        public static bool estadiaVerificarHuesped(Cliente cliente, Estadia estadia)
        {
            if (!clienteHabilitado(cliente))
            {
                ventanaInformarError("El cliente no se encuentra habilitado");
                return false;
            }
                
            if(estadia.huespedes.Contains(cliente.id))
            {
                ventanaInformarError("El cliente ya fue agregado a la lista");
                return false;
            }
            return true;                 
        }

        public static List<string> reservaObtenerHabitacionesEnLista(string reservaID)
        {
            SqlCommand consulta = consultaCrear("SELECT Habitacion_Numero FROM RIP.HabitacionesNoDisponibles JOIN RIP.Habitaciones ON HabitacionNoDisponible_HabitacionID = Habitacion_ID WHERE HabitacionNoDisponible_ReservaID = @ReservaID");
            consulta.Parameters.AddWithValue("@ReservaID", reservaID);
            return consultaObtenerLista(consulta);
        }


        #endregion

        #region Consumido

        public static DataTable consumidoObtenerTodosEnTabla(Consumido consumido)
        {
            SqlCommand consulta = consultaCrear("SELECT Consumible_Descripcion, Consumido_Cantidad FROM RIP.Consumidos JOIN RIP.Consumibles ON Consumido_ConsumibleID = Consumible_ID JOIN RIP.Estadias ON Consumido_EstadiaID = Estadia_ID WHERE Consumido_EstadiaID = @ID AND Estadia_FechaInicio IS NOT NULL AND Estadia_FechaFin IS NOT NULL");
            consulta.Parameters.AddWithValue("@ID", consumido.estadiaID);
            return consultaObtenerTabla(consulta);
        }

        public static void consumidoAgregar(Consumido consumido)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Consumidos (Consumido_EstadiaID, Consumido_HabitacionID, Consumido_ConsumibleID, Consumido_Cantidad) VALUES (@EstadiaID, @HabitacionID, @ConsumibleID, @Cantidad)");
            consulta.Parameters.AddWithValue("@EstadiaID", consumido.estadiaID);
            consulta.Parameters.AddWithValue("@HabitacionID", consumidoObtenerHabitacionID(consumido));
            consulta.Parameters.AddWithValue("@ConsumibleID", consumibleObtenerID(consumido.consumible));
            consulta.Parameters.AddWithValue("@Cantidad", consumido.cantidad);
            consultaEjecutar(consulta);
        }

        public static bool consumidoTodosRegistradosParaEstadia(Consumido consumido)
        {
            SqlCommand consulta = consultaCrear("SELECT Consumido_HabitacionID FROM RIP.Consumidos WHERE Consumido_EstadiaID = @EstadiaID AND Consumido_HabitacionID = @HabitacionID");
            consulta.Parameters.AddWithValue("@EstadiaID", consumido.estadiaID);
            consulta.Parameters.AddWithValue("@HabitacionID", consumidoObtenerHabitacionID(consumido));
            return consultaValorExiste(consultaObtenerValor(consulta));
        }

        public static string consumidoObtenerHabitacionID(Consumido consumido)
        {
            SqlCommand consulta = consultaCrear("SELECT Habitacion_ID FROM RIP.Habitaciones WHERE Habitacion_Numero = @Numero AND Habitacion_HotelID = @HotelID");
            consulta.Parameters.AddWithValue("@Numero", consumido.numeroHabitacion);
            consulta.Parameters.AddWithValue("@HotelID", consumido.hotelID);
            return consultaObtenerValor(consulta);
        }

        public static string consumidoObtenerEstadiaID(Consumido consumido)
        {
            SqlCommand consulta = consultaCrear("SELECT Estadia_ID FROM RIP.Estadias WHERE Estadia_ReservaID = @ReservaID AND Estadia_FechaInicio IS NOT NULL AND Estadia_FechaFin IS NOT NULL");
            consulta.Parameters.AddWithValue("@ReservaID", consumido.reservaCodigo);
            return consultaObtenerValor(consulta);
        }

        #endregion

        #region Consumible

        public static List<string> consumibleObtenerTodosEnLista()
        {
            SqlCommand consulta = consultaCrear("SELECT Consumible_Descripcion FROM RIP.Consumibles");
            return consultaObtenerLista(consulta);
        }

        public static string consumibleObtenerID(string consumible)
        {
            SqlCommand consulta = consultaCrear("SELECT Consumible_ID FROM RIP.Consumibles WHERE Consumible_Descripcion = @Descripcion");
            consulta.Parameters.AddWithValue("@Descripcion", consumible);
            return consultaObtenerValor(consulta);
        }

        #endregion


    }
}