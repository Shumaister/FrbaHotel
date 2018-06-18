using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Regimen
    {
        public string id { get; set; }
        public string descripcion { get; set; }
        public string precio { get; set; }

        public Regimen(string d, string p)
        {
            this.descripcion = d;
            this.precio = p;
        }
    }
}
