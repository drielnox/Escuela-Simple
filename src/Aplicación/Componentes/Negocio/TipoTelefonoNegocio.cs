using EscuelaSimple.Aplicacion.Entidades;
using System;
using System.Collections.Generic;

namespace EscuelaSimple.Aplicacion.Componentes.Negocio
{
    public class TipoTelefonoNegocio
    {
        #region Atributos

        // private TipoTelefonoRepositorio _repoTipoTelfonos;

        #endregion

        #region Constructores

        public TipoTelefonoNegocio()
        {
            //this._repoTipoTelfonos = new TipoTelefonoRepositorio(NHibernateWrapper.SesionActual);
        }

        #endregion

        public IEnumerable<TipoTelefono> ObtenerTelefonoTipos()
        {
            List<TipoTelefono> tiposTelefono = new List<TipoTelefono>();

            try
            {
                //return this._repoTipoTelfonos.ObtenerTodo();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return tiposTelefono;
        }
    }
}
