using EscuelaSimple.Modelos;
using NHibernate;

namespace EscuelaSimple.Datos.Repositorio
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
