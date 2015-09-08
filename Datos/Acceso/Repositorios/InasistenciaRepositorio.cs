using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.Repositorios.Contratos;
using EscuelaSimple.Datos.Acceso.Repositorios.TiposBase;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Contratos;

namespace EscuelaSimple.Datos.Acceso.Repositorios
{
    class InasistenciaRepositorio : RepositorioGenerico<Inasistencia, int>, IInasistenciaRepositorio
    {
        public InasistenciaRepositorio(IUnidadDeTrabajo unidadDeTrabajo)
            : base(unidadDeTrabajo)
        {

        }
    }
}
