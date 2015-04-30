using EscuelaSimple.Modelos;
using NHibernate;

namespace EscuelaSimple.Datos.Repositorio
{
    public class TipoTelefonoRepositorio : NHibernateRepositorio<TipoTelefono, uint>, ITipoTelefonoRepositorio
    {
        public TipoTelefonoRepositorio(ISession session)
            : base(session)
        {

        }
    }

    public interface ITipoTelefonoRepositorio : IRepositorio<TipoTelefono, uint>
    {

    }
}
