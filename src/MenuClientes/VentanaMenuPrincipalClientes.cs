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
using FrbaHotel.Login;
using FrbaHotel.RegistrarConsumible;
using FrbaHotel.GenerarModificacionReserva;

namespace FrbaHotel.Menus
{
    public partial class VentanaMenuPrincipalClientes : VentanaBase
    {
        //-------------------------------------- Atributos -------------------------------------
        

        //-------------------------------------- Constructores -------------------------------------

        public VentanaMenuPrincipalClientes()
        {
            InitializeComponent();
        }

        //-------------------------------------- Metodos para Eventos -------------------------------------

        private void VentanaMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void VentanaMenuPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void nuevaReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaGenerarReserva ven = new VentanaGenerarReserva();
            ven.Show();
        }

        private void modificarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
