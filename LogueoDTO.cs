using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public class LogueoDTO
    {
        //-------------------------------------- Atributos -------------------------------------

        public string mensaje { get; set; }
        public bool exito { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public LogueoDTO()
        {

        }

        //-------------------------------------- Metodos -------------------------------------

        public LogueoDTO informarExito(string nombreUsuario)
        {
            exito = true;
            mensaje = nombreUsuario;
            return this;
        }

        public LogueoDTO informarUsuarioInexistente()
        {
            exito = false;
            mensaje = "ERROR: El usuario no existe.";
            return this;
        }

        public LogueoDTO informarContraseniaIncorrecta()
        {
            exito = false;
            mensaje = "ERROR: Contraseña invalida.";
            return this;
        }

        public LogueoDTO informarBloqueo()
        {
            exito = false;
            mensaje = "ERROR: Usuario bloqueado por superar el limite de intentos fallidos.";
            return this;
        }
    }
}
