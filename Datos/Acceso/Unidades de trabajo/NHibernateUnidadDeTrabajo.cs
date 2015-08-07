using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Contratos;
using NHibernate;
using System;
using System.Collections;

namespace EscuelaSimple.Datos.Acceso.UnidadDeTrabajo
{
    public class NHibernateUnidadDeTrabajo : IUnidadDeTrabajo
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public NHibernateUnidadDeTrabajo(ISession sesion)
        {
            this._session = sesion;
            this._transaction = this._session.BeginTransaction();
        }

        public void GuardarCambios()
        {
            if (this._transaction == null)
            {
                throw new InvalidOperationException("UnitOfWork have already been saved.");
            }

            this._transaction.Commit();
            this._transaction = null;
        }

        public void Dispose()
        {
            if (this._session.IsOpen)
            {
                if (this._transaction.IsActive && !this._transaction.WasRolledBack)
                {
                    this._transaction.Rollback();
                }
            }

            if (this._transaction != null)
            {
                this._transaction.Rollback();
            }
        }
    }
}
