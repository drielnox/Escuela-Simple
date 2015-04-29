using EscuelaSimple.Entidad;

namespace EscuelaSimple.Modelo.Repositorio
{
    public interface IRepositorio<TEntidad, in TClavePrimaria> : ISoloLecturaRepositorio<TEntidad, TClavePrimaria>
        where TEntidad : IEntidad<TClavePrimaria>
        where TClavePrimaria : struct
    {
        void Crear(TEntidad entidad);
        void Actualizar(TEntidad entidad);
        void Borrar(TEntidad entidad);
    }
}
