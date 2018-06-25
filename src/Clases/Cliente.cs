using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Cliente
    {
        public string id { get; set; }
        public Persona persona { get; set; }
        public string estado { get; set; }

        public Cliente(string id, Persona persona, string estado)
        {
            this.id = id;
            this.persona = persona;
            this.estado = estado;
        }

        public Cliente()
        {
        }
    }
}
