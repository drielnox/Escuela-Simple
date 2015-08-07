using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.Repositorios.Contratos;
using NHibernate;

namespace EscuelaSimple.Datos.Repositorio.NHibernate
{
    public class FuncionRepostorio : NHibernateRepositorio<Funcion, int>, IFuncionRepositorio
    {
        public FuncionRepostorio(ISession sesion)
            : base(sesion)
        {

        }
    }

    internal interface IFuncionRepositorio : IRepositorio<Funcion, int>
    {

    }
}