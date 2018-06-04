using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Menus
{
    public partial class VentanaAjustesDeCuenta : VentanaBase
    {
        //-------------------------------------- Atributos -------------------------------------

        string nombreUsuario { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public VentanaAjustesDeCuenta(string nombre)
        {
            InitializeComponent();
            nombreUsuario = nombre;
        }

        //-------------------------------------- Metodos para Ventana -------------------------------------

        private void VentanaAjustesDeCuenta_Load(object sender, EventArgs e)
        {
            tbxNombreUsuario.Text = nombreUsuario;
        }

        private void btnGuardarContrasenia_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                string nuevaContrasenia = tbxContrasenia.Text;
                Database.usuarioModificarContrasenia(nombreUsuario, nuevaContrasenia);
                ventanaInformarExito();
            }
                
        }

        private void tbxContrasenia_TextChanged (object sender, EventArgs e)
        {
            controladorError.Clear();
        }
    }
}
