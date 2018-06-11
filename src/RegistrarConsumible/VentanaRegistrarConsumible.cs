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
    public partial class VentanaRegistrarConsumible : VentanaBase
    {
        private Hotel hotel { get; set; }
        public VentanaRegistrarConsumible(Sesion sesion)
        {
            InitializeComponent();
            ConsumibleCombo.SelectedIndex = 0;
            this.hotel = sesion.hotel;
            this.logo.Visible = false;
        }

        private void VentanaRegistrarConsumible_Load(object sender, EventArgs e)
        {

        }

        private void TextEstadia_TextChanged(object sender, EventArgs e)
        {

            if (!System.Text.RegularExpressions.Regex.IsMatch(TextEstadia.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en id Estadia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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


            if (TextEstadia.Text.Trim() == "" | TextCantidad.Text.Trim() == "")
            {
                MessageBox.Show("Faltan completar campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(TextEstadia.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en id Estadia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(TextCantidad.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en Cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            SqlCommand estadiaValida = Database.consultaCrear("select Estadia_ID from rip.Estadias where Estadia_ID=@Estadia");
            estadiaValida.Parameters.AddWithValue("@Estadia", TextEstadia.Text);
            string estadiaExistente = Database.consultaObtenerValor(estadiaValida);


            if (estadiaExistente == "") {
                MessageBox.Show("El numero de estadia "+TextEstadia.Text+" no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string consumibleSeleccionado = ConsumibleCombo.SelectedItem.ToString();
               SqlCommand consumible = Database.consultaCrear("select Consumible_ID from rip.Consumibles where Consumible_Descripcion=@Consumible");
             consumible.Parameters.AddWithValue("@Consumible", consumibleSeleccionado);
             string idConsumible = Database.consultaObtenerValor(consumible);

             SqlCommand hotel = Database.consultaCrear("select distinct Habitacion_HotelID from rip.Consumidos join rip.Estadias on Consumido_EstadiaID=Estadia_ID join rip.Reservas on Estadia_ReservaID=Reserva_ID join rip.Hoteles on Reserva_HotelID=Hotel_ID join rip.Domicilios on Hotel_DomicilioID=Domicilio_ID join rip.Calles on Domicilio_CalleID=Calle_ID join rip.Habitaciones on Consumido_HabitacionID=Habitacion_ID join rip.Regimenes on Reserva_RegimenID=Regimen_ID where estadia_id=@Estadia");
            hotel.Parameters.AddWithValue("@Estadia", TextEstadia.Text);
            string idHotel = Database.consultaObtenerValor(hotel);
          
            DialogResult result = MessageBox.Show("Estadia ID :" + TextEstadia.Text+ "\nConsumible Seleccionado : "+consumibleSeleccionado+"\nCantidad Seleccionada : "+TextCantidad.Text+"", "Desea Continuar?", MessageBoxButtons.YesNo);

            switch (result)
            {
                case DialogResult.Yes:

                    SqlCommand Regimen = Database.consultaCrear("select Regimen_ID from rip.Regimenes where Regimen_Descripcion=@Regimen");
              Regimen.Parameters.AddWithValue("@Regimen", TextRegimen.Text);
              string idRegimen = Database.consultaObtenerValor(Regimen);


              if (int.Parse(idRegimen) == 4)
              {
                SqlCommand consulta = Database.consultaCrear("Insert into rip.Consumidos(Consumido_EstadiaID,Consumido_HabitacionID,Consumido_ConsumibleID,Consumido_Cantidad)values(@Estadia,(select Habitacion_ID from rip.Habitaciones where Habitacion_Numero=@NumeroHabitacion and Habitacion_HotelID=@NumeroHotel),@ConsumibleId,@Cantidad)");
                consulta.Parameters.AddWithValue("@Estadia",TextEstadia.Text);
                consulta.Parameters.AddWithValue("@NumeroHabitacion",TextHabitacion.Text);
                consulta.Parameters.AddWithValue("@NumeroHotel",idHotel);
                consulta.Parameters.AddWithValue("@ConsumibleId",idConsumible);
                consulta.Parameters.AddWithValue("@Cantidad", TextCantidad.Text); 
                Database.consultaEjecutar(consulta);
                MessageBox.Show("Recuerde que usted posee el regimen all inclusive.");
                MessageBox.Show("Consumible registrado correctamente.");
                TextHabitacion.Text = "";
                TextHotel.Text = "";
                TextRegimen.Text = "";
                TextCantidad.Clear();
                TextEstadia.Clear();
              }
              else {

                  SqlCommand consulta = Database.consultaCrear("Insert into rip.Consumidos(Consumido_EstadiaID,Consumido_HabitacionID,Consumido_ConsumibleID,Consumido_Cantidad)values(@Estadia,(select Habitacion_ID from rip.Habitaciones where Habitacion_Numero=@NumeroHabitacion and Habitacion_HotelID=@NumeroHotel),@ConsumibleId,@Cantidad)");
                  consulta.Parameters.AddWithValue("@Estadia", TextEstadia.Text);
                  consulta.Parameters.AddWithValue("@NumeroHabitacion", TextHabitacion.Text);
                  consulta.Parameters.AddWithValue("@NumeroHotel", idHotel);
                  consulta.Parameters.AddWithValue("@ConsumibleId", idConsumible);
                  consulta.Parameters.AddWithValue("@Cantidad", TextCantidad.Text);
                  Database.consultaEjecutar(consulta);

                  MessageBox.Show("Consumible registrado correctamente.");
                  TextHabitacion.Text = "";
                  TextHotel.Text = "";
                  TextRegimen.Text = "";
                  TextCantidad.Clear();
                  TextEstadia.Clear();

              }
                    break;
                case DialogResult.No:
                    MessageBox.Show("Consumible no registrado.");
                    break;
            }
            
        }

        private void TextEstadia_TextChanged_1(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(TextEstadia.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en id Estadia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
    }
}


