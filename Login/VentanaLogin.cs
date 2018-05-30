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
                if (logueo.exito)
                {
                    this.Hide();
                    string nombreUsuario = logueo.nombreUsuario;
                    Usuario usuario = new Usuario(logueo);
                    if (Database.usuarioTrabajaEnUnSoloHotel(nombreUsuario) && Database.usuarioTieneUnSoloRol(nombreUsuario))
                        abrirVentanaMenuPrincipal(usuario);
                    else if (Database.usuarioTrabajaEnUnSoloHotel(nombreUsuario) && Database.usuarioTieneVariosRoles(nombreUsuario))
                        abrirVentanaSeleccionDeRol(usuario);
                    else if (Database.usuarioTrabajaEnVariosHoteles(nombreUsuario) && Database.usuarioTieneUnSoloRol(nombreUsuario))
                        abrirVentanaSeleccionDeHotel(usuario);
                    else
                        abrirVentanaSeleccionDeHotelYRol(usuario);
                }
                else
                    errorLogueo(logueo);
            }
        }

        private void abrirVentanaMenuPrincipal(Usuario usuario)
        {
            VentanaMenuPrincipal ventanaMenuPrincipal = new VentanaMenuPrincipal(usuario);
            ventanaMenuPrincipal.Show();
        }

        private void abrirVentanaSeleccionDeRol(Usuario usuario)
        {
            VentanaSeleccionHotelRol ventanaSeleccionRol = new VentanaSeleccionHotelRol(usuario);
            ventanaSeleccionRol.configurarParaRol();
            ventanaSeleccionRol.Show();
        }

        private void abrirVentanaSeleccionDeHotel(Usuario usuario)
        {
            VentanaSeleccionHotelRol ventanaSeleccionRol = new VentanaSeleccionHotelRol(usuario);
            ventanaSeleccionRol.configurarParaHotel();
            ventanaSeleccionRol.Show();
        }

        private void abrirVentanaSeleccionDeHotelYRol(Usuario usuario)
        {
            VentanaSeleccionHotelRol ventanaSeleccionRol = new VentanaSeleccionHotelRol(usuario);
            ventanaSeleccionRol.configurarParaHotelYRol();
            ventanaSeleccionRol.Show();
        }

        private void errorLogueo(LogueoDTO logueo)
        {
            txbUser.Clear();
            txbPass.Clear();
            lblErrorLogueo.Visible = true;
            lblErrorLogueo.Text = logueo.mensajeError;
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
