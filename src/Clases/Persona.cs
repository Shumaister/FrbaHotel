using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel
{
    public class Persona
    {
        #region Atributos

        public string id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string nacionalidad { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public Domicilio domicilio { get; set; }

        #endregion

        #region Constructores

        public Persona(string id, string nombre, string apellido, string nacionalidad, string tipoDocumento, string numeroDocumento, DateTime fechaNacimiento, string telefono, string email, Domicilio domicilio)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
            this.tipoDocumento = tipoDocumento;
            this.numeroDocumento = numeroDocumento;
            this.fechaNacimiento = fechaNacimiento;
            this.telefono = telefono;
            this.email = email;
            this.domicilio = domicilio;
        }

        #endregion
    }
}
