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

        Usuario usuario { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public VentanaSeleccionRolHotel(Usuario usuario)
        {
            this.usuario = usuario;    
            InitializeComponent();
            this.AcceptButton = btnIngresarRol;
            lblErrorRol.Hide();
        }

        //-------------------------------------- Metodos para Eventos -------------------------------------

        private void VentanaSeleccionRol_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
       
        public void configurarParaRol()
        {
            lblHotel.Hide();
            cbxHoteles.Hide();
            comboBoxCargar(cbxRoles, usuario.roles);
        }

        public void configurarParaHotel()
        {
            cbxRoles.Hide();
            lblRol.Hide();
            comboBoxCargar(cbxHoteles, usuario.hoteles);
        }

        public void configurarParaRolYHotel()
        {
            comboBoxCargar(cbxHoteles, usuario.hoteles);
            comboBoxCargar(cbxRoles, usuario.roles); ;
        }

        private void btnIngresarRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaMenuPrincipal ventanaMenuPrincipal = new VentanaMenuPrincipal(usuario);
            ventanaMenuPrincipal.Show();
        }
    }
}
