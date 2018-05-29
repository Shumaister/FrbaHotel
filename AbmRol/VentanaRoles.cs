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
            Database.obtenerFuncionalidades(cbxFuncionalidades);
            Database.obtenerRolesTotales(cbxModificar);
            //En eliminar mostrar solo roles los habilitados o todos?
            Database.obtenerRolesHabilitados(cbxEliminar);
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

        private void tabModificar_Click(object sender, EventArgs e)
        {

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
            if (VentanaBase.camposEstanCompletos(tabAgregar, controladorError))
            { 
                if (rbtRolActivado.Checked)
                    Database.agregarRol(nombreRol, "1");
                else
                    Database.agregarRol(nombreRol, "0");
                string idRol = Database.buscarIdRol(nombreRol);
                foreach (string nombreFuncionalidad in lbxFuncionalidades.Items)
                    Database.agregarFuncionalidad(idRol, nombreFuncionalidad);
                cbxModificar.Items.Clear();
                cbxEliminar.Items.Clear(); ;
                Database.obtenerRolesTotales(cbxModificar);
                //En eliminar mostrar solo los roles habilitados o todos?
                Database.obtenerRolesHabilitados(cbxEliminar);
                btnLimpiarRol_Click(sender, null);
                VentanaBase.informarExito();
            }    
        }

        private void tbxNombreRol_TextChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }

        private void lbxFuncionalidades_DataSourceChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Database.eliminarRol(cbxEliminar.SelectedItem.ToString());
            Database.obtenerRolesHabilitados(cbxEliminar);
            VentanaBase.informarExito();
        }

        private void bntModificar_Click(object sender, EventArgs e)
        {
            
        }

    }
}
