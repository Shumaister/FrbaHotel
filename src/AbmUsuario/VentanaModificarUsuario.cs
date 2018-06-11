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
    public partial class VentanaModificarUsuario : VentanaBase
    {

        #region Atributos

        VentanaUsuario ventanaUsuario {get; set;}
        Sesion sesion { get; set; }
        Usuario usuario { get; set; }

        #endregion

        #region Constructores

        public VentanaModificarUsuario(VentanaUsuario ventanaUsuario, Sesion sesion, Usuario usuario)
        {
            InitializeComponent();
            this.ventanaUsuario = ventanaUsuario;
            this.sesion = sesion;
            this.usuario = usuario;
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
            if (Database.usuarioHabilitado(usuario))
                rbtActivado.Select();
            else
                rbtDesactivado.Select();
        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError) && ventanaEmailValido())
            {
                ventanaModificarUsuario();
                if (Database.usuarioModificadoConExito(usuario))
                {
                    this.Hide();
                    ventanaUsuario.ventanaActualizar();
                }
            }
        }

        private void ventanaModificarUsuario()
        {
            cbxTipoDocumento.SelectedIndex = cbxTipoDocumento.Items.IndexOf(usuario.persona.tipoDocumento);
            usuario.nombre = tbxUsuario.Text;
            usuario.contrasenia = tbxContrasena.Text;
            usuario.estado = ventanaObtenerEstado();
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

        private string ventanaObtenerEstado()
        {
            if (rbtActivado.Checked)
                return "1";
            else
                return "0";
        }

        private bool ventanaEmailValido()
        {
            Regex expresionParaEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!expresionParaEmail.IsMatch(tbxEmail.Text))
            {
                ventanaInformarError("El email no es valido");
                return false;
            }
            else
                return true;
        }

        #endregion

        #region Eventos 

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
            comboBoxCargar(cbxTipoDocumento, Database.tipoDocumentoObtenerTodosEnLista());
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
            tbxFechaNacimiento.Text = calendario.SelectionStart.ToShortDateString();
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
        #endregion
    }   
}
