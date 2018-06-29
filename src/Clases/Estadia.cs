using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Estadia
    {
        public string reservaID { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public string checkInUsuarioID { get; set; }
        public string checkOutUsuarioID { get; set; }

        public Estadia()
        { 

        }


    }
}
