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

namespace FrbaHotel.Menus
{
    public partial class VentanaMenuPrincipal : VentanaBase
    {
        //-------------------------------------- Atributos -------------------------------------
        
        Sesion usuario { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public VentanaMenuPrincipal(Sesion usuario)
        {
            this.usuario = usuario; 
            InitializeComponent();
        }

        //-------------------------------------- Metodos para Eventos -------------------------------------

        private void VentanaMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuRoles_Click(object sender, EventArgs e)
        {
            VentanaRol ventanaRoles = new VentanaRol(usuario);
            ventanaRoles.ShowDialog();
        }

        private void menuUsuarios_Click(object sender, EventArgs e) 
        {
            VentanaUsuario ventanaUsuarios = new VentanaUsuario(usuario);
            ventanaUsuarios.ShowDialog();
        }

        private void menuCambiarContrasenia_Click(object sender, EventArgs e)
        {
            VentanaCambiarContrasenia ventanaAjustesDeCuenta = new VentanaCambiarContrasenia(usuario.nombreUsuario);
            ventanaAjustesDeCuenta.ShowDialog();
        }

        private void VentanaMenuPrincipal_Load(object sender, EventArgs e)
        {
            bool usuarioTieneFuncionesDeAdmnistrador = false;
            bool usuarioTieneFuncionesDeRecepcion = false;          
            if (usuario.funcionalidades.Contains("Usuarios"))
            {
                menuUsuarios.Visible = true;
                usuarioTieneFuncionesDeAdmnistrador = true;
            }                
            if (usuario.funcionalidades.Contains("Hoteles"))
            {
                menuHoteles.Visible = true;
                usuarioTieneFuncionesDeAdmnistrador = true;
            }
            if (usuario.funcionalidades.Contains("Habitaciones"))
            {
                 menuHabitaciones.Visible = true;
                usuarioTieneFuncionesDeAdmnistrador = true;
            }               
            if (usuario.funcionalidades.Contains("Roles"))
            {
                menuRoles.Visible = true;
                usuarioTieneFuncionesDeAdmnistrador = true;
            }                
            if (usuario.funcionalidades.Contains("Regimenes"))
            {
                menuRegimenes.Visible = true;
                usuarioTieneFuncionesDeAdmnistrador = true;
            }
            if (usuario.funcionalidades.Contains("Reservas"))
            {
                menuReservas.Visible = true;
                usuarioTieneFuncionesDeRecepcion = true;
            }                
            if (usuario.funcionalidades.Contains("Facturas"))
            {
                menuFacturas.Visible = true;
                usuarioTieneFuncionesDeRecepcion = true;
            }
            if (usuario.funcionalidades.Contains("Clientes"))
            {
                menuClientes.Visible = true;
                usuarioTieneFuncionesDeRecepcion = true;
            }
            if (usuario.funcionalidades.Contains("Consumibles"))
            {
                menuConsumibles.Visible = true;
                usuarioTieneFuncionesDeRecepcion = true;
            }
            if (usuario.funcionalidades.Contains("Estadias"))
            {
                menuEstadias.Visible = true;
                usuarioTieneFuncionesDeRecepcion = true;
            }
            if (usuario.funcionalidades.Contains("Estadisticas"))
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
            VentanaRegistrarConsumible registrarConsumible = new VentanaRegistrarConsumible();
            registrarConsumible.ShowDialog();
        }
    }
}
