using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EscuelaSimple.Entidad;

namespace EscuelaSimple.Modelo.Repositorio
{
    public interface ISoloLecturaRepositorio<TEntity, in TKey>
        where TEntity : IEntity<TKey>
        where TKey : struct
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TKey id);
        TEntity GetBy(Predicate<TEntity> predicate);
        IEnumerable<TEntity> FilterBy(Predicate<TEntity> predicate);
    }
}
