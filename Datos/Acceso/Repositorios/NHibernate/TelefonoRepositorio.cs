using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.Repositorios.Contratos;
using NHibernate;

namespace EscuelaSimple.Datos.Repositorio.NHibernate
{
    public class TelefonoRepositorio : NHibernateRepositorio<Telefono, int>, ITelefonoRepositorio
    {
        public TelefonoRepositorio(ISession session)
            : base(session)
        {

        }
    }

    public interface ITelefonoRepositorio : IRepositorio<Telefono, int>
    {
    }
}
