using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.Repositorios.Contratos;
using EscuelaSimple.Datos.Acceso.Repositorios.TiposBase;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Contratos;

namespace EscuelaSimple.Datos.Acceso.Repositorios
{
    class TipoTelefonoRepositorio : RepositorioGenerico<TipoTelefono, int>, ITipoTelefonoRepositorio
    {
        public TipoTelefonoRepositorio(IUnidadDeTrabajo unidadDeTrabajo)
            : base(unidadDeTrabajo)
        {

        }
    }
}
