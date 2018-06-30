using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Reserva
    {
        public string Codigo { get; set; }
        public Hotel Hotel { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CantidadHuespedes { get; set; }
        public string Regimen { get; set; }
        public string TipoHabitacion { get; set; }
        public List<Habitacion> Habitaciones { get; set; }
        public Cliente Cliente { get; set; }
        public Usuario Usuario { get ; set; }

        public Reserva()
        {
        }

    }
}
