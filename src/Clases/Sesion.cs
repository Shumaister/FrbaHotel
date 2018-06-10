using FrbaHotel.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaHotel.Clases;

namespace FrbaHotel
{
    public class Sesion
    {
        //-------------------------------------- Atributos -------------------------------------

        public Usuario usuario { get; set; }
        public Rol rol { get; set; }
        public Hotel hotel { get; set; }
        public List<string> roles { get; set; }
        public List<string> hoteles { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public Sesion(Usuario usuario, List<string> roles, List<string> hoteles)
        {
            this.usuario = usuario;
            this.roles = roles;
            this.hoteles = hoteles;
        }

        //-------------------------------------- Metodos para Usuario -------------------------------------

        public bool usuarioTrabajaEnUnSoloHotel()
        {
            return hoteles.Count == 1;
        }

        public bool usuarioTrabajaEnVariosHoteles()
        {
            return hoteles.Count > 1;
        }

        public bool usuarioTieneUnSoloRol()
        {
            return roles.Count == 1;
        }

        public bool usuarioTieneVariosRoles()
        {
            return roles.Count > 1; 
        }

    }
}
