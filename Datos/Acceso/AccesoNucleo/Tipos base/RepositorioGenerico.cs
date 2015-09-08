using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using EscuelaSimple.Datos.Acceso.Repositorio.Contratos;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Contratos;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace EscuelaSimple.Datos.Acceso.Repositorios.TiposBase
{
    public abstract class RepositorioGenerico<TEntidad, TIdentificador> : IRepositorio<TEntidad, TIdentificador>
        where TEntidad : Entidad<TIdentificador, TEntidad>
        where TIdentificador : struct, IComparable<TIdentificador>, IComparable, IEquatable<TIdentificador>
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get; set; }

        public RepositorioGenerico(IUnidadDeTrabajo unidadDeTrabajo)
        {
            Contract.Ensures(unidadDeTrabajo != null);

            UnidadDeTrabajo = unidadDeTrabajo;
        }

        public virtual TIdentificador? Crear(TEntidad entidad)
        {
            return UnidadDeTrabajo.Insertar<TIdentificador, TEntidad>(entidad);
        }

        public virtual void Actualizar(TEntidad entidad)
        {
            UnidadDeTrabajo.Actualizar<TIdentificador, TEntidad>(entidad);
        }

        public virtual void Borrar(TEntidad entidad)
        {
            UnidadDeTrabajo.Borrar<TIdentificador, TEntidad>(entidad);
        }

        public virtual IEnumerable<TEntidad> ObtenerTodo()
        {
            return UnidadDeTrabajo.ObtenerTodo<TIdentificador, TEntidad>();
        }

        public virtual TEntidad ObtenerPorIdentificador(TIdentificador identificador)
        {
            return UnidadDeTrabajo.ObtenerPorIdentificador<TIdentificador, TEntidad>(identificador);
        }

        public virtual TEntidad ObtenerPor(Predicate<TEntidad> predicado)
        {
            IList<TEntidad> resultado = FiltrarPor(predicado) as IList<TEntidad>;
            return resultado.Count > 0 ? resultado[0] : null;
        }

        public virtual IEnumerable<TEntidad> FiltrarPor(Predicate<TEntidad> predicado)
        {
            List<TEntidad> resultado = ObtenerTodo() as List<TEntidad>;
            return resultado.FindAll(predicado);
        }
    }
}
