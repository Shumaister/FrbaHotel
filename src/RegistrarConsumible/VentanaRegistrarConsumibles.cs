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

namespace FrbaHotel.RegistrarConsumible
{
    public partial class VentanaRegistrarConsumibles : VentanaBase
    {
        public Consumido consumido { get; set; }

        public VentanaRegistrarConsumibles(Consumido consumido)
        {
            InitializeComponent();
            this.consumido = consumido;
        }

        private void btnAgregarConsumible_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                dgvConsumibles.Rows.Add(cbxConsumibles.SelectedItem.ToString(), tbxCantidad.Text);
                ventanaControlarComboBox(cbxConsumibles);
            }
        }

        private void dgvConsumibles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                cbxConsumibles.Items.Add(dgvConsumibles.Rows[e.RowIndex].Cells["Consumible_Descripcion"].Value.ToString());
                cbxConsumibles.Sorted = true;
                cbxConsumibles.SelectedIndex = 0;
                dgvConsumibles.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void ventanaControlarComboBox(ComboBox comboBox)
        {
            if (comboBox.SelectedItem != null)
            {
                comboBox.Items.Remove(comboBox.SelectedItem);
                if (comboBox.Items.Count > 0)
                    comboBox.SelectedIndex = 0;
                else
                    comboBox.ResetText();
            }
        }

        private void btnLimpiarConsumibles_Click(object sender, EventArgs e)
        {
            tbxCantidad.Clear();
            dataGridViewCargar(dgvConsumibles, Database.consumidoObtenerDeEstadia(consumido));
            dgvConsumibles.DataSource = null;
        }

        private void btnGuardarConsumibles_Click(object sender, EventArgs e)
        {
            foreach (DataRow fila in dgvConsumibles.Rows)
            {
                consumido.consumible = (string)fila["Consumible_Descripcion"];
                consumido.cantidad = (string)fila["Consumido_Cantidad"];
                Database.consumidoAgregar(consumido);
            }       
        }

        private void VentanaRegistrarConsumibles_Load(object sender, EventArgs e)
        {
            comboBoxCargar(cbxConsumibles, Database.consumibleObtenerTodosEnLista());
            dataGridViewCargar(dgvConsumibles, Database.consumidoObtenerDeEstadia(consumido));
            dataGridViewAgregarBoton(dgvConsumibles, "Quitar");
        }
    }
}
