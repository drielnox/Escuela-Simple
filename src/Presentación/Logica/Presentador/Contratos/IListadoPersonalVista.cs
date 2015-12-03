using EscuelaSimple.Presentacion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Presentacion.Logica.Presentador.Contratos
{
    public interface IListadoPersonalVista
    {
        void CargarPersonalEnGrilla(IEnumerable<ListadoPersonalModelo> personal);
        void RefrescarPersonalEnGrilla(IEnumerable<ListadoPersonalModelo> personal);
        PersonalModelo AgregarPersonal();
        PersonalModelo ModificarPersonal(PersonalModelo personal);
        void BorrarPersonal(PersonalEnListadoModelo personal);
    }
}
