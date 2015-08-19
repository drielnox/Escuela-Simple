using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Presentacion.Modelo
{
    public class PersonalBasicoModelo
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string Barrio { get; set; }
        public IEnumerable<TelefonosEnListadoPersonalBasicoModelo> Telefonos { get; set; }
    }
}
