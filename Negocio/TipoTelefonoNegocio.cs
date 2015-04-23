using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EscuelaSimple.Modelo.Repositorio;
using EscuelaSimple.Modelo;

namespace EscuelaSimple.Negocio
{
    public class TipoTelefonoNegocio
    {
        #region Atributos

        private TipoTelefonoRepositorio _repoTipoTelfonos;

        #endregion

        #region Constructores

        public TipoTelefonoNegocio()
        {
            this._repoTipoTelfonos = new TipoTelefonoRepositorio(NHibernateWrapper.CurrentSession);
        }

        #endregion

        public IEnumerable<Entidad.TipoTelefono> ObtenerTelefonoTipos()
        {
            try
            {
                return this._repoTipoTelfonos.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
