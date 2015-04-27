using EscuelaSimple.Entidad;
using NHibernate;

namespace EscuelaSimple.Modelo.Repositorio
{
    public class InasistenciaRepositorio : NHibernateRepositorio<Inasistencia, uint>, IInasistenciaRepositorio
    {
        public InasistenciaRepositorio(ISession session)
            : base(session)
        {

        }
    }

    public interface IInasistenciaRepositorio : IRepositorio<Inasistencia, uint>
    {

    }
}
