using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Clases;

namespace FrbaHotel.AbmUsuario
{
    public partial class VentanaUsuario : VentanaBase
    {
        #region Atributos

        Sesion sesion {get; set;}

        #endregion

        #region Constructores

        public VentanaUsuario(Sesion sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }
        
        #endregion

        #region Agregar

        private List<Hotel> ventanaObtenerHotelesSeleccionados()
        {
            List<Hotel> hoteles = new List<Hotel>();
            foreach (string nombreHotel in lbxHoteles.Items)
            {
                string[] direccion = nombreHotel.Split('-');
                Domicilio domicilio = new Domicilio("", direccion[0], direccion[1], direccion[2], direccion[3]);
                Hotel hotel = new Hotel(domicilio);
                hoteles.Add(hotel);
            }
            return hoteles;
        }

        private List<Rol> ventanaObtenerRolesSeleccionados()
        {
            List<Rol> roles = new List<Rol>();
            foreach (string nombreRol in lbxRoles.Items)
            {
                Rol rol = new Rol(nombreRol);
                roles.Add(rol);
            }
            return roles;
        }

        private Usuario ventanaCrearUsuarioParaAgregar()
        {
            List<Rol> roles = ventanaObtenerRolesSeleccionados();
            List<Hotel> hoteles = ventanaObtenerHotelesSeleccionados();
            Domicilio domicilio = new Domicilio("", tbxPais.Text, tbxCiudad.Text, tbxCalle.Text, tbxNumeroCalle.Text, tbxPiso.Text, tbxDepartamento.Text);
            Persona persona = new Persona("", tbxNombre.Text, tbxApellido.Text, tbxNacionalidad.Text, cbxTipoDocumento.SelectedItem.ToString(), tbxDocumento.Text,  DateTime.Parse(tbxFechaNacimiento.Text), tbxTelefono.Text, tbxEmail.Text, domicilio);
            Usuario usuario = new Usuario("",tbxUsuario.Text, tbxContrasena.Text, persona, hoteles, roles);
            return usuario;
        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(pagAgregar, controladorError))
            {
                Usuario usuario = ventanaCrearUsuarioParaAgregar();
                if (Database.usuarioAgregadoConExito(usuario))
                    ventanaActualizar();
            }
        }

