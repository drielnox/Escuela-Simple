﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olfrad.EscuelaSimple.Entidad;

namespace Olfrad.EscuelaSimple.Modelo.Repositorio
{
    public interface IReadOnlyRepository<TEntity, in TKey>
        where TEntity : IEntity<TKey>
        where TKey : struct
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TKey id);
        TEntity GetBy(Predicate<TEntity> predicate);
        IEnumerable<TEntity> FilterBy(Predicate<TEntity> predicate);
    }
}