using System;

namespace EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Contratos
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        /*IRepositorio<TEntidad, TClavePrimaria> Repositorio<TEntidad, TClavePrimaria>()
            where TEntidad : IEntidad<TClavePrimaria>
            where TClavePrimaria : struct;*/
        void GuardarCambios();
    }
}
