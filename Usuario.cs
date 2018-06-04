using FrbaHotel.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel
{
    public class Usuario
    {
        //-------------------------------------- Atributos -------------------------------------

        public string nombre { get; set; }
        public string rolLogueado { get; set; }
        public string hotelLogueado { get; set; }
        public List<string> roles { get; set; }
        public List<string> funcionalidades { get; set; }
        public List<string> hoteles { get; set; }
        public bool logueoExitoso { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public Usuario(LogueoDTO logueo)
        {
            this.nombre = logueo.nombreUsuario;
            this.roles = logueo.rolesUsuario;
            this.hoteles = logueo.hotelesUsuario;
        }

        //-------------------------------------- Metodos para Usuario -------------------------------------

        public bool trabajaEnUnSoloHotel()
        {
            return hoteles.Count == 1;
        }

        public bool trabajaEnVariosHoteles()
        {
            return hoteles.Count > 1;
        }

        public bool tieneUnSoloRol()
        {
            return roles.Count == 1;
        }

        public bool tieneVariosRoles()
        {
            return roles.Count > 1;
        }
    }
}
