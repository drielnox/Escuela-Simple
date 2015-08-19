using EscuelaSimple.Presentacion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Presentacion.Logica.Presentador.Contratos
{
    public interface IPersonalCRUDVista
    {
        IPersonalBasicoCRUDVista Basico { get; set; }
        IPersonalTitulosCRUDVista Titulos { get; set; }
        IPersonalLaboralCRUDVista Laboral { get; set; }
        IPersonalInansistenciaCRUDVista Inasistencias { get; set; }
        PersonalModelo Guardar();
        void Cancelar();
    }
}
