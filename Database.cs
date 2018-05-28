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

        //-------------------------------------- Metodos para Base de datos -------------------------------------

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

        public static SqlCommand crearConsulta(string consulta) 
        {
            return new SqlCommand(consulta, Database.obtenerConexion());
        }

        public static int ejecutarConsulta(SqlCommand comando)
        {
            Database.conectar();
            int estado = 0;
            try
            {
                estado = comando.ExecuteNonQuery();
            }
            catch (Exception excepcion)
            {
                Database.informarError(excepcion);
            }
            Database.desconectar();
            return estado;
        }

        public static List<string> buscarValoresDeUnCampo(SqlCommand consulta) 
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
                Database.informarError(excepcion);
            }
            Database.desconectar();
            return listaValores;
        }

        public static string buscarValorDeUnCampo(SqlCommand consulta)
        {
            return Database.buscarValoresDeUnCampo(consulta)[0];
        }

        public static void informarError(Exception excepcion)
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

        internal static List<string> FuncionalidadesDeRol(string rol)
        {
            List<string> listaFuncionalidades = new List<string>();
            SqlConnection connection = obtenerConexion();

            SqlCommand loginCommand = new SqlCommand("SELECT f.Funcionalidad_Funcionalidad FROM rip.Funcionalidades f INNER JOIN RIP.Rol_Funcionalidad rf ON f.Funcionalidad_Id = rf.RolFunc_IdFuncionalidad INNER JOIN RIP.Roles r ON rf.RolFunc_IdRol = r.Rol_ID WHERE r.Rol_Nombre = @rol");
            loginCommand.Parameters.AddWithValue("rol", rol);
            loginCommand.Connection = connection;
            connection.Open();

            SqlDataReader reader = loginCommand.ExecuteReader();

            while (reader.Read())
            {
                listaFuncionalidades.Add(reader[0].ToString());
            }

            reader.Close();
            connection.Close();
            return listaFuncionalidades;
        }

        public static string buscarIdFuncionalidad(string nombreFuncionalidad)
        {
            SqlCommand consulta = crearConsulta("SELECT Funcionalidad_Id FROM RIP.Funcionalidades WHERE Funcionalidad_Funcionalidad = @nombreFuncionalidad");
            consulta.Parameters.AddWithValue("@nombreFuncionalidad", nombreFuncionalidad);
            return Database.buscarValorDeUnCampo(consulta);
        }

        public static void agregarFuncionalidad(string idRol, string nombreFuncionalidad)
        {
            string idFuncionalidad = buscarIdFuncionalidad(nombreFuncionalidad);
            SqlCommand consulta = crearConsulta("INSERT INTO RIP.Rol_Funcionalidad (RolFunc_IdRol, RolFunc_IdFuncionalidad) VALUES (@idRol, @idFuncionalidad)");
            consulta.Parameters.AddWithValue("@idRol", idRol);
            consulta.Parameters.AddWithValue("@idFuncionalidad", idFuncionalidad);
            ejecutarConsulta(consulta);
        }

        public static void eliminarFuncionalidadesDeUnRol(string nombreRol) 
        {
            string idRol = buscarIdRol(nombreRol);
            SqlCommand consulta = crearConsulta("DELETE FROM RIP.Rol_Funcionalidad WHERE RolFunc_IdRol = @idRol");
            consulta.Parameters.AddWithValue("@idRol", idRol);
            ejecutarConsulta(consulta);
        }

        public static void obtenerFuncionalidades(ComboBox comboBox)
        {
            Database.completarComboBox(comboBox, "SELECT Funcionalidad_Funcionalidad FROM RIP.Funcionalidades", "Funcionalidad_Funcionalidad");
        }
       
        //-------------------------------------- Metodos para Roles -------------------------------------

        public static List<string> Roles(string user)
        {
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
        }

        public static void agregarRol(string nombreRol, string estado) {
            SqlCommand consulta = crearConsulta("INSERT INTO RIP.Roles (Rol_Nombre, Rol_Estado) VALUES (@nombreRol, @estado)");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            consulta.Parameters.AddWithValue("@estado", estado);
            ejecutarConsulta(consulta);
        }

        public static void modificarRol(string nombreRolActual, string nombreRolNuevo, string estado)
        {
            SqlCommand consulta = crearConsulta("UPDATE RIP.Roles SET Rol_Nombre = @nuevoNombreRol Rol_Estado = @estado WHERE Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRolActual);
            consulta.Parameters.AddWithValue("@nuevoNombreRol", nombreRolNuevo);
            consulta.Parameters.AddWithValue("@estado", estado);
            Database.eliminarFuncionalidadesDeUnRol(nombreRolActual);
            ejecutarConsulta(consulta);
        }
        
        public static void eliminarRol(string nombreRol)
        {
            SqlCommand consulta = crearConsulta("UPDATE RIP.Roles SET Rol_Estado = 0 WHERE Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            ejecutarConsulta(consulta);
        }

        public static string buscarIdRol(string nombreRol)
        {
            SqlCommand consulta = crearConsulta("SELECT Rol_ID FROM RIP.Roles WHERE Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            return Database.buscarValorDeUnCampo(consulta);
        }

        public static void obtenerRolesTotales(ComboBox comboBox) 
        {
            Database.completarComboBox(comboBox, "SELECT Rol_Nombre FROM RIP.Roles", "Rol_Nombre");
        }

        public static void obtenerRolesHabilitados(ComboBox comboBox) 
        {
            Database.completarComboBox(comboBox, "SELECT Rol_Nombre FROM RIP.Roles WHERE Rol_Estado = 1", "Rol_Nombre");
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

        //-------------------------------------- Metodos para Ventanas -------------------------------------

        public static void completarComboBox(ComboBox comboBox, string consulta, string nombreColumna)
        {
            Database.conectar();
            try
            {
                SqlCommand comando = new SqlCommand(consulta, Database.obtenerConexion());
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                    comboBox.Items.Add(reader[nombreColumna]);
                reader.Close();
            }
            catch (Exception excepcion)
            {
                Database.informarError(excepcion);
            }
            Database.desconectar();
        }

        public static void completarDataGridView(DataGridView dataGridView, string consulta, string parametro)
        {
            Database.conectar();
            try
            {
                DataTable dataTable = new DataTable();
                SqlCommand comando = new SqlCommand(consulta + parametro, Database.obtenerConexion());
                SqlDataReader reader = comando.ExecuteReader();
                dataTable.Load(reader);
                dataGridView.DataSource = dataTable;
            }
            catch (Exception excepcion)
            {
                Database.informarError(excepcion);
            }
            Database.desconectar();
        }


        public static void filtrarDataGridViewParaModificarRol(DataGridView dataGridView, string nombre, string estado)
        {
            Database.conectar();
            try
            {
                DataTable dataTable = new DataTable();
                SqlCommand comando = new SqlCommand("SELECT * FROM RIP.Roles WHERE Rol_Nombre LIKE %" + nombre + "% AND Rol_Estado = " + estado, Database.obtenerConexion());
                SqlDataReader reader = comando.ExecuteReader();
                dataTable.Load(reader);
                dataGridView.DataSource = dataTable;
            }
            catch (Exception excepcion)
            {
                Database.informarError(excepcion);
            }
            Database.desconectar();
        }

        public static DataTable obtenerTabla(string consulta)
        {
            Database.conectar();
            DataTable dataTable = new DataTable();
            try
            {
                SqlCommand comando = new SqlCommand(consulta, Database.obtenerConexion());
                SqlDataReader reader = comando.ExecuteReader();
                dataTable.Load(reader);
            }
            catch (Exception excepcion)
            {
                Database.informarError(excepcion);
            }
            Database.desconectar();
            return dataTable;
        }

    }
}