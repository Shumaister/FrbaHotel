using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Menus;

namespace FrbaHotel.AbmRol
{
    public partial class VentanaRoles : VentanaBase
    {
        VentanaMenuPrincipal ventanaMenu;

        public VentanaRoles(VentanaMenuPrincipal ventana)
        {
            InitializeComponent();
            ventanaMenu = ventana;
        }

        private void VentanaRoles_Load(object sender, EventArgs e)
        {
            VentanaBase.comboBoxCargar(cbxFuncionalidades, Database.funcionalidadObtenerTodas());
            cbxFuncionalidades.Sorted = true;
            cbxFuncionalidades.SelectedIndex = 0;
            actualizarVentana();
        }

        public void actualizarVentana()
        {
            cbxModificar.Items.Clear();
            cbxEliminar.Items.Clear(); ;
            VentanaBase.comboBoxCargar(cbxModificar, Database.rolObtenerTodos());
#warning En eliminar mostrar solo roles habilitados o todos?
            VentanaBase.comboBoxCargar(cbxEliminar, Database.rolObtenerHabilitados());
            cbxModificar.SelectedIndex = 0;
            cbxEliminar.SelectedIndex = 0;
            rbtRolActivado.Select();
        }

        //-------------------------------------- Metodos para Agregar -------------------------------------

        private void btnAgregarFuncionalidad_Click(object sender, EventArgs e)
        {
            if (cbxFuncionalidades.SelectedItem != null)
            {
                lbxFuncionalidades.Items.Add(cbxFuncionalidades.SelectedItem);
                lbxFuncionalidades.SelectedIndex = 0;
                cbxFuncionalidades.Items.Remove(cbxFuncionalidades.SelectedItem);
                if (cbxFuncionalidades.Items.Count > 0)
                    cbxFuncionalidades.SelectedIndex = 0;
                else
                    cbxFuncionalidades.ResetText();
                
            }
        }

        private void btnQuitarRol_Click(object sender, EventArgs e)
        {
            if (lbxFuncionalidades.SelectedItem != null)
            {
                cbxFuncionalidades.Items.Add(lbxFuncionalidades.SelectedItem);
                cbxFuncionalidades.Sorted = true;
                lbxFuncionalidades.Items.Remove(lbxFuncionalidades.SelectedItem);
                cbxFuncionalidades.SelectedIndex = 0;
                if (lbxFuncionalidades.Items.Count > 0)
                    lbxFuncionalidades.SelectedIndex = 0;
            }
        }

        private void btnLimpiarRol_Click(object sender, EventArgs e)
        {
            tbxNombreRol.Clear();
            lbxFuncionalidades.Items.Clear();
            cbxFuncionalidades.Items.Clear();
            controladorError.Clear();
            rbtRolActivado.Select();
            //VER SI hACE FALTA
            VentanaBase.comboBoxCargar(cbxFuncionalidades, Database.funcionalidadObtenerTodas());
            cbxFuncionalidades.SelectedIndex = 0;
        }

        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            if (VentanaBase.ventanaCamposTodosCompletos(tabAgregar, controladorError))
            {
                string nombreRol = tbxNombreRol.Text;
                if (Database.rolNombreYaExiste(nombreRol))
                {
                    VentanaBase.ventanaInformarError("Un rol ya posee el mismo nombre");
                    return;
                }
                if (rbtRolActivado.Checked)
                    Database.rolAgregar(nombreRol, "1");
                else 
                    Database.rolAgregar(nombreRol, "0");
                string idRol = Database.rolObtenerId(nombreRol);
                foreach (string nombreFuncionalidad in lbxFuncionalidades.Items)
                    Database.rolAgregarFuncionalidad(idRol, nombreFuncionalidad);
                btnLimpiarRol_Click(sender, null);
                actualizarVentana();
                VentanaBase.ventanaInformarExito();
            }    
        }

        private void tbxNombreRol_TextChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }


        private void lbxFuncionalidades_ControlAdded(object sender, ControlEventArgs e)
        {
            
        }

        //-------------------------------------- Metodos para Modificar -------------------------------------

        private void bntModificar_Click(object sender, EventArgs e)
        {
            VentanaModificarRol ventanaModificarRol = new VentanaModificarRol(this, cbxModificar.SelectedItem.ToString());
            ventanaModificarRol.MdiParent = ventanaMenu;
            ventanaModificarRol.Show();

        }

        //-------------------------------------- Metodos para Eliminar -------------------------------------

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Database.rolEliminar(cbxEliminar.SelectedItem.ToString());
#warning En eliminar mostrar solo roles habilitados o todos?
            VentanaBase.comboBoxCargar(cbxEliminar, Database.rolObtenerHabilitados());
            cbxEliminar.SelectedIndex = 0;
            VentanaBase.ventanaInformarExito();
        }

        private void lbxFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }

    }
}
