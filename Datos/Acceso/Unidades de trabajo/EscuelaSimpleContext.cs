using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Inicializadores;
using EscuelaSimple.Datos.Mapeo.EntityFramework;
using EscuelaSimple.Datos.Utilitarios.Configuraciones.Mapeo.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;

namespace EscuelaSimple.Datos.Acceso.UnidadDeTrabajo
{
    public class EscuelaSimpleContext : DbContext
    {
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Funcion> Funcion { get; set; }
        public DbSet<Inasistencia> Inasistencia { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<SituacionRevista> SituacionRevista { get; set; }
        public DbSet<Tarea> Tarea { get; set; }
        public DbSet<Telefono> Telefono { get; set; }
        public DbSet<TipoTelefono> TipoTelefono { get; set; }
        public DbSet<Titulo> Titulo { get; set; }

        public EscuelaSimpleContext()
            : base("LocalDB")
        {
            Database.Log = s => Debug.Write(s);
            Database.SetInitializer<EscuelaSimpleContext>(new DebugInitializer());
        }

        public EscuelaSimpleContext(IDatabaseInitializer<EscuelaSimpleContext> inicializador) 
            : this()
        {
            Database.SetInitializer<EscuelaSimpleContext>(inicializador);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add<Cargo>(new CargoTypeConfiguration());
            modelBuilder.Configurations.Add<Funcion>(new FuncionTypeConfiguration());
            modelBuilder.Configurations.Add<Inasistencia>(new InasistenciaTypeConfiguration());
            modelBuilder.Configurations.Add<Personal>(new PersonalTypeConfiguration());
            modelBuilder.Configurations.Add<SituacionRevista>(new SituacionRevistaTypeConfiguration());
            modelBuilder.Configurations.Add<Tarea>(new TareaTypeConfiguration());
            modelBuilder.Configurations.Add<Telefono>(new TelefonoTypeConfiguration());
            modelBuilder.Configurations.Add<TipoTelefono>(new TipoTelefonoTypeConfiguration());
            modelBuilder.Configurations.Add<Titulo>(new TituloTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
