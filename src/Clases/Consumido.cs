using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Consumido
    {
        public string estadiaID { get; set; }
        public string reservaCodigo { get; set; }
        public string numeroHabitacion { get; set; }
        public string hotelID { get; set; }
        public string consumible { get; set; }
        public string cantidad { get; set; }

        public Consumido()
        {

        }
    }
}
