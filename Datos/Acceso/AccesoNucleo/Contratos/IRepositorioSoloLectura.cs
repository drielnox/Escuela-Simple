using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EscuelaSimple.Datos.Acceso.Repositorio.Contratos
{
    public interface IRepositorioSoloLectura<TEntidad, TIdentificador>
        where TEntidad : Entidad<TIdentificador, TEntidad>
        where TIdentificador : struct, IEquatable<TIdentificador>, IComparable<TIdentificador>, IComparable
    {
        IEnumerable<TEntidad> ObtenerTodo();
        TEntidad ObtenerPorIdentificador(TIdentificador identificador);
        TEntidad ObtenerPor(Predicate<TEntidad> predicado);
        IEnumerable<TEntidad> FiltrarPor(Predicate<TEntidad> predicado);
    }
}
