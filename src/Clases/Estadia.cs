using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Estadia
    {
        public Reserva reserva { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public string checkInUsuarioID { get; set; }
        public string checkOutUsuarioID { get; set; }
        public List<string> huespedes { get; set; }

        public Estadia()
        {
            huespedes = new List<string>();
        }


    }
}
