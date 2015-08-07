using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.Repositorios.Contratos;
using NHibernate;

namespace EscuelaSimple.Datos.Repositorio.NHibernate
{
    public class CargoRepositorio : NHibernateRepositorio<Cargo, int>, ICargoRepositorio
    {
        public CargoRepositorio(ISession sesion)
            : base(sesion)
        {

        }
    }

    internal interface ICargoRepositorio : IRepositorio<Cargo, int>
    {

    }
}
