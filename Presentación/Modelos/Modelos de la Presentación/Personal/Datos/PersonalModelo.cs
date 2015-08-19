using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Presentacion.Modelo
{
    public class PersonalModelo
    {
        public PersonalBasicoModelo Basico { get; set; }
        public PersonalTitulosModelo Titulos { get; set; }
        public PersonalLaboralModelo Laboral { get; set; }
        public PersonalInasistenciasModelo Inasistencias { get; set; }
    }
}
