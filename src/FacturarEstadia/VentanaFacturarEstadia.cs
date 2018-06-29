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


namespace FrbaHotel.FacturarEstadia
{
    public partial class VentanaFacturarEstadia : VentanaBase
    {
        public VentanaFacturarEstadia()
        {
            InitializeComponent();

            sub.Text = "";
        }


        private void VentanaFacturarEstadia_Load(object sender, EventArgs e)
        {
         
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlCommand consulta = Database.consultaCrear("select Consumible_Descripcion 'Consumible',Consumido_Cantidad'Cantidad',Consumible_Precio'Precio',Consumido_Cantidad*Consumible_Precio'Total' from rip.Consumidos join rip.Consumibles on Consumible_ID=Consumido_ConsumibleID join rip.Estadias on Estadia_ID=Consumido_EstadiaID join rip.Reservas on Reserva_ID=Estadia_ReservaID where Reserva_ID=@reserva");
            consulta.Parameters.AddWithValue("@reserva", CodReserva.Text);
            SqlCommand cantidadDeConsumibles = Database.consultaCrear("select Count(Consumible_Descripcion) from rip.Consumidos join rip.Consumibles on Consumible_ID=Consumido_ConsumibleID join rip.Estadias on Estadia_ID=Consumido_EstadiaID join rip.Reservas on Reserva_ID=Estadia_ReservaID where Reserva_ID=@reserva");
            cantidadDeConsumibles.Parameters.AddWithValue("@reserva", CodReserva.Text);
            string cantidadConsumibles = Database.consultaObtenerValor(cantidadDeConsumibles);


            dataGridViewCargar(dataConsumibles, Database.consultaObtenerTabla(consulta));

            SqlCommand reservaExistente = Database.consultaCrear("select Reserva_ID from rip.Reservas where Reserva_ID=@reserva");
            reservaExistente.Parameters.AddWithValue("@reserva", CodReserva.Text);
            string idReserva = Database.consultaObtenerValor(reservaExistente);

            if (idReserva == "")
            {
                MessageBox.Show("Codigo de reserva no valido");
            }
            else {

                allInclusive.Text = "";
                allinclusivecant.Text = "";
                allInclusivePrecio.Text = "";

                sub.Text = "Subtotal";
                SqlCommand consultasubtotal = Database.consultaCrear("select sum(Consumido_Cantidad*Consumible_Precio)  from rip.Consumidos join rip.Consumibles on Consumible_ID=Consumido_ConsumibleID join rip.Estadias on Estadia_ID=Consumido_EstadiaID join rip.Reservas on Reserva_ID=Estadia_ReservaID where Reserva_ID=@reserva");
                consultasubtotal.Parameters.AddWithValue("@reserva", CodReserva.Text);
                string subtotal = Database.consultaObtenerValor(consultasubtotal);
                SubTotal.Text = subtotal;

                SqlCommand consultaRegimen = Database.consultaCrear("select Reserva_RegimenID from rip.Reservas where Reserva_ID=@reserva");
                consultaRegimen.Parameters.AddWithValue("@reserva", CodReserva.Text);
                string idRegimen = Database.consultaObtenerValor(consultaRegimen);
                Decimal allinclusive = 0;
                if (int.Parse(idRegimen) == 1)
                {
                    allInclusive.Text = "Descuento por All Inclusive";
                    allinclusivecant.Text = "1";
                    allInclusivePrecio.Text = "-" + subtotal + "";
                    allinclusive = Convert.ToDecimal(subtotal)*(-1);
                }


                SqlCommand consultaRegimenTabla = Database.consultaCrear("select DATEDIFF(DAY,Reserva_FechaInicio,Reserva_FechaFin),Regimen_Descripcion,Regimen_Precio from rip.Reservas join rip.Regimenes on Regimen_ID=Reserva_RegimenID where Reserva_ID=@reserva");
                consultaRegimenTabla.Parameters.AddWithValue("@reserva", CodReserva.Text);
                DataTable tablaRegimen = Database.consultaObtenerTabla(consultaRegimenTabla);
                
                DiasRegimen.Text = Convert.ToString(tablaRegimen.Rows[0][0]);
                Regimen.Text = Convert.ToString(tablaRegimen.Rows[0][1]);
                RegimenPrecio.Text = Convert.ToString(tablaRegimen.Rows[0][2]);


               Decimal diasInt = Convert.ToDecimal(DiasRegimen.Text);
               Decimal regimenPrecioInt = Convert.ToDecimal(RegimenPrecio.Text);
               Decimal subtotalInt = allinclusive;
               subRegimenPrecio.Text = Convert.ToString((diasInt * regimenPrecioInt) + (subtotalInt ));

               TotalNumero.Text = Convert.ToString(Convert.ToDecimal(subRegimenPrecio.Text)+ Convert.ToDecimal(subtotal));
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

            SqlCommand numeroFactura = Database.consultaCrear("select top 1 Factura_ID from rip.Facturas order by 1 desc");
            string idFactura = Database.consultaObtenerValor(numeroFactura);
            int nuevaFactura = int.Parse(idFactura) + 1;
            int diasNoUtilizados = int.Parse(DiasRegimen.Text) - int.Parse(TextDiasUtilizados.Text);      

                  SqlCommand consulta = Database.consultaCrear("insert into rip.Facturas(Factura_ID,Factura_EstadiaID,Factura_DiasUtilizados,Factura_DiasNoUtilizados,Factura_Fecha,Factura_MontoTotal)values(@NumeroFactura,(select Estadia_ID from rip.Estadias join rip.Reservas on Reserva_ID=Estadia_ReservaID where Reserva_ID=@reserva),@diasUtilizados,@diasNoUtilizados,getdate(),@Total)");
                  consulta.Parameters.AddWithValue("@NumeroFactura",nuevaFactura);
                  consulta.Parameters.AddWithValue("@reserva", int.Parse(CodReserva.Text));
                  consulta.Parameters.AddWithValue("@diasUtilizados",int.Parse(TextDiasUtilizados.Text));
                  consulta.Parameters.AddWithValue("@diasNoUtilizados",diasNoUtilizados);
                  consulta.Parameters.AddWithValue("@Total",Convert.ToDecimal(TotalNumero.Text));
                  Database.consultaEjecutar(consulta);

        }
    }
}
