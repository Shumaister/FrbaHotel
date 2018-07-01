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
using FrbaHotel.RegistrarEstadia;
using FrbaHotel.GenerarModificacionReserva;

namespace FrbaHotel.AbmCliente
{
    public partial class VentanaCliente : VentanaBase
    {
        public VentanaGenerarReserva ventanaGenerarReserva;

        public Reserva Reserva { get; set; }
        public VentanaRegistrarIngreso ventanaRegistrarIngreso { get; set; }
        public string funcion { get; set; }
        
        #region Constructores

        public VentanaCliente(Reserva reserva)
        {
            InitializeComponent();
            this.Reserva = reserva;
            this.btnGuardarDesdeReserva.Visible = true;
            this.btnGuardarCliente.Visible = false;
            this.tabControl.TabPages.Remove(pagModificar);
            this.tabControl.TabPages.Remove(pagEliminar); 
            comboBoxCargar(cbxTipoDocumento, Database.tipoDocumentoObtenerTodosEnLista());
                
        }

        public VentanaCliente(VentanaRegistrarIngreso ventanaRegistrarIngreso, string funcion)
        {
            InitializeComponent();
            this.ventanaRegistrarIngreso = ventanaRegistrarIngreso;
            this.funcion = funcion;
            btnGuardarDesdeReserva.Visible = false;
            if (funcion == "Nuevo")
            {
                tabControl.TabPages.Remove(pagModificar);
                tabControl.TabPages.Remove(pagEliminar);     
            }
            if (funcion == "Buscar")
            {
                pagModificar.Text = "Buscar";
                tabControl.TabPages.Remove(pagAgregar);
                tabControl.TabPages.Remove(pagEliminar);     
            }

        }

        public VentanaCliente()
        {
            InitializeComponent();
            this.funcion = "ABM";
            this.btnGuardarDesdeReserva.Visible = false;
        }

        public VentanaCliente(VentanaGenerarReserva ventanaGenerarReserva, string p)
        {
            InitializeComponent();
            this.funcion = p;
            if (funcion == "BuscarDesdeReserva")
            {
                pagModificar.Text = "Buscar";
                tabControl.TabPages.Remove(pagAgregar);
                tabControl.TabPages.Remove(pagEliminar);
            }

            this.ventanaGenerarReserva = ventanaGenerarReserva;
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
            if (ventanaCamposEstanCompletos(pagAgregar, controladorError))
            {
                Cliente cliente = ventanaCrearClienteParaAgregar();
                if (Database.clienteAgregadoConExito(cliente))
                {
                    if (funcion == "ABM")
                        ventanaActualizar(sender, e);
                    if (funcion == "Nuevo")
                    {
                        ventanaRegistrarIngreso.huesped = cliente;
                        this.Hide();
                    }                      
                }
                    
                
            }
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

        #endregion

        #region Modificar

        private Cliente ventanaCrearClienteParaModificar(DataGridViewCellEventArgs e)
        {
            string clienteID = dgvModificarClientes.Rows[e.RowIndex].Cells["Cliente_ID"].Value.ToString();
            string clienteEstado = dgvModificarClientes.Rows[e.RowIndex].Cells["Cliente_Estado"].Value.ToString();
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
            Cliente cliente = new Cliente(clienteID, persona, clienteEstado);
            return cliente;
        }

        private void dgvModificarClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (funcion == "ABM")
                {
                    Cliente cliente = ventanaCrearClienteParaModificar(e);
                    new VentanaModificarCliente(this, cliente).ShowDialog();
                }
                if (funcion == "Buscar")
                {
                    Cliente cliente = ventanaCrearClienteParaModificar(e);
                    if (cliente.id == ventanaRegistrarIngreso.estadia.reserva.Cliente.id)
                    {
                        ventanaInformarError("El cliente ya esta registrado");
                        return;
                    }
                    if (Database.estadiaVerificarHuesped(cliente, ventanaRegistrarIngreso.estadia))
                    {
                        ventanaRegistrarIngreso.huesped = cliente;
                        this.Hide();
                    }
                }
                if (funcion == "BuscarDesdeReserva")
                {
                    ventanaGenerarReserva.Reserva.Cliente = ventanaCrearClienteParaModificar(e);
                    this.Hide();
                }
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
                string clienteID = dgvEliminarClientes.Rows[e.RowIndex].Cells["Cliente_ID"].Value.ToString();
                Cliente cliente = new Cliente(clienteID, null, null);
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
            if (funcion == "ABM")
            {
                comboBoxCargar(cbxTipoDocumento, Database.tipoDocumentoObtenerTodosEnLista());
                comboBoxCargar(cbxFiltroTipoDocumentoModificar, Database.tipoDocumentoFiltroObtenerTodosEnLista());
                comboBoxCargar(cbxFiltroTipoDocumentoEliminar, Database.tipoDocumentoFiltroObtenerTodosEnLista());
                ventanaActualizar(sender, e);
                dataGridViewAgregarBotonModificar(dgvModificarClientes);
                dataGridViewAgregarBotonEliminar(dgvEliminarClientes);
                ventanaOcultarColumnas();
            }

            if (funcion == "Nuevo")
            {
                comboBoxCargar(cbxTipoDocumento, Database.tipoDocumentoObtenerTodosEnLista());
            }

            if (funcion == "Buscar" || funcion == "BuscarDesdeReserva")
            {             
                comboBoxCargar(cbxFiltroTipoDocumentoModificar, Database.tipoDocumentoFiltroObtenerTodosEnLista());
                btnFiltrarModificar_Click(sender, e);
                dataGridViewAgregarBotonAgregar(dgvModificarClientes);
                ventanaOcultarColumnasModificar();
            }
        }

