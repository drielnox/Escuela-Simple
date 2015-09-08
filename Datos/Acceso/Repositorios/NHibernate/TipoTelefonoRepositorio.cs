using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.Repositorio.Contratos;
using EscuelaSimple.Datos.Repositorio.TiposBase;
using NHibernate;

namespace EscuelaSimple.Datos.Repositorio.NHibernate
{
    public class TipoTelefonoRepositorio : NHibernateRepositorio<TipoTelefono, int>, ITipoTelefonoRepositorio
    {
        public TipoTelefonoRepositorio(ISession session)
            : base(session)
        {

        }
    }

    public interface ITipoTelefonoRepositorio : IRepositorio<TipoTelefono, int>
    {

    }
}
