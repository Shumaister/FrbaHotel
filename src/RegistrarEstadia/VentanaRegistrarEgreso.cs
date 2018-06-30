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

namespace FrbaHotel.RegistrarEstadia
{
    public partial class VentanaRegistrarEgreso : VentanaBase
    {
        public Estadia estadia { get; set; }
        public Usuario usuario { get; set; }

        public VentanaRegistrarEgreso(Estadia estadia, Usuario usuario)
        {
            InitializeComponent();
            this.estadia = estadia;
            this.usuario = usuario;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            estadia.checkOutUsuarioID = Database.usuarioObtenerID(usuario);
            Database.estadiaEgresoExitoso(estadia);
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
