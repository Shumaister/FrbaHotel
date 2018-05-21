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
    class DB
    {
        private static SqlTransaction trans;
        private static String connectionString = ConfigurationManager.AppSettings["conexionSQL"];
        private static SqlConnection con = new SqlConnection(connectionString);
        public static SqlConnection getConnection()
        {
            return con;
        }

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
            SqlConnection connection = getConnection();

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
                return new LogueoDTO(true,"Exito!",usuario,roles);
             }
        }

        internal static List<string> FuncionalidadesDeRol(string rol)
        {
            List<string> listaFuncionalidades = new List<string>();
            SqlConnection connection = getConnection();

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

        public static List<string> Roles(string user)
        {
            List<String> listaRoles = new List<string>();
            List<String> listaEstados = new List<string>();
            SqlConnection connection = getConnection();
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

        public static void ActualizarIntentosLogueo(string user, int cant)
        {
            SqlConnection connection = getConnection();
            connection.Open();
            
            SqlCommand query = new SqlCommand("UPDATE RIP.Usuarios SET Usuario_CantidadDeIntentos = @cant WHERE Usuario_User = @user");
            query.Parameters.AddWithValue("user", user);
            query.Parameters.AddWithValue("cant", cant);
            query.Connection = connection;
            query.ExecuteNonQuery();

            connection.Close();
        }

        //Lo dejo aca por ahora
        // no se que es esta funcion
        public static void ComboBoxLlenar(ComboBox combo) 
        {
            try
            {
                SqlConnection conexion = getConnection();
                conexion.Open();
                SqlCommand query = new SqlCommand("SELECT Rol_nombre FROM RIP.Roles", conexion);
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    combo.Items.Add(reader["Rol_nombre"]);
                }
                reader.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show("Error en la base de datos" + exception.ToString());
            }
        }





        internal static List<string> HoltesDeUnUsuario(Usuario Usuario)
        {
            SqlConnection connection = getConnection();

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