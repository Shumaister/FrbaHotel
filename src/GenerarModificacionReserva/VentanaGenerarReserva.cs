using FrbaHotel.AbmCliente;
using FrbaHotel.AbmUsuario;
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
        private Usuario Usuario { get; set; }
        private int CantidadDeHabitacionesNecesarias { get; set; }
        private List<string> ListaIDHabitaciones { get; set; }
        private string IdHotel { get; set; }

        public VentanaGenerarReserva()
        {
            InitializeComponent();

            Reserva = new Reserva();
            Usuario = null;
            this.logo.Visible = false;
            
            comboBoxCargar(cbxHoteles, Database.reservaObtenerHoteles());
            
            OcultarErrores();
            groupBox3.Enabled = false;
            groupBox2.Enabled = false;
        }

        #region FuncionesAuxiliares

        private void LimpiarPaso1()
        {
            this.tbxCantidadHuespedes.Clear();
            this.lblResumenReserva.Text = "";
            this.Reserva = new Reserva();
        }

        private int CantidadPersonasSegunTipoHabitacion()
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
                this.cbxRegimenEstadiaObligatorio.Items.Add(this.cbxRegimenEstadia.SelectedItem);
            }
            else
            {
                comboBoxCargar(cbxRegimenEstadiaObligatorio, Database.ReservaObtenerEstadiasDeHotel(Reserva.Hotel.id));
                this.cbxRegimenEstadiaObligatorio.Items.Insert(0, "Seleccione");
                this.cbxRegimenEstadiaObligatorio.SelectionStart = 0;
            }

            ActualizarPrecio();
        }

        private void ActualizarPrecio()
        {
            this.lblNumeroPrecioFinal.Text = "U$S " + CuentaPrecioFinal().ToString();
        }

        private double CuentaPrecioFinal()
        {
            double precioBase;

            if (Reserva.Regimen == "Seleccione")
                precioBase = 1;
            else
                precioBase = Database.ReservaObtenerPrecioBase(Reserva.Regimen);

            this.lblTipoRegimen.Text = "U$S " + precioBase;

            double recargaHotel = Database.HotelObtenerCantidadEstrellasHotelPorID(Reserva.Hotel.id) * 42.00;

            this.lblCantHabi.Text = CantidadDeHabitacionesNecesarias.ToString();
            this.lblPrecioHab.Text = cbxTipoHabitacion.SelectedItem.ToString();
            this.lblrecargahotel.Text = Database.HotelObtenerCantidadEstrellasHotelPorID(Reserva.Hotel.id).ToString()+" * 42";

            return precioBase * (CantidadDeHabitacionesNecesarias * CantidadPersonasSegunTipoHabitacion()) * recargaHotel;
        }

        private void irAPaso3()
        {

            Reserva.Cliente = null;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
        }

        private void Saludo()
        {
            Reserva.Cliente.id = Database.clienteObtenerID(Reserva.Cliente);
            this.lblCliente.Text = "Ya casi terminamos " + Reserva.Cliente.persona.nombre.ToString() + "! Solo haz click en Confirmar Reserva!";
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
                    string tipoHabi = Database.HabitacionTipobyDescripcion(cbxTipoHabitacion.SelectedItem.ToString());
                    for (int i = 0; i < CantidadDeHabitacionesNecesarias; i++)
                    {
                        Reserva.Habitaciones.Add(new Habitacion(ListaIDHabitaciones[i], tipoHabi));
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
            if (Reserva.Regimen == "Seleccione")
            {
                this.lblErrorPaso2.Visible = true;
                return;
            }

            irAPaso3();
        }


        private void cbxRegimenEstadiaObligatorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reserva.Regimen = this.cbxRegimenEstadiaObligatorio.SelectedItem.ToString();
            ActualizarPrecio();
        }

        private void btnVolverPaso2_Click(object sender, EventArgs e)
        {
            this.groupBox3.Enabled = false;
            this.groupBox2.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            VentanaCliente ventanaCliente = new VentanaCliente(Reserva);
            ventanaCliente.ShowDialog();
            Saludo();
        }

        private void btnConfirmarReserva_Click(object sender, EventArgs e)
        {
            if (Reserva.Cliente != null)
            {
                Reserva.Codigo = Database.ReservaGenerarCodigo();
                
                if(Usuario == null)
                {
                    string id = Database.usuarioObtenerID(new Usuario("guest"));
                    Reserva.Usuario = new Usuario(id,"guest");
                }
                else
                {
                    Reserva.Usuario=Usuario;
                }
                
                try
                {
                    Database.ReservaSaveReserva(Reserva);
                    MessageBox.Show("Se a registrado con exito su reservar con codigo: "+Reserva.Codigo, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se ha producido un error al registrar la reserva, revise los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion


        #region FuncionesValidaciones

        private bool EsEstadiaValida()
        {
            CantidadDeHabitacionesNecesarias = 0;

            int cantPersPorHab = CantidadPersonasSegunTipoHabitacion();

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
