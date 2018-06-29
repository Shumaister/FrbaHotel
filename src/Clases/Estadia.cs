using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    class Estadia
    {
        public int CantidadHuespedes { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CodigoTipoHabitacion { get; set; }
        public int CantidadHabitaciones { get; set; }
        public int IdTipoEstadia { get; set; }

        public Estadia()
        { 
        }


    }
}
