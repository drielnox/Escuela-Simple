using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.Repositorios.Contratos;
using EscuelaSimple.Datos.Acceso.Repositorios.TiposBase;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Contratos;

namespace EscuelaSimple.Datos.Acceso.Repositorios.EntityFramework
{
    class TituloRepositorio : RepositorioGenerico<Titulo, int>, ITituloRepositorio
    {
        public TituloRepositorio(IUnidadDeTrabajo unidadDeTrabajo)
            : base(unidadDeTrabajo)
        {

        }
    }
}
