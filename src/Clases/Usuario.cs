using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Usuario
    {
        public string nombre { get; set; }
        public string contrasenia { get; set; }
        public string estado { get; set; }
        public Persona persona { get; set; }
        public List<Hotel> hoteles {get; set;}
        public List<Rol> roles { get; set; }

        public Usuario(string nombre, string contrasenia, Persona persona, string estado)
        {
            this.nombre = nombre;
            this.contrasenia = contrasenia;
            this.persona = persona;
            this.estado = estado;
        }

    }
}
