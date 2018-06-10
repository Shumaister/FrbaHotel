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
        //-------------------------------------- Atributos -----------------------------------

        VentanaRol ventanaRol {get; set;}
        Rol rol {get; set;}

        //-------------------------------------- Constructores -----------------------------------

        public VentanaModificarRol(VentanaRol ventanaRol, Rol rol)
        {
            InitializeComponent();
            this.ventanaRol = ventanaRol;
            this.rol = rol;
        }

        //-------------------------------------- Metodos para Eventos -----------------------------------

        private void VentanaModificarRol_Load(object sender, EventArgs e)
        {
            tbxNombreRol.Text = rol.nombre;
            listBoxCargar(lbxFuncionalidades, rol.funcionalidades);
            comboBoxCargar(cbxFuncionalidades, Database.rolObtenerFuncionalidadesFaltantes(rol));
            if (rol.estado == "1")
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
            comboBoxCargar(cbxFuncionalidades, Database.funcionalidadObtenerListaRegistros());
            tbxNombreRol.Clear();
            rbtRolActivado.Select();
            controladorError.Clear();
        }

        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                List<string> funcionalidades = new List<string>();
                foreach (string funcionalidad in lbxFuncionalidades.Items)
                    funcionalidades.Add(funcionalidad);
                Rol rolModificado = new Rol(tbxNombreRol.Text);
                rolModificado.funcionalidades = funcionalidades;
                if (rbtRolActivado.Checked)
                    rolModificado.estado = "1";
                else
                    rolModificado.estado = "0";
                if (Database.rolModificadoConExito(rol, rolModificado))
                {
                    this.Hide();
                    ventanaRol.ventanaActualizar();
                    Database.sesionActualizarDatos(ventanaRol.sesion);
                }
            }
        }
    }
}
