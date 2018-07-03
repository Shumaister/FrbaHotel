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
            factura.diasUtilizados = Database.estadiaObtenerDiasUtilizados(factura.estadia);
            factura.diasNoUtilizados = Database.estadiaObtenerDiasNoUtilizados(factura.estadia);

            Decimal precioHabitacion = Convert.ToDecimal(Database.facturaObtenerPrecioHabitacion(factura));
            Decimal cantidadHuespedes = Convert.ToDecimal(Database.facturaObtenerCantidadHuespedes(factura));
            Decimal recargaEstrellas = Convert.ToDecimal(Database.facturaObtenerRecargaEstrellas(factura));
            Decimal precioRegimen = Convert.ToDecimal(Database.facturaObtenerPrecioRegimen(factura));
            Decimal montoEstadiaDia = precioRegimen * recargaEstrellas * cantidadHuespedes * precioHabitacion;
            Decimal cantidadDias = Convert.ToDecimal(Database.facturaObtenerCantidadDias(factura));
            Decimal montoEstadiaDiasUtilizados = montoEstadiaDia * Convert.ToDecimal(factura.diasUtilizados);
            Decimal montoEstadiaDiasNoUtilizados = montoEstadiaDia * Convert.ToDecimal(factura.diasNoUtilizados);
            Decimal montoTotalEstadia = montoEstadiaDiasUtilizados + montoEstadiaDiasNoUtilizados;
            Decimal montoTotalConsumibles = Convert.ToDecimal(Database.facturaObtenerMontoConsumidos(factura));
            Decimal descuentoRegimen = Database.reservaTieneRegimenAllInclusive(tbxReserva.Text)? montoTotalConsumibles : Convert.ToDecimal("0");
            Decimal montoTotal = montoTotalEstadia + montoTotalConsumibles - descuentoRegimen;

            factura.formaPago = cbxFormasPagos.SelectedItem.ToString();
            factura.montoEstadiaDiasUtilizados = montoEstadiaDiasUtilizados;
            factura.montoEstadiaDiasNoUtilizados = montoEstadiaDiasNoUtilizados;
            factura.montoConsumibles = montoTotalConsumibles;
            factura.montoTotal = montoTotal;

            lblPrecioHabitacion.Text = precioHabitacion.ToString();
            lblCantidadHuespedes.Text = cantidadHuespedes.ToString();
            lblRecargaEstrellas.Text = recargaEstrellas.ToString() ;
            lblPrecioRegimen.Text = precioRegimen.ToString();
            lblMontoEstadiaDia.Text = montoEstadiaDia.ToString();
            lblDiasUtilizados.Text = factura.diasUtilizados;
            lblDiasNoUtilizados.Text = factura.diasNoUtilizados;
            lblMontoEstadiaDiasUtilizados.Text = montoEstadiaDiasUtilizados.ToString();
            lblMontoEstadiaDiasNoUtilizados.Text = montoEstadiaDiasNoUtilizados.ToString();
            lblMontoTotalEstadia.Text = montoTotalEstadia.ToString();
            lblMontoTotalConsumibles.Text = montoTotalConsumibles.ToString();
            lblDescuentoRegimen.Text = descuentoRegimen.ToString();
            lblMontoTotal.Text = montoTotal.ToString();
        }

        private void ventanaLimpiar()
        {
            lblPrecioHabitacion.Text = "-";
            lblCantidadHuespedes.Text = "-";
            lblRecargaEstrellas.Text = "-";
            lblPrecioRegimen.Text = "-";
            lblMontoEstadiaDia.Text = "-";
            lblDiasUtilizados.Text = "-";
            lblDiasNoUtilizados.Text = "-";
            lblMontoEstadiaDiasUtilizados.Text = "-";
            lblMontoEstadiaDiasNoUtilizados.Text = "-";
            lblMontoTotalEstadia.Text = "-";
            lblMontoTotalConsumibles.Text = "-";
            lblDescuentoRegimen.Text = "-";
            lblMontoTotal.Text = "-";
            dgvConsumibles.DataSource = null;
        }

        private void tbxBuscar_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                if (lblHotel.Text == "Ninguno")
                {
                    ventanaInformarError("El codigo de la reserva es invalido");
                    return;
                }
                Consumido consumido = new Consumido();
                consumido.reservaCodigo = tbxReserva.Text;
                consumido.numeroHabitacion = cbxHabitacion.SelectedItem.ToString();
                consumido.hotelID = sesion.hotel.id;
                consumido.estadiaID = Database.consumidoObtenerEstadiaID(consumido);
                if (consumido.estadiaID == "")
                {
                    ventanaInformarError("La estadia aun no fue finalizada");
                    return;
                }
                if (!Database.consumidoEstadiaConConsumiblesRegistrados(consumido))
                {
                    ventanaInformarError("Los consumibles aun no fueron registrados");
                    return;
                }
                factura.estadia.id = consumido.estadiaID;
                factura.estadia.reserva.Codigo = consumido.reservaCodigo;
                ventanaObtenerDatos();
                dataGridViewCargar(dgvConsumibles, Database.consumidoObtenerConsumiblesEnTabla(consumido));
                btnPagar.Enabled = true;
                cbxFormasPagos.Enabled = true;
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
            this.factura = new Factura();
            factura.estadia = new Estadia();
            factura.estadia.reserva = new Reserva();
            comboBoxCargar(cbxFormasPagos, Database.formaPagoObtenerTodasEnLista());
            ventanaEstadiaInvalida();
        }

        private void tbxReserva_TextChanged(object sender, EventArgs e)
        {
            ventanaLimpiar();
            if (string.IsNullOrWhiteSpace(tbxReserva.Text))
                ventanaEstadiaInvalida();
            else
            {
                string hotelNombre = Database.reservaObtenerHotel(tbxReserva.Text, sesion.hotel.id);
                if (hotelNombre != "")
                {
                    lblHotel.Text = hotelNombre;
                    lblRegimen.Text = Database.reservaObtenerRegimen(tbxReserva.Text);
                    comboBoxCargar(cbxHabitacion, Database.reservaObtenerHabitacionesEnLista(tbxReserva.Text));
                    if (cbxHabitacion.Items.Count == 0)
                        ventanaEstadiaInvalida();
                }
                else
                    ventanaEstadiaInvalida();
            }
        }

        private void ventanaEstadiaInvalida()
        {
            lblHotel.Text = "Ninguno";
            lblRegimen.Text = "Ninguno";
            cbxHabitacion.Items.Clear();
            cbxHabitacion.Items.Add("Ninguna");
            cbxHabitacion.SelectedIndex = 0;
            btnPagar.Enabled = false;
            cbxFormasPagos.Enabled = false;
        }
    }
}
