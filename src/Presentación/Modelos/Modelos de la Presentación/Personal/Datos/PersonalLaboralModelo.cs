using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Presentacion.Modelo
{
    public class PersonalLaboralModelo
    {
        public DateTime IngresoDocencia { get; set; }
        public DateTime IngresoEstablecimiento { get; set; }
        public IEnumerable<ComboCargosEnPersonalLaboralModelo> Cargos { get; set; }
        public IEnumerable<FuncionesEnListadoPersonalLaboralModelo> Funciones { get; set; }
        public string Observacion { get; set; }
    }
}
