using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel
{
    class Persona
    {
        //-------------------------------------- Atributos -------------------------------------

        public string nombre { get; set; }
        public string apellido { get; set; }
        public string fechaNacimiento { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string nacionalidad { get; set; }
        public string pais { get; set; }
        public string ciudad { get; set; }
        public string calle { get; set; }
        public string numeroCalle { get; set; }
        public string piso { get; set; }
        public string departamento { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }


        //-------------------------------------- Constructores -------------------------------------

        public Persona(string nombre, string apellido, string fechaNacimiento, string telefono, string email, int tipoDocumentoID, int numeroDocumento, int domicilioID, int nacionalidadID)
        {
        }
        
 
    }
}
