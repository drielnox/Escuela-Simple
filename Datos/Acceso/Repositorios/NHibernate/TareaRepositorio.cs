using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.Repositorios.Contratos;
using NHibernate;

namespace EscuelaSimple.Datos.Repositorio.NHibernate
{
    public class TareaRepositorio : NHibernateRepositorio<Tarea, int>, ITareaRepositorio
    {
        public TareaRepositorio(ISession sesion)
            : base(sesion)
        {

        }
    }

    public interface ITareaRepositorio : IRepositorio<Tarea, int>
    {

    }
}
