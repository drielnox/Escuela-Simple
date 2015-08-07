using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.Repositorios.Contratos;
using EscuelaSimple.Datos.Repositorio.TiposBase;
using NHibernate;

namespace EscuelaSimple.Datos.Repositorio.NHibernate
{
    public class InasistenciaRepositorio : NHibernateRepositorio<Inasistencia, int>, IInasistenciaRepositorio
    {
        public InasistenciaRepositorio(ISession session)
            : base(session)
        {

        }
    }

    public interface IInasistenciaRepositorio : IRepositorio<Inasistencia, int>
    {

    }
}
