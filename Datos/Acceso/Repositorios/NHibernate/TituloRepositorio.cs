using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.Repositorios.Contratos;
using NHibernate;

namespace EscuelaSimple.Datos.Repositorio.NHibernate
{
    public class TituloRepositorio : NHibernateRepositorio<Titulo, int>, ITituloRepositorio
    {
        public TituloRepositorio(ISession sesion)
            : base(sesion)
        {

        }
    }

    internal interface ITituloRepositorio : IRepositorio<Titulo, int>
    {

    }
}
