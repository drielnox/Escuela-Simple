using EscuelaSimple.Aplicacion.Entidades;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace EscuelaSimple.Datos.Mapeo.EntityFramework
{
    public class PersonalTypeConfiguration : EntityTypeConfiguration<Personal>
    {
        public PersonalTypeConfiguration()
        {
            ToTable("Personal");

            HasKey<int>(x => x.Identificador);

            Property<int>(x => x.Identificador)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nombre)
                .IsRequired();
            Property(x => x.Apellido)
                .IsRequired();
            Property<int>(x => x.DNI)
                .IsRequired()
                .HasColumnAnnotation("UK_Personal_DNI_1", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
            Property<DateTime>(x => x.FechaNacimiento)
                .IsRequired();
            Property(x => x.Domicilio)
                .IsOptional();
            Property(x => x.Localidad)
                .IsOptional();
            Property<DateTime>(x => x.IngresoDocencia)
                .IsOptional();
            Property<DateTime>(x => x.IngresoEstablecimiento)
                .IsOptional();
            Property(x => x.Observacion)
                .IsOptional();

            HasMany<Telefono>(x => x.Telefonos);
            HasMany<Inasistencia>(x => x.Inasistencias);
            HasMany<Titulo>(x => x.Titulos)
                .WithOptional();
            HasMany<Cargo>(x => x.Cargos)
                .WithOptional();
        }
    }
}
