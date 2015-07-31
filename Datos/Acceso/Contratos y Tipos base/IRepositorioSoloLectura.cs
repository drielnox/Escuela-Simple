using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Datos.Acceso
{
    public interface IRepositorioSoloLectura<TEntidad, in TIdentificador> 
        where TEntidad : Entidad<TIdentificador>
        where TIdentificador : struct, IEquatable<TIdentificador>, IComparable<TIdentificador>
    {
        IEnumerable<TEntidad> ObtenerTodo();
        TEntidad ObtenerPorIdentificador(TIdentificador identificador);
        TEntidad ObtenerPor(Predicate<TEntidad> predicado);
        IEnumerable<TEntidad> FiltrarPor(Predicate<TEntidad> predicado);
    }
}
