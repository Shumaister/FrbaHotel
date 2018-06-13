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

namespace FrbaHotel.AbmHabitacion
{
    public partial class VentanaHabitacion : VentanaBase
    {
        #region Atributos

        public Sesion sesion { get; set; }

        #endregion

        #region Constructores

        public VentanaHabitacion(Sesion sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }

        #endregion
        
        #region Agregar

        private Habitacion ventanaCrearHabitacionParaAgregar()
        {
            Habitacion habitacion = new Habitacion(null, tbxNumero.Text, tbxPiso.Text, cbxFrentes.SelectedItem.ToString() == "Interna"? "N" : "S" , cbxTipoHabitaciones.SelectedItem.ToString(), tbxDescripcion.Text, sesion.hotel, null); 
            return habitacion;
        }

        private void btnAgregarGuardar_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(pagAgregar, controladorError))
            {
                Habitacion habitacion = ventanaCrearHabitacionParaAgregar();
                if (Database.habitacionAgregadaConExito(habitacion))
                {
                    btnAgregarLimpiar_Click(sender, e);
                    ventanaActualizar(sender, e);
                }
            }
        }

        #endregion

        #region Modificar

        private Habitacion ventanaCrearHabitacionParaModificar(DataGridViewCellEventArgs e)
        {
            string habitacionID = dgvModificarHabitacion.Rows[e.RowIndex].Cells["Habitacion_ID"].Value.ToString();
            string numero = dgvModificarHabitacion.Rows[e.RowIndex].Cells["Habitacion_Numero"].Value.ToString();
            string piso = dgvModificarHabitacion.Rows[e.RowIndex].Cells["Habitacion_Piso"].Value.ToString();
            string tipoHabitacion = dgvModificarHabitacion.Rows[e.RowIndex].Cells["TipoHabitacion_Descripcion"].Value.ToString();
            string frente = dgvModificarHabitacion.Rows[e.RowIndex].Cells["Habitacion_Frente"].Value.ToString();
            string descripcion = dgvModificarHabitacion.Rows[e.RowIndex].Cells["Habitacion_Descripcion"].Value.ToString();
            string estado = dgvModificarHabitacion.Rows[e.RowIndex].Cells["Habitacion_Estado"].Value.ToString();
            Habitacion habitacion = new Habitacion(habitacionID, numero, piso, frente, tipoHabitacion, descripcion, sesion.hotel, estado);
            return habitacion;

        }

        private void dgvModificarHabitacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Habitacion habitacion = ventanaCrearHabitacionParaModificar(e);
                new VentanaModificarHabitacion(this, habitacion).ShowDialog();
            }
        }

        private void btnAgregarLimpiar_Click(object sender, EventArgs e)
        {
            tbxNumero.Clear();
            tbxPiso.Clear();
            tbxDescripcion.Clear();
            cbxFrentes.SelectedIndex = 0;
            cbxTipoHabitaciones.SelectedIndex = 0;
        }

        #endregion

        #region Eliminar

        private Habitacion ventanaCrearHabitacionParaEliminar(DataGridViewCellEventArgs e)
        {
            string habitacionID = dgvEliminarHabitacion.Rows[e.RowIndex].Cells["Habitacion_ID"].Value.ToString();
            Habitacion habitacion = new Habitacion(habitacionID);
            return habitacion;
        }

        private void dgvEliminarHabitacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Habitacion habitacion = ventanaCrearHabitacionParaEliminar(e);
                Database.habitacionEliminadaConExito(habitacion);
                ventanaActualizar(sender, e);
            }
        }

        #endregion

        #region Eventos

        public void ventanaActualizar(object sender, EventArgs e)
        {
            dataGridViewCargar(dgvModificarHabitacion, Database.hotelObtenerHabitacionesEnTabla(sesion.hotel));
            dataGridViewCargar(dgvEliminarHabitacion, Database.hotelObtenerHabitacionesHabilitadasEnTabla(sesion.hotel));
        }

        private void VentanaHabitacion_Load(object sender, EventArgs e)
        {
            lblHotel.Text = "Hotel: " + sesion.hotel.domicilio.pais + " - " + sesion.hotel.domicilio.ciudad + " - " + sesion.hotel.domicilio.calle + " - " + sesion.hotel.domicilio.numeroCalle;
            comboBoxCargar(cbxFrentes, Database.habitacionObtenerFrentes());
            comboBoxCargar(cbxTipoHabitaciones, Database.tipoHabitacionObtenerTodas());
            ventanaActualizar(sender, e);
            dataGridViewAgregarBotonModificar(dgvModificarHabitacion);
            dataGridViewAgregarBotonEliminar(dgvEliminarHabitacion);
            ventanaOcultarColumnas();
        }

        private void ventanaOcultarColumnas()
        {
            dgvModificarHabitacion.Columns["Habitacion_Estado"].Visible = false;
            dgvModificarHabitacion.Columns["Habitacion_Descripcion"].Visible = false;
            dgvEliminarHabitacion.Columns["Habitacion_Descripcion"].Visible = false;
            dgvModificarHabitacion.Columns["Habitacion_HotelID"].Visible = false;
            dgvEliminarHabitacion.Columns["Habitacion_HotelID"].Visible = false;
            dgvModificarHabitacion.Columns["Habitacion_ID"].Visible = false;
            dgvEliminarHabitacion.Columns["Habitacion_ID"].Visible = false;
        }

        private void tbxNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void tbxPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }
       
        #endregion
    }

}
