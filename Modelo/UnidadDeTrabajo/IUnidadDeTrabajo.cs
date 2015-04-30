using System;

namespace EscuelaSimple.Datos.UnidadDeTrabajo
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        void SaveChanges();
    }
}
