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
    public partial class IngresarNumeroReservaModificar : VentanaBase
    {
        public IngresarNumeroReservaModificar()
        {
            InitializeComponent();

            this.lblErrorIngresoReserva.Visible = false;
        }

        private void IngresarNumeroReservaModificar_Load(object sender, EventArgs e)
        {
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.lblErrorIngresoReserva.Visible = false;

            if (ventanaCamposEstanCompletos(this.groupBox1, controladorError))
            {
                DateTime hoy = DateTime.Now;
                DateTime ayer = DateTime.Now.AddDays(-1);
                string numeroReserva = this.tbxNumeroReserva.Text;

                if (Database.ReservaExiste(numeroReserva))
                {
                    if (Database.ReservaEsFechaMenor(numeroReserva, ayer))
                    {
                        if (Database.ReservaEstadoValidoParaCancelarModificar(numeroReserva))
                        {
                            Reserva reserva = Database.ReservaObtenerById(numeroReserva);
                            VentanaGenerarReserva asdd = new VentanaGenerarReserva(reserva, "ModificaCliente");
                            asdd.ShowDialog();
                        }
                        else
                        {
                            this.lblErrorIngresoReserva.Visible = true;
                            this.lblErrorIngresoReserva.Text = "Esta reserva ya esta cancelada.";
                        }
                    }
                    else
                    {
                        this.lblErrorIngresoReserva.Visible = true;
                        this.lblErrorIngresoReserva.Text = "No es posible modificar esta reserva. Paso el tiempo limite.";
                    }
                }
                else
                {
                    this.lblErrorIngresoReserva.Visible = true;
                    this.lblErrorIngresoReserva.Text = "No existe este numero de reserva.";
                }
            }
        }

        private void tbxNumeroReserva_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }
    }
}
