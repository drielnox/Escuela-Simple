using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;

namespace EscuelaSimple.Datos.Acceso.Repositorios.Contratos
{
    public interface IRepositorio<TEntidad, TIdentificador> : IRepositorioSoloLectura<TEntidad, TIdentificador>
        where TEntidad : Entidad<TIdentificador, TEntidad>
        where TIdentificador : struct, IComparable<TIdentificador>, IComparable, IEquatable<TIdentificador>
    {
        void Crear(TEntidad entidad);
        void Actualizar(TEntidad entidad);
        void Borrar(TEntidad entidad);
    }
}
