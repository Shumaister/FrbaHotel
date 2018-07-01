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
        public Sesion sesionLogueada { get; set; }
        public VentanaFacturarEstadia(Sesion sesion)
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            sub.Text = "";
            this.sesionLogueada = sesion;
        }


        private void VentanaFacturarEstadia_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CodReserva.Text))
            {
                MessageBox.Show("Codigo de reserva no valido");
                return;
            }
            Regex reg = new Regex(@"^[0-9]+$");

            if (!reg.IsMatch(CodReserva.Text))
            {
                MessageBox.Show("La reserva tiene caracteres invalidos");
                return;
            }


            SqlCommand consulta = Database.consultaCrear("select Consumible_Descripcion 'Consumible',Consumido_Cantidad'Cantidad',Consumible_Precio'Precio',Consumido_Cantidad*Consumible_Precio'Total' from rip.Consumidos join rip.Consumibles on Consumible_ID=Consumido_ConsumibleID join rip.Estadias on Estadia_ID=Consumido_EstadiaID join rip.Reservas on Reserva_ID=Estadia_ReservaID where Reserva_ID=@reserva");
            consulta.Parameters.AddWithValue("@reserva", Double.Parse(CodReserva.Text));
            dataGridViewCargar(dataConsumibles, Database.consultaObtenerTabla(consulta));

            SqlCommand consultaDos = Database.consultaCrear("select isnull(DATEDIFF(DAY,Estadia_CheckInUsuarioID,Estadia_CheckOutUsuarioID),0) from rip.Estadias join rip.Reservas on Estadia_ReservaID=Reserva_ID where Reserva_ID=@reserva");
            consultaDos.Parameters.AddWithValue("@reserva", Double.Parse(CodReserva.Text));
            string diasUtilizado = Database.consultaObtenerValor(consultaDos);
            diasUtilizados.Text = diasUtilizado;

            SqlCommand reservaExistente = Database.consultaCrear("select Reserva_ID from rip.Reservas where Reserva_ID=@reserva");
            reservaExistente.Parameters.AddWithValue("@reserva", Double.Parse(CodReserva.Text));
            string idReserva = Database.consultaObtenerValor(reservaExistente);

            if (idReserva == "")
            {
                MessageBox.Show("Codigo de reserva no valido");
            }
            else
            {

                allInclusive.Text = "";
                allinclusivecant.Text = "";
                allInclusivePrecio.Text = "";

                sub.Text = "Subtotal";
                SqlCommand consultasubtotal = Database.consultaCrear("select isnull(sum(Consumido_Cantidad*Consumible_Precio),0)  from rip.Consumidos join rip.Consumibles on Consumible_ID=Consumido_ConsumibleID join rip.Estadias on Estadia_ID=Consumido_EstadiaID join rip.Reservas on Reserva_ID=Estadia_ReservaID where Reserva_ID=@reserva");
                consultasubtotal.Parameters.AddWithValue("@reserva", Double.Parse(CodReserva.Text));
                string subtotal = Database.consultaObtenerValor(consultasubtotal);
                SubTotal.Text = subtotal;

                SqlCommand consultaRegimen = Database.consultaCrear("select Reserva_RegimenID from rip.Reservas where Reserva_ID=@reserva");
                consultaRegimen.Parameters.AddWithValue("@reserva", Double.Parse(CodReserva.Text));
                string idRegimen = Database.consultaObtenerValor(consultaRegimen);
                Decimal allinclusive = 0;
                if (int.Parse(idRegimen) == 1)
                {
                    allInclusive.Text = "Descuento por All Inclusive";
                    allinclusivecant.Text = "1";
                    allInclusivePrecio.Text = "-" + subtotal + "";
                    allinclusive = Convert.ToDecimal(subtotal) * (-1);
                }


                SqlCommand consultaRegimenTabla = Database.consultaCrear("select DATEDIFF(DAY,Reserva_FechaInicio,Reserva_FechaFin),Regimen_Descripcion,Regimen_Precio,isnull(Reserva_CantidadHuespedes,1),TipoHabitacion_Porcentual,TipoHabitacion_Descripcion from rip.Reservas join rip.Regimenes on Regimen_ID=Reserva_RegimenID join rip.TiposHabitaciones on TipoHabitacion_ID=Reserva_TipoHabitacionID where Reserva_ID=@reserva");
                consultaRegimenTabla.Parameters.AddWithValue("@reserva", CodReserva.Text);
                DataTable tablaRegimen = Database.consultaObtenerTabla(consultaRegimenTabla);

                DiasRegimen.Text = Convert.ToString(tablaRegimen.Rows[0][0]);
                Regimen.Text = Convert.ToString(tablaRegimen.Rows[0][1]);
                RegimenPrecio.Text = Convert.ToString(tablaRegimen.Rows[0][2]);
                label5.Text = Convert.ToString(tablaRegimen.Rows[0][5]);
                label6.Text = Convert.ToString(tablaRegimen.Rows[0][4]);
                label7.Text = Convert.ToString(tablaRegimen.Rows[0][3]);




                Decimal diasInt = Convert.ToDecimal(DiasRegimen.Text);
                Decimal regimenPrecioInt = Convert.ToDecimal(RegimenPrecio.Text);
                Decimal huspedes = Convert.ToDecimal(label7.Text);
                Decimal porcentual = Convert.ToDecimal(label6.Text);
                Decimal subtotalInt = allinclusive;
                subRegimenPrecio.Text = Convert.ToString((diasInt * regimenPrecioInt * huspedes * porcentual) + (subtotalInt));
                TotalNumero.Text = Convert.ToString(Convert.ToDecimal(subRegimenPrecio.Text) + Convert.ToDecimal(subtotal));
            }



        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void CodReserva_TextChanged(object sender, EventArgs e)
        {

        }

        private void sub_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string idHotelLogueado = sesionLogueada.hotel.id;
            SqlCommand idHotelSql = Database.consultaCrear("select Reserva_HotelID from rip.Reservas where Reserva_ID=@reserva");
            idHotelSql.Parameters.AddWithValue("@reserva", Double.Parse(CodReserva.Text));
            string idHotelReserva = Database.consultaObtenerValor(idHotelSql);

            if (int.Parse(idHotelLogueado) != int.Parse(idHotelReserva))
            {

                MessageBox.Show("Operacion no valida para el hotel logueado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CodReserva.Text.Trim() == "")
            {
                MessageBox.Show("Faltan completar campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlCommand reservaYaPaga = Database.consultaCrear("select Factura_ID from rip.Facturas join rip.Estadias on Factura_EstadiaID=Estadia_ID join rip.Reservas on Reserva_ID=Estadia_ReservaID where Reserva_ID=@reserva");
            reservaYaPaga.Parameters.AddWithValue("@reserva", Double.Parse(CodReserva.Text));
            string facturaId = Database.consultaObtenerValor(reservaYaPaga);

            if (facturaId != "")
            {
                MessageBox.Show("Factura ya paga", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlCommand sinChekOut = Database.consultaCrear("select DATEDIFF(DAY,Estadia_CheckInUsuarioID,Estadia_CheckOutUsuarioID) from rip.Estadias join rip.Reservas on Estadia_ReservaID=Reserva_ID where Reserva_ID=@reserva");
            sinChekOut.Parameters.AddWithValue("@reserva", int.Parse(CodReserva.Text));
            string chekOut = Database.consultaObtenerValor(sinChekOut);

            if (chekOut == "")
            {
                MessageBox.Show("Sin ChekOut", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlCommand numeroFactura = Database.consultaCrear("select top 1 Factura_ID from rip.Facturas order by 1 desc");
            string idFactura = Database.consultaObtenerValor(numeroFactura);
            int nuevaFactura = int.Parse(idFactura) + 1;
            int diasNoUtilizados = int.Parse(DiasRegimen.Text) - int.Parse(diasUtilizados.Text);
            int index = comboBox1.SelectedIndex;
            switch (index)
            {
                case 0:
                    {

                        SqlCommand InsertFactura = Database.consultaCrear("insert into rip.Facturas(Factura_ID,Factura_EstadiaID,Factura_DiasUtilizados,Factura_DiasNoUtilizados,Factura_Fecha,Factura_MontoTotal,Factura_FormaPagoID)values(@NumeroFactura,(select Estadia_ID from rip.Estadias join rip.Reservas on Reserva_ID=Estadia_ReservaID where Reserva_ID=@reserva),@diasUtilizados,@diasNoUtilizados,@fecha,@Total,2)");
                        InsertFactura.Parameters.AddWithValue("@NumeroFactura", nuevaFactura);
                        InsertFactura.Parameters.AddWithValue("@reserva", int.Parse(CodReserva.Text));
                        InsertFactura.Parameters.AddWithValue("@diasUtilizados", int.Parse(diasUtilizados.Text));
                        InsertFactura.Parameters.AddWithValue("@diasNoUtilizados", diasNoUtilizados);
                        InsertFactura.Parameters.AddWithValue("@Total", Convert.ToDecimal(TotalNumero.Text));
                        InsertFactura.Parameters.AddWithValue("@fecha", "convert(datetime,getdate(),121)");
                        Database.consultaEjecutar(InsertFactura);

                    };
                    break;

                case 1:
                    {

                        SqlCommand InsertFactura = Database.consultaCrear("insert into rip.Facturas(Factura_ID,Factura_EstadiaID,Factura_DiasUtilizados,Factura_DiasNoUtilizados,Factura_Fecha,Factura_MontoTotal,Factura_FormaPagoID)values(@NumeroFactura,(select Estadia_ID from rip.Estadias join rip.Reservas on Reserva_ID=Estadia_ReservaID where Reserva_ID=@reserva),@diasUtilizados,@diasNoUtilizados,@fecha,@Total,1)");
                        InsertFactura.Parameters.AddWithValue("@NumeroFactura", nuevaFactura);
                        InsertFactura.Parameters.AddWithValue("@reserva", int.Parse(CodReserva.Text));
                        InsertFactura.Parameters.AddWithValue("@diasUtilizados", int.Parse(diasUtilizados.Text));
                        InsertFactura.Parameters.AddWithValue("@diasNoUtilizados", diasNoUtilizados);
                        InsertFactura.Parameters.AddWithValue("@Total", Convert.ToDecimal(TotalNumero.Text));
                        InsertFactura.Parameters.AddWithValue("@fecha", "convert(datetime,getdate(),121)");
                        Database.consultaEjecutar(InsertFactura);

                    };
                    break;
            }


            SqlCommand insertItemFacturas = Database.consultaCrear("insert into rip.ItemsFacturas(ItemFactura_FacturaID,ItemFactura_ConsumidoID,ItemFactura_Cantidad,ItemFactura_Monto) select @idFactura,Consumido_ID,Consumido_Cantidad,Consumido_Cantidad*Consumible_Precio from rip.Consumidos join rip.Consumibles on Consumible_ID=Consumido_ConsumibleID join rip.Estadias on Estadia_ID=Consumido_EstadiaID join rip.Reservas on Reserva_ID=Estadia_ReservaID where Reserva_ID=@reserva");
            insertItemFacturas.Parameters.AddWithValue("@idFactura", nuevaFactura);
            insertItemFacturas.Parameters.AddWithValue("@reserva", CodReserva.Text);
            Database.consultaEjecutar(insertItemFacturas);


            MessageBox.Show("Pago realizado correctamente, Factura N°" + nuevaFactura + " ", "Info", MessageBoxButtons.OK);


        }
    }
}
