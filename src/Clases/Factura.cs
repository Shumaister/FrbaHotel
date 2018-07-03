using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Factura
    {
        public string id { get; set; }
        public Estadia estadia { get; set; }
        public Decimal montoEstadiaDia { get; set; }
        public string diasUtilizados { get; set; }
        public string diasNoUtilizados { get; set; }
        public string montoTotal { get; set; }
        public string formaPago { get; set; }

        public Factura()
        {

        }
    }
}
