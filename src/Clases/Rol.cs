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
        public string estado { get; set; }

        public Rol(string nombre, string estado)
        {
            this.nombre = nombre;
            this.estado = estado;
        }
    }
}
