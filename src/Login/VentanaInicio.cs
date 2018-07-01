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
    public partial class VentanaInicio : VentanaBase
    {
        //-------------------------------------- Constructores -------------------------------------

        public VentanaInicio()
        {
            InitializeComponent();
        }

        //-------------------------------------- Metodos para Eventos -------------------------------------

        private void VentanaInicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaLogin ventanaLogin = new VentanaLogin();
            ventanaLogin.ShowDialog();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaMenuPrincipalClientes ventanaMenu = new VentanaMenuPrincipalClientes();
            ventanaMenu.ShowDialog();
        }

    }
}
