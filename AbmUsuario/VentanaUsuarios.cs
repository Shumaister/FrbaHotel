using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmUsuario
{
    public partial class VentanaUsuarios : VentanaBase
    {
        //-------------------------------------- Constructores -------------------------------------

        public VentanaUsuarios()
        {
            InitializeComponent();
        }

        //-------------------------------------- Metodos para Eventos -------------------------------------

        private void VentanaUsuarios_Load(object sender, EventArgs e)
        {
            VentanaBase.dataGridViewCargar(dgvModificarUsuarios, Database.usuarioObtenerTodos());
            VentanaBase.dataGridViewAgregarBotonModificar(dgvModificarUsuarios);
            VentanaBase.dataGridViewAgregarBotonEliminar(dgvEliminarUsuarios);
            VentanaBase.comboBoxCargar(cbxRoles, Database.rolObtenerTodos());
            VentanaBase.comboBoxCargar(cbxHoteles, Database.hotelObtenerTodos());
            VentanaBase.comboBoxCargar(cbxTipoDocumento, Database.documentoObtenerTipos());
        }

        private void dgvModificarUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                MessageBox.Show("GG");
            }
        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            VentanaBase.botonAgregarComboBoxListBox(cbxRoles, lbxRoles);
        }

        private void btnQuitarRol_Click(object sender, EventArgs e)
        {
            VentanaBase.botonQuitarComboBoxListBox(cbxRoles, lbxRoles);
        }

        private void btnAgregarHotel_Click(object sender, EventArgs e)
        {
            VentanaBase.botonAgregarComboBoxListBox(cbxHoteles, lbxHoteles);
        }

        private void btnQuitarHotel_Click(object sender, EventArgs e)
        {
            VentanaBase.botonQuitarComboBoxListBox(cbxHoteles, lbxHoteles);
        }
    }
}
