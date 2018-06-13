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
        public List<Hotel> hoteles { get; set; }
        public List<Rol> roles { get; set; }

        #endregion

        #region Constructores

        public Usuario(string id, string nombre, string contrasenia, Persona persona, List<Hotel> hoteles, List<Rol> roles)
        {
            this.id = id;
            this.nombre = nombre;
            this.contrasenia = contrasenia;
            this.persona = persona;
            this.hoteles = hoteles;
            this.roles = roles;
        }

        public Usuario(string id, string nombre, string contrasenia, Persona persona, string estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.contrasenia = contrasenia;
            this.persona = persona;
            this.estado = estado;
        }

        public Usuario(string nombre)
        {
            this.nombre = nombre;
        }

        #endregion
    }
}
