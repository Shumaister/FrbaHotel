using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data;
//using PagoAgilFrba.Sucursal;
using System.Configuration;


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

        public static String AlgodelaDB()
        {
            SqlConnection connection = getConnection();

            SqlCommand loginCommand = new SqlCommand("SELECT Hotel_Ciudad FROM gd_esquema.Maestra WHERE Cliente_Apellido=@ape AND Cliente_Nombre=@nom");
            
            //select * from gd_esquema.Maestra where Cliente_Apellido = 'Gómez' and Cliente_Nombre = 'KAWA'

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
    }
}