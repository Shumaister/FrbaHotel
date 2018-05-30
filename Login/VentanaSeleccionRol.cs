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
    public partial class VentanaSeleccionRol : VentanaBase
    {
        Usuario Usuario { get; set; }

        public VentanaSeleccionRol(Usuario usu)
        {
            this.Usuario = usu;    
            InitializeComponent();
            lblErrorRol.Visible = false;
            TrabarSeleccionHotel();
        }

        private void TrabarSeleccionHotel()
        {
            cbxHoteles.Enabled = false;
            lblHotel.Enabled = false;
            btnIngresarHotel.Enabled = false;
        }

        private void SeleccionRol_Load(object sender, EventArgs e)
        {
            foreach(string rol in Usuario.Roles)
                cbxRoles.Items.Add(rol);

            if (Usuario.Roles.Count == 1) {
                // Usuario.RolLogueado = Usuario.Roles[0];
                // cbxRoles.Enabled = false;
                // no googles como hacerlo, pero la idea es que te auto-seleccione el unico rol existente  cbxRoles.Select[0];
                // btnIngresarRol_Click(sender, e);
            }

        }

        private void btnIngresarRol_Click(object sender, EventArgs e)
        {
            lblErrorRol.Visible = false;
            Usuario.RolLogueado = cbxRoles.SelectedItem.ToString();
            CargarRolesParaHotel();
        }

        private void CargarRolesParaHotel()
        {
            cbxHoteles.Enabled = true;
            lblHotel.Enabled = true;
            btnIngresarHotel.Enabled = true;

            List<string> hoteles = Database.HotelesDeUnUsuario(Usuario);

            if (hoteles == null)
            {
                lblErrorRol.Visible = true;
                lblErrorRol.Text = "Usted no tiene hoteles para el rol que selecciono";
                TrabarSeleccionHotel();
            }
            else
            {
                foreach (string hotel in hoteles)
                    cbxHoteles.Items.Add(hotel);
            }
        }

        private void btnIngresarHotel_Click(object sender, EventArgs e)
        {
            Usuario.Hotel = cbxHoteles.SelectedItem.ToString();
            this.Hide();
            VentanaMenuPrincipal mpu = new VentanaMenuPrincipal(Usuario);
            mpu.Show();
        }

        private void VentanaSeleccionRol_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }

    }
}
