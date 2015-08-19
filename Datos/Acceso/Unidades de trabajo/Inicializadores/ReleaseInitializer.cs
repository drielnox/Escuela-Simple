using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

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
