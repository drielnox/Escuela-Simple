using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.Repositorios.Contratos;
using EscuelaSimple.Datos.Acceso.Repositorios.TiposBase;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Contratos;

namespace EscuelaSimple.Datos.Acceso.Repositorios
{
    class SituacionRevistaRepositorio : RepositorioGenerico<SituacionRevista, int>, ISituacionRevistaRepositorio
    {
        public SituacionRevistaRepositorio(IUnidadDeTrabajo unidadDeTrabajo)
            : base(unidadDeTrabajo)
        {

        }
    }
}
