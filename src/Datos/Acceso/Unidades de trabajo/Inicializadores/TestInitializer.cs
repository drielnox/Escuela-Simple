using EscuelaSimple.Aplicacion.Entidades;
using System.Collections.Generic;
using System.Data.Entity;

namespace EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Inicializadores
{
    public class TestInitializer : DropCreateDatabaseIfModelChanges<EscuelaSimpleContext>
    {
        protected override void Seed(EscuelaSimpleContext context)
        {
            List<TipoTelefono> tipoTelefonos = new List<TipoTelefono>()
            {
                new TipoTelefono() { Descripcion = "Linea" },
                new TipoTelefono() { Descripcion = "Celular" },
                new TipoTelefono() { Descripcion = "Fax" }
            };

            context.TipoTelefono.AddRange(tipoTelefonos);

            List<SituacionRevista> situacionesRevista = new List<SituacionRevista>()
            {
                new SituacionRevista() { Abreviacion = "TIT", Descripcion = "Titular" },
                new SituacionRevista() { Abreviacion = "SUP", Descripcion = "Suplente" },
                new SituacionRevista() { Abreviacion = "AUX", Descripcion = "Auxiliar" },
                new SituacionRevista() { Abreviacion = "TII", Descripcion = "Titular Interino" },
                new SituacionRevista() { Abreviacion = "TIP", Descripcion = "Titular Provisional" },
                new SituacionRevista() { Abreviacion = "TMP", Descripcion = "Temporario" },
            };

            context.SituacionRevista.AddRange(situacionesRevista);

            List<Tarea> tareas = new List<Tarea>()
            {
                new Tarea() { Abreviacion = "MG", Descripcion = "Maestra de Grado" },
                new Tarea() { Abreviacion = "DIR", Descripcion = "Director" },
                new Tarea() { Abreviacion = "VD", Descripcion = "Vicedirector" },
                new Tarea() { Abreviacion = "SEC", Descripcion = "Secreatario" },
            };

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
