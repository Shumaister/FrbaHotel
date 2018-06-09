using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Menus;

namespace FrbaHotel.Login
{
    public partial class VentanaLogin : VentanaBase
    {
       //-------------------------------------- Constructores -------------------------------------

        public VentanaLogin()
        {
            InitializeComponent();
        }

        //-------------------------------------- Metodos para Eventos -------------------------------------

        private void VentanaLogin_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }

        private void VentanaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                LogueoDTO logueo = Database.loginAutenticar(txbUser.Text, txbPass.Text);
                if (logueo.exito)
                    ventanaLogueoExitoso(logueo);
                else
                    ventanaLogueoFallido(logueo);
            }
        }

        private void txbUser_TextChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
            lblErrorLogueo.Hide();
        }

        private void txbPass_TextChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
            lblErrorLogueo.Hide();
        }

        //-------------------------------------- Metodos para Ventana -------------------------------------

        private void ventanaLogueoExitoso(LogueoDTO logueo)
        {
            this.Hide();
            string nombreUsuario = logueo.mensaje;
            Sesion usuario = Database.sesionCrear(nombreUsuario);
            VentanaSeleccionRolHotel ventanaSeleccionRol = new VentanaSeleccionRolHotel(usuario);
        }

        private void ventanaLogueoFallido(LogueoDTO logueo)
        {
            txbPass.Clear();
            lblErrorLogueo.Text = logueo.mensaje;
            lblErrorLogueo.Show();
        }
    }
}
