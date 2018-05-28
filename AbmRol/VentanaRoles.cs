using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmRol
{
    public partial class VentanaRoles : VentanaBase
    {
        public VentanaRoles()
        {
            InitializeComponent();
        }

        private void VentanaRoles_Load(object sender, EventArgs e)
        {
            Database.completarComboBox(cbxFuncionalidades, "SELECT Funcionalidad_Funcionalidad FROM RIP.Funcionalidades", "Funcionalidad_Funcionalidad");
            Database.completarComboBox(cbxModificar, "SELECT Rol_Nombre FROM RIP.Roles", "Rol_Nombre");
            Database.completarComboBox(cbxEliminar, "SELECT Rol_Nombre FROM RIP.Roles", "Rol_Nombre");
            cbxFuncionalidades.SelectedIndex = 0;
            rbtRolActivado.Select();
        }

        private void btnAgregarFuncionalidad_Click(object sender, EventArgs e)
        {
            lbxFuncionalidades.Items.Add(cbxFuncionalidades.SelectedItem);
            cbxFuncionalidades.Items.Remove(cbxFuncionalidades.SelectedItem);
            cbxFuncionalidades.SelectedIndex = 0;
        }

        private void tabModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiarRol_Click(object sender, EventArgs e)
        {
            tbxNombreRol.Clear();
            cbxFuncionalidades.SelectedIndex = 0;
            rbtRolActivado.Select();
            lbxFuncionalidades.Items.Clear();
            cbxFuncionalidades.Items.Clear();
            Database.completarComboBox(cbxFuncionalidades, "SELECT Funcionalidad_Funcionalidad FROM RIP.Funcionalidades", "Funcionalidad_Funcionalidad");

        }

        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            string nombreRol = tbxNombreRol.Text;
            if (rbtRolActivado.Checked)
                Database.agregarRol(nombreRol, "1");
            else
                Database.agregarRol(nombreRol, "0");
            string idRol = Database.buscarIdRol(nombreRol);
            foreach (string nombreFuncionalidad in lbxFuncionalidades.Items) {
                Database.agregarFuncionalidad(idRol, nombreFuncionalidad);            
            }
        }
    }
}
