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
        public Usuario Usuario { get; set; }

        public VentanaCancelarReserva()
        {
            InitializeComponent();
            this.IniciarVentana();
            Usuario = new Usuario();
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
                string motivo = tbxNumeroReserva.Text.Trim(); 
                string usuario = (Usuario==null)? Database.usuarioObtenerID(new Usuario("guest")) ; Usuario.id.ToString();
                Reserva Reserva = Database.ReservaObtenerById(this.tbxNumeroReserva.Text);
                Database.ReservaCancelar(Reserva, motivo usuario);
            }
        }

        private void btnIngresoNroReserva_Click(object sender, EventArgs e)
        {
            this.lblErrorIngresoReserva.Enabled = false;

            if (ventanaCamposEstanCompletos(this.groupBox1, controladorError))
            {
                DateTime hoy = DateTime.Now;
                DateTime ayer = DateTime.Now.AddDays(-1);
                string numeroReserva = this.tbxNumeroReserva.Text;

                if (Database.ReservaExiste(numeroReserva))
                {
                    if (Database.ReservaEsFechaMenor(numeroReserva, ayer))
                    {
                        Reserva reserva = Database.ReservaObtenerById(numeroReserva);
                        this.lblUsuario.Text =  reserva.Usuario.nombre;
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
                    this.lblErrorIngresoReserva.Text = "No existe este este numero de reserva.";
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
