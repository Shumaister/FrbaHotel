using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.AbmRol;

namespace FrbaHotel.Menus
{
    public partial class VentanaMenuPrincipal : VentanaBase
    {
        Usuario Usuario { get; set; }
        public VentanaMenuPrincipal(Usuario usu)
        {
            this.Usuario = usu; 
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void funcionalidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MenuPrincipalUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuRoles_Click(object sender, EventArgs e)
        {
            VentanaRoles ventanaRoles = new VentanaRoles(this);
            ventanaRoles.MdiParent = this;
            ventanaRoles.Show();
        }

        private void VentanaMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
