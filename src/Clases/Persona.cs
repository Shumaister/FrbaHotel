using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel
{
    public class Persona
    {
        //-------------------------------------- Atributos -------------------------------------

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


        //-------------------------------------- Constructores -------------------------------------

        public Persona(string nombre, string apellido, DateTime fechaNacimiento, string tipoDocumento, string numeroDocumento, string nacionalidad, string telefono, string email, Domicilio domicilio)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
            this.tipoDocumento = tipoDocumento;
            this.numeroDocumento = numeroDocumento;
            this.nacionalidad = nacionalidad;
            this.telefono = telefono;
            this.email = email;
            this.domicilio = domicilio;
        }
        
 
    }
}
