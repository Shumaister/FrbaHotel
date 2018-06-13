using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Habitacion
    {
        public string id { get; set; }
        public string numero { get; set; }
        public string piso { get; set; }
        public string frente { get; set; }
        public string tipoHabitacion { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public Hotel hotel { get; set; }


        public Habitacion(string id, string numero, string piso, string frente, string tipoHabitacion, string descripcion, Hotel hotel)
        {
            this.id = id;
            this.numero = numero;
            this.piso = piso;
            this.frente = frente;
            this.tipoHabitacion = tipoHabitacion;
            this.descripcion = descripcion;
            this.hotel = hotel;
        }

        public Habitacion(string id)
        {
            this.id = id;
        }

    }
}
