using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;
using System.Collections.Generic;

namespace EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Contratos
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        ITransaccion EmpezarTransaccion();
        void TerminarTransaccion(ITransaccion transaccion);

        void Fluir();

        TEntidad ObtenerPorIdentificador<TIdentificador, TEntidad>(TIdentificador identificador)
            where TIdentificador : struct, IEquatable<TIdentificador>, IComparable, IComparable<TIdentificador>
            where TEntidad : Entidad<TIdentificador, TEntidad>;

        IEnumerable<TEntidad> ObtenerTodo<TIdentificador, TEntidad>()
            where TIdentificador : struct, IEquatable<TIdentificador>, IComparable, IComparable<TIdentificador>
            where TEntidad : Entidad<TIdentificador, TEntidad>;

        TIdentificador? Insertar<TIdentificador, TEntidad>(TEntidad entidad)
            where TIdentificador : struct, IEquatable<TIdentificador>, IComparable, IComparable<TIdentificador>
            where TEntidad : Entidad<TIdentificador, TEntidad>;
        
        void Actualizar<TIdentificador, TEntidad>(TEntidad entidad)
            where TIdentificador : struct, IEquatable<TIdentificador>, IComparable, IComparable<TIdentificador>
            where TEntidad : Entidad<TIdentificador, TEntidad>;

        void Borrar<TIdentificador, TEntidad>(TEntidad entidad)
            where TIdentificador : struct, IEquatable<TIdentificador>, IComparable, IComparable<TIdentificador>
            where TEntidad : Entidad<TIdentificador, TEntidad>;
    }
}
