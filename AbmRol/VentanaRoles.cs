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
        //-------------------------------------- Atributos -------------------------------------

        VentanaMenuPrincipal ventanaMenu;

        //-------------------------------------- Constructores ---------------------------------

        public VentanaRoles(VentanaMenuPrincipal ventana)
        {
            InitializeComponent();
            ventanaMenu = ventana;
        }

        //-------------------------------------- Metodos para Eventos ----------------------------

        private void VentanaRoles_Load(object sender, EventArgs e)
        {
            VentanaBase.comboBoxCargar(cbxFuncionalidades, Database.funcionalidadObtenerTodas());
            actualizarVentana();
        }

        private void tbxNombreRol_TextChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }

        private void lbxFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }

        public void actualizarVentana()
        {
            VentanaBase.comboBoxReiniciar(cbxModificar, Database.rolObtenerTodos());
            VentanaBase.comboBoxReiniciar(cbxEliminar, Database.rolObtenerHabilitados());
            rbtRolActivado.Select();
        }
        
        private void btnAgregarFuncionalidad_Click(object sender, EventArgs e)
        {
            VentanaBase.botonAgregarComboBoxListBox(cbxFuncionalidades, lbxFuncionalidades);
        }

        private void btnQuitarFuncionalidad_Click(object sender, EventArgs e)
        {
            VentanaBase.botonQuitarComboBoxListBox(cbxFuncionalidades, lbxFuncionalidades);
        }

        private void btnLimpiarRol_Click(object sender, EventArgs e)
        {
            VentanaBase.listBoxLimpiar(lbxFuncionalidades);
            VentanaBase.comboBoxReiniciar(cbxFuncionalidades, Database.funcionalidadObtenerTodas());
            tbxNombreRol.Clear();
            controladorError.Clear();
            rbtRolActivado.Select();           
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
                    Database.rolHabilitadoAgregar(nombreRol);
                else 
                    Database.rolDeshabilitadoAgregar(nombreRol);
                string idRol = Database.rolObtenerId(nombreRol);
                foreach (string nombreFuncionalidad in lbxFuncionalidades.Items)
                    Database.rolAgregarFuncionalidad(idRol, nombreFuncionalidad);
                btnLimpiarRol_Click(sender, null);
                actualizarVentana();
                VentanaBase.ventanaInformarExito();
            }    
        }

        private void bntModificar_Click(object sender, EventArgs e)
        {
            VentanaModificarRol ventanaModificarRol = new VentanaModificarRol(this, cbxModificar.SelectedItem.ToString());
            ventanaModificarRol.MdiParent = ventanaMenu;
            ventanaModificarRol.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Database.rolEliminar(cbxEliminar.SelectedItem.ToString());
            VentanaBase.comboBoxReiniciar(cbxEliminar, Database.rolObtenerHabilitados());
            VentanaBase.ventanaInformarExito();
        }
    }
}
