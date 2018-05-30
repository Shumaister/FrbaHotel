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
        public string nombreUsuario { get; set; }
        public string rolLogueado { get; set; }
        public string hotelLogueado { get; set; }
        public List<string> roles { get; set; }
        public List<string> funcionalidades { get; set; }
        public List<string> hoteles { get; set; }

        public Usuario(LogueoDTO logueo)
        {
            this.nombreUsuario = logueo.nombreUsuario;
            this.roles = logueo.rolesUsuario;
            this.hoteles = logueo.hotelesUsuario;
        }

        private List<string> FuncionalidadesDeRol(string rol)
        {
            return Database.rolObtenerFuncionalidades(rol);
        }

        private bool trabajaEnUnSoloHotel()
        {
            return Database.usuarioTrabajaEnUnSoloHotel(this.nombreUsuario);
        }

        private bool trabajaEnVariosHoteles()
        {
            return Database.usuarioTrabajaEnVariosHoteles(this.nombreUsuario);
        }

        private bool tieneUnSoloRol()
        {
            return Database.usuarioTieneUnSoloRol(this.nombreUsuario);
        }

        private bool tieneVariosRoles()
        {
            return Database.usuarioTieneVariosRoles(this.nombreUsuario);
        }
    }
}
