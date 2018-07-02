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
using FrbaHotel.Menus;
using FrbaHotel.Login;

namespace FrbaHotel.AbmHotel
{
    public partial class VentanaHotel : VentanaBase
    {

        #region Atributos

        public VentanaMenuPrincipal ventanaMenuPrincipal { get; set; }

        #endregion

        #region Constructores

        public VentanaHotel(VentanaMenuPrincipal ventanaMenuPrincipal)
        {
            InitializeComponent();
            this.ventanaMenuPrincipal = ventanaMenuPrincipal;
        }

        #endregion

        #region Agregar


        private Hotel ventanaCrearHotelParaAgregar()
        {
            Domicilio domicilio = new Domicilio(null, tbxPais.Text, tbxCiudad.Text, tbxCalle.Text, tbxNumeroCalle.Text);
            Hotel hotel = new Hotel(null, tbxNombre.Text, tbxEstrellas.Text, DateTime.Parse(tbxFechaCreacion.Text), tbxEmail.Text, tbxTelefono.Text, domicilio, listBoxExtraerItemsEnLista(lbxRegimenes), null);
            return hotel;
        }

        public void ventanaMenuPrincipalActualizar()
        {
            this.Hide();
            ventanaMenuPrincipal.Hide();
            ventanaInformarError("El hotel fue deshabilitado");
            new VentanaLogin().Show();
            return;
        }

