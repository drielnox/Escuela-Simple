using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Olfrad.EscuelaSimple.Modelo.UnidadDeTrabajo
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public NHibernateUnitOfWork(ISession session)
        {
            this._session = session;
            this._transaction = this._session.BeginTransaction();
        }

        public void SaveChanges()
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