        private void btnLimpiarUsuario_Click(object sender, EventArgs e)
        {
            tbxUsuario.Clear();
            tbxContrasena.Clear();
            comboBoxCargar(cbxRoles, Database.rolObtenerTodosEnLista());
            listBoxLimpiar(lbxRoles);
            comboBoxCargar(cbxHoteles, Database.hotelObtenerTodosLista());
            listBoxLimpiar(lbxHoteles);
            cbxTipoDocumento.SelectedIndex = 0;
            tbxNombre.Clear();
            tbxApellido.Clear();
            tbxDocumento.Clear();
            tbxFechaNacimiento.Clear();
            tbxNacionalidad.Clear();
            tbxPais.Clear();
            tbxCiudad.Clear();
            tbxCalle.Clear();
            tbxNumeroCalle.Clear();
            tbxPiso.Clear();
            tbxDepartamento.Clear();
            tbxEmail.Clear();
            tbxTelefono.Clear();
            controladorError.Clear();
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

        private Usuario ventanaCrearUsuarioParaModificar(DataGridViewCellEventArgs e)
        {
            string usuarioID = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Usuario_ID"].Value.ToString();
            string usuarioNombre = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Usuario_Nombre"].Value.ToString();
            string usuarioEstado = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Usuario_Estado"].Value.ToString();
            string idPersona = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Persona_ID"].Value.ToString();
            string nombre = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Persona_Nombre"].Value.ToString();
            string apellido = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Persona_Apellido"].Value.ToString();
            string nacionalidad = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Persona_Nacionalidad"].Value.ToString();
            string tipoDocumento = dgvModificarUsuarios.Rows[e.RowIndex].Cells["TipoDocumento_Descripcion"].Value.ToString();
            string numeroDocumento = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Persona_NumeroDocumento"].Value.ToString();
            DateTime fechaNacimiento = DateTime.Parse(dgvModificarUsuarios.Rows[e.RowIndex].Cells["Persona_FechaNacimiento"].Value.ToString());
            string telefono = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Persona_Telefono"].Value.ToString();
            string email = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Persona_Email"].Value.ToString();
            string idDomicilio = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Domicilio_ID"].Value.ToString();
            string pais = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Domicilio_Pais"].Value.ToString();
            string ciudad = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Domicilio_Ciudad"].Value.ToString();
            string calle = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Domicilio_Calle"].Value.ToString();
            string numeroCalle = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Domicilio_NumeroCalle"].Value.ToString();
            string piso = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Domicilio_Piso"].Value.ToString();
            string departamento = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Domicilio_Departamento"].Value.ToString();
            Domicilio domicilio = new Domicilio(idDomicilio, pais, ciudad, calle, numeroCalle, piso, departamento);
            Persona persona = new Persona(idPersona, nombre, apellido, nacionalidad, tipoDocumento, numeroDocumento, fechaNacimiento, telefono, email, domicilio);
            Usuario usuario = new Usuario(usuarioID, usuarioNombre, "", persona, usuarioEstado);
            usuario.contrasenia = Database.usuarioObtenerContrasenia(usuario);
            return usuario;
        }

        private void dgvModificarUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Usuario usuario = ventanaCrearUsuarioParaModificar(e);
                new VentanaModificarUsuario(this, sesion, usuario).ShowDialog();
            }
        }

        #endregion

        #region Eliminar

        private void dgvEliminarUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string id = dgvEliminarUsuarios.Rows[e.RowIndex].Cells["Usuario_ID"].Value.ToString();
                Usuario usuario = new Usuario(id, null, null, null, null);
                Database.usuarioEliminadoConExito(usuario);
                ventanaActualizar();
            }
        }

        #endregion

        #region Eventos

        public void VentanaUsuarios_Load(object sender, EventArgs e)
        {
            ventanaActualizar();
            dataGridViewAgregarBotonModificar(dgvModificarUsuarios);
            dataGridViewAgregarBotonEliminar(dgvEliminarUsuarios);
            ventanaOcultarColumnas();
            comboBoxCargar(cbxRoles, Database.rolObtenerTodosEnLista());
            comboBoxCargar(cbxHoteles, Database.hotelObtenerTodosLista());
            comboBoxCargar(cbxTipoDocumento, Database.tipoDocumentoObtenerTodosEnLista());
        }

        public void ventanaActualizar()
        {
            dataGridViewCargar(dgvModificarUsuarios, Database.hotelObtenerUsuariosEnTabla(sesion.hotel));
            dataGridViewCargar(dgvEliminarUsuarios, Database.hotelObtenerUsuariosHabilitadosEnTabla(sesion.hotel));
        }

        public void ventanaOcultarColumnas()
        {
            dgvModificarUsuarios.Columns["Usuario_ID"].Visible = false;
            dgvModificarUsuarios.Columns["Usuario_Estado"].Visible = false;
            dgvModificarUsuarios.Columns["Persona_ID"].Visible = false;
            dgvModificarUsuarios.Columns["Usuario_Estado"].Visible = false;
            dgvModificarUsuarios.Columns["Persona_Nacionalidad"].Visible = false;
            dgvModificarUsuarios.Columns["Persona_NumeroDocumento"].Visible = false;
            dgvModificarUsuarios.Columns["Persona_FechaNacimiento"].Visible = false;
            dgvModificarUsuarios.Columns["Persona_ID"].Visible = false;
            dgvModificarUsuarios.Columns["Persona_Telefono"].Visible = false;
            dgvModificarUsuarios.Columns["TipoDocumento_Descripcion"].Visible = false;
            dgvModificarUsuarios.Columns["Domicilio_ID"].Visible = false;
            dgvModificarUsuarios.Columns["Domicilio_Pais"].Visible = false;
            dgvModificarUsuarios.Columns["Domicilio_Ciudad"].Visible = false;
            dgvModificarUsuarios.Columns["Domicilio_Calle"].Visible = false;
            dgvModificarUsuarios.Columns["Domicilio_NumeroCalle"].Visible = false;
            dgvModificarUsuarios.Columns["Domicilio_Piso"].Visible = false;
            dgvModificarUsuarios.Columns["Domicilio_Departamento"].Visible = false;
            dgvEliminarUsuarios.Columns["Usuario_ID"].Visible = false;
            dgvEliminarUsuarios.Columns["Persona_ID"].Visible = false;
            dgvEliminarUsuarios.Columns["Persona_Nacionalidad"].Visible = false;
            dgvEliminarUsuarios.Columns["Persona_NumeroDocumento"].Visible = false;
            dgvEliminarUsuarios.Columns["Persona_FechaNacimiento"].Visible = false;
            dgvEliminarUsuarios.Columns["Persona_ID"].Visible = false;
            dgvEliminarUsuarios.Columns["Persona_Telefono"].Visible = false;
            dgvEliminarUsuarios.Columns["TipoDocumento_Descripcion"].Visible = false;
            dgvEliminarUsuarios.Columns["Domicilio_ID"].Visible = false;
            dgvEliminarUsuarios.Columns["Domicilio_Pais"].Visible = false;
            dgvEliminarUsuarios.Columns["Domicilio_Ciudad"].Visible = false;
            dgvEliminarUsuarios.Columns["Domicilio_Calle"].Visible = false;
            dgvEliminarUsuarios.Columns["Domicilio_NumeroCalle"].Visible = false;
            dgvEliminarUsuarios.Columns["Domicilio_Piso"].Visible = false;
            dgvEliminarUsuarios.Columns["Domicilio_Departamento"].Visible = false;
        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            buttonAgregarComboBoxListBox(cbxRoles, lbxRoles);
        }

        private void btnQuitarRol_Click(object sender, EventArgs e)
        {
            buttonQuitarComboBoxListBox(cbxRoles, lbxRoles);
        }

        private void btnAgregarHotel_Click(object sender, EventArgs e)
        {
            buttonAgregarComboBoxListBox(cbxHoteles, lbxHoteles);
        }

        private void btnQuitarHotel_Click(object sender, EventArgs e)
        {
            buttonQuitarComboBoxListBox(cbxHoteles, lbxHoteles);
        }

        private void tbxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaCuenta(e);
            controladorError.Clear();
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

        private void lbxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }

        private void lbxHoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }

        private void tbxContrasena_TextChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }

        #endregion
    }
}
