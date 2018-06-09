using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Data.SqlTypes;
using System.Configuration;
using FrbaHotel.Login;

using FrbaHotel.Clases;


namespace FrbaHotel.RegistrarConsumible
{
    public partial class VentanaRegistrarConsumible : Form
    {
        public VentanaRegistrarConsumible()
        {
            InitializeComponent();
        }

        private void VentanaRegistrarConsumible_Load(object sender, EventArgs e)
        {

        }

        private void TextEstadia_TextChanged(object sender, EventArgs e)
        {
            SqlCommand hotel = Database.consultaCrear("select distinct Calle_Nombre from rip.Consumidos join rip.Estadias on Consumido_EstadiaID=Estadia_ID join rip.Reservas on Estadia_ReservaID=Reserva_ID join rip.Hoteles on Reserva_HotelID=Hotel_ID join rip.Domicilios on Hotel_DomicilioID=Domicilio_ID join rip.Calles on Domicilio_CalleID=Calle_ID join rip.Habitaciones on Consumido_HabitacionID=Habitacion_ID join rip.Regimenes on Reserva_RegimenID=Regimen_ID where estadia_id=@Estadia");
            hotel.Parameters.AddWithValue("@Estadia", TextEstadia.Text);
            string nombreHotel = Database.consultaObtenerValor(hotel);
            TextHotel.Text = nombreHotel;

            SqlCommand habitacion = Database.consultaCrear("select distinct Habitacion_Numero from rip.Consumidos join rip.Estadias on Consumido_EstadiaID=Estadia_ID join rip.Reservas on Estadia_ReservaID=Reserva_ID join rip.Hoteles on Reserva_HotelID=Hotel_ID join rip.Domicilios on Hotel_DomicilioID=Domicilio_ID join rip.Calles on Domicilio_CalleID=Calle_ID join rip.Habitaciones on Consumido_HabitacionID=Habitacion_ID join rip.Regimenes on Reserva_RegimenID=Regimen_ID where estadia_id=@Estadia");
            habitacion.Parameters.AddWithValue("@Estadia", TextEstadia.Text);
            string numeroHabitacion = Database.consultaObtenerValor(habitacion);
            TextHabitacion.Text = numeroHabitacion;

            SqlCommand regimen = Database.consultaCrear("select distinct Regimen_Descripcion from rip.Consumidos join rip.Estadias on Consumido_EstadiaID=Estadia_ID join rip.Reservas on Estadia_ReservaID=Reserva_ID join rip.Hoteles on Reserva_HotelID=Hotel_ID join rip.Domicilios on Hotel_DomicilioID=Domicilio_ID join rip.Calles on Domicilio_CalleID=Calle_ID join rip.Habitaciones on Consumido_HabitacionID=Habitacion_ID join rip.Regimenes on Reserva_RegimenID=Regimen_ID where estadia_id=@Estadia");
            regimen.Parameters.AddWithValue("@Estadia", TextEstadia.Text);
            string nombreRegimen = Database.consultaObtenerValor(regimen);
            TextRegimen.Text = nombreRegimen;


        }

        private void button1_Click(object sender, System.EventArgs e)
        {
             
             string consumibleSeleccionado =ConsumibleCombo.SelectedItem.ToString();
             SqlCommand consumible = Database.consultaCrear("select Consumible_ID from rip.Consumibles where Consumible_Descripcion=@Consumible");
             consumible.Parameters.AddWithValue("@Consumible", consumibleSeleccionado);
             string idConsumible = Database.consultaObtenerValor(consumible);

             SqlCommand hotel = Database.consultaCrear("select distinct Habitacion_HotelID from rip.Consumidos join rip.Estadias on Consumido_EstadiaID=Estadia_ID join rip.Reservas on Estadia_ReservaID=Reserva_ID join rip.Hoteles on Reserva_HotelID=Hotel_ID join rip.Domicilios on Hotel_DomicilioID=Domicilio_ID join rip.Calles on Domicilio_CalleID=Calle_ID join rip.Habitaciones on Consumido_HabitacionID=Habitacion_ID join rip.Regimenes on Reserva_RegimenID=Regimen_ID where estadia_id=@Estadia");
            hotel.Parameters.AddWithValue("@Estadia", TextEstadia.Text);
            string idHotel = Database.consultaObtenerValor(hotel);
          
            DialogResult result = MessageBox.Show("Estadia :" + TextEstadia.Text+ "\n Consumible Seleccionado : "+consumibleSeleccionado+"\n", "Desea Continuar?", MessageBoxButtons.YesNo);

            switch (result)
            {
                case DialogResult.Yes:
                    MessageBox.Show("Yes");
                    break;
                case DialogResult.No:
                    MessageBox.Show("No");
                    break;
            }
            
            //Summary ventanaSummary = new Summary(TextEstadia.Text, consumibleSeleccionado, idConsumible, TextCantidad.Text, idHotel,TextHabitacion.Text);
             //ventanaSummary.ShowDialog();

        }
    }
}
