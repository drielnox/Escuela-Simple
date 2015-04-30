using EscuelaSimple.Modelos;
using NHibernate;

namespace EscuelaSimple.Datos.Repositorio
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
