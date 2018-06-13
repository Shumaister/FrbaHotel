﻿using System;
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
    public partial class VentanaCliente : VentanaBase
    {

        #region Constructores
        
        public VentanaCliente()
        {
            InitializeComponent();
        }

        #endregion

        #region Agregar

        private Cliente ventanaCrearClienteParaAgregar()
        {
            Domicilio domicilio = new Domicilio(null, tbxPais.Text, tbxCiudad.Text, tbxCalle.Text, tbxNumeroCalle.Text, tbxPiso.Text, tbxDepartamento.Text);
            Persona persona = new Persona(null, tbxNombre.Text, tbxApellido.Text, tbxNacionalidad.Text, cbxTipoDocumento.SelectedItem.ToString(), tbxDocumento.Text, DateTime.Parse(tbxFechaNacimiento.Text), tbxTelefono.Text, tbxEmail.Text, domicilio);
            Cliente cliente = new Cliente(null, persona, null);
            return cliente;
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(pagAgregar, controladorError) && textBoxValidarEmail(tbxEmail))
            {
                Cliente cliente = ventanaCrearClienteParaAgregar();
                if (Database.clienteAgregadoConExito(cliente))
                {
                    btnLimpiarCliente_Click(sender, e);
                    ventanaActualizar(sender, e);
                }
            }
        }

        #endregion

        #region Modificar

        private Cliente ventanaCrearClienteParaModificar(DataGridViewCellEventArgs e)
        {
            string clienteID = dgvModificarClientes.Rows[e.RowIndex].Cells["Cliente_ID"].Value.ToString();
            string personaID = dgvModificarClientes.Rows[e.RowIndex].Cells["Persona_ID"].Value.ToString();
            string nombre = dgvModificarClientes.Rows[e.RowIndex].Cells["Persona_Nombre"].Value.ToString();
            string apellido = dgvModificarClientes.Rows[e.RowIndex].Cells["Persona_Apellido"].Value.ToString();
            string nacionalidad = dgvModificarClientes.Rows[e.RowIndex].Cells["Persona_Nacionalidad"].Value.ToString();
            string tipoDocumento = dgvModificarClientes.Rows[e.RowIndex].Cells["TipoDocumento_Descripcion"].Value.ToString();
            string numeroDocumento = dgvModificarClientes.Rows[e.RowIndex].Cells["Persona_NumeroDocumento"].Value.ToString();
            DateTime fechaNacimiento = DateTime.Parse(dgvModificarClientes.Rows[e.RowIndex].Cells["Persona_FechaNacimiento"].Value.ToString());
            string telefono = dgvModificarClientes.Rows[e.RowIndex].Cells["Persona_Telefono"].Value.ToString();
            string email = dgvModificarClientes.Rows[e.RowIndex].Cells["Persona_Email"].Value.ToString();
            string idDomicilio = dgvModificarClientes.Rows[e.RowIndex].Cells["Domicilio_ID"].Value.ToString();
            string pais = dgvModificarClientes.Rows[e.RowIndex].Cells["Domicilio_Pais"].Value.ToString();
            string ciudad = dgvModificarClientes.Rows[e.RowIndex].Cells["Domicilio_Ciudad"].Value.ToString();
            string calle = dgvModificarClientes.Rows[e.RowIndex].Cells["Domicilio_Calle"].Value.ToString();
            string numeroCalle = dgvModificarClientes.Rows[e.RowIndex].Cells["Domicilio_NumeroCalle"].Value.ToString();
            string piso = dgvModificarClientes.Rows[e.RowIndex].Cells["Domicilio_Piso"].Value.ToString();
            string departamento = dgvModificarClientes.Rows[e.RowIndex].Cells["Domicilio_Departamento"].Value.ToString();
            Domicilio domicilio = new Domicilio(idDomicilio, pais, ciudad, calle, numeroCalle, piso, departamento);
            Persona persona = new Persona(personaID, nombre, apellido, nacionalidad, tipoDocumento, numeroDocumento, fechaNacimiento, telefono, email, domicilio);
            Cliente cliente = new Cliente(clienteID, persona, null);
            return cliente;
        }

        private void dgvModificarClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Cliente cliente = ventanaCrearClienteParaModificar(e);
                new VentanaModificarCliente(this, cliente).ShowDialog();
            }
        }

        private void btnFiltrarModificar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona(tbxFiltroNombreModificar.Text, tbxFiltroApellidoModificar.Text,cbxFiltroTipoDocumentoModificar.SelectedItem.ToString(), tbxFiltroDocumentoModificar.Text, tbxFiltroEmailModificar.Text);
            Cliente cliente = new Cliente(null, persona, null);
            dataGridViewCargar(dgvModificarClientes, Database.clienteFiltrarParaModificar(cliente));
        }

        private void btnLimpiarModificar_Click(object sender, EventArgs e)
        {
            tbxFiltroNombreModificar.Clear();
            tbxFiltroApellidoModificar.Clear();
            tbxFiltroDocumentoModificar.Clear();
            tbxFiltroEmailModificar.Clear();
            cbxFiltroTipoDocumentoModificar.SelectedIndex = 0;
            btnFiltrarModificar_Click(sender, e);
        }

        #endregion

        #region Eliminar

        private void dgvEliminarClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string id = dgvEliminarClientes.Rows[e.RowIndex].Cells["Cliente_ID"].Value.ToString();
                Cliente cliente = new Cliente(id, null, null);
                Database.clienteEliminadoConExito(cliente);
                ventanaActualizar(sender, e);
            }
        }

        private void btnFiltrarEliminar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona(tbxFiltroNombreEliminar.Text, tbxFiltroApellidoEliminar.Text, cbxFiltroTipoDocumentoEliminar.SelectedItem.ToString(), tbxFiltroDocumentoEliminar.Text, tbxFiltroEmailEliminar.Text);
            Cliente cliente = new Cliente(null, persona, null);
            dataGridViewCargar(dgvEliminarClientes, Database.clienteFiltrarParaEliminar(cliente));
        }

        private void btnLimpiarEliminar_Click(object sender, EventArgs e)
        {
            tbxFiltroNombreEliminar.Clear();
            tbxFiltroApellidoEliminar.Clear();
            tbxFiltroDocumentoEliminar.Clear();
            tbxFiltroEmailEliminar.Clear();
            cbxFiltroTipoDocumentoEliminar.SelectedIndex = 0;
            btnFiltrarEliminar_Click(sender, e);
        }

        #endregion

        #region Control


        public void ventanaActualizar(object sender, EventArgs e)
        {
            btnFiltrarEliminar_Click(sender, e);
            btnFiltrarModificar_Click(sender, e);
        }

        private void VentanaCliente_Load(object sender, EventArgs e)
        {
            comboBoxCargar(cbxTipoDocumento, Database.tipoDocumentoObtenerTodosEnLista());
            comboBoxCargar(cbxFiltroTipoDocumentoModificar, Database.tipoDocumentoFiltroObtenerTodosEnLista());
            comboBoxCargar(cbxFiltroTipoDocumentoEliminar, Database.tipoDocumentoFiltroObtenerTodosEnLista());
            ventanaActualizar(sender, e);
            dataGridViewAgregarBotonModificar(dgvModificarClientes);
            dataGridViewAgregarBotonEliminar(dgvEliminarClientes);            
        }

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
            cbxTipoDocumento.SelectedIndex = 0;
            calendario.Hide();
            btnGuardarFecha.Hide();
        }

        #endregion

        private void tbxFiltroNombreModificar_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
        }

        private void tbxFiltroDocumentoModificar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbxFiltroApellidoModificar_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
        }

        private void tbxFiltroEmailModificar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbxFiltroNombreEliminar_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
        }

        private void tbxFiltroDocumentoEliminar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbxFiltroApellidoEliminar_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
        }

        private void tbxFiltroEmailEliminar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

    }
}