using EscuelaSimple.Entidad;
using System;
using System.Collections.Generic;

namespace EscuelaSimple.Modelo.Repositorio
{
    public interface ISoloLecturaRepositorio<TEntidad, in TClavePrimaria>
        where TEntidad : IEntidad<TClavePrimaria>
        where TClavePrimaria : struct
    {
        IEnumerable<TEntidad> ObtenerTodo();
        TEntidad ObtenerPorIdentificador(TClavePrimaria identificador);
        TEntidad ObtenerPor(Predicate<TEntidad> predicado);
        IEnumerable<TEntidad> FiltrarPor(Predicate<TEntidad> predicado);
    }
}
