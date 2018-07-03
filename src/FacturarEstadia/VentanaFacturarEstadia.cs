using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Data.SqlTypes;
using System.Configuration;
using FrbaHotel.Login;
using FrbaHotel.Clases;
using System.Text.RegularExpressions;

namespace FrbaHotel.FacturarEstadia
{
    public partial class VentanaFacturarEstadia : VentanaBase
    {
        public Sesion sesion { get; set; }
        public Factura factura { get; set; }

        public VentanaFacturarEstadia(Sesion sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }

        private void ventanaObtenerDatos()
        {
            this.factura = new Factura();
            factura.estadia = new Estadia();
            factura.estadia.reserva = new Reserva();
            factura.estadia.reserva.Codigo = tbxReserva.Text;
            factura.estadia.id = Database.estadiaObtenerID(factura.estadia);
            Decimal precioHabitacion = Convert.ToDecimal(Database.facturaObtenerPrecioHabitacion(factura));
            Decimal cantidadHuespedes = Convert.ToDecimal(Database.facturaObtenerCantidadHuespedes(factura));
            Decimal recargaEstrellas = Convert.ToDecimal(Database.facturaObtenerRecargaEstrellas(factura));
            Decimal precioRegimen = Convert.ToDecimal(Database.facturaObtenerPrecioRegimen(factura));
            Decimal montoEstadiaDia = precioRegimen * recargaEstrellas * cantidadHuespedes * precioHabitacion;
            Decimal cantidadDias = Convert.ToDecimal(Database.facturaObtenerCantidadDias(factura));
            Decimal montoTotalEstadia = montoEstadiaDia * cantidadDias;
            Decimal montoTotalConsumibles = Convert.ToDecimal(Database.facturaObtenerMontoConsumidos(factura));
            Decimal descuentoRegimen = Database.reservaTieneRegimenAllInclusive(tbxReserva.Text)? montoTotalConsumibles : Convert.ToDecimal("0");
            Decimal montoTotal = montoTotalEstadia + montoTotalConsumibles - descuentoRegimen;

            lblPrecioHabitacion.Text = precioHabitacion.ToString();
            lblCantidadHuespedes.Text = cantidadHuespedes.ToString();
            lblRecargaEstrellas.Text = recargaEstrellas.ToString() ;
            lblPrecioRegimen.Text = precioRegimen.ToString();
            lblMontoEstadiaDia.Text = montoEstadiaDia.ToString();
            lblCantidadDias.Text = cantidadDias.ToString();
            lblMontoTotalEstadia.Text = montoTotalEstadia.ToString();
            lblMontoTotalConsumibles.Text = montoTotalConsumibles.ToString();
            lblDescuentoRegimen.Text = descuentoRegimen.ToString();
            lblMontoTotal.Text = montoTotal.ToString();

            factura.montoEstadiaDia = montoEstadiaDia;
            factura.diasUtilizados = Database.estadiaObtenerDiasUtilizados(factura.estadia);
            factura.diasNoUtilizados = Database.estadiaObtenerDiasNoUtilizados(factura.estadia);
            factura.formaPago = cbxFormasPagos.SelectedItem.ToString();
            factura.montoTotal = montoTotal.ToString();
        }

        private void tbxBuscar_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                ventanaObtenerDatos();
                dataGridViewCargar(dgvConsumibles, Database.estadiaObtenerConsumidosEnTabla(factura.estadia));
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            Database.facturaAgregadaConExito(factura);
        }

        private void tbxReserva_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void VentanaFacturarEstadia_Load(object sender, EventArgs e)
        {
            comboBoxCargar(cbxFormasPagos, Database.formaPagoObtenerTodasEnLista());
        }
    }
}
