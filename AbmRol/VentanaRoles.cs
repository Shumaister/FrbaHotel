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

        public Usuario usuario { get; set; }

        //-------------------------------------- Constructores ---------------------------------

        public VentanaRoles(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        //-------------------------------------- Metodos para Ventana ----------------------------

        public void ventanaActualizar()
        {
            dataGridViewCargar(dgvModificarRoles, Database.rolObtenerTodosTabla());
            dataGridViewCargar(dgvEliminarRoles, Database.rolObtenerHabilitadosTabla());
        }

        //-------------------------------------- Metodos para Eventos ----------------------------

        private void VentanaRoles_Load(object sender, EventArgs e)
        {
            comboBoxCargar(cbxFuncionalidades, Database.funcionalidadObtenerTodas());
            rbtRolActivado.Select();
            ventanaActualizar();
            dataGridViewAgregarBotonModificar(dgvModificarRoles);
            dataGridViewAgregarBotonEliminar(dgvEliminarRoles);
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
            controladorError.Clear();
            rbtRolActivado.Select();           
        }

        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(tabAgregar, controladorError))
            {
                string nombreRol = tbxNombreRol.Text;
                if (Database.rolNombreYaExiste(nombreRol))
                {
                    ventanaInformarError("Un rol ya posee el mismo nombre");
                    return;
                }
                if (rbtRolActivado.Checked)
                    Database.rolHabilitadoAgregar(nombreRol);
                else 
                    Database.rolDeshabilitadoAgregar(nombreRol);
                string idRol = Database.rolBuscarID(nombreRol);
                foreach (string nombreFuncionalidad in lbxFuncionalidades.Items)
                    Database.rolAgregarFuncionalidad(idRol, nombreFuncionalidad);
                btnLimpiarRol_Click(sender, null);
                ventanaActualizar();
                ventanaInformarExito();
            }    
        }

        private void dgvModificarRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string nombreRol = dgvModificarRoles.Rows[e.RowIndex].Cells["Rol_Nombre"].Value.ToString();
                VentanaModificarRol ventanaModificarRol = new VentanaModificarRol(this, nombreRol);
                ventanaModificarRol.ShowDialog();
            }          
        }

        private void dgvEliminarRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string nombreRol = dgvModificarRoles.Rows[e.RowIndex].Cells["Rol_Nombre"].Value.ToString();
                Database.rolEliminar(nombreRol);
                ventanaActualizar();
                Database.usuarioActualizarDatos(usuario);
                VentanaBase.ventanaInformarExito();
            }
        }
    }
}
