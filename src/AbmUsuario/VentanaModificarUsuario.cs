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
    public partial class VentanaModificarUsuario : VentanaBase
    {

        #region Atributos

        VentanaUsuario ventanaUsuario {get; set;}
        Usuario usuario { get; set; }
        bool HabilitadoDesdeInicio { get; set; }

        #endregion

        #region Constructores

        public VentanaModificarUsuario(VentanaUsuario ventanaUsuario, Usuario usuario)
        {
            InitializeComponent();
            this.ventanaUsuario = ventanaUsuario;
            this.usuario = usuario;
            this.HabilitadoDesdeInicio = false;
        }

        #endregion
        
        #region Modificar

        private void VentanaModificarUsuario_Load(object sender, EventArgs e)
        {
            comboBoxCargar(cbxTipoDocumento, Database.tipoDocumentoObtenerTodosEnLista());
            comboBoxCargar(cbxHoteles, Database.usuarioObtenerHotelesFaltantesEnLista(usuario));
            comboBoxCargar(cbxRoles, Database.usuarioObtenerRolesFaltantesEnLista(usuario));
            listBoxCargar(lbxHoteles, Database.usuarioObtenerHotelesEnLista(usuario));
            listBoxCargar(lbxRoles, Database.usuarioObtenerRolesEnLista(usuario));
            cbxTipoDocumento.SelectedIndex = cbxTipoDocumento.Items.IndexOf(usuario.persona.tipoDocumento);
            tbxUsuario.Text = usuario.nombre;
            tbxContrasena.Text = usuario.contrasenia;        
            tbxNombre.Text = usuario.persona.nombre;
            tbxApellido.Text = usuario.persona.apellido;
            tbxDocumento.Text = usuario.persona.numeroDocumento;
            tbxFechaNacimiento.Text = usuario.persona.fechaNacimiento.ToShortDateString();
            tbxNacionalidad.Text = usuario.persona.nacionalidad;
            tbxTelefono.Text = usuario.persona.telefono;
            tbxEmail.Text = usuario.persona.email;
            tbxPais.Text = usuario.persona.domicilio.pais;
            tbxCiudad.Text = usuario.persona.domicilio.ciudad;
            tbxCalle.Text = usuario.persona.domicilio.calle;
            tbxNumeroCalle.Text = usuario.persona.domicilio.numeroCalle;
            tbxPiso.Text = usuario.persona.domicilio.piso;
            tbxDepartamento.Text = usuario.persona.domicilio.departamento;
            if (bool.Parse(usuario.estado))
            {
                this.HabilitadoDesdeInicio = true;
                buttonHabilitarDesactivar(btnHabilitar);
            }   
        }

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

        private void ventanaModificarUsuario()
        {
            usuario.persona.tipoDocumento = cbxTipoDocumento.SelectedItem.ToString();
            usuario.nombre = tbxUsuario.Text;
            usuario.contrasenia = tbxContrasena.Text;
            usuario.estado = btnHabilitar.Enabled ? "0" : "1";
            usuario.persona.nombre = tbxNombre.Text;
            usuario.persona.apellido = tbxApellido.Text;
            usuario.persona.numeroDocumento = tbxDocumento.Text;
            usuario.persona.fechaNacimiento = DateTime.Parse(tbxFechaNacimiento.Text);
            usuario.persona.nacionalidad = tbxNacionalidad.Text;
            usuario.persona.telefono = tbxTelefono.Text;
            usuario.persona.email = tbxEmail.Text;
            usuario.persona.domicilio.pais = tbxPais.Text;
            usuario.persona.domicilio.ciudad = tbxCiudad.Text;
            usuario.persona.domicilio.calle = tbxCalle.Text;
            usuario.persona.domicilio.numeroCalle = tbxNumeroCalle.Text;
            usuario.persona.domicilio.piso = tbxPiso.Text;
            usuario.persona.domicilio.departamento = tbxDepartamento.Text;
            usuario.roles = ventanaObtenerRolesSeleccionados();
            usuario.hoteles = ventanaObtenerHotelesSeleccionados();
        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                ventanaModificarUsuario();
                if (Database.usuarioModificadoConExito(usuario))
                {
                    this.Hide();
                    ventanaUsuario.ventanaActualizar();
                    if (usuario.id == ventanaUsuario.ventanaMenuPrincipal.sesion.usuario.id)
                    {
                        ventanaUsuario.ventanaMenuPrincipal.sesion.usuario = this.usuario;
                        ventanaUsuario.ventanaMenuPrincipalActualizar();
                    }
                }
            }
        }

        private void btnLimpiarUsuario_Click(object sender, EventArgs e)
        {
            tbxUsuario.Clear();
            tbxContrasena.Clear();
            comboBoxCargar(cbxRoles, Database.rolObtenerTodosEnLista());
            listBoxLimpiar(lbxRoles);
            comboBoxCargar(cbxHoteles, Database.hotelObtenerTodosEnLista());
            listBoxLimpiar(lbxHoteles);
            tbxNombre.Clear();
            tbxApellido.Clear();
            tbxDocumento.Clear();
            cbxTipoDocumento.SelectedIndex = 0;
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
            if (!this.HabilitadoDesdeInicio)
                buttonHabilitarActivar(btnHabilitar);
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

        #region Eventos 

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

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            buttonHabilitarDesactivar(btnHabilitar);
        }
    }   
}
