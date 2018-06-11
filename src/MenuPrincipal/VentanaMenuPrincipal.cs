using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.AbmRol;
using FrbaHotel.AbmUsuario;
using FrbaHotel.Login;
using FrbaHotel.RegistrarConsumible;
using FrbaHotel.ListadoEstadistico;
using FrbaHotel.FacturarEstadia;

namespace FrbaHotel.Menus
{
    public partial class VentanaMenuPrincipal : VentanaBase
    {
        //-------------------------------------- Atributos -------------------------------------
        
        Sesion sesion { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public VentanaMenuPrincipal(Sesion sesion)
        {
            this.sesion = sesion; 
            InitializeComponent();
        }

        //-------------------------------------- Metodos para Eventos -------------------------------------

        private void VentanaMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuRoles_Click(object sender, EventArgs e)
        {
            VentanaRol ventanaRoles = new VentanaRol(sesion);
            ventanaRoles.ShowDialog();
        }

        private void menuUsuarios_Click(object sender, EventArgs e) 
        {
            VentanaUsuario ventanaUsuarios = new VentanaUsuario(sesion);
            ventanaUsuarios.ShowDialog();
        }

        private void menuCambiarContrasenia_Click(object sender, EventArgs e)
        {
            VentanaCambiarContrasenia ventanaCambiarContrasenia = new VentanaCambiarContrasenia(sesion);
            ventanaCambiarContrasenia.ShowDialog();
        }

        private void VentanaMenuPrincipal_Load(object sender, EventArgs e)
        {
            bool usuarioTieneFuncionesDeAdmnistrador = false;
            bool usuarioTieneFuncionesDeRecepcion = false;          
            if (sesion.rol.funcionalidades.Contains("Usuarios"))
            {
                menuUsuarios.Visible = true;
                usuarioTieneFuncionesDeAdmnistrador = true;
            }
            if (sesion.rol.funcionalidades.Contains("Hoteles"))
            {
                menuHoteles.Visible = true;
                usuarioTieneFuncionesDeAdmnistrador = true;
            }
            if (sesion.rol.funcionalidades.Contains("Habitaciones"))
            {
                 menuHabitaciones.Visible = true;
                usuarioTieneFuncionesDeAdmnistrador = true;
            }
            if (sesion.rol.funcionalidades.Contains("Roles"))
            {
                menuRoles.Visible = true;
                usuarioTieneFuncionesDeAdmnistrador = true;
            }
            if (sesion.rol.funcionalidades.Contains("Regimenes"))
            {
                menuRegimenes.Visible = true;
                usuarioTieneFuncionesDeAdmnistrador = true;
            }
            if (sesion.rol.funcionalidades.Contains("Reservas"))
            {
                menuReservas.Visible = true;
                usuarioTieneFuncionesDeRecepcion = true;
            }
            if (sesion.rol.funcionalidades.Contains("Facturas"))
            {
                menuFacturas.Visible = true;
                usuarioTieneFuncionesDeRecepcion = true;
            }
            if (sesion.rol.funcionalidades.Contains("Clientes"))
            {
                menuClientes.Visible = true;
                usuarioTieneFuncionesDeRecepcion = true;
            }
            if (sesion.rol.funcionalidades.Contains("Consumibles"))
            {
                menuConsumibles.Visible = true;
                usuarioTieneFuncionesDeRecepcion = true;
            }
            if (sesion.rol.funcionalidades.Contains("Estadias"))
            {
                menuEstadias.Visible = true;
                usuarioTieneFuncionesDeRecepcion = true;
            }
            if (sesion.rol.funcionalidades.Contains("Estadisticas"))
            {
                menuEstadisticas.Visible = true;
                usuarioTieneFuncionesDeRecepcion = true;
            }
            if (!usuarioTieneFuncionesDeAdmnistrador)
                menuAdministracion.Visible = false;
            if (!usuarioTieneFuncionesDeRecepcion)
                menuRecepcion.Visible = false;
        }

        private void nenuCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaLogin ventanaLogin = new VentanaLogin();
            ventanaLogin.Show();
        }

        private void menuConsumibles_Click(object sender, EventArgs e)
        {
            VentanaRegistrarConsumible registrarConsumible = new VentanaRegistrarConsumible(sesion);
            registrarConsumible.ShowDialog();
        }

        private void menuEstadisticas_Click(object sender, EventArgs e)
        {
          VentanaListadoEstadistico estadistico = new VentanaListadoEstadistico();
            estadistico.ShowDialog();
        }

        private void menuFacturas_Click(object sender, EventArgs e)
        {
            VentanaFacturarEstadia facturaestadia = new VentanaFacturarEstadia();
            facturaestadia.ShowDialog();
        }
    }
}
