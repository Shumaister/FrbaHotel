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
using FrbaHotel.Login;
using System.Windows.Forms;


namespace FrbaHotel
{
    public class Database
    {
        //-------------------------------------- Atributos -------------------------------------

        private static String configuracionConexion = ConfigurationManager.AppSettings["conexionSQL"];
        private static SqlConnection conexion = new SqlConnection(configuracionConexion);

        //-------------------------------------- Metodos para Conexion -------------------------------------

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

        //-------------------------------------- Metodos para Consultas -------------------------------------

        public static SqlCommand consultaCrear(string consulta)
        {
            return new SqlCommand(consulta, conexionObtener());
        }

        public static void consultaEjecutar(SqlCommand consulta)
        {
            conexionAbrir();
            try
            {
                consulta.ExecuteNonQuery();
            }
            catch (Exception excepcion)
            {
                consultaInformarError(excepcion);
            }
            conexionCerrar();
        }

        public static void consultaInformarError(Exception excepcion)
        {
            MessageBox.Show("ERROR EN LA BASE DE DATOS:\n" + excepcion.ToString());
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
                consultaInformarError(excepcion);
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

        //-------------------------------------- Metodos para Login -------------------------------------

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
            int intentosFallidos = (int)fila["Usuario_CantidadIntentos"];
            if (intentosFallidos >= 3)
                return loginCuentaBloqueada();
            else
                return loginVerificarContrasenia(nombreUsuario, contrasenia, contraseniaReal, intentosFallidos);
        }

        public static bool loginUsuarioExiste(DataRow fila)
        {
            //LA EXPRESIVIDAD NO SE MANCHA
            return fila != null;
        }

        public static LogueoDTO loginUsuarioInexistente()
        {
            LogueoDTO logueo = new LogueoDTO();
            return logueo.informarUsuarioInexistente();
        }

        public static LogueoDTO loginAutenticar(string nombreUsuario, string contrasenia)
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_Nombre, Usuario_Contrasenia, Usuario_CantidadIntentos FROM RIP.Usuarios WHERE Usuario_Nombre = @username");
            consulta.Parameters.AddWithValue("@username", nombreUsuario);            
            DataRow fila = consultaObtenerFila(consulta);         
            if(loginUsuarioExiste(fila))
                return loginVerificarCuenta(fila, contrasenia);
            else 
                return loginUsuarioInexistente();
        }

        public static void loginActualizarIntentos(string username, int cantidad)
        {
            SqlCommand query = consultaCrear("UPDATE RIP.Usuarios SET Usuario_CantidadIntentos = @cantidad WHERE Usuario_Nombre = @username");
            query.Parameters.AddWithValue("@username", username);
            query.Parameters.AddWithValue("@cantidad", cantidad);
            consultaEjecutar(query);
        }
        
        //-------------------------------------- Metodos para Funcionalidades -------------------------------------

        public static List<string> funcionalidadObtenerTodas()
        {
            SqlCommand consulta = consultaCrear("SELECT Funcionalidad_Nombre FROM RIP.Funcionalidades");
            return consultaObtenerLista(consulta);
        }
        
        public static string funcionalidadBuscarID(string nombreFuncionalidad)
        {
            SqlCommand consulta = consultaCrear("SELECT Funcionalidad_ID FROM RIP.Funcionalidades WHERE Funcionalidad_Nombre = @nombreFuncionalidad");
            consulta.Parameters.AddWithValue("@nombreFuncionalidad", nombreFuncionalidad);
            string funcionalidadID = consultaObtenerValor(consulta);
            return funcionalidadID;
        }

        //-------------------------------------- Metodos para Roles -------------------------------------

