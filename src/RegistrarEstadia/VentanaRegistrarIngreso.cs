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
        public Estadia estadia { get; set; }
        public Cliente huesped { get; set; }
        public int cantidadHuespedes { get; set; }
        
        public VentanaRegistrarIngreso(Estadia estadia, Sesion sesion)
        {
            InitializeComponent();
            this.estadia = estadia;
            this.sesion = sesion;
            this.cantidadHuespedes = estadia.reserva.CantidadHuespedes-1;
        }

        private void VentanaRegistrarIngreso_Load(object sender, EventArgs e)
        {
            lblClienteNombre.Text = estadia.reserva.Cliente.persona.nombre;
            lblClienteApellido.Text = estadia.reserva.Cliente.persona.apellido;
            lblTipoDocumento.Text = estadia.reserva.Cliente.persona.tipoDocumento;
            lblClienteDocumento.Text = estadia.reserva.Cliente.persona.numeroDocumento;
            lblClienteEmail.Text = estadia.reserva.Cliente.persona.email;
            lblCantidadHuespedes.Text = cantidadHuespedes.ToString();
        }

        private void btnGuardarIngreso_Click(object sender, EventArgs e)
        {
            estadia.checkInUsuarioID = Database.usuarioObtenerID(sesion.usuario);
            if (cantidadHuespedes == 0)
            {
                Database.estadiaIngresoExitoso(estadia);
                this.Hide();
            }
            else
                ventanaInformarError("Hay huespedes sin registrar");

        }

        private void btnAgregarClienteNuevo_Click(object sender, EventArgs e)
        {
            if (cantidadHuespedes > 0)
            {
                new VentanaCliente(this, "Nuevo").ShowDialog();
                ventanaAgregarHuesped();
            }
            else
                ventanaInformarError("Ya no quedan huespedes sin registrar");

        }

        private void btnAgregarClienteExistente_Click(object sender, EventArgs e)
        {
            if (cantidadHuespedes > 0)
            {
                new VentanaCliente(this, "Buscar").ShowDialog();
                ventanaAgregarHuesped();
            }
            else
                ventanaInformarError("Ya no quedan huespedes sin registrar");
        }

        private void ventanaAgregarHuesped()
        {
            if (huesped != null)
            {
                lbxHuespedes.Items.Add(huesped.persona.nombre + "-" + huesped.persona.apellido + "-" + huesped.persona.tipoDocumento + "-" + huesped.persona.numeroDocumento + "-" + huesped.persona.email);
                estadia.huespedes.Add(Database.clienteObtenerID(huesped));
                huesped = null;
                cantidadHuespedes--;
                lblCantidadHuespedes.Text = cantidadHuespedes.ToString();
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
                estadia.huespedes.Remove(Database.clienteObtenerID(cliente));
                listBoxQuitarElemento(lbxHuespedes);
                cantidadHuespedes++;
                lblCantidadHuespedes.Text = cantidadHuespedes.ToString();
            }

        }
    }
}
