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
        private string funcion;
        private Sesion Sesion;
        public Reserva Reserva { get; set; }
        public Reserva ReservaOriginal { get; set; }
        public Cliente Cliente { get; set; }
        private Usuario Usuario { get; set; }
        private int CantidadDeHabitacionesNecesarias { get; set; }
        private List<string> ListaIDHabitaciones { get; set; }
        private string IdHotel { get; set; }

        #region Constructores

        public VentanaGenerarReserva()
        {
            InitializeComponent();

            Reserva = new Reserva();
            Usuario = null;
            this.logo.Visible = false;
            this.funcion = "Crear";

            comboBoxCargar(cbxHoteles, Database.reservaObtenerHoteles());
            
            OcultarErrores();
            groupBox3.Enabled = false;
            groupBox2.Enabled = false;
       }

        public VentanaGenerarReserva(Reserva reserva, string p)
        {
            InitializeComponent();
            this.Reserva = reserva;
            this.ReservaOriginal = reserva;
            this.funcion = p;
            this.Cliente = Database.ReservaObtenerClienteByIdReserva(ReservaOriginal.Codigo);
            this.ReservaOriginal.Cliente = Database.ReservaObtenerClienteByIdReserva(ReservaOriginal.Codigo);
            comboBoxCargar(cbxHoteles, Database.reservaObtenerHoteles());

            OcultarErrores();
            groupBox3.Enabled = false;
            groupBox2.Enabled = false;
            
            cargarReservaAModificar();
        }

        public VentanaGenerarReserva(Sesion sesion)
        {
            InitializeComponent();
            this.Sesion = sesion;
            this.funcion = "CreaUsuario";

            string hotelloguea = Sesion.hotel.domicilio.pais + "-" + Sesion.hotel.domicilio.ciudad + "-" + Sesion.hotel.domicilio.calle + "-" + Sesion.hotel.domicilio.numeroCalle;
            List<string> h = new List<string>();
            h.Add(hotelloguea);

            comboBoxCargar(cbxHoteles, h);
            this.cbxHoteles.Enabled = false;

            Reserva = new Reserva();
            Usuario = Sesion.usuario;
            this.logo.Visible = false;

            OcultarErrores();
            groupBox3.Enabled = false;
            groupBox2.Enabled = false;
        }

        public VentanaGenerarReserva(Sesion sesion, Clases.Reserva reserva, string p)
        {
            this.Sesion = sesion;
            this.Reserva = reserva;
            this.funcion = p;
            this.Usuario = sesion.usuario;

            InitializeComponent();
            this.ReservaOriginal = reserva;
            
            this.Cliente = Database.ReservaObtenerClienteByIdReserva(ReservaOriginal.Codigo);
            this.ReservaOriginal.Cliente = Database.ReservaObtenerClienteByIdReserva(ReservaOriginal.Codigo);

            string hotelloguea = Sesion.hotel.domicilio.pais + "-" + Sesion.hotel.domicilio.ciudad + "-" + Sesion.hotel.domicilio.calle + "-" + Sesion.hotel.domicilio.numeroCalle;
            List<string> h = new List<string>();
            h.Add(hotelloguea);

            comboBoxCargar(cbxHoteles, h);
            this.cbxHoteles.Enabled = false;


            OcultarErrores();
            groupBox3.Enabled = false;
            groupBox2.Enabled = false;

            cargarReservaAModificar();        
        }

        #endregion

        #region FuncionesAuxiliares

        private void cargarReservaAModificar()
        {
            this.cbxHoteles.SelectedIndex = cbxHoteles.FindStringExact(Database.reservaObtenerHotelbyID(Reserva.Hotel.id));
            this.cbxTipoHabitacion.SelectedIndex = cbxTipoHabitacion.FindStringExact(Database.HabitacionTipobyID(Reserva.Habitaciones[0].tipoHabitacion));
            this.tbxCantidadHuespedes.Text = Reserva.CantidadHuespedes.ToString();
            this.cbxRegimenEstadia.SelectedIndex = cbxRegimenEstadia.FindStringExact(Database.reservaObtenerRegimen(Reserva.Codigo));
            this.calendarInicio.SelectionStart = ReservaOriginal.FechaInicio;
            this.calendarFin.SelectionStart = ReservaOriginal.FechaFin;
        }

       
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
                case "King":
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
            
            string anterior = Reserva.Regimen;
            comboBoxCargar(cbxRegimenEstadiaObligatorio, Database.ReservaObtenerEstadiasDeHotel(Reserva.Hotel.id));
            this.cbxRegimenEstadiaObligatorio.Items.Insert(0, "Seleccione");
            Reserva.Regimen = anterior;
    
            if (Reserva.Regimen != "Seleccione")
            {
                this.cbxRegimenEstadiaObligatorio.Enabled = false;
                this.cbxRegimenEstadiaObligatorio.SelectedIndex = this.cbxRegimenEstadia.FindStringExact(Reserva.Regimen);
            }
            else
            {
                this.cbxRegimenEstadiaObligatorio.SelectedIndex = 0;
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

            this.lblTipoRegimen.Text = "U$S " + precioBase + " (" + Reserva.Regimen + ")";

            double recargaHotel = Database.HotelObtenerCantidadEstrellasHotelPorID(Reserva.Hotel.id);
            double precioHab = Database.HabitacionObtenerPrecioBaseByTipo(Reserva.Habitaciones[0].tipoHabitacion);

            this.lblCantHabi.Text = CantidadDeHabitacionesNecesarias.ToString();
            this.lblPrecioHab.Text = "U$S " + precioHab + " (" + cbxTipoHabitacion.SelectedItem.ToString() + ")";
            this.lblrecargahotel.Text = Database.HotelObtenerCantidadEstrellasHotelPorID(Reserva.Hotel.id).ToString();

            double precioxdia= (precioBase * (precioHab * Reserva.CantidadHuespedes) * recargaHotel);
            this.lblpreciodiahab.Text = "U$S " + precioxdia.ToString();
            
            int dias =(Reserva.FechaFin - Reserva.FechaInicio).Days;
            this.lblcantidaddias.Text = dias.ToString();

            return precioxdia*dias;
        }

        private void irAPaso3()
        {
            this.btnNuevo.Enabled = true;
            Reserva.Cliente = null;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;

            if (funcion == "ModificaCliente")
            {
                this.btnNuevo.Enabled = false;
                this.btnClienteExistente.Enabled = false;
                this.ReservaOriginal.Cliente = this.Cliente;
                this.lblCliente.Text = "Ya casi terminamos " + ReservaOriginal.Cliente.persona.nombre.ToString() + "! Solo haz click en Confirmar Reserva!";
            }
            if (funcion == "CreaUsuario")
            {
                this.btnNuevo.Text = "Nuevo Cliente";
                this.btnClienteExistente.Text = "Ya es Cliente";
                this.lblCliente.Text = "La reserva es generada con el usuario " + Sesion.usuario.nombre;
            }
            if (funcion == "ModificaUsuario")
            {
                this.btnNuevo.Text = "Nuevo Cliente";
                this.btnClienteExistente.Text = "Ya es Cliente";
                this.lblCliente.Text = "La reserva es generada con el usuario " + Sesion.usuario.nombre;

                this.btnNuevo.Enabled = false;
                this.btnClienteExistente.Enabled = false;
                this.ReservaOriginal.Cliente = this.Cliente;
            }
        }

        private void CargarCliente()
        {
            try
            {
                if (funcion == "CreaUsuario" || funcion == "ModificaUsuario")
                {
                    Saludo();
                    this.lblCliente.Text = "La reserva es generada a nombre del cliente " + Reserva.Cliente.persona.nombre;
                }
                else
                {
                    Saludo();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Recuerde que debe ingresar obligatoriamiente quien es el cliente de la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Saludo()
        {
            Reserva.Cliente.id = Database.clienteObtenerID(Reserva.Cliente);
            this.lblCliente.Text = "Ya casi terminamos " + Reserva.Cliente.persona.nombre.ToString() + "! Solo haz click en Confirmar Reserva!";
            this.btnNuevo.Enabled = false;
        }

        private void ModificarReserva()
        {
            if (CamposCompletos())
            {
                if (EsEstadiaValidaModificacion())
                {
                    Reserva.Habitaciones = new List<Habitacion>();
                    string tipoHabi = Database.HabitacionTipobyDescripcion(cbxTipoHabitacion.SelectedItem.ToString());
                    for (int i = 0; i < CantidadDeHabitacionesNecesarias; i++)
                    {
                        Habitacion ha = new Habitacion();
                        ha.id = ListaIDHabitaciones[i];
                        ha.tipoHabitacion = tipoHabi;
                        Reserva.Habitaciones.Add(ha);
                    }

                    Reserva.FechaInicio = calendarInicio.SelectionStart;
                    Reserva.FechaFin = calendarFin.SelectionStart;

                    Reserva.CantidadHuespedes = int.Parse(this.tbxCantidadHuespedes.Text.Trim());

                    Reserva.Regimen = cbxRegimenEstadia.SelectedItem.ToString();

                    Reserva.Hotel = new Hotel(IdHotel);

                    lblResumenReserva.Text = "Para la cantidad de " + Reserva.CantidadHuespedes + " huespedes,\nCon fecha inicio: " + Reserva.FechaInicio.ToShortDateString() + " con fecha fin: " + Reserva.FechaFin.ToShortDateString() + "\nNecesitara " + CantidadDeHabitacionesNecesarias.ToString() + " habitaciones " + cbxTipoHabitacion.SelectedItem.ToString();

                    groupBox1.Enabled = false;
                    irAPaso2();
                }
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

            if (this.funcion == "ModificaCliente")
            {
                ModificarReserva();
            }
            else
            {
                if (CamposCompletos())
                {
                    if (EsEstadiaValida())
                    {
                        Reserva.Habitaciones = new List<Habitacion>();
                        string tipoHabi = Database.HabitacionTipobyDescripcion(cbxTipoHabitacion.SelectedItem.ToString());
                        for (int i = 0; i < CantidadDeHabitacionesNecesarias; i++)
                        {
                            Habitacion ha = new Habitacion();
                            ha.id = ListaIDHabitaciones[i];
                            ha.tipoHabitacion = tipoHabi;
                            Reserva.Habitaciones.Add(ha);
                        }

                        Reserva.FechaInicio = calendarInicio.SelectionStart;
                        Reserva.FechaFin = calendarFin.SelectionStart;

                        Reserva.CantidadHuespedes = int.Parse(this.tbxCantidadHuespedes.Text.Trim());

                        Reserva.Regimen = cbxRegimenEstadia.SelectedItem.ToString();

                        Reserva.Hotel = new Hotel(IdHotel);

                        lblResumenReserva.Text = "Para la cantidad de " + Reserva.CantidadHuespedes + " huespedes,\nCon fecha inicio: " + Reserva.FechaInicio.ToShortDateString() + " con fecha fin: " + Reserva.FechaFin.ToShortDateString() + "\nNecesitara " + CantidadDeHabitacionesNecesarias.ToString() + " habitaciones " + cbxTipoHabitacion.SelectedItem.ToString();

                        groupBox1.Enabled = false;
                        irAPaso2();
                    }
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            Reserva.Regimen = "Seleccione";
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

            CargarCliente();
        }


        private void btnClienteExistente_Click(object sender, EventArgs e)
        {
            new VentanaCliente(this, "BuscarDesdeReserva").ShowDialog();

            CargarCliente();
        }

        private void btnConfirmarReserva_Click(object sender, EventArgs e)
        {
            if (funcion == "Crear")
            {
                if (Reserva.Cliente != null)
                {
                    Reserva.Codigo = Database.ReservaGenerarCodigo();

                    if (Usuario == null)
                    {
                        string id = Database.usuarioObtenerID(new Usuario("guest"));
                        Reserva.Usuario = new Usuario(id, "guest");
                    }
                    else
                    {
                        Reserva.Usuario = Usuario;
                    }

                    try
                    {
                        Database.ReservaSaveReserva(Reserva);
                        this.lblcodreserva.Text = "Su codigo de reserva es: " + Reserva.Codigo;
                        MessageBox.Show("Se a registrado con exito su reserva con codigo: " + Reserva.Codigo, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Se ha producido un error al registrar la reserva, revise los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (funcion == "ModificaCliente")
            {
                Reserva.Usuario.id = Database.usuarioObtenerID(Reserva.Usuario);
                Reserva.Cliente = ReservaOriginal.Cliente;
                Reserva.Cliente.id = Database.clienteObtenerIDPersona(Reserva.Cliente.persona.id);
                try
                {
                    Database.ReservaSaveReserva(Reserva);
                    this.lblcodreserva.Text = "Su codigo de reserva es: " + Reserva.Codigo;
                    MessageBox.Show("Se a modificado con exito su reserva con codigo: " + Reserva.Codigo, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se ha producido un error al registrar la reserva, revise los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (funcion == "CreaUsuario")
            {
                Reserva.Codigo = Database.ReservaGenerarCodigo();

                Reserva.Usuario = Usuario;

                try
                {
                    Database.ReservaSaveReserva(Reserva);
                    this.lblcodreserva.Text = "Su codigo de reserva es: " + Reserva.Codigo;
                    MessageBox.Show("Se a registrado con exito su reserva con codigo: " + Reserva.Codigo, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se ha producido un error al registrar la reserva, revise los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (funcion == "ModificaUsuario")
            {
                Reserva.Usuario = Usuario;
                Reserva.Cliente = ReservaOriginal.Cliente;
                Reserva.Cliente.id = Database.clienteObtenerIDPersona(Reserva.Cliente.persona.id);
                try
                {
                    Database.ReservaSaveReserva(Reserva);
                    this.lblcodreserva.Text = "Su codigo de reserva es: " + Reserva.Codigo;
                    MessageBox.Show("Se a modificado con exito su reserva con codigo: " + Reserva.Codigo, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            int personasSinHabitacion = int.Parse(this.tbxCantidadHuespedes.Text.Trim());
            bool flag = true;

            while (flag)
            {
                CantidadDeHabitacionesNecesarias += 1;

                personasSinHabitacion = personasSinHabitacion - cantPersPorHab;

                if (personasSinHabitacion <= cantPersPorHab)
                {
                    if(personasSinHabitacion > 0)
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

        private bool EsEstadiaValidaModificacion()
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
                    if (personasSinHabitacion > 0)
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

            ListaIDHabitaciones = Database.ReservaHabitacionesModificacionDisponiblesEntre(this.calendarInicio.SelectionStart, this.calendarFin.SelectionStart, IdHotel, ReservaOriginal.Codigo);

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

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        #endregion



    }
}
