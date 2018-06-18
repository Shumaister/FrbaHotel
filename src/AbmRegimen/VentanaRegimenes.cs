using FrbaHotel.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmRegimen
{
    public partial class VentanaRegimenes : VentanaBase
    {
        public VentanaRegimenes()
        {
            InitializeComponent();
            VentanaActualizar();
            VentanaOcultarColumnas();
            dataGridViewAgregarBotonModificar(dgvModificarRegimenes);
            dataGridViewAgregarBotonEliminar(dgvEliminarRegimenes);
        }

        #region Metodos

        public void VentanaActualizar()
        {
            dataGridViewCargar(dgvModificarRegimenes, Database.RegimenesObtenerTodosEnTabla());
            dataGridViewCargar(dgvEliminarRegimenes, Database.RegimenesObtenerHabilitadosEnTabla());
        }

        private void VentanaOcultarColumnas()
        {
            dgvModificarRegimenes.Columns["Regimen_ID"].Visible = false;
            dgvEliminarRegimenes.Columns["Regimen_ID"].Visible = false;
        }

        private Regimen CrearRegimen()
        {
            return new Regimen(this.tbxDescipcionRegimen.Text, this.tbxPrecioRegimen.Text);
        }

        private void LimpiarCampos()
        {
            this.tbxPrecioRegimen.Clear();
            this.tbxDescipcionRegimen.Clear();
        }

        private Regimen RegimenAEliminar(DataGridViewCellEventArgs e)
        {
            return new Regimen(dgvEliminarRegimenes.Rows[e.RowIndex].Cells["Regimen_ID"].Value.ToString());
        }

        #endregion


        #region Botones

        private void btnLimpiarRol_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(tabAgregar, controladorError))
            {
                Regimen regimen = CrearRegimen();
            
                if (Database.RegimenAgregadoConExito(regimen)) 
                    VentanaActualizar();

                LimpiarCampos();
            }
        }

        #endregion


        #region Eventos

        private void tbxNumeroCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void dgvModificarRegimenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // ACA VA LA NUEVA VENTANA PARA MODIFICAR LOS REGIMENES
                //Rol rol = ventanaCrearRolParaModificar(e);
                //VentanaModificarRol ventanaModificarRol = new VentanaModificarRol(this, rol);
                //ventanaModificarRol.ShowDialog();
            }
        }

        private void dgvEliminarRegimenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Database.RegimenEliminadoConExito(RegimenAEliminar(e));
                VentanaActualizar();
            }
        }

        #endregion

        #region LosCreeSinQuererUps

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        #endregion



    }
}
