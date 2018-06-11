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

namespace FrbaHotel.ListadoEstadistico
{
    public partial class VentanaListadoEstadistico : VentanaBase
    {
        public VentanaListadoEstadistico()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void añoNUD_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            int tipo = cmbTipo.SelectedIndex;
            int trimestre = cmbTrimestre.SelectedIndex + 1;
            string anio = añoNUD.Value.ToString();

            if (cmbTipo.Text == "Seleccione..." || cmbTrimestre.Text == "Seleccione")
            {
                MessageBox.Show("Complete todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                switch (tipo)
                {
                    case 0:
                        {

                            SqlCommand consulta = Database.consultaCrear("select top 5 CONCAT(Domicilio_Ciudad,' ',Domicilio_Calle,' ',Domicilio_NumeroCalle)'Hotel',count(Reserva_ID)'Cantidad de reservas canceladas' from rip.Reservas join rip.ReservasCanceladas on Reserva_ID=ReservaCancelada_RerservaID join rip.Hoteles on Hotel_ID=Reserva_HotelID join rip.Domicilios on Hotel_DomicilioID=Domicilio_ID where YEAR(ReservaCancelada_Fecha)=@anio and DATEPART(QUARTER,ReservaCancelada_Fecha)=@trimestre group by Domicilio_NumeroCalle,Domicilio_Ciudad,domicilio_calle order by 2 desc");
                            consulta.Parameters.AddWithValue("@anio", anio);
                            consulta.Parameters.AddWithValue("@trimestre", trimestre);
                            dataGridViewCargar(dataGridEstadisticas,Database.consultaObtenerTabla(consulta));
            
                        };
                        break;
                    case 1:
                        {
                            SqlCommand consulta = Database.consultaCrear("select top 5 CONCAT(Domicilio_Ciudad,' ',Domicilio_Calle,' ',Domicilio_NumeroCalle) 'Hotel',sum(isnull(Consumido_Cantidad,0))'Cantidad de consumibles' from rip.Consumidos join rip.ItemsFacturas on Consumido_ID=ItemFactura_ConsumidoID join rip.Facturas on Factura_ID=ItemFactura_FacturaID join rip.Habitaciones on Habitacion_ID=Consumido_HabitacionID join rip.Hoteles on Hotel_ID=Habitacion_HotelID join rip.Domicilios on Hotel_DomicilioID=Domicilio_ID where YEAR(Factura_Fecha)=@anio and DATEPART(QUARTER,Factura_Fecha)=@trimestre and Factura_FormaPagoID is not null group by Domicilio_NumeroCalle,Domicilio_Ciudad,Domicilio_Calle order by 2 desc");
                            consulta.Parameters.AddWithValue("@anio", anio);
                            consulta.Parameters.AddWithValue("@trimestre", trimestre);
                            dataGridViewCargar(dataGridEstadisticas,Database.consultaObtenerTabla(consulta));                           
                        };
                        break;
                    case 2:
                        {
                         //   dataGridEstadisticas.DataSource = 
                        };
                        break;
                    case 3://Clientes cumplidores
                        {
                         //   dataGridEstadisticas.DataSource = 
                        };
                        break;
                }
            }
        }
    }
}
