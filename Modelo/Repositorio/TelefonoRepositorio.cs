using EscuelaSimple.Entidad;
using NHibernate;

namespace EscuelaSimple.Modelo.Repositorio
{
    public class TelefonoRepositorio : NHibernateRepositorio<Telefono, uint>, ITelefonoRepositorio
    {
        public TelefonoRepositorio(ISession session)
            : base(session)
        {

        }
    }

    public interface ITelefonoRepositorio : IRepositorio<Telefono, uint>
    {
    }
}
