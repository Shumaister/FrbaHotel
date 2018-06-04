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

        public Usuario(LogueoDTO logueo)
        {
            this.nombre = logueo.nombreUsuario;
            this.roles = logueo.rolesUsuario;
            this.hoteles = logueo.hotelesUsuario;

        }

        //-------------------------------------- Metodos para Usuarios -------------------------------------

        private List<string> FuncionalidadesDeRol(string rol)
        {
            return Database.rolObtenerFuncionalidades(rol);
        }

        private bool trabajaEnUnSoloHotel()
        {
            return Database.usuarioTrabajaEnUnSoloHotel(this.nombre);
        }

        private bool trabajaEnVariosHoteles()
        {
            return Database.usuarioTrabajaEnVariosHoteles(this.nombre);
        }

        private bool tieneUnSoloRol()
        {
            return Database.usuarioTieneUnSoloRol(this.nombre);
        }

        private bool tieneVariosRoles()
        {
            return Database.usuarioTieneVariosRoles(this.nombre);
        }
    }
}
