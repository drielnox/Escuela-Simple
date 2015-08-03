using EscuelaSimple.Aplicacion.Entidades.TiposBase;

namespace EscuelaSimple.Datos.Acceso.Repositorios.Contratos
{
    public interface IRepositorio<TEntidad, in TIdentificador> : IRepositorioSoloLectura<TEntidad, TIdentificador>
        where TEntidad : Entidad<TIdentificador>
        where TIdentificador : struct
    {
        void Crear(TEntidad entidad);
        void Actualizar(TEntidad entidad);
        void Borrar(TEntidad entidad);
    }
}
