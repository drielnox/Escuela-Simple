using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olfrad.EscuelaSimple.Modelo.UnidadDeTrabajo
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
