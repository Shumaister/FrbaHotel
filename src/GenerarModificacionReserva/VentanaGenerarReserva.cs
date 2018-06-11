using FrbaHotel.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class VentanaGenerarReserva : VentanaBase
    {
        private Estadia Estadia { get; set; }

        public VentanaGenerarReserva()
        {
            InitializeComponent();

            Estadia = new Estadia();
            this.logo.Visible = false;
            this.btnConfirmarPaso1.Enabled = false;
            comboBoxCargar(cbxTipoHabitacion, Database.tipoHabitacionObtenerTodas());
            comboBoxCargar(cbxRegimenEstadia, Database.DescripcionRegimenObtenerTodos());
        }

        private void VentanaGenerarReserva_Load(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarFecha_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void btnCheckear_Click(object sender, EventArgs e)
        {
            this.lblerrorcantidad.Visible = false;
            this.lblerrorfechas.Visible = false;
            this.lblErrorPaso1.Visible = false;

            // cosas a validar: que solo se ingresen numeros en la cantidad de huespedes, que la fecha no este vacia, que la fecha de inicio no sea mayor a la de fin
            // TODO
            if (EsEstadiaValida())
            {
                Estadia.FechaInicio = calendarInicio.SelectionStart;
                Estadia.FechaFin = calendarFin.SelectionStart;
                Estadia.CantidadHuespedes = int.Parse(this.tbxCantidadHuespedes.Text.Trim());

                lblResumenReserva.Text = "Para la cantidad de " + Estadia.CantidadHuespedes + " huespedes,\n con fecha inicio: " + Estadia.FechaInicio.ToShortDateString() + " con fecha fin: " + Estadia.FechaFin.ToShortDateString();

                this.btnConfirmarPaso1.Enabled = true;
            }
            else
            {
                LimpiarPaso1();
            }

        }

        private bool EsEstadiaValida()
        {
            if (calendarFin.SelectionStart <= calendarInicio.SelectionStart)
            {
                this.lblerrorfechas.Visible = true;
                return false;
            }

            if (!ventanaCamposEstanCompletos(this.groupBox1, controladorError))
            {
                this.lblerrorcantidad.Text = "Este campo no puede estar vacio";
                this.lblerrorcantidad.Visible = true;
                return false;
            }
            else
            {
                             
                if (int.Parse(this.tbxCantidadHuespedes.Text.Trim()) <= 0)
                {
                    this.lblerrorcantidad.Text = "La cantidad debe ser un numero mayor a 0";
                    this.lblerrorcantidad.Visible = true;
                    return false;
                }
            }

            if (Database.HayReservasEntreFechas(this.calendarInicio.SelectionStart, this.calendarFin.SelectionStart))
            {
                lblErrorPaso1.Visible = true;
            }

            return true;
        }

        private void tbxCantidadHuespedes_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void calendarInicio_DateChanged(object sender, DateRangeEventArgs e)
        {
            lblFechaInicio.Text = this.calendarInicio.SelectionStart.ToShortDateString();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            lblFechaFin.Text = this.calendarFin.SelectionStart.ToShortDateString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarPaso1();
        }

        private void LimpiarPaso1()
        {
            this.tbxCantidadHuespedes.Clear();
            this.lblResumenReserva.Text = "";
           /* this.lblFechaInicio.Text = "";
            this.lblFechaFin.Text = "";
            this.calendarInicio.SelectionStart = DateTime.Now;
            this.calendarFin.SelectionStart = DateTime.Now;*/
        }
    }
}
