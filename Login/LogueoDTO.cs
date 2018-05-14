using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Login
{
    public class LogueoDTO
    {
        public bool Exito { get; set; }
        public string MensajeError { get; set; }
        public string User { get; set; }
        public List<string> Roles { get; set; } 

        public LogueoDTO(bool e, string m, string u, List<string> r){
            this.Exito = e;
            this.MensajeError = m;
            this.User = u;
            this.Roles = r;
        }
        public LogueoDTO(bool e, string m)
        {
            this.Exito = e;
            this.MensajeError = m;
        }
    }
}
