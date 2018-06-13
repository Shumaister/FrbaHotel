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

namespace FrbaHotel.AbmHabitacion
{
    public partial class VentanaModificarHabitacion : VentanaBase
    {
        #region Atributos

        public VentanaHabitacion ventanaHabitacion { get; set; }
        public Habitacion habitacion { get; set; }

        #endregion

        #region Constructores

        public VentanaModificarHabitacion(VentanaHabitacion ventanaHabitacion, Habitacion habitacion)
        {
            InitializeComponent();
            this.ventanaHabitacion = ventanaHabitacion;
            this.habitacion = habitacion;
        }

        #endregion

        #region Modificar

        private void VentanaModificarHabitacion_Load(object sender, EventArgs e)
        {
            lblHotel.Text = "Hotel: " + habitacion.hotel.domicilio.pais + " - " + habitacion.hotel.domicilio.ciudad + " - " + habitacion.hotel.domicilio.calle + " - " + habitacion.hotel.domicilio.numeroCalle;
            tbxNumero.Text = habitacion.numero;
            tbxPiso.Text = habitacion.piso;
            tbxDescripcion.Text = habitacion.descripcion;
            if (habitacion.frente == "S")
                rbtExterna.Select();
            else
                rbtInterna.Select();
            comboBoxCargar(cbxTipoHabitaciones, Database.tipoHabitacionObtenerTodas());
            cbxTipoHabitaciones.SelectedIndex = cbxTipoHabitaciones.Items.IndexOf(habitacion.tipoHabitacion);
        }

        private Habitacion ventanaCrearHabitacionParaModificar()
        {
            Habitacion habitacionModificada = new Habitacion(null, tbxNumero.Text, tbxPiso.Text, rbtExterna.Checked ? "S" : "N", cbxTipoHabitaciones.SelectedItem.ToString(), tbxDescripcion.Text, habitacion.hotel);
            return habitacionModificada;
        }

        private void btnModificarGuardar_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                Habitacion habitacion = ventanaCrearHabitacionParaModificar();
                if (Database.habitacionModificadaConExito(habitacion))
                {
                    btnModificarLimpiar_Click(sender, e);
                    ventanaHabitacion.ventanaActualizar(sender, e);
                }
            }
        }

        private void btnModificarLimpiar_Click(object sender, EventArgs e)
        {
            tbxNumero.Clear();
            tbxPiso.Clear();
            tbxDescripcion.Clear();
            rbtInterna.Select();
            cbxTipoHabitaciones.SelectedIndex = 0;
        }

        #endregion
        
        #region Control

        private void tbxNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void tbxPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        #endregion
    }
}
