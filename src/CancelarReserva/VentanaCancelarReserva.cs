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

namespace FrbaHotel.CancelarReserva
{
    public partial class VentanaCancelarReserva : VentanaBase
    {
        private Sesion sesion;
        public Usuario Usuario { get; set; }
        private bool esCliente;

        public VentanaCancelarReserva()
        {
            InitializeComponent();
            this.IniciarVentana();
            string id = Database.usuarioObtenerID(new Usuario("guest"));
            Usuario = new Usuario(id, "guest");
            esCliente = true;
        }

        public VentanaCancelarReserva(Sesion sesion)
        {
            InitializeComponent();
            this.IniciarVentana();
            this.sesion = sesion;
            Usuario = sesion.usuario;
            esCliente = false;
        }

        private void IniciarVentana() 
        {
            this.logo.Visible = false;
            this.lblFecha.Text = "--/--/--";
            this.lblUsuario.Text = "-";
            this.tbxMotivo.Text = "Ingrese un motivo...";
            this.tbxMotivo.Enabled = false;
            this.btnCancelarReserva.Enabled = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tbxCantidadHuespedes_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this.groupBox1, controladorError))
            {
                string motivo = this.tbxMotivo.Text.Trim(); 
                int estadoReserva = (Usuario.nombre == "guest") ? 4 : 3; // 4-cancelada cliente - 3-cancelada recepcion
                Reserva Reserva = Database.ReservaObtenerById(this.tbxNumeroReserva.Text);
                Database.ReservaCancelar(Reserva, motivo, Usuario.id, estadoReserva);
                MessageBox.Show("Se a canelado con exito su reservar con codigo: " + this.tbxNumeroReserva.Text, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnIngresoNroReserva_Click(object sender, EventArgs e)
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
                                this.lblUsuario.Text = reserva.Usuario.nombre;
                            }
                            else
                            {
                                if (Database.ReservaEsDeMiHotel(numeroReserva, sesion.hotel.id))
                                {
                                    Reserva reserva = Database.ReservaObtenerById(numeroReserva);
                                    this.lblUsuario.Text = reserva.Usuario.nombre;
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
                        this.lblErrorIngresoReserva.Text = "No es posible cancelar esta reserva. Paso el tiempo limite de reserva.";
                    }
                }
                else
                {
                    this.lblErrorIngresoReserva.Visible = true;
                    this.lblErrorIngresoReserva.Text = "No existe este numero de reserva.";
                }
                    
                this.tbxNumeroReserva.Enabled = false;
                this.btnIngresoNroReserva.Enabled = false;
                this.tbxMotivo.Enabled = true;
                this.lblFecha.Text = hoy.ToString();
                this.btnCancelarReserva.Enabled = true;
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            this.btnIngresoNroReserva.Enabled = true;
            this.tbxNumeroReserva.Enabled = true;
            this.tbxNumeroReserva.Clear();
            IniciarVentana();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
