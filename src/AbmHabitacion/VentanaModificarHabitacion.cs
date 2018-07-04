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
        bool HabilitadoDesdeInicio { get; set; }

        #endregion

        #region Constructores

        public VentanaModificarHabitacion(VentanaHabitacion ventanaHabitacion, Habitacion habitacion)
        {
            InitializeComponent();
            this.ventanaHabitacion = ventanaHabitacion;
            this.habitacion = habitacion;
            this.HabilitadoDesdeInicio = false;
        }

        #endregion

        #region Modificar

        private void VentanaModificarHabitacion_Load(object sender, EventArgs e)
        {
            lblHotel.Text = "Hotel: " + habitacion.hotel.domicilio.pais + " - " + habitacion.hotel.domicilio.ciudad + " - " + habitacion.hotel.domicilio.calle + " - " + habitacion.hotel.domicilio.numeroCalle;
            tbxNumero.Text = habitacion.numero;
            tbxPiso.Text = habitacion.piso;
            tbxDescripcion.Text = habitacion.descripcion;
            if (bool.Parse(habitacion.estado))
            {
                this.HabilitadoDesdeInicio = true;
                buttonHabilitarDesactivar(btnHabilitar);
            }
            comboBoxCargar(cbxTipoHabitaciones, Database.tipoHabitacionObtenerTodasEnLista());
            cbxTipoHabitaciones.SelectedIndex = cbxTipoHabitaciones.Items.IndexOf(habitacion.tipoHabitacion);
            cbxTipoHabitaciones.Enabled = false;
            comboBoxCargar(cbxFrentes, Database.habitacionObtenerFrentes());
            cbxFrentes.SelectedIndex = habitacion.frente == "N" ? 0 : 1; 
        }

        private void ventanaCrearHabitacionParaModificar()
        {
            habitacion.numero = tbxNumero.Text;
            habitacion.piso = tbxPiso.Text;
            habitacion.frente = cbxFrentes.SelectedItem.ToString() == "Interna" ? "N" : "S";
            habitacion.tipoHabitacion = cbxTipoHabitaciones.SelectedItem.ToString();
            habitacion.descripcion = tbxDescripcion.Text;
            habitacion.estado = btnHabilitar.Enabled ? "0" : "1";
        }

        private void btnModificarGuardar_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                ventanaCrearHabitacionParaModificar();
                if (Database.habitacionModificadaConExito(habitacion))
                {
                    this.Hide();
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
            cbxFrentes.SelectedIndex = 0;
            if (!this.HabilitadoDesdeInicio)
                buttonHabilitarActivar(btnHabilitar);
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

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            buttonHabilitarDesactivar(btnHabilitar);
        }
    }
}
