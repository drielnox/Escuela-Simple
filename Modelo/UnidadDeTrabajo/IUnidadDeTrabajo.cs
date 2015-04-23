using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Modelo.UnidadDeTrabajo
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        void SaveChanges();
    }
}
