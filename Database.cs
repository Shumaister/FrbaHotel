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

        //-------------------------------------- Metodos generales -------------------------------------

        public static SqlConnection obtenerConexion()
        {
            return conexion;
        }

        public static void conectar()
        {
            conexion.Open();
        }

        public static void desconectar()
        {
            conexion.Close();
        }

        //-------------------------------------- Metodos para consultas -------------------------------------

        public static SqlCommand consultaCrear(string consulta)
        {
            return new SqlCommand(consulta, Database.obtenerConexion());
        }

        public static int consultaEjecutar(SqlCommand consulta)
        {
            Database.conectar();
            int estado = 0;
            try
            {
                estado = consulta.ExecuteNonQuery();
            }
            catch (Exception excepcion)
            {
                Database.consultaInformarError(excepcion);
            }
            Database.desconectar();
            return estado;
        }

        public static List<string> consultaObtenerValores(SqlCommand consulta)
        {
            Database.conectar();
            List<string> listaValores = new List<string>();
            try
            {
                SqlDataReader reader = consulta.ExecuteReader();
                while (reader.Read())
                    listaValores.Add(reader[0].ToString());
                reader.Close();
            }
            catch (Exception excepcion)
            {
                Database.consultaInformarError(excepcion);
            }
            Database.desconectar();
            return listaValores;
        }

        public static string consultaObtenerValor(SqlCommand consulta)
        {
            return Database.consultaObtenerValores(consulta)[0];
        }

        public static void consultaInformarError(Exception excepcion)
        {
            MessageBox.Show("ERROR EN LA BASE DE DATOS:\n" + excepcion.ToString());
        }

        //-------------------------------------- Metodos para Login -------------------------------------

        public static Byte[] Sha256_hash(String value)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                return hash.ComputeHash(enc.GetBytes(value));
            }
        }

        internal static LogueoDTO Autenticar(string user, string pas)
        {
            SqlConnection connection = obtenerConexion();

            SqlCommand logueo = new SqlCommand("SELECT Usuario_User, Usuario_Contrasena, Usuario_CantidadDeIntentos FROM RIP.Usuarios WHERE Usuario_User=@username");
            logueo.Parameters.AddWithValue("username", user);
            logueo.Connection = connection;
            connection.Open();
            SqlDataReader reader = logueo.ExecuteReader();

            String usuario = null;
            byte[] contrasenia = null;
            int intentosFallidos = 0;

            while (reader.Read())
            {
                usuario = reader["Usuario_User"].ToString();
                contrasenia = reader.GetSqlBytes(reader.GetOrdinal("Usuario_Contrasena")).Buffer;
                intentosFallidos = reader.GetInt32(reader.GetOrdinal("Usuario_CantidadDeIntentos"));
            }

            reader.Close();
            connection.Close();

            if (usuario == null)
                return new LogueoDTO(false, "Error al loguearse. Usuario incorrecto.");

            if (intentosFallidos >= 3)
                return new LogueoDTO(false, "El usuario se encuentra bloqueado. Contactese con un administrador.");

            if (!Sha256_hash(pas).SequenceEqual(contrasenia))
            {
                intentosFallidos++;
                ActualizarIntentosLogueo(user, intentosFallidos);

                if (intentosFallidos >= 3)
                    return new LogueoDTO(false, "El usuario se ha bloqueado por cantidad de intentos fallidos de contranenia.\nContactese con un administrador.");

                return new LogueoDTO(false, "Error al loguearse. Contrasenia incorrecta.");
            }
            else
            {
                ActualizarIntentosLogueo(user, 0);
                List<string> roles = Roles(usuario);
                return new LogueoDTO(true, "Exito!", usuario, roles);
            }
        }

        public static void ActualizarIntentosLogueo(string user, int cant)
        {
            SqlConnection connection = obtenerConexion();
            connection.Open();

            SqlCommand query = new SqlCommand("UPDATE RIP.Usuarios SET Usuario_CantidadDeIntentos = @cant WHERE Usuario_User = @user");
            query.Parameters.AddWithValue("user", user);
            query.Parameters.AddWithValue("cant", cant);
            query.Connection = connection;
            query.ExecuteNonQuery();

            connection.Close();
        }

        //-------------------------------------- Metodos para Funcionalidades -------------------------------------

        public static List<string> funcionalidadObtenerTodas()
        {
            SqlCommand consulta = consultaCrear("SELECT Funcionalidad_Funcionalidad FROM RIP.Funcionalidades");
            return Database.consultaObtenerValores(consulta);
        }
        
        public static string funcionalidadObtenerId(string nombreFuncionalidad)
        {
            SqlCommand consulta = consultaCrear("SELECT Funcionalidad_Id FROM RIP.Funcionalidades WHERE Funcionalidad_Funcionalidad = @nombreFuncionalidad");
            consulta.Parameters.AddWithValue("@nombreFuncionalidad", nombreFuncionalidad);
            return Database.consultaObtenerValor(consulta);
        }

        //-------------------------------------- Metodos para Roles -------------------------------------

        public static List<string> Roles(string user)
        {
            SqlCommand loginCommand = consultaCrear("SELECT r.Rol_Nombre FROM rip.Roles r INNER JOIN RIP.Usuario_Rol ur on r.Rol_ID = ur.Usuario_Rol_Rol_ID INNER JOIN RIP.Usuarios u on ur.Usuario_Rol_Usuario_ID = u.Usuario_ID where u.Usuario_User = @user and r.Rol_Estado = 1");
            loginCommand.Parameters.AddWithValue("user", user);
            return Database.consultaObtenerValores(loginCommand);
            /*
            List<String> listaRoles = new List<string>();
            List<String> listaEstados = new List<string>();
            SqlConnection connection = obtenerConexion();
            SqlCommand loginCommand = new SqlCommand("SELECT r.Rol_Nombre FROM rip.Roles r INNER JOIN RIP.Usuario_Rol ur on r.Rol_ID = ur.Usuario_Rol_Rol_ID INNER JOIN RIP.Usuarios u on ur.Usuario_Rol_Usuario_ID = u.Usuario_ID where u.Usuario_User = @user and r.Rol_Estado = 1");
            loginCommand.Parameters.AddWithValue("user", user);
            loginCommand.Connection = connection;
            connection.Open();

            SqlDataReader reader = loginCommand.ExecuteReader();

            while (reader.Read())
            {
                listaRoles.Add(reader[0].ToString());
            }
            reader.Close();
            connection.Close();
            return listaRoles;
            */
        }

        public static void rolAgregar(string nombreRol, string estado)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Roles (Rol_Nombre, Rol_Estado) VALUES (@nombreRol, @estado)");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            consulta.Parameters.AddWithValue("@estado", estado);
            consultaEjecutar(consulta);
        }

        public static void rolAgregarFuncionalidad(string idRol, string nombreFuncionalidad)
        {
            string idFuncionalidad = funcionalidadObtenerId(nombreFuncionalidad);
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Rol_Funcionalidad (RolFunc_IdRol, RolFunc_IdFuncionalidad) VALUES (@idRol, @idFuncionalidad)");
            consulta.Parameters.AddWithValue("@idRol", idRol);
            consulta.Parameters.AddWithValue("@idFuncionalidad", idFuncionalidad);
            consultaEjecutar(consulta);
        }

        public static void rolEliminarFuncionalidades(string nombreRol)
        {
            string idRol = rolObtenerId(nombreRol);
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Rol_Funcionalidad WHERE RolFunc_IdRol = @idRol");
            consulta.Parameters.AddWithValue("@idRol", idRol);
            consultaEjecutar(consulta);
        }

        public static void rolModificar(string nombreRolActual, string nombreRolNuevo, string estado)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Roles SET Rol_Nombre = @nombreRolNuevo Rol_Estado = @estado WHERE Rol_Nombre = @nombreRolActual");
            consulta.Parameters.AddWithValue("@nombreRolActual", nombreRolActual);
            consulta.Parameters.AddWithValue("@nombreRolNuevo", nombreRolNuevo);
            consulta.Parameters.AddWithValue("@estado", estado);
            consultaEjecutar(consulta);
            Database.rolEliminarFuncionalidades(nombreRolActual);
        }

        public static void rolEliminar(string nombreRol)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Roles SET Rol_Estado = 0 WHERE Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            consultaEjecutar(consulta);
        }

        public static string rolObtenerId(string nombreRol)
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_ID FROM RIP.Roles WHERE Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            return Database.consultaObtenerValor(consulta);
        }

        public static List<string> rolObtenerTodos()
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_Nombre FROM RIP.Roles");
            return Database.consultaObtenerValores(consulta);
        }

        public static List<string> rolObtenerHabilitados()
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_Nombre FROM RIP.Roles WHERE Rol_Estado = 1");
            return Database.consultaObtenerValores(consulta);
        }

        public static bool rolNombreYaExiste(string nombreRol)
        {
            SqlCommand consulta = consultaCrear("SELECT count(Rol_Nombre) FROM RIP.Roles WHERE Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            int resultado = Convert.ToInt32(Database.consultaObtenerValor(consulta));
            return resultado > 0;
        }

        public static bool rolEstaHabilitado(string nombreRol)
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_Estado FROM RIP.Roles WHERE Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            int resultado = Convert.ToInt32(Database.consultaObtenerValor(consulta));
            return resultado == 1;
        }

        public static bool rolNoTieneEsaFuncionalidad(string nombreRol, string nombreFuncionalidad)
        {
            string idRol = Database.rolObtenerId(nombreRol);
            string idFuncionalidad = Database.funcionalidadObtenerId(nombreFuncionalidad);
            SqlCommand consulta = consultaCrear("SELECT count(*) FROM RIP.Rol_Funcionalidad WHERE RolFunc_IdRol = @idRol AND RolFunc_IdFuncionalidad = @idFuncionalidad");
            consulta.Parameters.AddWithValue("@idRol", idRol);
            consulta.Parameters.AddWithValue("@idFuncionalidad", idFuncionalidad);
            int resultado = Convert.ToInt32(Database.consultaObtenerValor(consulta));
            return resultado == 0;
        }

        public static List<string> rolObtenerFuncionalidades(string nombreRol)
        {
            SqlCommand consulta = Database.consultaCrear("SELECT f.Funcionalidad_Funcionalidad FROM rip.Funcionalidades f INNER JOIN RIP.Rol_Funcionalidad rf ON f.Funcionalidad_Id = rf.RolFunc_IdFuncionalidad INNER JOIN RIP.Roles r ON rf.RolFunc_IdRol = r.Rol_ID WHERE r.Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            return Database.consultaObtenerValores(consulta);
        }

        public static List<string> rolObtenerFuncionalidadesFaltantes(string nombreRol)
        {
#warning Use un subselect para obtener las funcionalidades faltantes de un rol
            SqlCommand consulta = Database.consultaCrear("SELECT Funcionalidad_Funcionalidad FROM RIP.Funcionalidades WHERE Funcionalidad_Id NOT IN (SELECT RolFunc_IdFuncionalidad FROM RIP.Rol_Funcionalidad INNER JOIN RIP.Roles ON RolFunc_IdRol = Rol_ID WHERE Rol_Nombre = @nombreRol)");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            return Database.consultaObtenerValores(consulta);
        }

        //-------------------------------------- Metodos para Hoteles -------------------------------------

        internal static List<string> HotelesDeUnUsuario(Usuario Usuario)
        {
            SqlConnection connection = obtenerConexion();

            SqlCommand hotelesquery = new SqlCommand("SELECT ci.Ciudades_Descripcion, c.Calles_Descripcion, d.Domicilio_Nro_calle FROM rip.Hoteles h JOIN RIP.Hotel_Usuario hu on hu.Hotel_Usuario_IdHotel = h.Hoteles_ID JOIN RIP.Usuarios u on u.Usuario_ID = hu.Hotel_Usuario_IdUsuario JOIN RIP.Domicilio d on d.Domicilio_ID = h.Hoteles_Domicilio_ID JOIN RIP.Calles c on c.Calles_ID = d.Domicilio_Calle_ID JOIN RIP.Ciudades ci on ci.Ciudades_ID = d.Domicilio_Ciudad_ID where u.Usuario_User = @username");
            hotelesquery.Parameters.AddWithValue("username", Usuario.NombreUsuario);
            hotelesquery.Connection = connection;
            connection.Open();
            SqlDataReader reader = hotelesquery.ExecuteReader();

            List<string> hoteles = new List<string>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    hoteles.Add(reader[0].ToString().TrimEnd() + " " + reader[1].ToString() + " " + reader[2].ToString());
                }
            }

            reader.Close();
            connection.Close();

            return hoteles;
        }
    }
}