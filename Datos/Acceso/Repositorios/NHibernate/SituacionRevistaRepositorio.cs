using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.Repositorios.Contratos;
using NHibernate;

namespace EscuelaSimple.Datos.Repositorio.NHibernate
{
    public class SituacionRevistaRepositorio : NHibernateRepositorio<SituacionRevista, int>, ISituacionRevistaRepositorio
    {
        public SituacionRevistaRepositorio(ISession sesion)
            : base(sesion)
        {

        }
    }

    public interface ISituacionRevistaRepositorio : IRepositorio<SituacionRevista, int>
    {

    }
}
