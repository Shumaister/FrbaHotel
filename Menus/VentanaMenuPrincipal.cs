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
using FrbaHotel.AbmUsuario;

namespace FrbaHotel.Menus
{
    public partial class VentanaMenuPrincipal : VentanaBase
    {
        //-------------------------------------- Atributos -------------------------------------
        
        Usuario Usuario { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public VentanaMenuPrincipal(Usuario usuario)
        {
            this.Usuario = usuario; 
            InitializeComponent();
        }

        //-------------------------------------- Metodos para Eventos -------------------------------------

        private void VentanaMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuRoles_Click(object sender, EventArgs e)
        {
            VentanaRoles ventanaRoles = new VentanaRoles(this);
            ventanaRoles.MdiParent = this;
            ventanaRoles.Show();
        }

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            VentanaUsuarios ventanaUsuarios = new VentanaUsuarios();
            ventanaUsuarios.MdiParent = this;
            ventanaUsuarios.Show();
        }
    }
}
