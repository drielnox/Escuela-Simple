using System.Data.Entity;

namespace EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Inicializadores
{
    public class ReleaseInitializer : CreateDatabaseIfNotExists<EscuelaSimpleContext>
    {
        protected override void Seed(EscuelaSimpleContext context)
        {
            base.Seed(context);
        }
    }
}
