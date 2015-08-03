using EscuelaSimple.Datos.Repositorio;
using EscuelaSimple.Modelos;
using System;

namespace EscuelaSimple.Datos.UnidadDeTrabajo
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        /*IRepositorio<TEntidad, TClavePrimaria> Repositorio<TEntidad, TClavePrimaria>()
            where TEntidad : IEntidad<TClavePrimaria>
            where TClavePrimaria : struct;*/
        void GuardarCambios();
    }
}
