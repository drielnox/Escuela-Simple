using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Presentacion.Modelo
{
    public class InasistenciasEnListadoPersonalInasistenciasModelo
    {
        public string Articulo { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public int Dias { get; set; }
    }
}
