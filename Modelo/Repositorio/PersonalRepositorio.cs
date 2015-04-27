using EscuelaSimple.Entidad;
using NHibernate;

namespace EscuelaSimple.Modelo.Repositorio
{
    public class PersonalRepositorio : NHibernateRepositorio<Personal, uint>, IPersonalRepositorio
    {
        public PersonalRepositorio(ISession session)
            : base(session)
        {

        }
    }

    public interface IPersonalRepositorio : IRepositorio<Personal, uint>
    {
    }
}
