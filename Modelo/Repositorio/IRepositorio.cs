using EscuelaSimple.Entidad;

namespace EscuelaSimple.Modelo.Repositorio
{
    public interface IRepositorio<TEntity, in TKey> : ISoloLecturaRepositorio<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : struct
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
