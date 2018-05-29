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

        public void VentanaRoles_Load(object sender, EventArgs e)
        {
            Database.funcionalidadObtenerTodas(cbxFuncionalidades);
            Database.obtenerRolesTotales(cbxModificar);
#warning En eliminar mostrar solo roles habilitados o todos?
            Database.obtenerRolesHabilitados(cbxEliminar);
            cbxFuncionalidades.SelectedIndex = 0;
            rbtRolActivado.Select();
        }

        private void actualizarVentana()
        {
            cbxModificar.Items.Clear();
            cbxEliminar.Items.Clear(); ;
            Database.obtenerRolesTotales(cbxModificar);
#warning En eliminar mostrar solo roles habilitados o todos?
            Database.obtenerRolesHabilitados(cbxEliminar);
        }

        //-------------------------------------- Metodos para Agregar -------------------------------------

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
            Database.funcionalidadObtenerTodas(cbxFuncionalidades);
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
                    Database.rolAgregarFuncionalidad(idRol, nombreFuncionalidad);
                btnLimpiarRol_Click(sender, null);
                actualizarVentana();
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

        //-------------------------------------- Metodos para Modificar -------------------------------------

        private void bntModificar_Click(object sender, EventArgs e)
        {
            new VentanaModificarRol(this, cbxModificar.SelectedItem.ToString()).Show();
        }

        //-------------------------------------- Metodos para Eliminar -------------------------------------

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Database.eliminarRol(cbxEliminar.SelectedItem.ToString());
#warning En eliminar mostrar solo roles habilitados o todos?
            Database.obtenerRolesHabilitados(cbxEliminar);
            VentanaBase.informarExito();
        }
    }
}
