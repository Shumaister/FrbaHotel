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

namespace FrbaHotel.Menus
{
    public partial class VentanaMenuPrincipal : VentanaBase
    {
        //-------------------------------------- Atributos -------------------------------------
        
        Usuario usuario { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public VentanaMenuPrincipal(Usuario usuario)
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
            VentanaRoles ventanaRoles = new VentanaRoles(usuario);
            ventanaRoles.ShowDialog();
        }

        private void menuUsuarios_Click(object sender, EventArgs e) 
        {
            VentanaUsuarios ventanaUsuarios = new VentanaUsuarios(usuario);
            ventanaUsuarios.ShowDialog();
        }

        private void menuCambiarContrasenia_Click(object sender, EventArgs e)
        {
            VentanaCambiarContrasenia ventanaAjustesDeCuenta = new VentanaCambiarContrasenia(usuario.nombre);
            ventanaAjustesDeCuenta.ShowDialog();
        }

        private void VentanaMenuPrincipal_Load(object sender, EventArgs e)
        {
            /*
            bool usuarioTieneFuncionesDeAdmnistrador = false;
            bool usuarioTieneFuncionesDeRecepcion = false;
            
            foreach(string )
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
                menuHabitaciones.Visible = true;
            if (usuario.funcionalidades.Contains("Roles"))
                menuRoles.Visible = true;
            if (usuario.funcionalidades.Contains("Regimenes"))
                menuRegimenes.Visible = true;
            if (usuario.funcionalidades.Contains("Reservas"))
                menuReservas.Visible = true;
            if (usuario.funcionalidades.Contains("Facturas"))
                menuFacturas.Visible = true;
            if (usuario.funcionalidades.Contains("Clientes"))
                menuClientes.Visible = true;
            if (usuario.funcionalidades.Contains("Consumibles"))
                menuConsumibles.Visible = true;
            if (usuario.funcionalidades.Contains("Estadias"))
                menuEstadias.Visible = true;
            if (usuario.funcionalidades.Contains("Estadisticas"))
                menuEstadisticas.Visible = true;
            if ( > 0)
                
            else
                MessageBox.Show("NO TENGO ELEMENTORs");
             */
        }

        private void nenuCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaLogin ventanaLogin = new VentanaLogin();
            ventanaLogin.Show();
        }
    }
}
