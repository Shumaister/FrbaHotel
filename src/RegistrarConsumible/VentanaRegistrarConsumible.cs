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
    public partial class VentanaRegistrarConsumible : VentanaBase
    {
        public Sesion sesion { get; set; }

        public VentanaRegistrarConsumible(Sesion sesion)
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
                    ventanaInformarError("El codigo de la estadia es invalido");
                    return;
                }
                if (Database.consumidoRegistradosEnEstadia(tbxEstadia.Text, cbxHabitacion.SelectedItem.ToString(), sesion.hotel.id))
                {
                    ventanaInformarError("Los consumibles ya fueron registrados");
                    return;
                }
                Consumido consumido = new Consumido();
                consumido.estadiaID = tbxEstadia.Text;
                consumido.habitacionID = Database.consumidoObtenerHabitacionID(cbxHabitacion.SelectedItem.ToString(), sesion.hotel.id);
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

        private void tbxEstadia_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxEstadia.Text))
            {
                ventanaEstadiaInvalida();
            }
            else
            {
                Estadia estadia = new Estadia();
                estadia.id = tbxEstadia.Text;
                string hotelNombre = Database.estadiaObtenerHotel(estadia, sesion.hotel.id);
                if (hotelNombre != "")
                {
                    lblHotel.Text = hotelNombre;
                    lblRegimen.Text = Database.estadiaObtenerRegimen(estadia);
                    comboBoxCargar(cbxHabitacion, Database.estadiaObtenerHabitacionesEnLista(estadia));
                }
                else
                    ventanaEstadiaInvalida();
            }

        }

        private void tbxEstadia_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }
    }
}


