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

        //-------------------------------------- Constructores -------------------------------------

        public Usuario(string nombre, List<string> roles, List<string> hoteles)
        {
            this.nombre = nombre;
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
