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
        string nombreRolActual;

        public VentanaModificarRol(VentanaRoles ventana, string nombre)
        {
            InitializeComponent();
            ventanaRoles = ventana;
            nombreRolActual = nombre;
        }

        private void VentanaModificarRol_Load(object sender, EventArgs e)
        {
            tbxNombreRol.Text = nombreRolActual;
            VentanaBase.listBoxCargar(lbxFuncionalidades, Database.rolObtenerFuncionalidades(nombreRolActual));
            VentanaBase.comboBoxCargar(cbxFuncionalidades, Database.rolObtenerFuncionalidadesFaltantes(nombreRolActual));
            cbxFuncionalidades.SelectedIndex = 0;
            if(Database.rolEstaHabilitado(nombreRolActual))
                rbtRolActivado.Select();
            else
                rbtRolDesactivado.Select();
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
            VentanaBase.comboBoxCargar(cbxFuncionalidades, Database.funcionalidadObtenerTodas());
            cbxFuncionalidades.SelectedIndex = 0;
        }

        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            string nombreRolNuevo = tbxNombreRol.Text;
            string idRol = Database.rolObtenerId(nombreRolNuevo);
            if (Database.rolNombreYaExiste(nombreRolNuevo) && nombreRolNuevo != nombreRolActual)
            {
                VentanaBase.ventanaInformarError("Un rol ya posee el mismo nombre");
                return;
            }
            if (VentanaBase.ventanaCamposTodosCompletos(this, controladorError))
            {
                if (rbtRolActivado.Checked)
                    Database.rolModificar(nombreRolActual, nombreRolNuevo, "1");
                else
                    Database.rolModificar(nombreRolActual, nombreRolNuevo, "0");
                foreach (string nombreFuncionalidad in lbxFuncionalidades.Items)
                        Database.rolAgregarFuncionalidad(idRol, nombreFuncionalidad);
                this.Close();
                ventanaRoles.VentanaRoles_Load(sender, null);
                VentanaBase.ventanaInformarExito();
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
