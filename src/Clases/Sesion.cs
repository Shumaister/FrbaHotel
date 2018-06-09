using FrbaHotel.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel
{
    public class Sesion
    {
        //-------------------------------------- Atributos -------------------------------------

        public string nombreUsuario { get; set; }
        public string rolLogueado { get; set; }
        public string hotelLogueado { get; set; }
        public List<string> roles { get; set; }
        public List<string> funcionalidades { get; set; }
        public List<string> hoteles { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public Sesion(string nombre, List<string> roles, List<string> hoteles)
        {
            this.nombreUsuario = nombre;
            this.roles = roles;
            this.hoteles = hoteles;
        }

        //-------------------------------------- Metodos para Usuario -------------------------------------

        public void configurarDatos(string rol, string hotel, List<string> funcionalidades)
        {
            this.rolLogueado = rol;
            this.hotelLogueado = hotel;
            this.funcionalidades = funcionalidades;
        }

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
