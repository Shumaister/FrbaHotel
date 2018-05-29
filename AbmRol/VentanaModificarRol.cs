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
    public partial class VentanaModificarRol : VentanaBase
    {
        VentanaRoles ventanaRoles;

        public VentanaModificarRol(VentanaRoles ventana)
        {
            InitializeComponent();
            ventanaRoles = ventana;
        }

        private void VentanaModificarRol_Load(object sender, EventArgs e)
        {
            Database.obtenerFuncionalidades(cbxFuncionalidades);
            cbxFuncionalidades.SelectedIndex = 0;
            rbtRolActivado.Select();
        }

        private void btnAgregarFuncionalidad_Click(object sender, EventArgs e)
        {
            lbxFuncionalidades.Items.Add(cbxFuncionalidades.SelectedItem);
            cbxFuncionalidades.Items.Remove(cbxFuncionalidades.SelectedItem);
            cbxFuncionalidades.SelectedIndex = 0;
        }

        private void btnQuitarRol_Click(object sender, EventArgs e)
        {
            if (lbxFuncionalidades.SelectedItem != null)
            {
                cbxFuncionalidades.Items.Add(lbxFuncionalidades.SelectedItem);
                lbxFuncionalidades.Items.Remove(lbxFuncionalidades.SelectedItem);
            }
        }

        private void btnLimpiarRol_Click(object sender, EventArgs e)
        {
            tbxNombreRol.Clear();
            rbtRolActivado.Select();
            lbxFuncionalidades.Items.Clear();
            cbxFuncionalidades.Items.Clear();
            controladorError.Clear();
            Database.obtenerFuncionalidades(cbxFuncionalidades);
            cbxFuncionalidades.SelectedIndex = 0;
        }

        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            string nombreRol = tbxNombreRol.Text;
            if (Database.rolNombreYaExiste(nombreRol))
            {
                VentanaBase.informarError("Un rol ya posee el mismo nombre");
                return;
            }
            if (VentanaBase.camposEstanCompletos(this, controladorError))
            {
                if (rbtRolActivado.Checked)
                    Database.agregarRol(nombreRol, "1");
                else
                    Database.agregarRol(nombreRol, "0");
                string idRol = Database.buscarIdRol(nombreRol);
                foreach (string nombreFuncionalidad in lbxFuncionalidades.Items)
                    Database.agregarFuncionalidad(idRol, nombreFuncionalidad);
                this.Close();
                ventanaRoles.VentanaRoles_Load(sender, null);
                VentanaBase.informarExito();
            }
        }

        private void tbxNombreRol_TextChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }

        private void lbxFuncionalidades_DataSourceChanged(object sender, EventArgs e)
        {
#warning El list box no borra el aviso de error provider cuando se lo modifica
            controladorError.Clear();
        }

    }
}
