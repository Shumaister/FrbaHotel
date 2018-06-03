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
            dataGridViewCargar(dgvModificarUsuarios, Database.usuarioObtenerTodos());
            dataGridViewAgregarBotonModificar(dgvModificarUsuarios);
            dataGridViewAgregarBotonEliminar(dgvEliminarUsuarios);
            comboBoxCargar(cbxRoles, Database.rolObtenerTodos());
            comboBoxCargar(cbxHoteles, Database.hotelObtenerTodos());
            comboBoxCargar(cbxTipoDocumento, Database.documentoObtenerTipos());
        }

        private void dgvModificarUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                new VentanaModificarUsuario().Show();
        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            botonAgregarComboBoxListBox(cbxRoles, lbxRoles);
        }

        private void btnQuitarRol_Click(object sender, EventArgs e)
        {
            botonQuitarComboBoxListBox(cbxRoles, lbxRoles);
        }

        private void btnAgregarHotel_Click(object sender, EventArgs e)
        {
            botonAgregarComboBoxListBox(cbxHoteles, lbxHoteles);
        }

        private void btnQuitarHotel_Click(object sender, EventArgs e)
        {
            botonQuitarComboBoxListBox(cbxHoteles, lbxHoteles);
        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(pagAgregar, controladorError))
                MessageBox.Show("IZI");
        }

        private void tbxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaEmail(e);
        }

        private void tbxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbxDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