        private void ventanaOcultarColumnasModificar()
        {
            dgvModificarClientes.Columns["Cliente_ID"].Visible = false;
            dgvModificarClientes.Columns["Cliente_Estado"].Visible = false;
            dgvModificarClientes.Columns["Persona_ID"].Visible = false;
            dgvModificarClientes.Columns["Persona_Nacionalidad"].Visible = false;
            dgvModificarClientes.Columns["Persona_FechaNacimiento"].Visible = false;
            dgvModificarClientes.Columns["Persona_Telefono"].Visible = false;
            dgvModificarClientes.Columns["Domicilio_ID"].Visible = false;
            dgvModificarClientes.Columns["Domicilio_Pais"].Visible = false;
            dgvModificarClientes.Columns["Domicilio_Ciudad"].Visible = false;
            dgvModificarClientes.Columns["Domicilio_Calle"].Visible = false;
            dgvModificarClientes.Columns["Domicilio_NumeroCalle"].Visible = false;
            dgvModificarClientes.Columns["Domicilio_Piso"].Visible = false;
            dgvModificarClientes.Columns["Domicilio_Departamento"].Visible = false;
        }

        private void ventanaOcultarColumnasEliminar()
        {
            dgvEliminarClientes.Columns["Cliente_ID"].Visible = false;
            dgvEliminarClientes.Columns["Persona_ID"].Visible = false;
            dgvEliminarClientes.Columns["Persona_Nacionalidad"].Visible = false;
            dgvEliminarClientes.Columns["Persona_FechaNacimiento"].Visible = false;
            dgvEliminarClientes.Columns["Persona_Telefono"].Visible = false;
            dgvEliminarClientes.Columns["Domicilio_ID"].Visible = false;
            dgvEliminarClientes.Columns["Domicilio_Pais"].Visible = false;
            dgvEliminarClientes.Columns["Domicilio_Ciudad"].Visible = false;
            dgvEliminarClientes.Columns["Domicilio_Calle"].Visible = false;
            dgvEliminarClientes.Columns["Domicilio_NumeroCalle"].Visible = false;
            dgvEliminarClientes.Columns["Domicilio_Piso"].Visible = false;
            dgvEliminarClientes.Columns["Domicilio_Departamento"].Visible = false;
        }

        private void ventanaOcultarColumnas()
        {
            ventanaOcultarColumnasModificar();
            ventanaOcultarColumnasEliminar();
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

        private void tbxFiltroNombreModificar_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
        }

        private void tbxFiltroDocumentoModificar_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
        }

        private void tbxFiltroApellidoModificar_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
        }

        private void tbxFiltroNombreEliminar_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
        }

        private void tbxFiltroDocumentoEliminar_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
        }

        private void tbxFiltroApellidoEliminar_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
        }

        #endregion

        private void btnGuardarDesdeReserva_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(pagAgregar, controladorError))
            {
                Cliente cliente = ventanaCrearClienteParaAgregar();

                if (Database.clienteAgregadoConExito(cliente))
                {
                    Reserva.Cliente = cliente;
                    this.Hide();
                }
            }
        }

        private void cbxTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
