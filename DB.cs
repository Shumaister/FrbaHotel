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

        public static String AlgodelaDB()
        {
            SqlConnection connection = getConnection();

            SqlCommand loginCommand = new SqlCommand("SELECT Hotel_Ciudad FROM gd_esquema.Maestra WHERE Cliente_Apellido=@ape AND Cliente_Nombre=@nom");
           
            loginCommand.Parameters.AddWithValue("ape", "Gómez");
            loginCommand.Parameters.AddWithValue("nom", "KAWA");
            loginCommand.Connection = connection;
            connection.Open();

            SqlDataReader reader = loginCommand.ExecuteReader();
            string cantidadDeVeces = "0";
            while (reader.Read())
            {
                cantidadDeVeces = reader["Hotel_Ciudad"].ToString();
            }
            reader.Close();
            connection.Close();

            return cantidadDeVeces;
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
                List<string> roles = new List<string>();
                roles.Add("Hola");
                return new LogueoDTO(true,"Exito!",usuario,roles);
             }
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


        
    
    }

}