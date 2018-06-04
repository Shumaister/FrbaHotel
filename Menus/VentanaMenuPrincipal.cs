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
            VentanaRoles ventanaRoles = new VentanaRoles(this);
            ventanaRoles.MdiParent = this;
            ventanaRoles.Show();
        }

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            VentanaUsuarios ventanaUsuarios = new VentanaUsuarios();
            ventanaUsuarios.MdiParent = this;
            ventanaUsuarios.Show();
        }

        private void menuCambiarContrasenia_Click(object sender, EventArgs e)
        {
            VentanaAjustesDeCuenta ventanaAjustesDeCuenta = new VentanaAjustesDeCuenta(usuario.nombre);
            ventanaAjustesDeCuenta.MdiParent = this;
            ventanaAjustesDeCuenta.Show();
        }

        private void VentanaMenuPrincipal_Load(object sender, EventArgs e)
        {
            usuario.rolLogueado = "Recepcionista";
            usuario.funcionalidades = Database.rolObtenerFuncionalidades(usuario.rolLogueado);
            if (usuario.funcionalidades.Contains("Usuarios"))
                menuUsuarios.Visible = true;
            if (usuario.funcionalidades.Contains("Hoteles"))
                menuHoteles.Visible = true;
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
        }
    }
}
