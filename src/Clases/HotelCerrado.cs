using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class HotelCerrado
    {

        //-------------------------------------- Atributos -------------------------------------

        public Hotel hotel { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public string motivo { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public HotelCerrado(Hotel hotel, DateTime fechaInicio, DateTime fechaFin, string motivo)
        {
            this.hotel = hotel;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.motivo = motivo;
        }
    }
}
