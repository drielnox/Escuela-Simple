using Olfrad.EscuelaSimple.DatosEntityFramework.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Olfrad.EscuelaSimple.DatosEntityFramework
{
    public class EscuelaSimpleContext : DbContext
    {
        public DbSet<Personal> Personal { get; set; }

        public EscuelaSimpleContext() 
            : base()
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Personal>().ToTable("Personal");
            modelBuilder.Entity<Personal>().HasKey<uint>(x => x.Id);
            modelBuilder.Entity<Personal>().Property(x => x.Nombre).IsRequired();
            modelBuilder.Entity<Personal>().Property(x => x.Apellido).IsRequired();
            modelBuilder.Entity<Personal>().Property(x => x.DNI).IsRequired();
            modelBuilder.Entity<Personal>().Property(x => x.FechaNacimiento).IsRequired();
            modelBuilder.Entity<Personal>().Property(x => x.Domicilio).IsOptional();
            modelBuilder.Entity<Personal>().Property(x => x.Localidad).IsOptional();
            modelBuilder.Entity<Personal>().Property(x => x.IngresoDocencia).IsOptional();
            modelBuilder.Entity<Personal>().Property(x => x.IngresoEstablecimiento).IsOptional();
            modelBuilder.Entity<Personal>().Property(x => x.Titulo).IsOptional();
            modelBuilder.Entity<Personal>().Property(x => x.Cargo).IsOptional();
            modelBuilder.Entity<Personal>().Property(x => x.SituacionRevista).IsOptional();
            modelBuilder.Entity<Personal>().Property(x => x.Observacion).IsOptional();
            modelBuilder.Entity<Personal>().HasMany<Telefono>(x => x.Telefonos).;
            
            modelBuilder.Entity<Telefono>()
                .ToTable("Telefono")
                .HasKey<uint>(x => x.Id);
            
            modelBuilder.Entity<TipoTelefono>()
                .ToTable("TipoTelefono")
                .HasKey<uint>(x => x.Id);
            
            modelBuilder.Entity<Inasistencia>()
                .ToTable("Inasistencia")
                .HasKey<uint>(x => x.Id);

            // Personal
            EntityTypeConfiguration<Personal> personalEntityConfig = modelBuilder.Entity<Personal>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
