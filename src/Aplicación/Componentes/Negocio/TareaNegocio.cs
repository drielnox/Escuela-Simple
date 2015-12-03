using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Contratos;
using System;
using System.Collections.Generic;

namespace EscuelaSimple.Aplicacion.Componentes.Negocio
{
    public class TareaNegocio
    {
        #region Atributos

        //private IUnidadDeTrabajo _unidadDeTrabajo;
        //private ITareaRepositorio _repositorio;

        #endregion

        public TareaNegocio()
        {
            //this._unidadDeTrabajo = new NHibernateUnidadDeTrabajo(NHibernateWrapper.SesionActual);
            //this._repositorio = new TareaRepositorio(NHibernateWrapper.SesionActual);
        }

        public IEnumerable<Tarea> ObtenerTareas()
        {
            List<Tarea> tareas = new List<Tarea>();

            try
            {
                //IEnumerable<Tarea> tareas = this._repositorio.ObtenerTodo();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return tareas;
        }
    }
}