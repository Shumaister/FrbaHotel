using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Habitacion
    {
        public Hotel hotel { get; set; }
        public string numero { get; set; }
        public string piso { get; set; }
        public string frente { get; set; }
        public string tipoHabitacion { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }

        public Habitacion(Hotel hotel, string numero)
        {
            this.hotel = hotel;
            this.numero = numero;
        }
    }
}
