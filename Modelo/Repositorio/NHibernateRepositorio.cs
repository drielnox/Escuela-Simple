using EscuelaSimple.Modelos;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EscuelaSimple.Datos.Repositorio
{
    public abstract class NHibernateRepositorio<TEntidad, TClavePrimaria> : IRepositorio<TEntidad, TClavePrimaria>
        where TEntidad : class, IEntidad<TClavePrimaria>
        where TClavePrimaria : struct
    {
        public ISession Sesion { get; set; }

        public NHibernateRepositorio(ISession sesion)
        {
            this.Sesion = sesion;
        }

        public TEntidad ObtenerPorIdentificador(TClavePrimaria id)
        {
            return this.Sesion.Get<TEntidad>(id);
        }

        public IEnumerable<TEntidad> ObtenerTodo()
        {
            IQueryOver<TEntidad> result = this.Sesion.QueryOver<TEntidad>();
            return result.List(); // <<< Aca tira ProxyAccessException!!!
        }

        public void Crear(TEntidad entity)
        {
            this.Sesion.Save(entity);
        }

        public void Actualizar(TEntidad entity)
        {
            this.Sesion.Update(entity);
        }

        public void Borrar(TEntidad entity)
        {
            this.Sesion.Delete(entity);
        }

        public TEntidad ObtenerPor(Predicate<TEntidad> predicate)
        {
            List<TEntidad> result = this.FiltrarPor(predicate) as List<TEntidad>;
            return result.Count > 0 ? result[0] : null;
        }

        public IEnumerable<TEntidad> FiltrarPor(Predicate<TEntidad> predicate)
        {
            List<TEntidad> result = this.ObtenerTodo() as List<TEntidad>;
            return result.FindAll(predicate);
        }
    }
}
