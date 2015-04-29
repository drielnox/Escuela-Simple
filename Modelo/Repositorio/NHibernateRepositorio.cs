//using System.Linq;
using EscuelaSimple.Entidad;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EscuelaSimple.Modelo.Repositorio
{
    public abstract class NHibernateRepositorio<TEntidad, TClavePrimaria> : IRepositorio<TEntidad, TClavePrimaria>
        where TEntidad : class, IEntidad<TClavePrimaria>
        where TClavePrimaria : struct
    {
        ISession Sesion { get; set; }

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
            return this.Sesion.QueryOver<TEntidad>().List();
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
