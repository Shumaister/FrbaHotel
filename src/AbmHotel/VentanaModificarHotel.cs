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
    public partial class VentanaModificarHotel : VentanaBase
    {

        #region Atributos

        public VentanaHotel ventanaHotel { get; set; }
        public Hotel hotel { get; set; }
        
        #endregion

        #region Constructores

        public VentanaModificarHotel(VentanaHotel ventanaHotel, Hotel hotel)
        {
            InitializeComponent();
            this.ventanaHotel = ventanaHotel;
            this.hotel = hotel;
        }

        #endregion

        #region Modificar

        private void ventanaCargarClienteParaModificar()
        {
            tbxNombre.Text = hotel.nombre;
            tbxEstrellas.Text = hotel.cantidadEstrellas;
            tbxFechaCreacion.Text = hotel.fechaCreacion.ToShortDateString();
            tbxTelefono.Text = hotel.telefono;
            tbxEmail.Text = hotel.email;
            tbxPais.Text = hotel.domicilio.pais;
            tbxCiudad.Text = hotel.domicilio.ciudad;
            tbxCalle.Text = hotel.domicilio.calle;
            tbxNumeroCalle.Text = hotel.domicilio.numeroCalle;
            if (bool.Parse(hotel.estado))
                rbtActivado.Select();
            else
                rbtDesactivado.Select();
        }

        private void btnGuardarHotel_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                ventanaCrearHotelModificado();
                if (Database.hotelModificadoConExito(hotel))
                {
                    this.Hide();
                    ventanaHotel.ventanaActualizar(sender, e);
                }                  
            }
        }
        private void ventanaCrearHotelModificado()
        {
            hotel.domicilio.pais = tbxPais.Text;
            hotel.domicilio.ciudad = tbxCiudad.Text;
            hotel.domicilio.calle = tbxCalle.Text;
            hotel.domicilio.numeroCalle = tbxNumeroCalle.Text;
            hotel.cantidadEstrellas = tbxEstrellas.Text;
            hotel.fechaCreacion = DateTime.Parse(tbxFechaCreacion.Text);
            hotel.email = tbxEmail.Text;
            hotel.telefono = tbxTelefono.Text;
            hotel.estado = radioButtonEstado(rbtActivado);
        }

        private void btnAgregarRegimen_Click(object sender, EventArgs e)
        {
            buttonAgregarComboBoxListBox(cbxRegimenes, lbxRegimenes);
        }

        private void btnQuitarRegimen_Click(object sender, EventArgs e)
        {
            buttonQuitarComboBoxListBox(cbxRegimenes, lbxRegimenes);
        }

        private void btnSeleccionarFecha_Click(object sender, EventArgs e)
        {
            calendario.Show();
            btnGuardarFecha.Show();
            controladorError.Clear();
        }

        private void btnGuardarFecha_Click(object sender, EventArgs e)
        {
            tbxFechaCreacion.Text = calendario.SelectionStart.ToShortDateString();
            calendario.Hide();
            btnGuardarFecha.Hide();
        }

        private void btnLimpiarModificar_Click(object sender, EventArgs e)
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

        #endregion

        #region Eventos

        private void VentanaModificarHotel_Load(object sender, EventArgs e)
        {
            comboBoxCargar(cbxRegimenes, Database.hotelObtenerRegimenesFaltantesEnLista(hotel));
            listBoxCargar(lbxRegimenes, Database.hotelObtenerRegimenesEnLista(hotel));
            ventanaCargarClienteParaModificar();
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
        #endregion
    }
}
