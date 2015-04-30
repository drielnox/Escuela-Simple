﻿using EscuelaSimple.Datos;
using EscuelaSimple.Datos.Repositorio;
using System;
using System.Collections.Generic;

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

        public IEnumerable<Modelos.TipoTelefono> ObtenerTelefonoTipos()
        {
            try
            {
                return this._repoTipoTelfonos.ObtenerTodo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
