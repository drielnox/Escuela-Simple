using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Presentacion.Modelo
{
    public class PersonalTelefonoModelo
    {
        public IEnumerable<ComboTiposTelefonoEnPersonalTelefonoModelo> TiposTelefono { get; set; }
        public int Numero { get; set; }
    }
}
