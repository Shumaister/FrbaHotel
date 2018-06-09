using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Regimen
    {
        //-------------------------------------- Atributos -------------------------------------

        public string descripcion;
        public string precio;
        public string estado;

        //-------------------------------------- Metodos -------------------------------------

        public Regimen(string descripcion)
        {
            this.descripcion = descripcion;
        }
    }
}
