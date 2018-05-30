using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Login
{
    public class LogueoDTO
    {
        //-------------------------------------- Atributos -------------------------------------

        public bool exito { get; set; }
        public string mensajeError { get; set; }
        public string nombreUsuario { get; set; }
        public List<string> rolesUsuario { get; set; }
        public List<string> hotelesUsuario { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public LogueoDTO(bool exito, string mensaje, string usuario, List<string> roles, List<string> hoteles)
        {
            this.exito = exito;
            this.mensajeError = mensaje;
            this.nombreUsuario = usuario;
            this.rolesUsuario = roles;
            this.hotelesUsuario = hoteles;
        }
        public LogueoDTO(bool exito, string mensaje)
        {
            this.exito = exito;
            this.mensajeError = mensaje;
        }
    }
}
