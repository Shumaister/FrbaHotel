using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarEstadia
{
    public partial class VentanaRegistrarEstadia : VentanaBase
    {
        public VentanaRegistrarEstadia()
        {
            InitializeComponent();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                VentanaRegistrarIngreso ventanaRegistrarIngreso = new VentanaRegistrarIngreso(tbxNumeroReserva.Text);
                ventanaRegistrarIngreso.ShowDialog();
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                VentanaRegistrarEgreso ventanaRegistrarIngreso = new VentanaRegistrarEgreso(tbxNumeroReserva.Text);
                ventanaRegistrarIngreso.ShowDialog();
            }
        }

        private void tbxNumeroReserva_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void VentanaRegistrarEstadia_Load(object sender, EventArgs e)
        {
            lblHotelNombre.Text = "Ninguno";
            lblRegimenDescripcion.Text = "Ninguno";
        }

        private void tbxNumeroReserva_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxNumeroReserva.Text))
            {
                lblHotelNombre.Text = "Ninguno";
                lblRegimenDescripcion.Text = "Ninguno";
            }
            else
            {
                string hotelNombre = Database.reservaObtenerHotel(tbxNumeroReserva.Text);
                if (hotelNombre != "")
                {
                    lblHotelNombre.Text = hotelNombre;
                    lblRegimenDescripcion.Text = Database.reservaObtenerRegimen(tbxNumeroReserva.Text);
                }
                else
                {
                    lblHotelNombre.Text = "Ninguno";
                    lblRegimenDescripcion.Text = "Ninguno";
                }

            }
        }
    }
}
