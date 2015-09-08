using System;

namespace EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Contratos
{
    public interface IFabricaUnidadDeTrabajo : IDisposable
    {
        IUnidadDeTrabajo EmpezarUnidadDeTrabajo();
        void TerminarUnidadDeTrabajo(IUnidadDeTrabajo unidadDeTrabajo);
    }
}
