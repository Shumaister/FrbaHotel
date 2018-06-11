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
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label18.Text = "";
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
            
            Label[] labelsDescripcion = { label1, label2, label3, label4, label5, label6 };
            Label[] labelsCantidad = { label7, label8, label9, label10, label11, label12 };
            Label[] labelsPrecio = { label13, label14, label15, label16, label17, label18 };
            SqlCommand consulta = Database.consultaCrear("select Consumible_Descripcion,Consumido_Cantidad,Consumible_Precio,Consumido_Cantidad*Consumible_Precio from rip.Consumidos join rip.Consumibles on Consumible_ID=Consumido_ConsumibleID join rip.Estadias on Estadia_ID=Consumido_EstadiaID join rip.Reservas on Reserva_ID=Estadia_ReservaID where Reserva_ID=@reserva");
            consulta.Parameters.AddWithValue("@reserva", CodReserva.Text);
            SqlCommand cantidadDeConsumibles = Database.consultaCrear("select Count(Consumible_Descripcion) from rip.Consumidos join rip.Consumibles on Consumible_ID=Consumido_ConsumibleID join rip.Estadias on Estadia_ID=Consumido_EstadiaID join rip.Reservas on Reserva_ID=Estadia_ReservaID where Reserva_ID=@reserva");
            cantidadDeConsumibles.Parameters.AddWithValue("@reserva", CodReserva.Text);
            string cantidadConsumibles = Database.consultaObtenerValor(cantidadDeConsumibles);
            
            DataTable tabla =  Database.consultaObtenerTabla(consulta);
           // label1.Text = Convert.ToString(tabla.Rows[0][0]);
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label18.Text = "";
            for (int i=0; i <int.Parse(cantidadConsumibles); i++)
            {
                labelsDescripcion[i].Text=Convert.ToString(tabla.Rows[i][0]);
                labelsCantidad[i].Text = Convert.ToString(tabla.Rows[i][1]);
                labelsPrecio[i].Text = Convert.ToString(tabla.Rows[i][2]);
            }
            sub.Text = "Subtotal";
            SqlCommand consultasubtotal = Database.consultaCrear("select sum(Consumido_Cantidad*Consumible_Precio)  from rip.Consumidos join rip.Consumibles on Consumible_ID=Consumido_ConsumibleID join rip.Estadias on Estadia_ID=Consumido_EstadiaID join rip.Reservas on Reserva_ID=Estadia_ReservaID where Reserva_ID=@reserva");
            consultasubtotal.Parameters.AddWithValue("@reserva", CodReserva.Text);
            string subtotal = Database.consultaObtenerValor(consultasubtotal);
            SubTotal.Text = subtotal;

            SqlCommand consultaRegimen = Database.consultaCrear("select Reserva_RegimenID from rip.Reservas where Reserva_ID=@reserva");
            consultaRegimen.Parameters.AddWithValue("@reserva", CodReserva.Text);
            string idRegimen = Database.consultaObtenerValor(consultaRegimen);

            if (int.Parse(idRegimen) == 1) {
                allInclusive.Text = "Descuento por All Inclusive";
            allinclusivecant.Text="1";
            allInclusivePrecio.Text = "-"+subtotal+"";
            }
            
        
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void CodReserva_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
