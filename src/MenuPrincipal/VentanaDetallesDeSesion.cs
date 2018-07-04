using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace FrbaHotel.MenuPrincipal
{
    public partial class VentanaDetallesDeSesion : VentanaBase
    {
        public Sesion sesion { get; set; }

        public VentanaDetallesDeSesion(Sesion sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }

        private void VentanaDetallesDeSesion_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = sesion.usuario.nombre;
            lblHotel.Text = sesion.hotel.domicilio.pais + "-" + sesion.hotel.domicilio.ciudad + "-" + sesion.hotel.domicilio.calle + "-" + sesion.hotel.domicilio.numeroCalle;
            lblRol.Text = sesion.rol.nombre;
            DateTime fechaSistema = DateTime.Parse(ConfigurationManager.AppSettings["fechaSistema"]);
            lblFecha.Text = fechaSistema.Day.ToString() + "/" + fechaSistema.Month.ToString() + "/" + fechaSistema.Year.ToString();          
        }
    }
}
