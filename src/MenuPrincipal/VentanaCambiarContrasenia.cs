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
    public partial class VentanaCambiarContrasenia : VentanaBase
    {
        //-------------------------------------- Atributos -------------------------------------

        Sesion sesion { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public VentanaCambiarContrasenia(Sesion sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }

        //-------------------------------------- Metodos para Ventana -------------------------------------

        private void VentanaAjustesDeCuenta_Load(object sender, EventArgs e)
        {
            tbxNombreUsuario.Text = sesion.usuario.nombre;
        }

        private void btnGuardarContrasenia_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                sesion.usuario.contrasenia = tbxContrasenia.Text;
                Database.sesionModificarContrasenia(sesion);
            }               
        }

        private void tbxContrasenia_TextChanged (object sender, EventArgs e)
        {
            controladorError.Clear();
        }
    }
}
