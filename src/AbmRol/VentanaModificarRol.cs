using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Clases;

namespace FrbaHotel.AbmRol
{
    public partial class VentanaModificarRol : VentanaBase
    {
        #region Atributos

        VentanaRol ventanaRol {get; set;}
        Rol rol {get; set;}

        #endregion

        #region Constructores

        public VentanaModificarRol(VentanaRol ventanaRol, Rol rol)
        {
            InitializeComponent();
            this.ventanaRol = ventanaRol;
            this.rol = rol;
        }

        #endregion

        #region Modificar

        private void ventanaCrearRol()
        {
            List<string> funcionalidades = new List<string>();
            foreach (string funcionalidad in lbxFuncionalidades.Items)
                funcionalidades.Add(funcionalidad);
            rol.nombre = tbxNombreRol.Text;
            rol.estado = rbtRolActivado.Checked ? "1" : "0";
            rol.funcionalidades = funcionalidades;
        }

        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                ventanaCrearRol();
                if (Database.rolModificadoConExito(rol))
                {
                    this.Hide();
                    ventanaRol.ventanaActualizar();
                }
            }
        }

        private void btnLimpiarRol_Click(object sender, EventArgs e)
        {
            listBoxLimpiar(lbxFuncionalidades);
            comboBoxCargar(cbxFuncionalidades, Database.funcionalidadObtenerTodasEnLista());
            tbxNombreRol.Clear();
            rbtRolActivado.Select();
            controladorError.Clear();
        }

        #endregion

        #region Eventos

        private void VentanaModificarRol_Load(object sender, EventArgs e)
        {
            tbxNombreRol.Text = rol.nombre;
            listBoxCargar(lbxFuncionalidades, rol.funcionalidades);
            comboBoxCargar(cbxFuncionalidades, Database.rolObtenerFuncionalidadesFaltantes(rol));
            if (bool.Parse(rol.estado))
                rbtRolActivado.Select();
            else
                rbtRolDesactivado.Select();          
        }

        private void tbxNombreRol_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
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

        #endregion
    }
}
