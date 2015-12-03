using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;

namespace EscuelaSimple.Datos.Acceso.Repositorio.Contratos
{
    public interface IRepositorio<TEntidad, TIdentificador> : IRepositorioSoloLectura<TEntidad, TIdentificador>
        where TEntidad : Entidad<TIdentificador, TEntidad>
        where TIdentificador : struct, IComparable<TIdentificador>, IComparable, IEquatable<TIdentificador>
    {
        TIdentificador? Crear(TEntidad entidad);
        void Actualizar(TEntidad entidad);
        void Borrar(TEntidad entidad);
    }
}
