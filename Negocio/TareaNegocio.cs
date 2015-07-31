using EscuelaSimple.Datos;
using EscuelaSimple.Datos.Repositorio.NHibernate;
using EscuelaSimple.Datos.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Negocio
{
    public class TareaNegocio
    {
        #region Atributos

        private IUnidadDeTrabajo _unidadDeTrabajo;
        private ITareaRepositorio _repositorio;

        #endregion

        public TareaNegocio()
        {
            this._unidadDeTrabajo = new NHibernateUnidadDeTrabajo(NHibernateWrapper.SesionActual);
            this._repositorio = new TareaRepositorio(NHibernateWrapper.SesionActual);
        }

        public IEnumerable<Modelos.Tarea> ObtenerTareas()
        {
            try
            {
                IEnumerable<Modelos.Tarea> tareas = this._repositorio.ObtenerTodo();
                return tareas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}