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
        //-------------------------------------- Atributos -----------------------------------

        VentanaRoles ventanaRoles;
        string nombreRolActual;

        //-------------------------------------- Constructores -----------------------------------

        public VentanaModificarRol(VentanaRoles ventana, string nombre)
        {
            InitializeComponent();
            ventanaRoles = ventana;
            nombreRolActual = nombre;
        }

        //-------------------------------------- Metodos para Eventos -----------------------------------

        private void VentanaModificarRol_Load(object sender, EventArgs e)
        {
            tbxNombreRol.Text = nombreRolActual;
            listBoxCargar(lbxFuncionalidades, Database.rolObtenerFuncionalidades(nombreRolActual));
            comboBoxCargar(cbxFuncionalidades, Database.rolObtenerFuncionalidadesFaltantes(nombreRolActual));
            if (Database.rolEstaHabilitado(nombreRolActual))
                rbtRolActivado.Select();
            else
                rbtRolDesactivado.Select();
        }

        private void tbxNombreRol_TextChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }

        private void lbxFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }

        private void btnAgregarFuncionalidad_Click(object sender, EventArgs e)
        {
            botonAgregarComboBoxListBox(cbxFuncionalidades, lbxFuncionalidades);
        }

        private void btnQuitarFuncionalidad_Click(object sender, EventArgs e)
        {
            botonQuitarComboBoxListBox(cbxFuncionalidades, lbxFuncionalidades);
        }

        private void btnLimpiarRol_Click(object sender, EventArgs e)
        {
            listBoxLimpiar(lbxFuncionalidades);
            comboBoxCargar(cbxFuncionalidades, Database.funcionalidadObtenerTodas());
            tbxNombreRol.Clear();
            rbtRolActivado.Select();
            controladorError.Clear();
        }

        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            if (ventanaCamposTodosCompletos(this, controladorError))
            {
                string nombreRolNuevo = tbxNombreRol.Text;
                if (Database.rolNombreYaExiste(nombreRolNuevo) && nombreRolNuevo != nombreRolActual)
                {
                    ventanaInformarError("Un rol ya posee el mismo nombre");
                    return;
                }
                if (rbtRolActivado.Checked)
                    Database.rolHabilitadoModificar(nombreRolActual, nombreRolNuevo);
                else
                    Database.rolDeshabilitadoModificar(nombreRolActual, nombreRolNuevo);
                string idRol = Database.rolObtenerId(nombreRolNuevo);
                foreach (string nombreFuncionalidad in lbxFuncionalidades.Items)
                        Database.rolAgregarFuncionalidad(idRol, nombreFuncionalidad);
                ventanaRoles.actualizarVentana();
                nombreRolActual = nombreRolNuevo;
                ventanaInformarExito();
            }
        }
    }
}
