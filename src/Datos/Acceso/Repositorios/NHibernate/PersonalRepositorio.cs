using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.Repositorio.Contratos;
using EscuelaSimple.Datos.Repositorio.TiposBase;
using NHibernate;

namespace EscuelaSimple.Datos.Repositorio.NHibernate
{
    public class PersonalRepositorio : NHibernateRepositorio<Personal, int>, IPersonalRepositorio
    {
        public PersonalRepositorio(ISession session)
            : base(session)
        {

        }
    }

    public interface IPersonalRepositorio : IRepositorio<Personal, int>
    {
    }
}
