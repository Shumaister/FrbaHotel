using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel
{
    public class Domicilio
    {
        //-------------------------------------- Atributos -------------------------------------
       
        public string pais { get; set; }
        public string ciudad { get; set; }
        public string calle { get; set; }
        public string numeroCalle { get; set; }
        public string piso { get; set; }
        public string departamento { get; set; }

        //-------------------------------------- Constructores -------------------------------------
        
        public Domicilio()
        {

        }

        //-------------------------------------- Metodos -------------------------------------

    }
}
