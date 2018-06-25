using FrbaHotel.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class VentanaGenerarReserva : VentanaBase
    {
        private Reserva Reserva { get; set; }
        private int CantidadDeHabitacionesNecesarias { get; set; }
        private List<string> ListaIDHabitaciones { get; set; }
        private string IdHotel { get; set; }

        public VentanaGenerarReserva()
        {
            InitializeComponent();

            Reserva = new Reserva();
            this.logo.Visible = false;
            
            comboBoxCargar(cbxHoteles, Database.reservaObtenerHoteles());
            
            OcultarErrores();
            groupBox2.Enabled = false;
        }

        #region FuncionesAuxiliares

        private void LimpiarPaso1()
        {
            this.tbxCantidadHuespedes.Clear();
            this.lblResumenReserva.Text = "";
            this.Reserva = new Reserva();
        }

        private int cantidadPersonasSegunTipoHabitacion()
        {
            int cant;

            switch (cbxTipoHabitacion.SelectedItem.ToString())
            {
                case "Base Simple":
                    {
                        cant = 1;
                        break;
                    }
                case "Base Doble":
                    {
                        cant = 2;
                        break;
                    }
                case "Base Triple":
                    {
                        cant = 3;
                        break;
                    }
                case "Base Cuadruple":
                    {
                        cant = 4;
                        break;
                    }
                case "Base King":
                    {
                        cant = 5;
                        break;
                    }
                default:
                    {
                        throw new Exception("No se definio de cuantas personas se trata la modalidad " + cbxTipoHabitacion.SelectedItem.ToString());
                    }
            }
            return cant;
        }

        private void OcultarErrores()
        {
            this.lblerrorcantidad.Visible = false;
            this.lblerrorfechas.Visible = false;
            this.lblErrorPaso1.Visible = false;
            this.lblErroHabitacionesHotel.Visible = false;
        }

        private void irAPaso2()
        {
            groupBox2.Enabled = true;

            if (Reserva.Regimen != "Seleccione")
            {
                this.cbxRegimenEstadiaObligatorio.Enabled = false;
                int eleccion = this.cbxRegimenEstadia.SelectedIndex;
                this.cbxRegimenEstadiaObligatorio.SelectedIndex = eleccion;
            }
            else
            {
                comboBoxCargar(cbxRegimenEstadiaObligatorio, Database.ReservaObtenerEstadiasDeHotel(Reserva.Hotel.id));
            }
        }

        #endregion


        #region Eventos

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarPaso1();
        }
        
        private void tbxCantidadHuespedes_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void cbxHoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCargar(cbxTipoHabitacion, Database.tipoHabitacionObtenerTodasEnLista());

            Hotel hotel = Database.hotelObtenerDesdeNombre(cbxHoteles.SelectedItem.ToString());
            comboBoxCargar(cbxRegimenEstadia, Database.ReservaObtenerEstadiasDeHotel(hotel.id));

            this.cbxRegimenEstadia.Items.Insert(0, "Seleccione");
        }

        private void calendarInicio_DateChanged(object sender, DateRangeEventArgs e)
        {
            lblFechaInicio.Text = this.calendarInicio.SelectionStart.ToShortDateString();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            lblFechaFin.Text = this.calendarFin.SelectionStart.ToShortDateString();
        }

        private void btnCheckear_Click(object sender, EventArgs e)
        {
            OcultarErrores();

            if (CamposCompletos())
            {
                if (EsEstadiaValida())
                {
                    Reserva.Habitaciones = new List<Habitacion>();

                    for (int i = 0; i <= CantidadDeHabitacionesNecesarias; i++)
                    {
                        Reserva.Habitaciones.Add(new Habitacion(ListaIDHabitaciones[i]));
                    }

                    Reserva.FechaInicio = calendarInicio.SelectionStart;
                    Reserva.FechaFin = calendarFin.SelectionStart;
                    
                    Reserva.CantidadHuespedes = int.Parse(this.tbxCantidadHuespedes.Text.Trim());

                    Reserva.Regimen= cbxRegimenEstadia.SelectedItem.ToString();

                    Reserva.Hotel = new Hotel(IdHotel);

                    lblResumenReserva.Text = "Para la cantidad de " + Reserva.CantidadHuespedes + " huespedes,\nCon fecha inicio: " + Reserva.FechaInicio.ToShortDateString() + " con fecha fin: " + Reserva.FechaFin.ToShortDateString() +"\nNecesitara "+CantidadDeHabitacionesNecesarias.ToString()+" habitaciones "+cbxTipoHabitacion.SelectedItem.ToString();

                    groupBox1.Enabled = false;
                    irAPaso2();
                }
            }
            else
            {
                LimpiarPaso1();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
        }

        private void btnConfirmarPrecio_Click(object sender, EventArgs e)
        {

        }

        #endregion


        #region FuncionesValidaciones

        private bool EsEstadiaValida()
        {
            CantidadDeHabitacionesNecesarias = 0;

            int cantPersPorHab = cantidadPersonasSegunTipoHabitacion();

            int aux = 0;
            int personasSinHabitacion = int.Parse(this.tbxCantidadHuespedes.Text.Trim());
            bool flag = true;
            while (flag)
            {
                CantidadDeHabitacionesNecesarias += 1;

                personasSinHabitacion = personasSinHabitacion - cantPersPorHab;

                if (personasSinHabitacion <= cantPersPorHab)
                {
                    CantidadDeHabitacionesNecesarias += 1;
                    flag = false;
                }
            }

            string domicilioPelado = cbxHoteles.SelectedItem.ToString();
            Domicilio domicilio = new Domicilio();
            domicilio.pais = domicilioPelado.Split('-')[0].Trim();
            domicilio.ciudad = domicilioPelado.Split('-')[1].Trim();
            domicilio.calle = domicilioPelado.Split('-')[2].Trim();
            domicilio.numeroCalle = domicilioPelado.Split('-')[3].Trim();

            Hotel hotel = new Hotel(domicilio);
            IdHotel = Database.hotelObtenerIDPorDomicilio(hotel);

            ListaIDHabitaciones = Database.ReservaHabitacionesDisponiblesEntre(this.calendarInicio.SelectionStart, this.calendarFin.SelectionStart, IdHotel);

            if (ListaIDHabitaciones.Count < CantidadDeHabitacionesNecesarias)
            {
                lblErroHabitacionesHotel.Visible = true;
                return false;
            }
            return true;
        }

        private bool CamposCompletos()
        {
            if (calendarFin.SelectionStart <= calendarInicio.SelectionStart)
            {
                this.lblerrorfechas.Visible = true;
                return false;
            }

            if (!ventanaCamposEstanCompletos(this.groupBox1, controladorError))
            {
                this.lblerrorcantidad.Text = "Este campo no puede estar vacio";
                this.lblerrorcantidad.Visible = true;
                return false;
            }
            else
            {

                if (int.Parse(this.tbxCantidadHuespedes.Text.Trim()) <= 0)
                {
                    this.lblerrorcantidad.Text = "La cantidad debe ser un numero mayor a 0";
                    this.lblerrorcantidad.Visible = true;
                    return false;
                }
            }


            return true;
        }

        #endregion



        #region CreadoSinQuerer

        private void lblerrorfechas_Click(object sender, EventArgs e)
        {

        }

        private void VentanaGenerarReserva_Load(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarFecha_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbxRegimenEstadia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        #endregion

  



      
    }
}
