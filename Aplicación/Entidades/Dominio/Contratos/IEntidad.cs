using System;

namespace EscuelaSimple.Aplicacion.Entidades.Contratos
{
    public interface IEntidad<TIdentificador> 
        where TIdentificador : struct, IEquatable<TIdentificador>, IComparable, IComparable<TIdentificador>
    {
        TIdentificador Identificador { get; set; }
    }
}
