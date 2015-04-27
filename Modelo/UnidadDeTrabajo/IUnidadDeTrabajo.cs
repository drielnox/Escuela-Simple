using System;

namespace EscuelaSimple.Modelo.UnidadDeTrabajo
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        void SaveChanges();
    }
}
