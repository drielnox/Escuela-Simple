using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.Repositorios.Contratos;
using EscuelaSimple.Datos.Acceso.Repositorios.TiposBase;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Contratos;

namespace EscuelaSimple.Datos.Acceso.Repositorios
{
    class TelefonoRepositorio : RepositorioGenerico<Telefono, int>, ITelefonoRepositorio
    {
        public TelefonoRepositorio(IUnidadDeTrabajo unidadDeTrabajo)
            : base(unidadDeTrabajo)
        {

        }
    }
}
