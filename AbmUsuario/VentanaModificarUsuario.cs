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
    public partial class VentanaModificarUsuario : VentanaBase
    {
        //-------------------------------------- Constructores -------------------------------------

        public VentanaModificarUsuario()
        {
            InitializeComponent();
        }

        //-------------------------------------- Metodos para Eventos -------------------------------------

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

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            if (VentanaBase.ventanaCamposTodosCompletos(this, controladorError))
                MessageBox.Show("IZI");
        }
    }
}
