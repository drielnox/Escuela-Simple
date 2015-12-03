using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Contratos;
using System;
using System.Collections.Generic;

namespace EscuelaSimple.Aplicacion.Componentes.Negocio
{
    public class SituacionRevistaNegocio
    {

        #region Atributos

        //private IUnidadDeTrabajo _unidadDeTrabajo;
        //private ISituacionRevistaRepositorio _repositorio;

        #endregion

        public SituacionRevistaNegocio()
        {
            //this._unidadDeTrabajo = new NHibernateUnidadDeTrabajo(NHibernateWrapper.SesionActual);
            //this._repositorio = new SituacionRevistaRepositorio(NHibernateWrapper.SesionActual);
        }

        public IEnumerable<SituacionRevista> ObtenerSituacionesRevista()
        {
            List<SituacionRevista> situacionesRevista = new List<SituacionRevista>();

            try
            {
                //IEnumerable<SituacionRevista> situacionesRevista = this._repositorio.ObtenerTodo();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return situacionesRevista;
        }
    }
}
