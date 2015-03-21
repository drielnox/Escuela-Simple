using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olfrad.EscuelaSimple.Modelo.Repositorio;
using Olfrad.EscuelaSimple.Modelo;

namespace Olfrad.EscuelaSimple.Negocio
{
    public class TipoTelefonoNegocio
    {
        #region Atributos

        private TipoTelefonoRepository _repoTipoTelfonos;

        #endregion

        #region Constructores

        public TipoTelefonoNegocio()
        {
            this._repoTipoTelfonos = new TipoTelefonoRepository(NHibernateWrapper.CurrentSession);
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
