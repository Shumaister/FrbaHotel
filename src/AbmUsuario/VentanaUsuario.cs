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

namespace FrbaHotel.AbmUsuario
{
    public partial class VentanaUsuario : VentanaBase
    {
        //-------------------------------------- Atributos -------------------------------------

        Sesion sesion {get; set;}

        //-------------------------------------- Constructores -------------------------------------

        public VentanaUsuario(Sesion sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }

        //-------------------------------------- Metodos para Eventos -------------------------------------

        private void VentanaUsuarios_Load(object sender, EventArgs e)
        {
            dataGridViewCargar(dgvModificarUsuarios, Database.usuarioObtenerTodos());
            dataGridViewCargar(dgvEliminarUsuarios, Database.usuarioObtenerTodos());
            dataGridViewAgregarBotonModificar(dgvModificarUsuarios);
            dataGridViewAgregarBotonEliminar(dgvEliminarUsuarios);
            comboBoxCargar(cbxRoles, Database.rolObtenerTodosEnLista());
            comboBoxCargar(cbxHoteles, Database.hotelObtenerTodosLista());
            comboBoxCargar(cbxTipoDocumento, Database.tipoDocumentoObtenerTodosEnLista());
        }

        private void dgvModificarUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string nombreUsuario = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Usuario_Nombre"].Value.ToString();
                string contrasenia = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Usuario_Contrasenia"].Value.ToString();
                string estado = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Usuario_Estado"].Value.ToString();
                string nombre = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Persona_Nombre"].Value.ToString();
                string apellido = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Pesona_Apellido"].Value.ToString();
                string tipoDocumento = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Persona_TipoDocumento"].Value.ToString();
                string numeroDocumento = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Persona_NumeroDocumento"].Value.ToString();
                string nacionalidad = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Persona_Nacionalidad"].Value.ToString();
                string fechaNacimiento = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Persona_FechaNacimiento"].Value.ToString();
                string telefono = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Persona_Telefono"].Value.ToString();
                string email = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Persona_Email"].Value.ToString();
                string numeroCalle = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Domicilio_NumeroCalle"].Value.ToString();
                string piso = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Domicilio_Piso"].Value.ToString();
                string departamento = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Domicilio_Departamento"].Value.ToString();
                string pais = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Pais_Nombre"].Value.ToString();
                string ciudad = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Ciudad_Nombre"].Value.ToString();
                string calle = dgvModificarUsuarios.Rows[e.RowIndex].Cells["Calle_Nombre"].Value.ToString();
                Domicilio domicilio = new Domicilio(pais, ciudad, calle, numeroCalle, piso, departamento);
                Persona persona = new Persona(nombre, apellido, fechaNacimiento, tipoDocumento, numeroDocumento, nacionalidad, telefono, email, domicilio);
                Usuario usuario = new Usuario(nombreUsuario, contrasenia, persona, estado);
                new VentanaModificarUsuario(sesion, usuario).ShowDialog(); 
            }
        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            botonAgregarComboBoxListBox(cbxRoles, lbxRoles);
        }

        private void btnQuitarRol_Click(object sender, EventArgs e)
        {
            botonQuitarComboBoxListBox(cbxRoles, lbxRoles);
        }

        private void btnAgregarHotel_Click(object sender, EventArgs e)
        {
            botonAgregarComboBoxListBox(cbxHoteles, lbxHoteles);
        }

        private void btnQuitarHotel_Click(object sender, EventArgs e)
        {
            botonQuitarComboBoxListBox(cbxHoteles, lbxHoteles);
        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(pagAgregar, controladorError))
            {
                if(Database.usuarioExiste(tbxUsuario.Text))
                {
                    ventanaInformarError("ERROR: El nombre de usuario ya existe");
                    return;
                }
                if (Database.personaAlguienTieneEseEmail(tbxEmail.Text))
                {
                    ventanaInformarError("ERROR: El email ya fue registrado para otro usuario");      
                    return;                                                  
                }
                if (Database.personaAlguienTieneEseDocumento(cbxTipoDocumento.SelectedItem.ToString(), tbxDocumento.Text))
                {
                    ventanaInformarError("ERROR: Otro usuario ya fue registrado con ese documento");
                    return;                   
                }
                    
                Domicilio domicilio = new Domicilio(tbxPais.Text, tbxCiudad.Text, tbxCalle.Text, tbxNumeroCalle.Text, tbxPiso.Text, tbxDepartamento.Text);
                Persona persona = new Persona(tbxNombre.Text, tbxApellido.Text, tbxFechaNacimiento.Text.ToString(), cbxTipoDocumento.SelectedItem.ToString(), tbxDocumento.Text, tbxNacionalidad.Text, tbxTelefono.Text, tbxEmail.Text, domicilio);
                Usuario usuario = new Usuario(tbxUsuario.Text, tbxContrasena.Text, persona, "");
                Database.domicilioAgregar(domicilio);
                Database.personaAgregar(persona);
                Database.usuarioAgregar(usuario);
                ventanaInformarExito();
            }
                       
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
            textBoxConfigurarParaCuenta(e);
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
            textBoxConfigurarParaLetras(e);
            controladorError.Clear();
        }

        private void tbxCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
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

        private void btnLimpiarUsuario_Click(object sender, EventArgs e)
        {
            tbxUsuario.Clear();
            tbxContrasena.Clear();
            comboBoxCargar(cbxRoles, Database.rolObtenerTodosEnLista());          
            listBoxLimpiar(lbxRoles);
            comboBoxCargar(cbxHoteles, Database.hotelObtenerTodosLista());
            listBoxLimpiar(lbxHoteles);
            tbxNombre.Clear();
            tbxApellido.Clear();
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

        private void btnSeleccionarFecha_Click(object sender, EventArgs e)
        {
            calendario.Show();
            btnGuardarFecha.Show();
            controladorError.Clear();
        }

        private void btnGuardarFecha_Click(object sender, EventArgs e)
        {
            tbxFechaNacimiento.Text = calendario.SelectionStart.ToString();
            calendario.Hide();
            btnGuardarFecha.Hide();
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

    }
}
