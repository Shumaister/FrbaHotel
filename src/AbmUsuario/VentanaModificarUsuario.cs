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
        //-------------------------------------- Atributos -------------------------------------

        Sesion sesion { get; set; }
        Usuario usuario { get; set; }
        
        //-------------------------------------- Constructores -------------------------------------

        public VentanaModificarUsuario(Sesion sesion, Usuario usuario)
        {
            InitializeComponent();
            this.sesion = sesion;
            this.usuario = usuario;
        }

        //-------------------------------------- Metodos para Eventos -------------------------------------

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
            /*
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                if (Database.usuarioExiste(tbxUsuario.Text))
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

                Domicilio domicilioModificado = new Domicilio(tbxPais.Text, tbxCiudad.Text, tbxCalle.Text, tbxNumeroCalle.Text, tbxPiso.Text, tbxDepartamento.Text);
                Persona personaModificada = new Persona(tbxNombre.Text, tbxApellido.Text, tbxFechaNacimiento.Text.ToString(), cbxTipoDocumento.SelectedItem.ToString(), tbxDocumento.Text, tbxNacionalidad.Text, tbxTelefono.Text, tbxEmail.Text, domicilioModificado);
                Usuario usuarioModificado = new Usuario(tbxUsuario.Text, tbxContrasena.Text, personaModificada, "");
                Database.domicilioModificar(usuario.persona.domicilio, domicilioModificado);
                Database.personaModificar(personaModificada, usuario.persona.email);
                Database.usuarioModificar(usuarioModificado, tbxUsuario.Text);
                ventanaInformarExito();
            }
             */
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

        private void VentanaModificarUsuario_Load(object sender, EventArgs e)
        {
            /*
            tbxUsuario.Text = usuario.nombre;
            tbxContrasena.Text = usuario.contrasenia;
            tbxNombre.Text = usuario.persona.nombre;
            comboBoxCargar(cbxHoteles, Database.usuarioObtenerHotelesLista(usuario.nombre));
            comboBoxCargar(cbxRoles, Database.usuarioObtenerRoles(usuario.nombre));
            comboBoxCargar(cbxTipoDocumento, Database.tipoDocumentoObtenerTodosEnLista());
            tbxApellido.Text = usuario.persona.apellido;
            if(usuario.persona.tipoDocumento == "DNI")
                cbxTipoDocumento.SelectedIndex = 0;
            else
                cbxTipoDocumento.SelectedIndex = 1;
            tbxDocumento.Text = usuario.persona.numeroDocumento;
            tbxTelefono.Text = usuario.persona.telefono;
            tbxEmail.Text = usuario.persona.email;
            tbxCalle.Text = usuario.persona.domicilio.calle;
            tbxCiudad.Text = usuario.persona.domicilio.ciudad;
            tbxPais.Text = usuario.persona.domicilio.pais;
            tbxPiso.Text = usuario.persona.domicilio.piso;
            tbxDepartamento.Text = usuario.persona.domicilio.departamento;
             */
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
    }
}
