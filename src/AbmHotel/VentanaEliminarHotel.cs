using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Clases;

namespace FrbaHotel.AbmHotel
{
    public partial class VentanaEliminarHotel : VentanaBase
    {

        #region Atributos
        
        VentanaHotel ventanaHotel { get; set; }
        Hotel hotel { get; set; }

        #endregion
        #region Constructores

        public VentanaEliminarHotel(VentanaHotel ventanaHotel, Hotel hotel)
        {
            InitializeComponent();
            this.ventanaHotel = ventanaHotel;
            this.hotel = hotel;
        }

        #endregion

        private void logo_Click(object sender, EventArgs e)
        {

        }

        private void VentanaEliminarHotel_Load(object sender, EventArgs e)
        {
            lblHotel.Text = "Hotel: " + hotel.domicilio.pais + " - " + hotel.domicilio.ciudad + " - " + hotel.domicilio.calle + " - " + hotel.domicilio.numeroCalle ;
        }

        private void btnElminarGuardar_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                HotelCerrado hotelCerrado = new HotelCerrado(hotel, DateTime.Parse(tbxFechaInicio.Text), DateTime.Parse(tbxFechaFin.Text), tbxMotivo.Text);
                if (Database.hotelCerradoAgregadoConExito(hotelCerrado))
                {
                    this.Hide();
                    ventanaHotel.ventanaActualizar(sender, e);
                }
            }

        }

        private void btnEliminarLimpiar_Click(object sender, EventArgs e)
        {
            tbxFechaInicio.Clear();
            tbxFechaFin.Clear();
            tbxMotivo.Clear();
            tbxFechaInicio.Enabled = true;
            tbxFechaFin.Enabled = true;
            calendario.Hide();
            btnAceptarFecha.Hide();
        }

        private void btnAceptarFecha_Click(object sender, EventArgs e)
        {
            if (tbxFechaInicio.Enabled)
            {
                tbxFechaInicio.Text = calendario.SelectionStart.ToShortDateString();
                tbxFechaFin.Enabled = true;
            }
            else
            {
                tbxFechaFin.Text = calendario.SelectionStart.ToShortDateString();
                tbxFechaInicio.Enabled = true;
            }
            calendario.Hide();
            btnAceptarFecha.Hide();
        }

        private void btnSeleccionarFechaIFin_Click(object sender, EventArgs e)
        {
            calendario.Show();
            btnAceptarFecha.Show();
            controladorError.Clear();
        }

        private void btnSeleccionarFechaInicio_Click(object sender, EventArgs e)
        {
            tbxFechaFin.Enabled = false;
            calendario.Show();
            btnAceptarFecha.Show();
        }

        private void btnSeleccionarFecha_Click(object sender, EventArgs e)
        {
            tbxFechaInicio.Enabled = false;
            calendario.Show();
            btnAceptarFecha.Show();
        }
    }
}
