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
            Usuario usuario = new Usuario();
            usuario.nombre = logueo.mensaje;
            ventanaAbrirSegunUsuario(usuario);
        }

        private void ventanaLogueoFallido(LogueoDTO logueo)
        {
            txbUser.Clear();
            txbPass.Clear();
            lblErrorLogueo.Text = logueo.mensaje;
            lblErrorLogueo.Show();
        }

        private void ventanaLogueoFallidoMensaje()
        {

        }

        private void ventanaAbrirSegunUsuario(Usuario usuario)
        {
            string nombreUsuario = usuario.nombre;
            if (Database.usuarioTrabajaEnUnSoloHotel(nombreUsuario) && Database.usuarioTieneUnSoloRol(nombreUsuario))
                ventanaMenuPrincipalAbrir(usuario);
            else if (Database.usuarioTrabajaEnUnSoloHotel(nombreUsuario) && Database.usuarioTieneVariosRoles(nombreUsuario))
                ventanaSeleccionDeRolAbrir(usuario);
            else if (Database.usuarioTrabajaEnVariosHoteles(nombreUsuario) && Database.usuarioTieneUnSoloRol(nombreUsuario))
                ventanaSeleccionDeHotelAbrir(usuario);
            else
                ventanaSeleccionDeRolYHotelAbrir(usuario);
        }

        private void ventanaMenuPrincipalAbrir(Usuario usuario)
        {
            VentanaMenuPrincipal ventanaMenuPrincipal = new VentanaMenuPrincipal(usuario);
            ventanaMenuPrincipal.Show();
        }

        private void ventanaSeleccionDeRolAbrir(Usuario usuario)
        {
            VentanaSeleccionRolHotel ventanaSeleccionRol = new VentanaSeleccionRolHotel(usuario);
            ventanaSeleccionRol.ventanaConfigurarParaRol();
            ventanaSeleccionRol.Show();
        }

        private void ventanaSeleccionDeHotelAbrir(Usuario usuario)
        {
            VentanaSeleccionRolHotel ventanaSeleccionRol = new VentanaSeleccionRolHotel(usuario);
            ventanaSeleccionRol.ventanaConfigurarParaHotel();
            ventanaSeleccionRol.Show();
        }

        private void ventanaSeleccionDeRolYHotelAbrir(Usuario usuario)
        {
            VentanaSeleccionRolHotel ventanaSeleccionRol = new VentanaSeleccionRolHotel(usuario);
            ventanaSeleccionRol.ventanaConfigurarParaRolYHotel();
            ventanaSeleccionRol.Show();
        }
    }
}
