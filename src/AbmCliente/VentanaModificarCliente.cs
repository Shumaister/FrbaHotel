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

namespace FrbaHotel.AbmCliente
{
    public partial class VentanaModificarCliente : VentanaBase
    {
        #region Atributos

        public VentanaCliente ventanaCliente { get; set; }
        public Cliente cliente { get; set; }
        
        #endregion

        #region Constructores

        public VentanaModificarCliente(VentanaCliente ventanaCliente, Cliente cliente)
        {
            InitializeComponent();
            this.ventanaCliente = ventanaCliente;
            this.cliente = cliente;
        }

        #endregion

        #region Modificar

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError) && textBoxValidarEmail(tbxEmail))
            {
                ventanaCrearClienteModificado();
                if (Database.clienteModificadoConExito(cliente))
                {
                    this.Hide();
                    ventanaCliente.ventanaActualizar(sender, e);
                }
            }
        }

        private void VentanaModificarCliente_Load(object sender, EventArgs e)
        {
            comboBoxCargar(cbxTipoDocumento, Database.tipoDocumentoObtenerTodosEnLista());
            cbxTipoDocumento.SelectedIndex = cbxTipoDocumento.Items.IndexOf(cliente.persona.tipoDocumento);
            tbxNombre.Text = cliente.persona.nombre;
            tbxApellido.Text = cliente.persona.apellido;
            tbxDocumento.Text = cliente.persona.numeroDocumento;
            tbxFechaNacimiento.Text = cliente.persona.fechaNacimiento.ToShortDateString();
            tbxNacionalidad.Text = cliente.persona.nacionalidad;
            tbxTelefono.Text = cliente.persona.telefono;
            tbxEmail.Text = cliente.persona.email;
            tbxPais.Text = cliente.persona.domicilio.pais;
            tbxCiudad.Text = cliente.persona.domicilio.ciudad;
            tbxCalle.Text = cliente.persona.domicilio.calle;
            tbxNumeroCalle.Text = cliente.persona.domicilio.numeroCalle;
            tbxPiso.Text = cliente.persona.domicilio.piso;
            tbxDepartamento.Text = cliente.persona.domicilio.departamento;
            if (Database.clienteHabilitado(cliente))
                rbtActivado.Select();
            else
                rbtDesactivado.Select();
        }

        private void ventanaCrearClienteModificado()
        {
            cbxTipoDocumento.SelectedIndex = cbxTipoDocumento.Items.IndexOf(cliente.persona.tipoDocumento);
            cliente.estado = radioButtonActivado(rbtActivado);
            cliente.persona.nombre = tbxNombre.Text;
            cliente.persona.apellido = tbxApellido.Text;
            cliente.persona.numeroDocumento = tbxDocumento.Text;
            cliente.persona.fechaNacimiento = DateTime.Parse(tbxFechaNacimiento.Text);
            cliente.persona.nacionalidad = tbxNacionalidad.Text;
            cliente.persona.telefono = tbxTelefono.Text;
            cliente.persona.email = tbxEmail.Text;
            cliente.persona.domicilio.pais = tbxPais.Text;
            cliente.persona.domicilio.ciudad = tbxCiudad.Text;
            cliente.persona.domicilio.calle = tbxCalle.Text;
            cliente.persona.domicilio.numeroCalle = tbxNumeroCalle.Text;
            cliente.persona.domicilio.piso = tbxPiso.Text;
            cliente.persona.domicilio.departamento = tbxDepartamento.Text;
        }

        #endregion

        #region Eventos

        private void tbxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
            controladorError.Clear();
        }

        private void tbxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
            controladorError.Clear();
        }

        private void tbxDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void tbxNacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
            controladorError.Clear();
        }

        private void tbxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            controladorError.Clear();
        }

        private void tbxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void tbxPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
            controladorError.Clear();
        }

        private void tbxCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetrasYNumeros(e);
            controladorError.Clear();
        }

        private void tbxCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetrasYNumeros(e);
            controladorError.Clear();
        }

        private void tbxNumeroCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void tbxPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void tbxDepartamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
            controladorError.Clear();
        }

        private void btnSeleccionarFecha_Click(object sender, EventArgs e)
        {
            calendario.Show();
            btnGuardarFecha.Show();
            controladorError.Clear();
        }

        private void btnGuardarFecha_Click(object sender, EventArgs e)
        {
            tbxFechaNacimiento.Text = calendario.SelectionStart.ToShortDateString();
            calendario.Hide();
            btnGuardarFecha.Hide();
        }

        private void btnLimpiarCliente_Click(object sender, EventArgs e)
        {
            tbxNombre.Clear();
            tbxApellido.Clear();
            tbxNacionalidad.Clear();
            tbxDocumento.Clear();
            tbxFechaNacimiento.Clear();
            tbxPais.Clear();
            tbxCiudad.Clear();
            tbxCalle.Clear();
            tbxNumeroCalle.Clear();
            tbxPiso.Clear();
            tbxDepartamento.Clear();
            tbxEmail.Clear();
            tbxTelefono.Clear();
            controladorError.Clear();
        }

        #endregion
    }
}
