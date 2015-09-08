using System;

namespace EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Contratos
{
    public interface ITransaccion : IDisposable
    {
        void Comprometer();
        void Devolver();
    }
}