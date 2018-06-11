using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Rol
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public List<string> funcionalidades { get; set; }
        public string estado { get; set; }

        public Rol(string nombre)
        {
            this.nombre = nombre;
        }

        public Rol(string id, string nombre, List<string> funcionalidades, string estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.funcionalidades = funcionalidades;
            this.estado = estado;
        }
    }
}
