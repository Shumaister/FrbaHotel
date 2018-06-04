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

        public Usuario(string nombreUsuario, List<string> rolesUsuario, List<string> hotelesUsuario)
        {
            nombre = nombreUsuario;
            roles = rolesUsuario;
            hoteles = hotelesUsuario;
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

        public void configurarDatos(string rol, string hotel, List<string> listaFuncionalidades)
        {
            rolLogueado = rol;
            hotelLogueado = hotel;
            funcionalidades = listaFuncionalidades;
        }
    }
}
