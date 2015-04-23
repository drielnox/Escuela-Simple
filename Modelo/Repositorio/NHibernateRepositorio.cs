using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using EscuelaSimple.Entidad;
using NHibernate;

namespace EscuelaSimple.Modelo.Repositorio
{
    public abstract class NHibernateRepositorio<TEntity, TKey> : IRepositorio<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct
    {
        ISession Session { get; set; }

        public NHibernateRepositorio(ISession session)
        {
            this.Session = session;
        }

        public TEntity GetById(TKey id)
        {
            return this.Session.Get<TEntity>(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.Session.QueryOver<TEntity>().List();
        }

        public void Create(TEntity entity)
        {
            this.Session.Save(entity);
        }

        public void Update(TEntity entity)
        {
            this.Session.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            this.Session.Delete(entity);
        }

        public TEntity GetBy(Predicate<TEntity> predicate)
        {
            List<TEntity> result = this.FilterBy(predicate) as List<TEntity>;
            return result.Count > 0 ? result[0] : null;
        }

        public IEnumerable<TEntity> FilterBy(Predicate<TEntity> predicate)
        {
            List<TEntity> result = this.GetAll() as List<TEntity>;
            return result.FindAll(predicate);
        }
    }
}
