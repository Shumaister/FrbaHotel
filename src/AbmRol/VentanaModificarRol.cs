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
        bool HabilitadoDesdeInicio { get; set; }

        #endregion

        #region Constructores

        public VentanaModificarRol(VentanaRol ventanaRol, Rol rol)
        {
            InitializeComponent();
            this.ventanaRol = ventanaRol;
            this.rol = rol;
            this.HabilitadoDesdeInicio = false;
        }

        #endregion

        #region Modificar

        private void ventanaCrearRol()
        {
            List<string> funcionalidades = new List<string>();
            foreach (string funcionalidad in lbxFuncionalidades.Items)
                funcionalidades.Add(funcionalidad);
            rol.nombre = tbxNombreRol.Text;
            rol.estado = btnHabilitar.Enabled? "0" : "1";
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
                    if (rol.id == ventanaRol.ventanaMenuPrincipal.sesion.rol.id)
                    {
                        ventanaRol.ventanaMenuPrincipal.sesion.rol = this.rol;
                        ventanaRol.ventanaMenuPrincipalActualizar();
                    }
                }
            }
        }

        private void btnLimpiarRol_Click(object sender, EventArgs e)
        {
            listBoxLimpiar(lbxFuncionalidades);
            comboBoxCargar(cbxFuncionalidades, Database.funcionalidadObtenerTodasEnLista());
            tbxNombreRol.Clear();
            if (!this.HabilitadoDesdeInicio)
            {
                buttonHabilitarActivar(btnHabilitar);
            }
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
            {
                this.HabilitadoDesdeInicio = true;
                buttonHabilitarDesactivar(btnHabilitar);
            }      
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
            buttonAgregarComboBoxListBox(cbxFuncionalidades, lbxFuncionalidades);
        }

        private void btnQuitarFuncionalidad_Click(object sender, EventArgs e)
        {
            buttonQuitarComboBoxListBox(cbxFuncionalidades, lbxFuncionalidades);
        }

        #endregion

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            buttonHabilitarDesactivar(btnHabilitar);
        }
    }
}
