using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.AbmCliente;
using FrbaHotel.Clases;

namespace FrbaHotel.RegistrarEstadia
{
    public partial class VentanaRegistrarIngreso : VentanaBase
    {
        public Sesion sesion { get; set; }
        public Reserva reserva { get; set; }
        public Cliente huesped { get; set; }
        public List<string> huespedes { get; set; }
        
        public VentanaRegistrarIngreso(Reserva reserva, Sesion sesion)
        {
            InitializeComponent();
            this.reserva = reserva;
            this.sesion = sesion;
            this.huespedes = new List<string>();
        }

        private void VentanaRegistrarIngreso_Load(object sender, EventArgs e)
        {
            lblClienteNombre.Text = reserva.Cliente.persona.nombre;
            lblClienteApellido.Text = reserva.Cliente.persona.apellido;
            lblTipoDocumento.Text = reserva.Cliente.persona.tipoDocumento;
            lblClienteDocumento.Text = reserva.Cliente.persona.numeroDocumento;
            lblClienteEmail.Text = reserva.Cliente.persona.email;
        }

        private void btnGuardarIngreso_Click(object sender, EventArgs e)
        {
            Estadia estadia = new Estadia();
            estadia.reservaID = reserva.Codigo;
            estadia.checkInUsuarioID = Database.usuarioObtenerID(sesion.usuario);
            Database.estadiaIngresoExitoso(estadia, sesion.hotel.id);
            this.Hide();
        }

        private void btnAgregarClienteNuevo_Click(object sender, EventArgs e)
        {
            new VentanaCliente(this, "Nuevo").ShowDialog();
            ventanaAgregarHuesped();
        }

        private void btnAgregarClienteExistente_Click(object sender, EventArgs e)
        {
            new VentanaCliente(this, "Buscar").ShowDialog();
            ventanaAgregarHuesped();
        }

        private void ventanaAgregarHuesped()
        {
            if (huesped != null)
            {
                lbxHuespedes.Items.Add(huesped.persona.nombre + "-" + huesped.persona.apellido + "-" + huesped.persona.tipoDocumento + "-" + huesped.persona.numeroDocumento + "-" + huesped.persona.email);
                huespedes.Add(Database.clienteObtenerID(huesped));
                huesped = null;
            }
        }

        private void btnQuitarCliente_Click(object sender, EventArgs e)
        {
            if (lbxHuespedes.SelectedItem != null)
            {
                string clienteListBox = lbxHuespedes.SelectedItem.ToString();
                string[] clienteDatos = clienteListBox.Split('-');
                Cliente cliente = new Cliente();
                cliente.persona = new Persona();
                cliente.persona.email = clienteDatos[4];
                huespedes.Remove(Database.clienteObtenerID(cliente));
                listBoxQuitarElemento(lbxHuespedes);
            }

        }
    }
}
