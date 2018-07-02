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
using FrbaHotel.AbmCliente;
using FrbaHotel.AbmHabitacion;
using FrbaHotel.AbmHotel;
using FrbaHotel.Login;
using FrbaHotel.RegistrarConsumible;
using FrbaHotel.ListadoEstadistico;
using FrbaHotel.FacturarEstadia;
using FrbaHotel.AbmRegimen;
using FrbaHotel.RegistrarEstadia;
using FrbaHotel.MenuPrincipal;

namespace FrbaHotel.Menus
{
    public partial class VentanaMenuPrincipal : VentanaBase
    {
        //-------------------------------------- Atributos -------------------------------------
        
        public Sesion sesion { get; set; }

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

        public void ventanaReiniciar()
        {
            menuAdministracion.Visible = true;
            menuRecepcion.Visible = true;
            menuUsuarios.Visible = false;
            menuHoteles.Visible = false;
            menuHabitaciones.Visible = false;
            menuRoles.Visible = false;
            menuRegimenes.Visible = false;
            menuReservas.Visible = false;
            menuFacturas.Visible = false;
            menuClientes.Visible = false;
            menuConsumibles.Visible = false;
            menuEstadias.Visible = false;
            menuEstadisticas.Visible = false;
        }

        public void VentanaMenuPrincipal_Load(object sender, EventArgs e)
        {
            ventanaReiniciar();
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
                menuEstadisticas.Visible = true;

            if (!usuarioTieneFuncionesDeAdmnistrador)
                menuAdministracion.Visible = false;
            if (!usuarioTieneFuncionesDeRecepcion)
                menuRecepcion.Visible = false;
        }

        private void menuRoles_Click(object sender, EventArgs e)
        {
            new VentanaRol(this).ShowDialog();
        }

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            new VentanaUsuario(this).ShowDialog();
        }

        private void menuHoteles_Click(object sender, EventArgs e)
        {
             new VentanaHotel(this).ShowDialog();
        }

        private void menuHabitaciones_Click(object sender, EventArgs e)
        {
            new VentanaHabitacion(sesion).ShowDialog();
        }

        private void menuClientes_Click(object sender, EventArgs e)
        {
            new VentanaCliente().ShowDialog();
        }

        private void menuConsumibles_Click(object sender, EventArgs e)
        {
            new VentanaConsumibles(sesion).ShowDialog();
        }

        private void menuEstadisticas_Click(object sender, EventArgs e)
        {
            new VentanaListadoEstadistico().ShowDialog();
        }

        private void menuFacturas_Click(object sender, EventArgs e)
        {
            new VentanaFacturarEstadia(sesion).ShowDialog();
        }

        private void menuRegimenes_Click(object sender, EventArgs e)
        {
            new VentanaEnDesarrollo().ShowDialog();
         }

        private void menuEstadias_Click(object sender, EventArgs e)
        {
            new VentanaRegistrarEstadia(sesion).ShowDialog();
        }

        private void menuCambiarContrasenia_Click(object sender, EventArgs e)
        {
            new VentanaCambiarContrasenia(sesion).ShowDialog();
        }

        private void nenuCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            new VentanaLogin().Show();
        }

        private void menuDetallesDeSesion_Click(object sender, EventArgs e)
        {
            new VentanaDetallesDeSesion(sesion).ShowDialog();
        }
    }
}
