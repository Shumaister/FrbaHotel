using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Hotel
    {
        //-------------------------------------- Atributos -------------------------------------

        public string id { get; set; }
        public string nombre { get; set; }
        public string cantidadEstrellas { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string fechaCreacion { get; set; }
        public string tipoRegimen { get; set; }
        public string estado { get; set; }
        public Domicilio domicilio { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public Hotel(string id)
        {
            this.id = id;
        }
        
        public Hotel(Domicilio domicilio)
        {
            this.domicilio = domicilio;
        }

        public Hotel(string id, string nombre, string cantidadEstrellas, string email, string telefono, string fechaCreacion, string tipoRegimen, string estado, Domicilio domicilio)
        {
            this.id = id;
            this.nombre = nombre;
            this.cantidadEstrellas = cantidadEstrellas;
            this.email = email;
            this.telefono = telefono;
            this.fechaCreacion = fechaCreacion;
            this.tipoRegimen = tipoRegimen;
            this.estado = estado;
            this.domicilio = domicilio;
        }
    }
}
