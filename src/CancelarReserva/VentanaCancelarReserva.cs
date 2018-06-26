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
        public VentanaCancelarReserva()
        {
            InitializeComponent();
            this.IniciarVentana();
        }

        private void IniciarVentana() 
        {
            this.logo.Visible = false;
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
                //
                lblErrorIngresoReserva.Text = "algo";
                btnCancelarReserva.Enabled = true;
            }
        }

        private void btnIngresoNroReserva_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this.groupBox1, controladorError))
            {
                DateTime hoy = DateTime.Now;
                /**
                  if(nuemero reserva es valido) 
                 *  if(fechainicioreserva >= ayer)
                 *      cargardatos(reserva)
                 *   else
                 *      errorlbl = ya no se puede cancelar cerca de tiempo
                 * else
                 *  numero de reserva no valido
                 *  
                 * */
                this.tbxNumeroReserva.Enabled = false;
                this.btnIngresoNroReserva.Enabled = false;
                this.tbxMotivo.Enabled = true;
                this.lblFecha.Text = hoy.ToString();
                btnCancelarReserva.Enabled = true;
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
