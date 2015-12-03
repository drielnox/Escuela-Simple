using EscuelaSimple.Presentacion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Presentacion.Logica.Presentador.Contratos
{
    public interface IPersonalBasicoCRUDVista
    {
        PersonalTelefonoModelo AgregarTelefono();
        PersonalTelefonoModelo ModificarTelefono(PersonalTelefonoModelo telefono);
        void BorrarTelefono();
    }
}