        private void btnGuardarHotel_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(pagAgregar, controladorError))
            {
                Hotel hotel = ventanaCrearHotelParaAgregar();
                if (Database.hotelAgregadoConExito(hotel))
                    ventanaActualizar(sender, e);
            }
        }

        private void btnLimpiarAgregar_Click(object sender, EventArgs e)
        {
            tbxNombre.Clear();
            tbxEstrellas.Clear();
            tbxFechaCreacion.Clear();
            tbxPais.Clear();
            tbxCiudad.Clear();
            tbxCalle.Clear();
            tbxNumeroCalle.Clear();
            tbxEmail.Clear();
            tbxTelefono.Clear();
            controladorError.Clear();
            comboBoxCargar(cbxRegimenes, Database.regimenObtenerTodosEnLista());
            listBoxLimpiar(lbxRegimenes);
            calendario.Hide();
            btnGuardarFecha.Hide();
        }

        private void btnAgregarRegimen_Click(object sender, EventArgs e)
        {
            buttonAgregarComboBoxListBox(cbxRegimenes, lbxRegimenes);
        }

        private void btnQuitarRegimen_Click(object sender, EventArgs e)
        {
            buttonQuitarComboBoxListBox(cbxRegimenes, lbxRegimenes);
        }

        private void btnGuardarFecha_Click(object sender, EventArgs e)
        {
            tbxFechaCreacion.Text = calendario.SelectionStart.ToShortDateString();
            calendario.Hide();
            btnGuardarFecha.Hide();
        }

        private void btnSeleccionarFecha_Click(object sender, EventArgs e)
        {
            calendario.Show();
            btnGuardarFecha.Show();
            controladorError.Clear();
        }

        #endregion

        #region Modificar

        private Hotel ventanaCrearHotelParaModificar(DataGridViewCellEventArgs e)
        {
            return ventanaCrearHotel(dgvModificarHotel, e);
        }

        private Hotel ventanaCrearHotelParaEliminar(DataGridViewCellEventArgs e)
        {
            return ventanaCrearHotel(dgvEliminarHotel, e);
        }

        private void dgvModificarHotel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Hotel hotel = ventanaCrearHotelParaModificar(e);
                new VentanaModificarHotel(this, hotel).ShowDialog();
            }
        }

        private void btnModificarFiltrar_Click(object sender, EventArgs e)
        {
            Domicilio domicilio = new Domicilio(null, tbxModificarFiltroPais.Text, tbxModificarFiltroCiudad.Text, null, null);
            Hotel hotel = new Hotel(tbxModificarFiltroNombre.Text, tbxModificarFiltroEstrellas.Text, domicilio);
            dataGridViewCargar(dgvModificarHotel, Database.hotelFiltrarParaModificar(hotel));
        }

        private void btnModificarLimpiar_Click(object sender, EventArgs e)
        {
            tbxModificarFiltroNombre.Clear();
            tbxModificarFiltroPais.Clear();
            tbxModificarFiltroCiudad.Clear();
            tbxModificarFiltroEstrellas.Clear();
        }

        #endregion
      
        #region Eliminar

        private void dgvEliminarClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Hotel hotel = ventanaCrearHotelParaEliminar(e);
                new VentanaEliminarHotel(this, hotel).ShowDialog();
            }
        }

        private void btnEliminarFiltrar_Click(object sender, EventArgs e)
        {
            Domicilio domicilio = new Domicilio(null, tbxEliminarFiltroPais.Text, tbxEliminarFiltroCiudad.Text, null, null);
            Hotel hotel = new Hotel(tbxEliminarFiltroNombre.Text, tbxEliminarFiltroEstrellas.Text, domicilio);
            dataGridViewCargar(dgvEliminarHotel, Database.hotelFiltrarParaEliminar(hotel));
        }

        private void btnEliminarLimpiar_Click(object sender, EventArgs e)
        {
            tbxEliminarFiltroNombre.Clear();
            tbxEliminarFiltroEstrellas.Clear();
            tbxEliminarFiltroPais.Clear();
            tbxEliminarFiltroCiudad.Clear();
        }

        #endregion

        #region Control

        public void ventanaActualizar(object sender, EventArgs e)
        {
            btnModificarFiltrar_Click(sender, e);
            btnEliminarFiltrar_Click(sender, e);
        }

        private void VentanaHotel_Load(object sender, EventArgs e)
        {
            ventanaActualizar(sender, e);
            comboBoxCargar(cbxRegimenes, Database.regimenObtenerTodosEnLista());
            dataGridViewAgregarBotonModificar(dgvModificarHotel);
            dataGridViewAgregarBotonEliminar(dgvEliminarHotel);
            ventanaOcultarColumnas();
        }

        private Hotel ventanaCrearHotel(DataGridView datagridView, DataGridViewCellEventArgs e)
        {
            string hotelID = datagridView.Rows[e.RowIndex].Cells["Hotel_ID"].Value.ToString();
            string nombre = datagridView.Rows[e.RowIndex].Cells["Hotel_Nombre"].Value.ToString();
            string estado = datagridView.Rows[e.RowIndex].Cells["Hotel_Estado"].Value.ToString();
            string cantidadEstrellas = datagridView.Rows[e.RowIndex].Cells["Hotel_CantidadEstrellas"].Value.ToString();
            string fecha = datagridView.Rows[e.RowIndex].Cells["Hotel_FechaCreacion"].Value.ToString();
            DateTime fechaCreacion = string.IsNullOrEmpty(fecha)? new DateTime() : fechaCreacion = DateTime.Parse(fecha);           
            string telefono = datagridView.Rows[e.RowIndex].Cells["Hotel_Telefono"].Value.ToString();
            string email = datagridView.Rows[e.RowIndex].Cells["Hotel_Email"].Value.ToString();
            string domicilioID = datagridView.Rows[e.RowIndex].Cells["Domicilio_ID"].Value.ToString();
            string pais = datagridView.Rows[e.RowIndex].Cells["Domicilio_Pais"].Value.ToString();
            string ciudad = datagridView.Rows[e.RowIndex].Cells["Domicilio_Ciudad"].Value.ToString();
            string calle = datagridView.Rows[e.RowIndex].Cells["Domicilio_Calle"].Value.ToString();
            string numeroCalle = datagridView.Rows[e.RowIndex].Cells["Domicilio_NumeroCalle"].Value.ToString();
            Domicilio domicilio = new Domicilio(domicilioID, pais, ciudad, calle, numeroCalle);
            Hotel hotel = new Hotel(hotelID, nombre, cantidadEstrellas, fechaCreacion, email, telefono, domicilio, null, estado);
            return hotel;
        }

        private void ventanaOcultarColumnas()
        {
            dgvModificarHotel.Columns["Hotel_ID"].Visible = false;
            dgvModificarHotel.Columns["Domicilio_ID"].Visible = false;
            dgvModificarHotel.Columns["Hotel_Telefono"].Visible = false;
            dgvModificarHotel.Columns["Hotel_FechaCreacion"].Visible = false;
            dgvModificarHotel.Columns["Hotel_Estado"].Visible = false;
            dgvEliminarHotel.Columns["Hotel_ID"].Visible = false;
            dgvEliminarHotel.Columns["Domicilio_ID"].Visible = false;
            dgvEliminarHotel.Columns["Hotel_Telefono"].Visible = false;
            dgvEliminarHotel.Columns["Hotel_FechaCreacion"].Visible = false;
            dgvEliminarHotel.Columns["Hotel_Estado"].Visible = false;
        }

        private void tbxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetrasYNumeros(e);
            controladorError.Clear();
        }

        private void tbxEstrellas_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void tbxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            controladorError.Clear();
        }

        private void tbxModificarFiltroNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetrasYNumeros(e);
        }

        private void tbxModificarFiltroEstrellas_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
        }

        private void tbxModificarFiltroCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetrasYNumeros(e);
        }

        private void tbxModificarFiltroPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
        }

        private void tbxEliminarFiltroNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetrasYNumeros(e);
        }

        private void tbxEliminarFiltroCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetrasYNumeros(e);
        }

        private void tbxEliminarFiltroEstrellas_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
        }

        private void tbxEliminarFiltroPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
        }

        #endregion

    }
}
