using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Hotel
    {
        //-------------------------------------- Atributos -------------------------------------

        public string nombre { get; set; }
        public string cantidadEstrellas { get; set; }
        public Domicilio domicilio { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string fechaCreacion { get; set; }
        public string tipoRegimen { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public Hotel(Domicilio domicilio)
        {
            this.domicilio = domicilio;
        }
    }
}
