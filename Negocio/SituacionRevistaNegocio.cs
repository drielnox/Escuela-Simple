using EscuelaSimple.Datos;
using EscuelaSimple.Datos.Repositorio.NHibernate;
using EscuelaSimple.Datos.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Negocio
{
    public class SituacionRevistaNegocio
    {

        #region Atributos

        private IUnidadDeTrabajo _unidadDeTrabajo;
        private ISituacionRevistaRepositorio _repositorio;

        #endregion

        public SituacionRevistaNegocio()
        {
            this._unidadDeTrabajo = new NHibernateUnidadDeTrabajo(NHibernateWrapper.SesionActual);
            this._repositorio = new SituacionRevistaRepositorio(NHibernateWrapper.SesionActual);
        }

        public IEnumerable<Modelos.SituacionRevista> ObtenerSituacionesRevista()
        {
            try
            {
                IEnumerable<Modelos.SituacionRevista> situacionesRevista = this._repositorio.ObtenerTodo();
                return situacionesRevista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
