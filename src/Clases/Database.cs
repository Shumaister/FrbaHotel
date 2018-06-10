﻿using System;
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
using FrbaHotel.Login;


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

        /*PARA HACER CONSULTAS UTILIZAR ESTO
         * 
         * SIEMPRE HAY QUE USARLAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
         * 
         * 
         * Ejemplo: Quiero buscar el ID de un rol, hacer esto
         * 
         * SqlCommand consulta = consultaCrear("SELECT Rol_Nombre FROM RIP.Roles WHERE Rol_Nombre = @nombreRol);
         * consulta.Parameters.AddWithValue("@nombreRol");
         * 
         * LO DE ARRIBA LO VAN A TENER QUE HACERLO SIEMPRE SI VAN A NECESITAR UTILIZAR VARIABLES EN LA QUERY
         * ANTES YO CONTANTENABA LAS VARIABLES EN MEDIO DE LAS CONSULTAS ASI NOMAS PERO A LOS GORDOS DE STACKOVERFLOW NO LES GUSTA 
         * Y DICEN QUE ES INSEGURO ASI QUE YO LES HAGO CASO, SOLO POR ESA RAZON EXISTE ESTE METODO
         * 
         * List<string> nombresDeRoles = consultaObtenerLista(consulta);
         * 
         * La gracia de este metodo es poder pasarle las variables de forma "segura" y no estar concatenando string en medio de la query
         * 
         * 
         */
        public static SqlCommand consultaCrear(string consulta)
        {
            return new SqlCommand(consulta, conexionObtener());
        }

        //Para cuando necesiten hacer inserts, updates o deletes, le pasan previamente la consulta
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

        public static void consultaAgregarParametro(SqlCommand consulta, string parametro ,object objeto)
        {
            consulta.Parameters.AddWithValue(parametro, objeto);
        }

        //NO LA VAN A USAR NUNCA 
        public static void consultaInformarError(Exception excepcion)
        {
            MessageBox.Show("ERROR EN LA BASE DE DATOS:\n" + excepcion.ToString());
        }

        //LA USAN IMPLICITAMENTE NUNCA LA VAN A LLAMAR EXPLICITAMENTE
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

        /* ES PARA CUANDO SU VENTANA TIENE TABLAS O 'DATAGRIDVIEW' MEJOR DICHO Y NECESITAN
         * LLENARLO CON ALGO BUENO LE MANDA LA CONSULTA COMO PARAMETRO
         * PREVIAMENTE DEBEN HABER USADO EL 'ConsultaCrear'
         * LO VAN A USAR SIEMPRE PARA LLENAR UNA TABLA CON DATOS
         */
        public static DataTable consultaObtenerTabla(SqlCommand consulta)
        {
            DataSet dataSet = consultaObtenerDatos(consulta);
            DataTable tabla = dataSet.Tables[0];
            return tabla;
        }

        //USAR CUANDO NECESITEN OBTENER UNA COLUMNA CON TODOS LOS DATOS
        //LO VAN A USAR PAR A LLENAR COMBO BOX CASI SIEMPRE

        public static List<string> consultaObtenerLista(SqlCommand consulta)
        {
            DataTable tabla = consultaObtenerTabla(consulta);
            List<string> columna = new List<string>();
            if (tabla.Rows.Count > 0)
                foreach (DataRow fila in tabla.Rows)
                    columna.Add(fila[0].ToString());
            return columna;
        }

        //USAR ESTO CUANDO NECESITEN OBTENER SOLO UN CAMPO DE UNA SOLA FILA
        /*
         * EJEMPLO QUIERO EL ID DEL ROL CON UN X NOMBRE
         * 
         * SqlCommand consulta = consultaCrear("SELECT Rol_ID FROM RIP.Roles WHERE Rol_Nombre = @nombre ");
         * consulta.Parameters.AddWitValue("@nombre", unNombre);
         * string idDelRol = consultaObtenerValor(consulta);
         * SI EL NOMBRE NO EXISTIERA DEVUELVE UNA CADENA VACIA
         * 
         */
        public static string consultaObtenerValor(SqlCommand consulta)
        {
            List<string> columna = consultaObtenerLista(consulta);
            if(columna.Count > 0)
                return columna[0];
            else
                return "";
        }

         /*
         * EJEMPLO QUIERO LA FILA DONDE DEL ROL CON X NOMBRE
         * 
         * SqlCommand consulta = consultaCrear("SELECT Rol_ID FROM RIP.Roles WHERE Rol_Nombre = @nombre ");
         * consulta.Parameters.AddWitValue("@nombre", unNombre);
         * DataRow miFila = consultaObtenerFila(consulta);
         * DE ESA FILA SACAN LOS DATOS QUE NECESITE HACIENDO miFila["NombreDelCampoQueNecesites"];
         * SI EL NOMBRE NO EXISTE, LA FILA NO EXISTE POR LO TANTO DEVUELVE NULL
         * 
         */

        public static DataRow consultaObtenerFila(SqlCommand consulta)
        {
            DataTable tabla = consultaObtenerTabla(consulta);
            if (tabla.Rows.Count > 0)
                return tabla.Rows[0];
            else
                return null;
        }

        //FUNCIONES PARA SER MAS EXPRESIVO COMO ME ENSEÑO FRANQUITO

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
            int intentosFallidos = (int)fila["Usuario_IntentosFallidos"];
            if (intentosFallidos >= 3)
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

        //-------------------------------------- Metodos para Sesion -------------------------------------

        public static void sesionActualizarDatos(Sesion sesion)
        {
            sesion.roles = usuarioObtenerRoles(sesion.usuario);
            sesion.hoteles = usuarioObtenerHotelesLista(sesion.usuario);
            sesion.funcionalidades = rolObtenerFuncionalidades(sesion.rol);
        }

        public static Sesion sesionCrear(string nombreUsuario, string contrasenia)
        {
            Usuario usuario = new Usuario(nombreUsuario, contrasenia, null, "");
            List<string> roles = usuarioObtenerRoles(usuario);
            List<string> hoteles = usuarioObtenerHotelesLista(usuario);
            Sesion sesion = new Sesion(usuario, roles, hoteles);
            return sesion;
        }

        public static void sesionModificarContrasenia(Sesion sesion)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Usuarios SET Usuario_Contrasenia = @Contrasenia WHERE Usuario_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", sesion.usuario.nombre);
            consulta.Parameters.AddWithValue("@Contrasenia", loginEncriptarContraseña(sesion.usuario.contrasenia));
            consultaEjecutar(consulta);
        }


        //-------------------------------------- Metodos para Funcionalidades -------------------------------------

        public static string funcionalidadObtenerID(string funcionalidad)
        {
            SqlCommand consulta = consultaCrear("SELECT Funcionalidad_ID FROM RIP.Funcionalidades WHERE Funcionalidad_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", funcionalidad);
            return consultaObtenerValor(consulta);
        }
        
        public static List<string> funcionalidadObtenerListaRegistros()
        {
            SqlCommand consulta = consultaCrear("SELECT Funcionalidad_Nombre FROM RIP.Funcionalidades");
            return consultaObtenerLista(consulta);
        }
        
        //-------------------------------------- Metodos para Roles -------------------------------------

        public static void rolAgregar(Rol rol)
        {
            if (rolYaExiste(rol))
                VentanaBase.ventanaInformarError("ERROR: Ya existe un rol registrado con ese nombre");
            else
            {
                SqlCommand consulta = consultaCrear("INSERT INTO RIP.Roles (Rol_Nombre) VALUES (@Nombre)");
                consulta.Parameters.AddWithValue("@Nombre", rol.nombre);
                consultaEjecutar(consulta);
            }
        }

        public static void rolModificar(Rol rol, Rol nuevoRol)
        {
            if (rolYaExiste(nuevoRol) && rolSonDistintos(rol, nuevoRol))
                VentanaBase.ventanaInformarError("ERROR: Ya existe un rol registrado con ese nombre");
            else
            {
                rolEliminarFuncionalidades(rol);
                SqlCommand consulta = consultaCrear("UPDATE RIP.Roles SET Rol_Nombre = @NuevoNombre, Rol_Estado = @NuevoEstado WHERE Rol_Nombre = @Nombre");
                consulta.Parameters.AddWithValue("@Nombre", rol.nombre);
                consulta.Parameters.AddWithValue("@NuevoNombre", nuevoRol.nombre);
                consulta.Parameters.AddWithValue("@NuevoEstado", nuevoRol.estado);
                consultaEjecutar(consulta);
            }
        }

        public static bool rolSonDistintos(Rol unRol, Rol otroRol)
        {
            return rolObtenerID(unRol) != rolObtenerID(otroRol);
        }

        public static void rolEliminar(Rol rol)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Roles SET Rol_Estado = 0 WHERE Rol_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", rol.nombre);
            consultaEjecutar(consulta);
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

        public static void rolEliminarFuncionalidades(Rol rol)
        {
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Roles_Funcionalidades WHERE RolFuncionalidad_RolID = @RolID");
            consulta.Parameters.AddWithValue("@RolID", rolObtenerID(rol));
            consultaEjecutar(consulta);
        }

        public static bool rolYaExiste(Rol rol)
        {
            SqlCommand consulta = consultaCrear("SELECT COUNT(*) FROM RIP.Roles WHERE Rol_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", rol.nombre);            
            return consultaValorEsMayorA(consultaObtenerValor(consulta), 0);
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

        //-------------------------------------- Metodos para Usuarios -------------------------------------

        public static void usuarioAgregar(Usuario usuario)
        {
            if (usuarioYaExiste(usuario))
                VentanaBase.ventanaInformarError("ERROR: Ya existe un usuario registrado con ese nombre");
            else
            {
                SqlCommand consulta = consultaCrear("INSERT INTO RIP.Usuarios (Usuario_Nombre, Usuario_Contrasenia, Usuario_PersonaID) VALUES (@Nombre, @Contrasenia, @PersonaID)");
                consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
                consulta.Parameters.AddWithValue("@Contrasenia", loginEncriptarContraseña(usuario.contrasenia));
                consulta.Parameters.AddWithValue("@PersonaID", personaObtenerID(usuario.persona));
                consultaEjecutar(consulta);
                usuarioAgregarHoteles(usuario);
                usuarioAgregarRoles(usuario);
            }
        }

        public static void usuarioModificar(Usuario usuario, Usuario nuevoUsuario)
        {
            if (usuarioYaExiste(usuario) && usuarioSonDistintos(usuario, nuevoUsuario))
                VentanaBase.ventanaInformarError("ERROR: Ya existe un usuario registrado con ese nombre");
            else
            {
                SqlCommand consulta = consultaCrear("UPDATE RIP.Usuarios SET Usuario_Nombre = @NuevoNombre, Usuario_Contrasenia = @NuevaContrasenia, Usuario_Estado = @NuevoEstado WHERE Usuario_Nombre = @Nombre");
                consulta.Parameters.AddWithValue("@NuevoNombre", nuevoUsuario.nombre);
                consulta.Parameters.AddWithValue("@NuevaContrasenia", loginEncriptarContraseña(nuevoUsuario.contrasenia));
                consulta.Parameters.AddWithValue("@NuevoEstado", nuevoUsuario.estado);
                consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
                consultaEjecutar(consulta);
                usuarioEliminarHoteles(usuario);
                usuarioEliminarRoles(usuario);
                usuarioAgregarHoteles(nuevoUsuario);
                usuarioAgregarRoles(nuevoUsuario);
            }
        }

        public static void usuarioEliminar(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Usuarios SET Usuario_Estado = 0 WHERE Usuario_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            consultaEjecutar(consulta);
        }

        public static string usuarioObtenerID(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_ID FROM RIP.Usuarios WHERE Usuario_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            return consultaObtenerValor(consulta);
        }

        public static bool usuarioSonDistintos(Usuario unUsuario, Usuario otroUsuario)
        {
            return usuarioObtenerID(unUsuario) != usuarioObtenerID(otroUsuario);
        }

        public static List<string> usuarioObtenerHotelesLista(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT Ciudad_Nombre, Calle_Nombre, Domicilio_NumeroCalle FROM RIP.Hoteles JOIN RIP.Hoteles_Usuarios ON HotelUsuario_HotelID = Hotel_ID JOIN RIP.Usuarios ON Usuario_ID = HotelUsuario_UsuarioID JOIN RIP.Domicilios ON Domicilio_ID = Hotel_DomicilioID JOIN RIP.Calles ON Calle_ID = Domicilio_CalleID JOIN RIP.Ciudades ON Ciudad_ID = Domicilio_CiudadID WHERE Usuario_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            return hotelConfigurarNombres(consulta);
        }
       
        public static List<string> usuarioObtenerRoles(Usuario usuario)
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

        public static DataTable usuarioObtenerTodos()
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_Nombre, Persona_Nombre, Persona_Apellido, Persona_TipoDocumentoID, Persona_NumeroDocumento, Persona_FechaNacimiento, Persona_Telefono, Persona_Email, Ciudad_Nombre, Calle_Nombre, Domicilio_NumeroCalle FROM RIP.Usuarios JOIN RIP.Personas ON Usuario_PersonaID = Persona_ID JOIN RIP.Domicilios ON Persona_DomicilioID = Domicilio_ID JOIN RIP.Calles ON Domicilio_CalleID = Calle_ID JOIN RIP.Ciudades ON Domicilio_CiudadID = Ciudad_ID");
            return consultaObtenerTabla(consulta);
        }

        public static bool usuarioYaExiste(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_Nombre FROM RIP.Usuarios WHERE Usuario_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", usuario.nombre);
            return consultaValorExiste(consultaObtenerValor(consulta));
        }

        public static void usuarioAgregarRol(Usuario usuario, Rol rol)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Usuarios_Roles (UsuarioRol_UsuarioID, UsuarioRol_RolID) VALUES (@usuarioID, @rolID)");
            consulta.Parameters.AddWithValue("@usuarioID", usuarioObtenerID(usuario));
            consulta.Parameters.AddWithValue("@rolID", rolObtenerID(rol));
            consultaEjecutar(consulta);
        }

        public static void usuarioAgregarHotel(Usuario usuario, Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Hoteles_Usuarios (HotelUsuario_HotelID, UsuarioRol_RolID) VALUES (@usuarioID, @rolID)");
            consulta.Parameters.AddWithValue("@HotelID", hotelObtenerID(hotel));
            consulta.Parameters.AddWithValue("@UsuarioID", usuarioObtenerID(usuario));  
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
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Hoteles_Usuarios WHERE HotelUsuario_UsuarioID = @UsuarioID");
            consulta.Parameters.AddWithValue("@UsuarioID", usuarioObtenerID(usuario));
            consultaEjecutar(consulta);
        }

        public static void usuarioEliminarRoles(Usuario usuario)
        {
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Usuarios_Roles WHERE UsuarioRol_UsuarioID = @UsuarioID");
            consulta.Parameters.AddWithValue("@UsuarioID", usuarioObtenerID(usuario));
            consultaEjecutar(consulta);
        }
        //-------------------------------------- Metodos para Hoteles -------------------------------------

        public static void hotelAgregar(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Hoteles (Hotel_Nombre, Hotel_CantidadEstrellas, Hotel_DomicilioID, Hotel_Telefono, Hotel_Email, Hotel_FechaCreacion) VALUES (@Nombre, @CantidadEstrellas, @DomicilioID, @Telefono, @Email, @FechaCreacion)");
            consulta.Parameters.AddWithValue("@Nombre", hotel.nombre);
            consulta.Parameters.AddWithValue("@Nombre", hotel.cantidadEstrellas);
            consulta.Parameters.AddWithValue("@Nombre", hotel.domicilio);
            consulta.Parameters.AddWithValue("@Nombre", hotel.telefono);
            consulta.Parameters.AddWithValue("@Nombre", hotel.email);
            consulta.Parameters.AddWithValue("@Nombre", hotel.fechaCreacion);
        }

        public static void hotelModificar(Hotel hotel, Hotel nuevoHotel)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Hoteles SET Hotel_Nombre = @NuevoNombre, Hotel_CantidadEstrellas = @NuevaCantidadEstrellas, Hotel_DomicilioID = @NuevoDomicilioID, Hotel_Telefono = @NuevoTelefono, Hotel_Email = @NuevoEmail, Hotel_FechaCreacion = @NuevaFechaCreacion, Hotel_Estado = @NuevoEstado WHERE Hotel_ID = @HotelID");
            consulta.Parameters.AddWithValue("@HotelID", hotelObtenerID(hotel));
            consulta.Parameters.AddWithValue("@NuevoNombre", nuevoHotel.nombre);
            consulta.Parameters.AddWithValue("@NuevaCantidadEstrellas", nuevoHotel.cantidadEstrellas);
            consulta.Parameters.AddWithValue("@NuevoDomicilio", nuevoHotel.domicilio);
            consulta.Parameters.AddWithValue("@NuevoTelefono", nuevoHotel.telefono);
            consulta.Parameters.AddWithValue("@NuevoEmail", nuevoHotel.email);
            consulta.Parameters.AddWithValue("@NuevaFechaCreacion", nuevoHotel.fechaCreacion);
            consulta.Parameters.AddWithValue("@NuevoEstado", nuevoHotel.estado);

        }

        public static void hotelEliminar(Hotel hotel)
        {/*
            if (hotelNoTieneReservasEnElPeriodo())
            {
            }
            else
                VentanaBase.ventanaInformarError("ERROR: El hotel no puede darse de baja ya que tiene reservas dentro del periodo elegido");
        
          */
        }

        public static List<string> hotelConfigurarNombres(SqlCommand consulta)
        {
            DataTable tabla = consultaObtenerTabla(consulta);
            List<string> hoteles = new List<string>();
            foreach (DataRow fila in tabla.Rows)
                hoteles.Add(fila[0].ToString() + " | " + fila[1].ToString() + " | " + fila[2].ToString());
            return hoteles;
        }

        public static List<string> hotelObtenerTodosLista()
        {
            SqlCommand consulta = consultaCrear("SELECT ci.Ciudad_Nombre, c.Calle_Nombre, d.Domicilio_NumeroCalle FROM RIP.Hoteles h JOIN RIP.Hoteles_Usuarios hu ON hu.HotelUsuario_HotelID = h.Hotel_ID JOIN RIP.Usuarios u ON u.Usuario_ID = hu.HotelUsuario_UsuarioID JOIN RIP.Domicilios d ON d.Domicilio_ID = h.Hotel_DomicilioID JOIN RIP.Calles c on c.Calle_ID = d.Domicilio_CalleID JOIN RIP.Ciudades ci on ci.Ciudad_ID = d.Domicilio_CiudadID");
            List<string> hoteles = hotelConfigurarNombres(consulta);
            return hoteles;
        }

        public static string hotelObtenerID(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("SELECT Hotel_ID FROM RIP.Hoteles WHERE Hotel_DomicilioID = @domicilioID");
            consulta.Parameters.AddWithValue("@domicilioID", domicilioObtenerID(hotel.domicilio));
            return consultaObtenerValor(consulta);
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

        public static bool hotelYaExiste(Hotel hotel)
        {
            return consultaValorExiste(hotelObtenerID(hotel));
        }

        public static void hotelAgregarRegimen(Hotel hotel, Regimen regimen)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Hoteles_Regimenes (HotelRegimen_HotelID, HotelRegimen_RegimenID) VALUES (@hotelID, @regimenID)");     
        }

       
        public static void hotelEliminarRegimenes(Hotel hotel)
        {
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Hoteles_Regimenes WHERE HotelRegimen_HotelID = @HotelID");
            consulta.Parameters.AddWithValue("@HotelID", hotelObtenerID(hotel));
            consultaEjecutar(consulta);
        }

        public static void hotelAgregarRegimenes(Hotel hotel, List<Regimen> regimenes)
        {
            foreach(Regimen regimen in regimenes)
                hotelAgregarRegimen(hotel, regimen);
        }


        public static void hotelCerradoAgregar(HotelCerrado hotelCerrado)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.HotelesCerrados (HotelCerrado_HotelID, HotelCerrado_FechaInicio, HotelCerrado_FechaFin, HotelCerrado_Motivo) VALUES (@HotelID, @FechaInicio, @FechaFin, @Motivo)");
            consulta.Parameters.AddWithValue("@HotelID", hotelObtenerID(hotelCerrado.hotel));
            consulta.Parameters.AddWithValue("@FechaInicio", hotelCerrado.fechaInicio);
            consulta.Parameters.AddWithValue("@FechaFin", hotelCerrado.fechaFin);
            consulta.Parameters.AddWithValue("@Motivo", hotelCerrado.motivo);
        }

        //-------------------------------------- Metodos para Habitaciones -------------------------------------

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

        //-------------------------------------- Metodos para Tipo Habitaciones -------------------------------------

        public static string tipoHabitacionObtenerID(string tipoHabitacion)
        {
            SqlCommand consulta = consultaCrear("SELECT TipoHabitacion_ID FROM RIP.TiposHabitaciones WHERE TipoHabitacion_Descripcion = @Descripcion");
            consulta.Parameters.AddWithValue("@Descripcion", tipoHabitacion);
            return consultaObtenerValor(consulta);
        }


        //-------------------------------------- Metodos para Personas -------------------------------------

        public static void personaAgregar(Persona persona)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Personas (Persona_Nombre, Persona_Apellido, Persona_TipoDocumentoID, Persona_NumeroDocumento, Persona_FechaNacimiento, Persona_NacionalidadID, Persona_DomicilioID, Persona_Telefono, Persona_Email) VALUES (@nombre, @apellido, @tipoDocumentoID, @numeroDocumento, @fechaNacimiento, @nacionalidadID, @domicilioID, @telefono, @email)");
            consulta.Parameters.AddWithValue("@nombre", persona.nombre);
            consulta.Parameters.AddWithValue("@apellido", persona.apellido);
            consulta.Parameters.AddWithValue("@tipoDocumentoID", tipoDocumentoObtenerID(persona.tipoDocumento));
            consulta.Parameters.AddWithValue("@numeroDocumento", persona.numeroDocumento);
            consulta.Parameters.AddWithValue("@fechaNacimiento", DateTime.Parse(persona.fechaNacimiento));
            consulta.Parameters.AddWithValue("@nacionalidadID", nacionalidadObtenerID(persona.nacionalidad));
            consulta.Parameters.AddWithValue("@domicilioID", domicilioObtenerID(persona.domicilio));
            consulta.Parameters.AddWithValue("@telefono", persona.telefono);
            consulta.Parameters.AddWithValue("@email", persona.email);
            consultaEjecutar(consulta);
        }

        public static void personaModificar(Persona persona, string emailActual)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Personas SET Persona_Nombre = @nombre, Persona_Apellido = @apellido, Persona_TipoDocumentoID = @tipoDocumentoID, Persona_NumeroDocumento = @numeroDocumento, Persona_FechaNacimiento = @fechaNacimiento, Persona_NacionalidadID = @nacionalidadID, Persona_DomicilioID = @domicilioID, Persona_Telefono = @telefono, Persona_Email = @email WHERE Persona_Email = @emailActual");
            consulta.Parameters.AddWithValue("@emailActual", emailActual);
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

        public static string personaObtenerID(Persona persona)
        {
            SqlCommand consulta = consultaCrear("SELECT Persona_ID FROM RIP.Personas WHERE Persona_Nombre = @nombre AND Persona_Apellido = @apellido AND Persona_TipoDocumentoID = @tipoDocumentoID AND Persona_NumeroDocumento = @numeroDocumento AND Persona_FechaNacimiento = @fechaNacimiento AND Persona_NacionalidadID = @nacionalidadID AND Persona_DomicilioID = @domicilioID AND Persona_Telefono = @telefono AND Persona_Email = @email");
            consulta.Parameters.AddWithValue("@nombre", persona.nombre);
            consulta.Parameters.AddWithValue("@apellido", persona.apellido);
            consulta.Parameters.AddWithValue("@tipoDocumentoID", tipoDocumentoObtenerID(persona.tipoDocumento));
            consulta.Parameters.AddWithValue("@numeroDocumento", persona.numeroDocumento);
            consulta.Parameters.AddWithValue("@fechaNacimiento", DateTime.Parse(persona.fechaNacimiento));
            consulta.Parameters.AddWithValue("@nacionalidadID", nacionalidadObtenerID(persona.nacionalidad));
            consulta.Parameters.AddWithValue("@domicilioID", domicilioObtenerID(persona.domicilio));
            consulta.Parameters.AddWithValue("@telefono", persona.telefono);
            consulta.Parameters.AddWithValue("@email", persona.email);
            return consultaObtenerValor(consulta);
        }

        public static bool personaAlguienTieneEseEmail(string email)
        {
            SqlCommand consulta = consultaCrear("SELECT Persona_Email FROM RIP.Personas WHERE Persona_Email = @email");
            consulta.Parameters.AddWithValue("@email", email);
            return consultaValorExiste(consultaObtenerValor(consulta));
        }

        public static bool personaAlguienTieneEseDocumento(string tipoDocumento, string numeroDocumento)
        {
            SqlCommand consulta = consultaCrear("SELECT Persona_Email FROM RIP.Personas WHERE Persona_TipoDocumentoID = @tipoDocumentoID AND Persona_NumeroDocumento = @numeroDocumento");
            consulta.Parameters.AddWithValue("@tipoDocumentoID", tipoDocumentoObtenerID(tipoDocumento));
            consulta.Parameters.AddWithValue("@numeroDocumento", numeroDocumento);
            return consultaValorExiste(consultaObtenerValor(consulta));
        }

        //-------------------------------------- Metodos para Domicilios -------------------------------------

        public static void domicilioAgregar(Domicilio domicilio)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Domicilios (Domicilio_PaisID, Domicilio_CiudadID, Domicilio_CalleID, Domicilio_NumeroCalle, Domicilio_Piso, Domicilio_Departamento) VALUES (@PaisID, @CiudadID, @CalleID, @NumeroCalle, @Piso, @Departamento)");
            consulta.Parameters.AddWithValue("@PaisID", paisObtenerID(domicilio.pais));
            consulta.Parameters.AddWithValue("@CiudadID", ciudadObtenerID(domicilio.ciudad));
            consulta.Parameters.AddWithValue("@CalleID", calleObtenerID(domicilio.calle));
            consulta.Parameters.AddWithValue("@NumeroCalle", domicilio.numeroCalle);
            consulta.Parameters.AddWithValue("@Piso", domicilio.piso);
            consulta.Parameters.AddWithValue("@Departamento", domicilio.departamento);
            consultaEjecutar(consulta);
        }

        public static void domicilioModificar(Domicilio domicilio, Domicilio domicilioModificado)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Domicilios SET Domicilio_PaisID = @PaisID, Domicilio_CiudadID = @CiudadID, Domicilio_CalleID = @CalleID, Domicilio_NumeroCalle = @NumeroCalle, Domicilio_Piso = @Piso, Domicilio_Departamento = @Departamento WHERE Domicilio_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", domicilioBuscarID(domicilio));
            consulta.Parameters.AddWithValue("@PaisID", paisObtenerID(domicilioModificado.pais));
            consulta.Parameters.AddWithValue("@CiudadID", ciudadObtenerID(domicilioModificado.ciudad));
            consulta.Parameters.AddWithValue("@CalleID", calleObtenerID(domicilioModificado.calle));
            consulta.Parameters.AddWithValue("@NumeroCalle", domicilioModificado.numeroCalle);
            consulta.Parameters.AddWithValue("@Piso", domicilioModificado.piso);
            consulta.Parameters.AddWithValue("@Departamento", domicilioModificado.departamento);
            consultaEjecutar(consulta);
        }
        
        public static string domicilioObtenerID(Domicilio domicilio)
        {
            if (domocilioNoExiste(domicilio))
                domicilioAgregar(domicilio);
            return domicilioBuscarID(domicilio);
        }

        public static bool domocilioNoExiste(Domicilio domicilio)
        {
            return consultaValorNoExiste(domicilioBuscarID(domicilio));
        }

        public static string domicilioBuscarID(Domicilio domicilio)
        {
            SqlCommand consulta = consultaCrear("SELECT Domicilio_ID FROM RIP.Domicilios WHERE Domicilio_PaisID = @PaisID AND Domicilio_CiudadID = @CiudadID AND Domicilio_CalleID = @CalleID AND Domicilio_NumeroCalle = @NumeroCalle AND Domicilio_Piso = @Piso AND Domicilio_Departamento = @Departamento");
            consulta.Parameters.AddWithValue("@PaisID", paisObtenerID(domicilio.pais));
            consulta.Parameters.AddWithValue("@CiudadID", ciudadObtenerID(domicilio.ciudad));
            consulta.Parameters.AddWithValue("@CalleID", calleObtenerID(domicilio.calle));
            consulta.Parameters.AddWithValue("@NumeroCalle", domicilio.numeroCalle);
            consulta.Parameters.AddWithValue("@Piso", domicilio.piso);
            consulta.Parameters.AddWithValue("@Departamento", domicilio.departamento);
            return consultaObtenerValor(consulta);
        }

        //-------------------------------------- Metodos para Calles -------------------------------------

        public static void calleAgregar(string calle)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Calles (Calle_Nombre) VALUES (@Nombre)");
            consulta.Parameters.AddWithValue("@Nombre", calle);
            consultaEjecutar(consulta);
        }

        public static void calleEliminar(string calle)
        {
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Calles WHERE Calle_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", calleBuscarID(calle));
            consultaEjecutar(consulta);
        }

        public static string calleObtenerID(string calle)
        {
            if (calleNoExiste(calle))
                calleAgregar(calle);
            return calleBuscarID(calle);
        }

        public static bool calleNoExiste(string calle)
        {
            return consultaValorNoExiste(calleBuscarID(calle)); 
        }

        public static string calleBuscarID(string calle)
        {
            SqlCommand consulta = consultaCrear("SELECT Calle_ID FROM RIP.Calles WHERE Calle_Nombre = @calle");
            consulta.Parameters.AddWithValue("@calle", calle);
            return consultaObtenerValor(consulta);
        }

        public static bool calleEstaEnAlgunDomicilio(string calle)
        {
            SqlCommand consulta = consultaCrear("SELECT COUNT(*) FROM RIP.Domicilios WHERE Domicilio_CalleID = @CalleID");
            consulta.Parameters.AddWithValue("@CalleID", calleBuscarID(calle));
            return consultaValorEsMayorA(consultaObtenerValor(consulta), 0);
        }

        //-------------------------------------- Metodos para Ciudades -------------------------------------

        public static void ciudadAgregar(string ciudad)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Ciudades (Ciudad_Nombre) VALUES (@Nombre)");
            consulta.Parameters.AddWithValue("@Nombre", ciudad);
            consultaEjecutar(consulta);
        }

        public static void ciudadEliminar(string ciudad)
        {
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Ciudades WHERE Ciudad_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", ciudadBuscarID(ciudad));
            consultaEjecutar(consulta);
        }

        public static string ciudadObtenerID(string ciudad)
        {
            if (ciudadNoExiste(ciudad))
                ciudadAgregar(ciudad);
            return ciudadBuscarID(ciudad);
        }

        public static bool ciudadNoExiste(string ciudad)
        {
            return consultaValorNoExiste(ciudadBuscarID(ciudad));
        }

        public static string ciudadBuscarID(string ciudad)
        {
            SqlCommand consulta = consultaCrear("SELECT Ciudad_ID FROM RIP.Ciudades WHERE Ciudad_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", ciudad);
            return consultaObtenerValor(consulta);
        }

        public static bool ciudadEstaEnAlgunDomicilio(string ciudad)
        {
            SqlCommand consulta = consultaCrear("SELECT COUNT(*) FROM RIP.Domicilios WHERE Domicilio_CiudadID = @CiudadID");
            consulta.Parameters.AddWithValue("@CiudadID", ciudadBuscarID(ciudad));
            return consultaValorEsMayorA(consultaObtenerValor(consulta), 0);
        }

        //-------------------------------------- Metodos para Paises -------------------------------------

        public static void paisAgregar(string pais)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Paises (Pais_Nombre) VALUES (@Nombre)");
            consulta.Parameters.AddWithValue("@Nombre", pais);
            consultaEjecutar(consulta);
        }

        public static void paisEliminar(string pais)
        {
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Paises WHERE Pais_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", paisBuscarID(pais));
            consultaEjecutar(consulta);
        }

        public static string paisObtenerID(string pais)
        {
            if (paisNoExiste(pais))
                paisAgregar(pais);
            return paisBuscarID(pais);
        }

        public static bool paisNoExiste(string pais)
        {
            return consultaValorNoExiste(paisObtenerID(pais));
        }

        public static string paisBuscarID(string pais)
        {
            SqlCommand consulta = consultaCrear("SELECT Pais_ID FROM RIP.Paises WHERE Pais_Nombre = @Nombre");
            consulta.Parameters.AddWithValue("@Nombre", pais);
            return consultaObtenerValor(consulta);
        }

        public static bool paisEstaEnAlgunDomicilio(string pais)
        {
            SqlCommand consulta = consultaCrear("SELECT COUNT(*) FROM RIP.Domicilios WHERE Domicilio_PaisID = @PaisID");
            consulta.Parameters.AddWithValue("@PaisID", paisBuscarID(pais));
            return consultaValorEsMayorA(consultaObtenerValor(consulta), 0);
        }

        //-------------------------------------- Metodos para Nacionalidades -------------------------------------

        public static void nacionalidadAgregar(string nacionalidad) 
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Nacionalidades (Nacionalidad_Descripcion) VALUES (@Descripcion)");
            consulta.Parameters.AddWithValue("@Descripcion", nacionalidad);
            consultaEjecutar(consulta);
        }

        public static void nacionalidadEliminar(string nacionalidad)
        {
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Personas WHERE Nacionalidad_ID = @ID");
            consulta.Parameters.AddWithValue("@ID", nacionalidadBuscarID(nacionalidad));
            consultaEjecutar(consulta);
        }

        public static string nacionalidadObtenerID(string nacionalidad)
        {
            if(nacionalidadNoExiste(nacionalidad))
                nacionalidadAgregar(nacionalidad);
            return nacionalidadBuscarID(nacionalidad);
        }

        public static bool nacionalidadNoExiste(string nacionalidad)
        {
            return consultaValorNoExiste(nacionalidadBuscarID(nacionalidad));
        }

        public static string nacionalidadBuscarID(string nacionalidad)
        {
            SqlCommand consulta = consultaCrear("SELECT Nacionalidad_ID FROM RIP.Nacionalidades WHERE Nacionalidad_Descripcion = @Descripcion");
            consulta.Parameters.AddWithValue("@Descripcion", nacionalidad);
            return consultaObtenerValor(consulta);
        }

        public static bool nacionalidadEstaEnAlgunaPersona(string nacionalidad)
        {
            SqlCommand consulta = consultaCrear("SELECT COUNT(*) FROM RIP.Personas WHERE Persona_Nacionalidad = @Nacionalidad");
            consulta.Parameters.AddWithValue("@Nacionalidad", nacionalidadBuscarID(nacionalidad));
            return consultaValorEsMayorA(consultaObtenerValor(consulta), 0);
        }

        //-------------------------------------- Metodos para Tipos Documentos -------------------------------------

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
    }
}