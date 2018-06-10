using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Rol
    {
        public string nombre { get; set; }
        public List<string> funcionalidades { get; set; }
        public string estado { get; set; }

        public Rol(string nombre)
        {
            this.nombre = nombre;
        }
    }
}
