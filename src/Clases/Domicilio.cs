using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel
{
    public class Domicilio
    {
        #region Atributos

        public string id { get; set; }
        public string pais { get; set; }
        public string ciudad { get; set; }
        public string calle { get; set; }
        public string numeroCalle { get; set; }
        public string piso { get; set; }
        public string departamento { get; set; }

        #endregion

        #region Constructores

        public Domicilio(string id, string pais, string ciudad, string calle, string numeroCalle, string piso, string departamento)
        {
            this.id = id;
            this.pais = pais;
            this.ciudad = ciudad;
            this.calle = calle;
            this.numeroCalle = numeroCalle;
            this.piso = piso;
            this.departamento = departamento;
        }

        public Domicilio(string id, string pais, string ciudad, string calle, string numeroCalle)
        {
            this.id = id;
            this.pais = pais;
            this.ciudad = ciudad;
            this.calle = calle;
            this.numeroCalle = numeroCalle;
        }

        #endregion
    }
}
