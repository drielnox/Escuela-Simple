using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.Repositorio.Contratos;
using EscuelaSimple.Datos.Repositorio.TiposBase;
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
