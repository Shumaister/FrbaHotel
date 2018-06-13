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

namespace FrbaHotel.AbmHotel
{
    public partial class VentanaHotel : VentanaBase
    {
        public VentanaHotel()
        {
            InitializeComponent();
        }

        #region Agregar

        private Hotel ventanaCrearHotelParaAgregar()
        {
            Domicilio domicilio = new Domicilio(null, tbxPais.Text, tbxCiudad.Text, tbxCalle.Text, tbxNumeroCalle.Text);
            Hotel hotel = new Hotel(null, tbxNombre.Text, tbxEstrellas.Text, DateTime.Parse(tbxFechaCreacion.Text), tbxEmail.Text, tbxTelefono.Text, domicilio);
            return hotel;
        }

        private void btnGuardarHotel_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(pagAgregar, controladorError) && textBoxValidarEmail(tbxEmail))
            {
                Hotel hotel = ventanaCrearHotelParaAgregar();
                if (Database.hotelAgregadoConExito(hotel))
                {
                    btnLimpiarAgregar_Click(sender, e);
                    ventanaActualizar(sender, e);
                }
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
            cbxRegimenes.SelectedIndex = 0;
            listBoxLimpiar(lbxRegimenes);
            calendario.Hide();
            btnGuardarFecha.Hide();
        }

        #endregion

        #region Modificar

        private Hotel ventanaCrearHotel(DataGridView datagridView, DataGridViewCellEventArgs e)
        {
            string hotelID = datagridView.Rows[e.RowIndex].Cells["Hotel_ID"].Value.ToString();
            string nombre = datagridView.Rows[e.RowIndex].Cells["Hotel_Nombre"].Value.ToString();
            string cantidadEstrellas = datagridView.Rows[e.RowIndex].Cells["Hotel_CantidadEstrellas"].Value.ToString();
            DateTime fechaCreacion = DateTime.Parse(datagridView.Rows[e.RowIndex].Cells["Hotel_FechaCreacion"].Value.ToString());
            string telefono = datagridView.Rows[e.RowIndex].Cells["Hotel_Telefono"].Value.ToString();
            string email = datagridView.Rows[e.RowIndex].Cells["Hotel_Email"].Value.ToString();
            string domicilioID = datagridView.Rows[e.RowIndex].Cells["Domicilio_ID"].Value.ToString();
            string pais = datagridView.Rows[e.RowIndex].Cells["Domicilio_Pais"].Value.ToString();
            string ciudad = datagridView.Rows[e.RowIndex].Cells["Domicilio_Ciudad"].Value.ToString();
            string calle = datagridView.Rows[e.RowIndex].Cells["Domicilio_Calle"].Value.ToString();
            string numeroCalle = datagridView.Rows[e.RowIndex].Cells["Domicilio_NumeroCalle"].Value.ToString();
            Domicilio domicilio = new Domicilio(domicilioID, pais, ciudad, calle, numeroCalle);
            Hotel hotel = new Hotel(hotelID, nombre, cantidadEstrellas, fechaCreacion, email, telefono, domicilio);
            return hotel;
        }

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

        private void btnFiltrarModificar_Click(object sender, EventArgs e)
        {
            Hotel hotel = new Hotel(tbxModificarFiltroNombre.Text, tbxModificarFiltroEstrellas.Text, tbxModificarFiltroPais.Text, tbxModificarFiltroCiudad.Text);
            dataGridViewCargar(dgvModificarHotel, Database.hotelFiltrarParaModificar(hotel));
        }

        private void btnLimpiarModificar_Click(object sender, EventArgs e)
        {
            tbxModificarFiltroCiudad.Clear();
            tbxModificarFiltroEstrellas.Clear();
            tbxModificarFiltroNombre.Clear();
            tbxModificarFiltroPais.Clear();
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

        private void btnFiltrarEliminar_Click(object sender, EventArgs e)
        {
            Hotel hotel = new Hotel(tbxEliminarFiltrarNombre.Text, tbxEliminarFiltrarEstrellas.Text, tbxEliminarFiltrarPais.Text, tbxEliminarFiltrarCiudad.Text);
            dataGridViewCargar(dgvEliminarHotel, Database.hotelFiltrarParaEliminar(hotel));
        }

        private void btnLimpiarEliminar_Click(object sender, EventArgs e)
        {
            tbxEliminarFiltrarCiudad.Clear();
            tbxEliminarFiltrarEstrellas.Clear();
            tbxEliminarFiltrarNombre.Clear();
            tbxEliminarFiltrarPais.Clear();
        }

        #endregion

        #region Eventos

        public void ventanaActualizar(object sender, EventArgs e)
        {
            btnFiltrarEliminar_Click(sender, e);
            btnFiltrarModificar_Click(sender, e);
        }

        private void VentanaHotel_Load(object sender, EventArgs e)
        {

        }

        private void tbxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
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

        }

#endregion

    }
}
