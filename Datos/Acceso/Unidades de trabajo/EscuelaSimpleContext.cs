using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Inicializadores;
using EscuelaSimple.Datos.Mapeo.EntityFramework;
using EscuelaSimple.Datos.Utilitarios.Configuraciones.Mapeo.EntityFramework;
using System.Data.Entity;

namespace EscuelaSimple.Datos.Acceso.UnidadDeTrabajo
{
    public class EscuelaSimpleContext : DbContext
    {
        public DbSet<Cargo> Cargo { get; protected set; }
        public DbSet<Funcion> Funcion { get; protected set; }
        public DbSet<Inasistencia> Inasistencia { get; protected set; }
        public DbSet<Personal> Personal { get; protected set; }
        public DbSet<SituacionRevista> SituacionRevista { get; protected set; }
        public DbSet<Tarea> Tarea { get; protected set; }
        public DbSet<Telefono> Telefono { get; protected set; }
        public DbSet<TipoTelefono> TipoTelefono { get; protected set; }
        public DbSet<Titulo> Titulo { get; protected set; }

        public EscuelaSimpleContext()
            : base("MySQLConx")
        {
            Database.SetInitializer<EscuelaSimpleContext>(new DebugInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

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
