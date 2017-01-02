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
        public Reserva reserva { get; set; }
        public Usuario usuario { get; set; }

        public VentanaRegistrarEgreso(Reserva reserva, Usuario usuario)
        {
            InitializeComponent();
            this.reserva = reserva;
            this.usuario = usuario;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Estadia estadia = new Estadia();
            estadia.reservaID = reserva.Codigo;
            estadia.checkOutUsuarioID = Database.usuarioObtenerID(usuario);
            Database.estadiaAgregarEgreso(estadia);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
