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
using FrbaHotel.Clases;
using FrbaHotel.Login;

namespace FrbaHotel.AbmRol
{ 
    public partial class VentanaRol : VentanaBase
    {
        #region Atributos

        public VentanaMenuPrincipal ventanaMenuPrincipal {get; set;}

        #endregion

        #region Constructores

        public VentanaRol(VentanaMenuPrincipal ventanaMenuPrincipal)
        {
            InitializeComponent();
            this.ventanaMenuPrincipal = ventanaMenuPrincipal;
        }

        #endregion

        #region Agregar

        private Rol ventanaCrearRolParaAgregar()
        {
            List<string> funcionalidades = new List<string>();
            foreach (string funcionalidad in lbxFuncionalidades.Items)
                funcionalidades.Add(funcionalidad);
            Rol rol = new Rol(tbxNombreRol.Text);
            rol.funcionalidades = funcionalidades;
            return rol;
        }

        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(tabAgregar, controladorError))
            {
                Rol rol = ventanaCrearRolParaAgregar();
                if (Database.rolAgregadoConExito(rol))
                    ventanaActualizar();
            }
        }

        private void btnLimpiarRol_Click(object sender, EventArgs e)
        {
            listBoxLimpiar(lbxFuncionalidades);
            comboBoxCargar(cbxFuncionalidades, Database.funcionalidadObtenerTodasEnLista());
            tbxNombreRol.Clear();
            controladorError.Clear();
        }

        #endregion

        #region Modificar

        private Rol ventanaCrearRolParaModificar(DataGridViewCellEventArgs e)
        {
            string rolID = dgvModificarRoles.Rows[e.RowIndex].Cells["Rol_ID"].Value.ToString();
            string rolNombre = dgvModificarRoles.Rows[e.RowIndex].Cells["Rol_Nombre"].Value.ToString();
            string rolEstado = dgvModificarRoles.Rows[e.RowIndex].Cells["Rol_Estado"].Value.ToString();
            Rol rol = new Rol(rolID, rolNombre, null, rolEstado);
            rol.funcionalidades = Database.rolObtenerFuncionalidades(rol);
            return rol;
        }

        private void dgvModificarRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Rol rol = ventanaCrearRolParaModificar(e);
                VentanaModificarRol ventanaModificarRol = new VentanaModificarRol(this, rol);
                ventanaModificarRol.ShowDialog();
            }
        }

        public void ventanaMenuPrincipalActualizar()
        {
            if(ventanaMenuPrincipal.sesion.rol.estado == "0")
            {
                this.Hide();
                ventanaMenuPrincipal.Hide();
                ventanaInformarError("El rol fue deshabilitado");
                new VentanaLogin().Show();
                return;
            }
            if (!ventanaMenuPrincipal.sesion.rol.funcionalidades.Contains("Roles"))
            {
                this.Hide();
                ventanaInformarError("El rol ya no posee la funcionalidad 'Roles'");
            }
            ventanaMenuPrincipal.VentanaMenuPrincipal_Load(null, null);
        }

        #endregion

        #region Eliminar

        private Rol ventanaCrearRolParaEliminar(DataGridViewCellEventArgs e)
        {
            string rolID = dgvEliminarRoles.Rows[e.RowIndex].Cells["Rol_ID"].Value.ToString();
            return new Rol(rolID, null, null, null);
        }

        private void dgvEliminarRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Rol rol = ventanaCrearRolParaEliminar(e);
                Database.rolEliminadoConExito(rol);
                ventanaActualizar();
                if(ventanaMenuPrincipal.sesion.rol.id == rol.id)
                {
                    this.Hide();
                    ventanaMenuPrincipal.Hide();
                    ventanaInformarError("El rol fue deshabilitado");
                    new VentanaLogin().Show();
                }
            }
        }

        #endregion

        #region Eventos

        private void VentanaRoles_Load(object sender, EventArgs e)
        {           
            ventanaActualizar();
            ventanaOcultarColumnas();
            comboBoxCargar(cbxFuncionalidades, Database.funcionalidadObtenerTodasEnLista());
            dataGridViewAgregarBotonModificar(dgvModificarRoles);
            dataGridViewAgregarBotonEliminar(dgvEliminarRoles);
        }

        public void ventanaActualizar()
        {
            dataGridViewCargar(dgvModificarRoles, Database.rolObtenerTodosEnTabla());
            dataGridViewCargar(dgvEliminarRoles, Database.rolObtenerHabilitadosEnTabla());
        }

        private void ventanaOcultarColumnas()
        {
            dgvModificarRoles.Columns["Rol_ID"].Visible = false;
            dgvModificarRoles.Columns["Rol_Estado"].Visible = false;
            dgvEliminarRoles.Columns["Rol_ID"].Visible = false;
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
    }
}
