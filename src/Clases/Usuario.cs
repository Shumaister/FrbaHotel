using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Usuario
    {
        #region Atributos

        public string id { get; set; }
        public string nombre { get; set; }
        public string contrasenia { get; set; }
        public string estado { get; set; }
        public Persona persona { get; set; }
        public List<Hotel> hoteles {get; set;}
        public List<Rol> roles { get; set; }


        #endregion

        #region Constructores

        public Usuario(string nombre, string contrasenia, Persona persona)
        {
            this.nombre = nombre;
            this.contrasenia = contrasenia;
            this.persona = persona;
        }

        public Usuario(string id)
        {
            this.id = id;
        }

        #endregion
    }
}
