using FrbaHotel.Menus;
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
    public partial class VentanaSeleccionRolHotel : VentanaBase
    {
        //-------------------------------------- Atributos -------------------------------------

        Sesion usuario { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public VentanaSeleccionRolHotel(Sesion usuario)
        {
            InitializeComponent();
            this.usuario = usuario;  
            ventanaConfigurar();
        }

        //-------------------------------------- Metodos para Eventos -------------------------------------

        private void VentanaSeleccionRolHotel_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnIngresarRol;
            lblErrorRol.Hide();
        }

        private void VentanaSeleccionRol_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ventanaConfigurar()
        {
            ventanaCargarRolesYHoteles();
            if (usuario.usuarioTrabajaEnUnSoloHotel() && usuario.usuarioTieneUnSoloRol())
                ventanaAbrirMenuPrincipal();
            else if (usuario.usuarioTrabajaEnUnSoloHotel() && usuario.usuarioTieneVariosRoles())
                ventanaConfigurarParaRol();
            else if (usuario.usuarioTrabajaEnVariosHoteles() && usuario.usuarioTieneUnSoloRol())
                ventanaConfigurarParaHotel();
            else
                ventanaConfigurarParaRolYHotel();
        }

        private void ventanaCargarRolesYHoteles()
        {
            comboBoxCargar(cbxHoteles, usuario.hoteles);
            comboBoxCargar(cbxRoles, usuario.roles);
        }

        private void ventanaConfigurarParaRol()
        {
            lblHotel.Hide();
            cbxHoteles.Hide();
            this.Show();
        }

        private void ventanaConfigurarParaHotel()
        {
            cbxRoles.Hide();
            lblRol.Hide();
            this.Show();
        }

        private void ventanaConfigurarParaRolYHotel()
        {
            this.Show();
        }

        public void ventanaConfigurarUsuario()
        {
            string rolLogueado = cbxRoles.SelectedItem.ToString();
            string hotelLogueado = cbxHoteles.SelectedItem.ToString();
            List<string> funcionalidades = Database.rolObtenerFuncionalidades(rolLogueado);
            usuario.configurarDatos(rolLogueado, hotelLogueado, funcionalidades); 
        }

        private void btnIngresarRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            ventanaAbrirMenuPrincipal();
        }

        private void ventanaAbrirMenuPrincipal()
        {
            ventanaConfigurarUsuario();
            VentanaMenuPrincipal ventanaMenuPrincipal = new VentanaMenuPrincipal(usuario);
            ventanaMenuPrincipal.Show();
        }
    }
}
