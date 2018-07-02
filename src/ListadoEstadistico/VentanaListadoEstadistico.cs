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
            cmbTipo.SelectedIndex = 0;
            cmbTrimestre.SelectedIndex = 0;
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

            switch (tipo)
            {
                case 0:
                    {    SqlCommand consulta = Database.consultaCrear("select top 5 CONCAT(Domicilio_Ciudad,' ',Domicilio_Calle,' ',Domicilio_NumeroCalle)'Hotel',count(Reserva_ID)'Cantidad de reservas canceladas' from rip.Reservas join rip.ReservasCanceladas on Reserva_ID=ReservaCancelada_RerservaID join rip.Hoteles on Hotel_ID=Reserva_HotelID join rip.Domicilios on Hotel_DomicilioID=Domicilio_ID where YEAR(ReservaCancelada_Fecha)=@anio and DATEPART(QUARTER,ReservaCancelada_Fecha)=@trimestre group by Domicilio_NumeroCalle,Domicilio_Ciudad,domicilio_calle order by 2 desc");
                        consulta.Parameters.AddWithValue("@anio", anio);
                        consulta.Parameters.AddWithValue("@trimestre", trimestre);
                        dataGridViewCargar(dataGridEstadisticas, Database.consultaObtenerTabla(consulta));

                    };
                    break;
                case 1:
                    {
                        SqlCommand consulta = Database.consultaCrear("select top 5 CONCAT(Domicilio_Ciudad,' ',Domicilio_Calle,' ',Domicilio_NumeroCalle) 'Hotel',sum(isnull(Consumido_Cantidad,0))'Cantidad de consumibles' from rip.Consumidos join rip.ItemsFacturas on Consumido_ID=ItemFactura_ConsumidoID join rip.Facturas on Factura_ID=ItemFactura_FacturaID join rip.Habitaciones on Habitacion_ID=Consumido_HabitacionID join rip.Hoteles on Hotel_ID=Habitacion_HotelID join rip.Domicilios on Hotel_DomicilioID=Domicilio_ID where YEAR(Factura_Fecha)=@anio and DATEPART(QUARTER,Factura_Fecha)=@trimestre and Factura_FormaPagoID is not null group by Domicilio_NumeroCalle,Domicilio_Ciudad,Domicilio_Calle order by 2 desc");
                        consulta.Parameters.AddWithValue("@anio", anio);
                        consulta.Parameters.AddWithValue("@trimestre", trimestre);
                        dataGridViewCargar(dataGridEstadisticas, Database.consultaObtenerTabla(consulta));
                    };
                    break;
                case 2:
                    {

                        SqlCommand consulta = Database.consultaCrear("select CONCAT(Domicilio_Ciudad,' ',Domicilio_Calle,' ',Domicilio_NumeroCalle)'Hotel',sum(DATEDIFF ( DAY ,HotelCerrado_FechaInicio,HotelCerrado_FechaFin))'Dias fuera de servicio' from rip.HotelesCerrados join rip.Hoteles on Hotel_ID=HotelCerrado_HotelID join rip.Domicilios on Domicilio_ID=Hotel_DomicilioID where YEAR(HotelCerrado_FechaInicio)=@anio and DATEPART(QUARTER,HotelCerrado_FechaInicio)=@trimestre group by Domicilio_Ciudad,Domicilio_Calle,Domicilio_NumeroCalle order by 2 desc");
                        consulta.Parameters.AddWithValue("@anio", anio);
                        consulta.Parameters.AddWithValue("@trimestre", trimestre);
                        dataGridViewCargar(dataGridEstadisticas, Database.consultaObtenerTabla(consulta));
                        
                    };
                    break;
                case 3:
                    {
                      
                        SqlCommand consulta = Database.consultaCrear(" select top 5 CONCAT(Domicilio_Ciudad,' ',Domicilio_Calle,' ',Domicilio_NumeroCalle) 'Hotel',Habitacion_Numero'N° Habitación',DATEDIFF(day,Estadia_FechaInicio,Estadia_FechaFin)'Dias utilizados',(select COUNT(HabitacionNoDisponible_HabitacionID)'Cantidad de veces utilizadas' from rip.HabitacionesNoDisponibles where a.HabitacionNoDisponible_HabitacionID=HabitacionNoDisponible_HabitacionID group by HabitacionNoDisponible_HabitacionID)'Cantidad de veces utilizadas' from rip.Estadias join rip.Reservas on Reserva_ID=Estadia_ReservaID join rip.Hoteles on Reserva_HotelID=Hotel_ID  join rip.Domicilios on Domicilio_ID=Hotel_DomicilioID  join rip.HabitacionesNoDisponibles a on Reserva_ID=HabitacionNoDisponible_ReservaID join rip.Habitaciones on Habitacion_ID=HabitacionNoDisponible_HabitacionID where YEAR(Estadia_FechaInicio)=@anio and DATEPART(QUARTER,Estadia_FechaInicio)=@trimestre order by 3 desc,4 desc");
                        consulta.Parameters.AddWithValue("@anio", anio);
                        consulta.Parameters.AddWithValue("@trimestre", trimestre);
                        dataGridViewCargar(dataGridEstadisticas, Database.consultaObtenerTabla(consulta));
                    };
                    break;
                case 4:
                    {

                        SqlCommand consulta = Database.consultaCrear("select top 5 Persona_Nombre,Persona_Apellido,((sum((Consumido_Cantidad*Consumible_Precio))/10)+((DATEDIFF(DAY,Estadia_FechaInicio,Estadia_FechaFin)*Regimen_Precio)/20))'Puntos' from rip.Consumidos join rip.Consumibles on Consumido_ConsumibleID=Consumible_ID join rip.Estadias on Consumido_EstadiaID=Estadia_ID join rip.Reservas on Reserva_ID=Estadia_ReservaID join rip.Clientes on Reserva_ClienteID=Cliente_ID join rip.Personas on Cliente_PersonaID=Persona_ID join rip.Regimenes on Reserva_RegimenID=Regimen_ID where YEAR(Estadia_FechaInicio)=@anio and DATEPART(QUARTER,Estadia_FechaInicio)=@trimestre group by Persona_Nombre,Persona_Apellido,Estadia_FechaInicio,Estadia_FechaFin,Regimen_Precio order by 3 desc,1 asc");
                        consulta.Parameters.AddWithValue("@anio", anio);
                        consulta.Parameters.AddWithValue("@trimestre", trimestre);
                        dataGridViewCargar(dataGridEstadisticas, Database.consultaObtenerTabla(consulta));

                    };
                    break;
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
