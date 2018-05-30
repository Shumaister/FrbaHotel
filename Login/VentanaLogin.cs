using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class VentanaLogin : VentanaBase
    {
        public VentanaLogin()
        {
            InitializeComponent();
            lblErrorLogueo.Visible = false;
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblErrorLogueo.Visible = false;
            if (ventanaCamposTodosCompletos(this, controladorError)) 
            {
                LogueoDTO logueo = Database.Autenticar(txbUser.Text, txbPass.Text);
                if (logueo.Exito)
                {
                    this.Hide();
                    if (Usuario.trabajaEnUnSoloHotel() && Usuario.tieneUnSoloRol())
                        abrirMenuPrincipal();
                    else if (Usuario.trabajaEnUnSoloHotel && Usuario.tieneVariosRoles())
                        abrirSeleccionDeRol();
                    else if (Usuario.trabajaEnVariosHoteles && Usuario.tieneUnSoloRol())
                        abrirSeleccionDeHotel();
                    else
                        abrirSeleccionDeHotelYRol();
                }
                else
                    errorLogueo(logueo);
            }
        }

        private void errorLogueo(LogueoDTO logueo)
        {
            txbUser.Clear();
            txbPass.Clear();
            lblErrorLogueo.Visible = true;
            lblErrorLogueo.Text = logueo.MensajeError;
        }

        private void txbUser_TextChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }

        private void txbPass_TextChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }

        private void VentanaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
