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
        private Sesion sesion;
        private bool esCliente;

        public IngresarNumeroReservaModificar()
        {
            InitializeComponent();
            this.esCliente = true;
            this.lblErrorIngresoReserva.Visible = false;
        }

        public IngresarNumeroReservaModificar(Sesion sesion)
        {
            InitializeComponent();
            this.lblErrorIngresoReserva.Visible = false;
            this.sesion = sesion;
            this.esCliente = false;
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
                            if (esCliente)
                            {
                                Reserva reserva = Database.ReservaObtenerById(numeroReserva);
                                VentanaGenerarReserva asdd = new VentanaGenerarReserva(reserva, "ModificaCliente");
                                asdd.ShowDialog();
                            }
                            else
                            {
                                if (Database.ReservaEsDeMiHotel(numeroReserva, sesion.hotel.id))
                                {
                                    Reserva reserva = Database.ReservaObtenerById(numeroReserva);
                                    VentanaGenerarReserva asdd = new VentanaGenerarReserva(sesion, reserva, "ModificaUsuario");
                                    asdd.ShowDialog();
                                }
                                else
                                {
                                    this.lblErrorIngresoReserva.Visible = true;
                                    this.lblErrorIngresoReserva.Text = "Esta reserva no pertenece a este hotel.";
                                }
                            }
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