        public static void rolAgregar(string nombreRol, string estado)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Roles (Rol_Nombre, Rol_Estado) VALUES (@nombreRol, @estado)");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            consulta.Parameters.AddWithValue("@estado", estado);
            consultaEjecutar(consulta);
        }

        public static void rolHabilitadoAgregar(string nombreRol)
        {
            rolAgregar(nombreRol, "1");
        }

        public static void rolDeshabilitadoAgregar(string nombreRol)
        {
            rolAgregar(nombreRol, "0");
        }

        public static void rolAgregarFuncionalidad(string idRol, string nombreFuncionalidad)
        {
            string idFuncionalidad = funcionalidadBuscarID(nombreFuncionalidad);
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Roles_Funcionalidades (RolFuncionalidad_RolID, RolFuncionalidad_FuncionalidadID) VALUES (@idRol, @idFuncionalidad)");
            consulta.Parameters.AddWithValue("@idRol", idRol);
            consulta.Parameters.AddWithValue("@idFuncionalidad", idFuncionalidad);
            consultaEjecutar(consulta);
        }

        public static void rolEliminarFuncionalidades(string nombreRol)
        {
            string idRol = rolBuscarID(nombreRol);
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Roles_Funcionalidades WHERE RolFuncionalidad_RolID = @idRol");
            consulta.Parameters.AddWithValue("@idRol", idRol);
            consultaEjecutar(consulta);
        }

        public static void rolModificar(string nombreRolActual, string nombreRolNuevo, string estado)
        {
            rolEliminarFuncionalidades(nombreRolActual);
            SqlCommand consulta = consultaCrear("UPDATE RIP.Roles SET Rol_Nombre = @nombreRolNuevo, Rol_Estado = @estado WHERE Rol_Nombre = @nombreRolActual");
            consulta.Parameters.AddWithValue("@nombreRolActual", nombreRolActual);
            consulta.Parameters.AddWithValue("@nombreRolNuevo", nombreRolNuevo);
            consulta.Parameters.AddWithValue("@estado", estado);
            consultaEjecutar(consulta);
        }

        public static void rolHabilitadoModificar(string nombreRolActual, string nombreRolNuevo)
        {
            rolModificar(nombreRolActual, nombreRolNuevo, "1");
        }

        public static void rolDeshabilitadoModificar(string nombreRolActual, string nombreRolNuevo)
        {
            rolModificar(nombreRolActual, nombreRolNuevo, "0");
        }

        public static void rolEliminar(string nombreRol)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Roles SET Rol_Estado = 0 WHERE Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            consultaEjecutar(consulta);
        }

        public static string rolBuscarID(string nombreRol)
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_ID FROM RIP.Roles WHERE Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            string rolID = consultaObtenerValor(consulta);
            return rolID;
        }

        public static DataTable rolObtenerTodosTabla()
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_ID, Rol_Nombre FROM RIP.Roles ORDER BY Rol_ID");
            return consultaObtenerTabla(consulta);
        }

        public static List<string> rolObtenerTodosLista()
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_Nombre FROM RIP.Roles");
            return consultaObtenerLista(consulta);
        }

        public static DataTable rolObtenerHabilitadosTabla()
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_ID, Rol_Nombre FROM RIP.Roles WHERE Rol_Estado = 1 ORDER BY Rol_ID");
            return consultaObtenerTabla(consulta);
        }

        public static bool rolNombreYaExiste(string nombreRol)
        {
            SqlCommand consulta = consultaCrear("SELECT COUNT(Rol_Nombre) FROM RIP.Roles WHERE Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            string valor = consultaObtenerValor(consulta);
            return consultaValorEsMayorA (valor, 0);
        }

        public static bool rolEstaHabilitado(string nombreRol)
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_Estado FROM RIP.Roles WHERE Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            bool estado = Boolean.Parse(consultaObtenerValor(consulta));
            return estado;
        }

        public static bool rolNoTieneEsaFuncionalidad(string nombreRol, string nombreFuncionalidad)
        {
            string idRol = rolBuscarID(nombreRol);
            string idFuncionalidad = funcionalidadBuscarID(nombreFuncionalidad);
            SqlCommand consulta = consultaCrear("SELECT COUNT(*) FROM RIP.Roles_Funcionalidades WHERE RolFuncionalidad_RolID = @idRol AND RolFuncionalidad_FuncionalidadID = @idFuncionalidad");
            consulta.Parameters.AddWithValue("@idRol", idRol);
            consulta.Parameters.AddWithValue("@idFuncionalidad", idFuncionalidad);
            string valor = consultaObtenerValor(consulta);
            return consultaValorEsIgualA(valor, 0);
        }

        public static List<string> rolObtenerFuncionalidades(string nombreRol)
        {
            SqlCommand consulta = consultaCrear("SELECT f.Funcionalidad_Nombre FROM RIP.Funcionalidades f JOIN RIP.Roles_Funcionalidades rf ON f.Funcionalidad_ID = rf.RolFuncionalidad_FuncionalidadID JOIN RIP.Roles r ON rf.RolFuncionalidad_RolID = r.Rol_ID WHERE r.Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            return consultaObtenerLista(consulta);
        }

        public static List<string> rolObtenerFuncionalidadesFaltantes(string nombreRol)
        {
            SqlCommand consulta = consultaCrear("SELECT Funcionalidad_Nombre FROM RIP.Funcionalidades WHERE Funcionalidad_ID NOT IN (SELECT RolFuncionalidad_FuncionalidadID FROM RIP.Roles_Funcionalidades JOIN RIP.Roles ON RolFuncionalidad_RolID = Rol_ID WHERE Rol_Nombre = @nombreRol)");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            return consultaObtenerLista(consulta);
        }

        //-------------------------------------- Metodos para Usuarios -------------------------------------

        public static Usuario usuarioCrear(string nombreUsuario)
        {
            List<string> roles = usuarioObtenerRoles(nombreUsuario);
            List<string> hoteles = usuarioObtenerHotelesLista(nombreUsuario);
            Usuario usuario = new Usuario(nombreUsuario, roles, hoteles);
            return usuario;
        }

        public static void usuarioGuardar()
        {

        }

        public static void usuarioModificar()
        {

        }

        public static void usuarioEliminar()
        {

        }

        public static List<string> usuarioObtenerHotelesLista(string nombreUsuario)
        {
            SqlCommand consulta = consultaCrear("SELECT ci.Ciudad_Nombre, c.Calle_Nombre, d.Domicilio_NumeroCalle FROM RIP.Hoteles h JOIN RIP.Hoteles_Usuarios hu ON hu.HotelUsuario_HotelID = h.Hotel_ID JOIN RIP.Usuarios u ON u.Usuario_ID = hu.HotelUsuario_UsuarioID JOIN RIP.Domicilios d ON d.Domicilio_ID = h.Hotel_DomicilioID JOIN RIP.Calles c on c.Calle_ID = d.Domicilio_CalleID JOIN RIP.Ciudades ci on ci.Ciudad_ID = d.Domicilio_CiudadID WHERE u.Usuario_Nombre = @username");
            consulta.Parameters.AddWithValue("@username", nombreUsuario);
            List<string> hoteles = hotelConfigurarNombres(consulta);
            return hoteles;
        }
        
        public static bool usuarioTrabajaEnUnSoloHotel(string nombreUsuario)
        {
            SqlCommand consulta = consultaCrear("SELECT COUNT(HotelUsuario_HotelID) FROM RIP.Hoteles_Usuarios JOIN RIP.Usuarios ON HotelUsuario_UsuarioID = Usuario_ID WHERE Usuario_Nombre = @nombreUsuario");
            consulta.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            string valor = consultaObtenerValor(consulta);
            return consultaValorEsIgualA(valor, 1);
        }

        public static bool usuarioTrabajaEnVariosHoteles(string nombreUsuario)
        {
            return !usuarioTrabajaEnUnSoloHotel(nombreUsuario);
        }

        public static bool usuarioTieneUnSoloRol(string nombreUsuario)
        {
            SqlCommand consulta = consultaCrear("SELECT COUNT(Rol_Nombre) FROM RIP.Roles r INNER JOIN RIP.Usuarios_Roles ur ON r.Rol_ID = ur.UsuarioRol_RolID JOIN RIP.Usuarios u ON ur.UsuarioRol_UsuarioID = u.Usuario_ID WHERE u.Usuario_Nombre = @nombreUsuario");
            consulta.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            string valor = consultaObtenerValor(consulta);
            return consultaValorEsIgualA(valor, 1);
        }

        public static bool usuarioTieneVariosRoles(string nombreUsuario)
        {
            return !usuarioTieneUnSoloRol(nombreUsuario);
        }

        public static List<string> usuarioObtenerRoles(string nombreUsuario)
        {
            SqlCommand consulta = consultaCrear("SELECT r.Rol_Nombre FROM RIP.Roles r JOIN RIP.Usuarios_Roles ur ON r.Rol_ID = ur.UsuarioRol_RolID JOIN RIP.Usuarios u ON ur.UsuarioRol_UsuarioID = u.Usuario_ID WHERE u.Usuario_Nombre = @nombreUsuario");
            consulta.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            return consultaObtenerLista(consulta);
        }

        public static List<string> usuarioObtenerRolesHabilitadosLista(string nombreUsuario)
        {
            SqlCommand consulta = consultaCrear("SELECT r.Rol_Nombre FROM RIP.Roles r JOIN RIP.Usuarios_Roles ur ON r.Rol_ID = ur.UsuarioRol_RolID JOIN RIP.Usuarios u ON ur.UsuarioRol_UsuarioID = u.Usuario_ID WHERE u.Usuario_Nombre = @nombreUsuario AND r.Rol_Estado = 1");
            consulta.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            return consultaObtenerLista(consulta);
        }

        public static DataTable usuarioObtenerTodos()
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_Nombre, Persona_Nombre, Persona_Apellido, Persona_TipoDocumentoID, Persona_NumeroDocumento, Persona_FechaNacimiento, Persona_Telefono, Persona_Email, Ciudad_Nombre, Calle_Nombre, Domicilio_NumeroCalle FROM RIP.Usuarios JOIN RIP.Personas ON Usuario_PersonaID = Persona_ID JOIN RIP.Domicilios ON Persona_DomicilioID = Domicilio_ID JOIN RIP.Calles ON Domicilio_CalleID = Calle_ID JOIN RIP.Ciudades ON Domicilio_CiudadID = Ciudad_ID");
            return consultaObtenerTabla(consulta);
        }

        public static void usuarioModificarContrasenia(string nombreUsuario, string nuevaContrasenia)
        {
            byte[] contraseniaEncriptada = loginEncriptarContraseña(nuevaContrasenia);
            SqlCommand consulta = consultaCrear("UPDATE RIP.Usuarios SET Usuario_Contrasenia = @nuevaContrasenia WHERE Usuario_Nombre = @nombreUsuario");
            consulta.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            consulta.Parameters.AddWithValue("@nuevaContrasenia", contraseniaEncriptada);
            consultaEjecutar(consulta);
        }

        public static void usuarioActualizarDatos(Usuario usuario)
        {
            usuario.roles = usuarioObtenerRoles(usuario.nombre);
            usuario.hoteles = usuarioObtenerHotelesLista(usuario.nombre);
            usuario.funcionalidades = rolObtenerFuncionalidades(usuario.rolLogueado);
        }
 
        //-------------------------------------- Metodos para Hoteles -------------------------------------

        public static List<string> hotelConfigurarNombres(SqlCommand consulta)
        {
            DataTable tabla = consultaObtenerTabla(consulta);
            List<string> hoteles = new List<string>();
            foreach (DataRow fila in tabla.Rows)
                hoteles.Add(fila[0].ToString().Trim() + " " + fila[1].ToString() + " " + fila[2].ToString());
            return hoteles;
        }

        public static List<string> hotelObtenerTodosLista()
        {
            SqlCommand consulta = consultaCrear("SELECT ci.Ciudad_Nombre, c.Calle_Nombre, d.Domicilio_NumeroCalle FROM RIP.Hoteles h JOIN RIP.Hoteles_Usuarios hu ON hu.HotelUsuario_HotelID = h.Hotel_ID JOIN RIP.Usuarios u ON u.Usuario_ID = hu.HotelUsuario_UsuarioID JOIN RIP.Domicilios d ON d.Domicilio_ID = h.Hotel_DomicilioID JOIN RIP.Calles c on c.Calle_ID = d.Domicilio_CalleID JOIN RIP.Ciudades ci on ci.Ciudad_ID = d.Domicilio_CiudadID");
            List<string> hoteles = hotelConfigurarNombres(consulta);
            return hoteles;
        }

        //-------------------------------------- Metodos para Personas -------------------------------------

        public static void personaAgregar(Persona persona)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Personas (Persona_Nombre, Persona_Apellido, Persona_TipoDocumentoID, Persona_NumeroDocumento, Persona_FechaNacimiento, Persona_NacionalidadID, Persona_DomicilioID, Persona_Telefono, Persona_Email) VALUES (@nombre, @apellido, @tipoDocumentoID, @numeroDocumento, @fechaNacimiento, @nacionalidadID, @domicilioID, @telefono, @email)");
            consulta.Parameters.AddWithValue("@nombre", persona.nombre);
            consulta.Parameters.AddWithValue("@apellido", persona.apellido);
            consulta.Parameters.AddWithValue("@tipoDocumentoID", tipoDocumentoObtenerID(persona.tipoDocumento));
            consulta.Parameters.AddWithValue("@numeroDocumento", persona.numeroDocumento);
            consulta.Parameters.AddWithValue("@fechaNacimiento", persona.fechaNacimiento);
            consulta.Parameters.AddWithValue("@nacionalidadID", nacionalidadObtenerID(persona.nacionalidad));
            consulta.Parameters.AddWithValue("@domicilioID", domicilioObtenerID(persona.domicilio));
            consulta.Parameters.AddWithValue("@telefono", persona.telefono);
            consulta.Parameters.AddWithValue("@email", persona.email);
            consultaEjecutar(consulta);
        }

        public static void personaModificar(Persona persona, string emailActual, string numeroDocumentoActual)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Personas SET Persona_Nombre = @nombre, Persona_Apellido = @apellido, Persona_TipoDocumentoID = @tipoDocumentoID, Persona_NumeroDocumento = @numeroDocumento, Persona_FechaNacimiento = @fechaNacimiento, Persona_NacionalidadID = @nacionalidadID, Persona_DomicilioID = @domicilioID, Persona_Telefono = @telefono, Persona_Email = @email WHERE Persona_Email = @emailActual AND Persona_NumeroDocumento = @numeroDocumentoActual");
            consulta.Parameters.AddWithValue("@emailActual", emailActual);
            consulta.Parameters.AddWithValue("@numeroDocumentoActual", numeroDocumentoActual);
            consulta.Parameters.AddWithValue("@nombre", persona.nombre);
            consulta.Parameters.AddWithValue("@apellido", persona.apellido);
            consulta.Parameters.AddWithValue("@tipoDocumentoID", tipoDocumentoObtenerID(persona.tipoDocumento));
            consulta.Parameters.AddWithValue("@numeroDocumento", persona.numeroDocumento);
            consulta.Parameters.AddWithValue("@fechaNacimiento", persona.fechaNacimiento);
            consulta.Parameters.AddWithValue("@nacionalidadID", nacionalidadObtenerID(persona.nacionalidad));
            consulta.Parameters.AddWithValue("@domicilioID", domicilioObtenerID(persona.domicilio));
            consulta.Parameters.AddWithValue("@telefono", persona.telefono);
            consulta.Parameters.AddWithValue("@email", persona.email);
            consultaEjecutar(consulta);
        }

        public static void personaEliminar(string email, string numeroDocumento)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Personas SET Persona_Estado = 0 WHERE Persona_Email = @email AND Persona_NumeroDocumento = @numeroDocumento");
            consulta.Parameters.AddWithValue("@email", email);
            consulta.Parameters.AddWithValue("@numeroDocumento", numeroDocumento);
            consultaEjecutar(consulta);
        }

        //-------------------------------------- Metodos para Domicilios -------------------------------------

        public static string domicilioBuscarID(Domicilio domicilio)
        {
            SqlCommand consulta = consultaCrear("SELECT Domicilio_ID FROM RIP.Domicilios WHERE Domicilio_PaisID = @paisID , Domicilio_CiudadID = @ciudadID, Domicilio_CalleID = @calleID, Domicilio_NumeroCalle = @numeroCalle, Domicilio_Piso = @piso, Domicilio_Departamento = @departamento");
            consulta.Parameters.AddWithValue("@paisID", paisObtenerID(domicilio.pais));
            consulta.Parameters.AddWithValue("@ciudadID", ciudadObtenerID(domicilio.ciudad));
            consulta.Parameters.AddWithValue("@calleID", calleObtenerID(domicilio.calle));
            consulta.Parameters.AddWithValue("@numeroCalle", domicilio.numeroCalle);
            consulta.Parameters.AddWithValue("@piso", domicilio.piso);
            consulta.Parameters.AddWithValue("@departamento", domicilio.departamento);
            string domicilioID = consultaObtenerValor(consulta);
            return domicilioID;
        }

        public static string domicilioAgregar(Domicilio domicilio)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO (Domicilio_PaisID, Domicilio_CiudadID, Domicilio_CalleID, Domicilio_NumeroCalle, Domicilio_Piso, Domicilio_Departamento) VALUES (@paisID, @ciudadID, @calleID, @numeroCalle, @piso, @departamento)");
            consulta.Parameters.AddWithValue("@paisID", paisObtenerID(domicilio.pais));
            consulta.Parameters.AddWithValue("@ciudadID", ciudadObtenerID(domicilio.ciudad));
            consulta.Parameters.AddWithValue("@calleID", calleObtenerID(domicilio.calle));
            consulta.Parameters.AddWithValue("@numeroCalle", domicilio.numeroCalle);
            consulta.Parameters.AddWithValue("@piso", domicilio.piso);
            consulta.Parameters.AddWithValue("@departamento", domicilio.departamento);
            consultaEjecutar(consulta);
            string domicilioID = domicilioBuscarID(domicilio);
            return domicilioID;
        }

        public static string domicilioObtenerID(Domicilio domicilio)
        {
            string domicilioID = domicilioBuscarID(domicilio);
            if (consultaValorNoExiste(domicilioID))
                domicilioAgregar(domicilio);
            return domicilioID;
        }

        //-------------------------------------- Metodos para Calles -------------------------------------

        public static string calleAgregar(string calle)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Calles (Calle_Nombre) VALUES (@calle)");
            consulta.Parameters.AddWithValue("@calle", calle);
            consultaEjecutar(consulta);
            string calleID = calleBuscarID(calle);
            return calleID;
        }

        public static string calleBuscarID(string calle)
        {
            SqlCommand consulta = consultaCrear("SELECT Calle_ID FROM RIP.Calles WHERE Calle_Nombre = @calle");
            consulta.Parameters.AddWithValue("@calle", calle);
            string calleID = consultaObtenerValor(consulta);
            return calleID;
        }

        public static string calleObtenerID(string calle)
        {
            string calleID = calleBuscarID(calle);
            if (consultaValorNoExiste(calleID))
                ciudadAgregar(calle);
            return calleID;
        }

        //-------------------------------------- Metodos para Ciudades -------------------------------------

        public static string ciudadAgregar(string ciudad)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Ciudades (Ciudad_Nombre) VALUES (@ciudad)");
            consulta.Parameters.AddWithValue("@ciudad", ciudad);
            consultaEjecutar(consulta);
            string ciudadID = ciudadBuscarID(ciudad);
            return ciudadID;
        }

        public static string ciudadBuscarID(string ciudad)
        {
            SqlCommand consulta = consultaCrear("SELECT Ciudad_ID FROM RIP.Ciudades WHERE Ciudad_Nombre = @ciudad");
            consulta.Parameters.AddWithValue("@ciudad", ciudad);
            string ciudadID = consultaObtenerValor(consulta);
            return ciudadID;
        }

        public static string ciudadObtenerID(string ciudad)
        {
            string ciudadID = ciudadBuscarID(ciudad);
            if (consultaValorNoExiste(ciudadID))
                ciudadID = ciudadAgregar(ciudad);
            return ciudadID;
        }

        //-------------------------------------- Metodos para Paises -------------------------------------

        public static string paisAgregar(string pais)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Paises (Pais_Nombre) VALUES (@pais)");
            consulta.Parameters.AddWithValue("@pais", pais);
            consultaEjecutar(consulta);
            string paisID = paisBuscarID(pais);
            return paisID;
        }

        public static string paisBuscarID(string pais)
        {
            SqlCommand consulta = consultaCrear("SELECT Pais_ID FROM RIP.Paises WHERE Pais_Nombre = @pais");
            consulta.Parameters.AddWithValue("@pais", pais);
            string paisID = consultaObtenerValor(consulta);
            return paisID;
        }

        public static string paisObtenerID(string pais)
        {
            string paisID = paisBuscarID(pais);
            if (consultaValorNoExiste(paisID))           
                paisID = paisAgregar(pais);
            return paisID;
        }

        //-------------------------------------- Metodos para Nacionalidades -------------------------------------

        public static string nacionalidadAgregar(string nacionalidad) 
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Nacionalidades (Nacionalidad_Descripcion) VALUES (@nacionalidad)");
            consulta.Parameters.AddWithValue("@nacionalidad", nacionalidad);
            consultaEjecutar(consulta);
            string nacionalidadID = nacionalidadBuscarID(nacionalidad);
            return nacionalidadID;
        }

        public static string nacionalidadBuscarID(string nacionalidad)
        {
            SqlCommand consulta = consultaCrear("SELECT Nacionalidad_ID FROM RIP.Nacionalidades WHERE Nacionalidad_Descripcion = @nacionalidad");
            consulta.Parameters.AddWithValue("@nacionalidad", nacionalidad);
            string nacionalidadID = consultaObtenerValor(consulta);
            return nacionalidadID;
        }

        public static string nacionalidadObtenerID(string nacionalidad)
        {
            string nacionalidadID = nacionalidadBuscarID(nacionalidad);
            if (consultaValorNoExiste(nacionalidadID))
                nacionalidadID = nacionalidadAgregar(nacionalidad);
            return nacionalidadID;
        }

        //-------------------------------------- Metodos para Tipos Documentos -------------------------------------

        public static string tipoDocumentoAgregar(string tipoDocumento)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.TiposDocumentos (TipoDocumento_Descripcion) VALUES (@tipoDocumento)");
            consulta.Parameters.AddWithValue("@tipoDocumento", tipoDocumento);
            consultaEjecutar(consulta);
            string tipoDocumentoID = tipoDocumentoBuscarID(tipoDocumento);
            return tipoDocumentoID;
        }

        public static string tipoDocumentoBuscarID(string tipoDocumento)
        {
            SqlCommand consulta = consultaCrear("SELECT TipoDocumento_ID FROM RIP.TiposDocumentos WHERE TipoDocumento_Descripcion = @tipoDocumento");
            consulta.Parameters.AddWithValue("@tipoDocumento", tipoDocumento);
            string tipoDocumentoID = consultaObtenerValor(consulta); 
            return tipoDocumentoID;
        }

        public static string tipoDocumentoObtenerID(string tipoDocumento)
        {
            string tipoDocumentoID = tipoDocumentoBuscarID(tipoDocumento);
            if(consultaValorNoExiste(tipoDocumentoID))
                tipoDocumentoID = tipoDocumentoAgregar(tipoDocumento);
            return tipoDocumentoID;
        }

        public static List<string> tipoDocumentoObtenerTodos()
        {
            SqlCommand consulta = consultaCrear("SELECT TipoDocumento_Descripcion FROM RIP.TiposDocumentos");
            return consultaObtenerLista(consulta);
        }

    }
}