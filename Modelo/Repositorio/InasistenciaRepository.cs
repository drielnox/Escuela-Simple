using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olfrad.EscuelaSimple.Entidad;
using NHibernate;

namespace Olfrad.EscuelaSimple.Modelo.Repositorio
{
    public class InasistenciaRepository : NHibernateRepository<Inasistencia, uint>, IInasistenciaRepository
    {
        public InasistenciaRepository(ISession session)
            : base(session)
        {

        }
    }

    public interface IInasistenciaRepository : IRepository<Inasistencia, uint>
    {

    }
}
