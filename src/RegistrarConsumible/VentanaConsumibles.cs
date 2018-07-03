using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using FrbaHotel.Clases;

namespace FrbaHotel.RegistrarConsumible
{
    public partial class VentanaConsumibles : VentanaBase
    {
        public Sesion sesion { get; set; }

        public VentanaConsumibles(Sesion sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }

        private void btnRegistrarConsumibles_Click(object sender, EventArgs e)
        {
            if(ventanaCamposEstanCompletos(this, controladorError))
            {
                if (lblHotel.Text == "Ninguno")
                {
                    ventanaInformarError("El codigo de la reserva es invalido");
                    return;
                }
                Consumido consumido = new Consumido();               
                consumido.reservaCodigo = tbxReserva.Text;
                consumido.numeroHabitacion = cbxHabitacion.SelectedItem.ToString();
                consumido.hotelID = sesion.hotel.id;
                consumido.estadiaID = Database.consumidoObtenerEstadiaID(consumido);
                if (consumido.estadiaID == "")
                {
                    ventanaInformarError("La estadia aun no tiene registrado el ingreso o el egreso");
                    return;
                }
                if (Database.consumidoHabitacionConConsumiblesRegistrados(consumido))
                {
                    ventanaInformarError("Los consumibles ya fueron registrados");
                    return;
                }
                new VentanaRegistrarConsumibles(consumido).ShowDialog();
            }
        }

        private void VentanaRegistrarConsumible_Load(object sender, EventArgs e)
        {
            ventanaEstadiaInvalida();
        }

        private void ventanaEstadiaInvalida()
        {
            lblHotel.Text = "Ninguno";
            lblRegimen.Text = "Ninguno";
            cbxHabitacion.Items.Clear();
            cbxHabitacion.Items.Add("Ninguna");
            cbxHabitacion.SelectedIndex = 0;
        }

        private void tbxReserva_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxReserva.Text))
                ventanaEstadiaInvalida();
            else
            {
                string hotelNombre = Database.reservaObtenerHotel(tbxReserva.Text, sesion.hotel.id);
                if (hotelNombre != "")
                {
                    lblHotel.Text = hotelNombre;
                    lblRegimen.Text = Database.reservaObtenerRegimen(tbxReserva.Text);
                    comboBoxCargar(cbxHabitacion, Database.reservaObtenerHabitacionesPorNumeroEnLista(tbxReserva.Text));
                    if (cbxHabitacion.Items.Count == 0)
                        ventanaEstadiaInvalida();
                }
                else
                    ventanaEstadiaInvalida();
            }
        }

        private void tbxReserva_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }
    }
}


