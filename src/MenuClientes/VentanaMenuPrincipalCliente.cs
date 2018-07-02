using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.GenerarModificacionReserva;
using FrbaHotel.CancelarReserva;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Data.SqlTypes;

namespace FrbaHotel.MenuClientes
{
    public partial class VentanaMenuPrincipalCliente : VentanaBase
    {
        public VentanaMenuPrincipalCliente()
        {
            InitializeComponent();

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            new VentanaGenerarReserva().ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            new IngresarNumeroReservaModificar().ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            new VentanaCancelarReserva().ShowDialog();
        }

        private void VentanaMenuPrincipalCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void VentanaMenuPrincipalCliente_Load(object sender, EventArgs e)
        {
            SqlCommand updateReservas = Database.consultaCrear("update rip.Reservas set Reserva_EstadoReservaID=5 where YEAR(GETDATE())>=YEAR(Reserva_FechaInicio) and MONTH(GETDATE())>=MONTH(Reserva_FechaInicio) and DAY(GETDATE())>DAY(Reserva_FechaInicio) and (Reserva_EstadoReservaID!=6 or Reserva_EstadoReservaID is null)");
            Database.consultaEjecutar(updateReservas);
        }
    }
}
