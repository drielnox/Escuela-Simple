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
                .HasColumnName("IdPersonal")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nombre)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(255);
            Property(x => x.Apellido)
                .HasColumnName("Apellido")
                .IsRequired()
                .HasMaxLength(255);
            Property<int>(x => x.DNI)
                .HasColumnName("DNI")
                .IsRequired()
                .HasColumnAnnotation("UK_Personal_DNI_1", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
            Property<DateTime>(x => x.FechaNacimiento)
                .HasColumnName("FechaNacimiento")
                .IsRequired();
            Property(x => x.Domicilio)
                .HasColumnName("Domicilio")
                .IsOptional()
                .HasMaxLength(255);
            Property(x => x.Barrio)
                .HasColumnName("Barrio")
                .IsOptional()
                .HasMaxLength(255);
            Property(x => x.Localidad)
                .HasColumnName("Localidad")
                .IsOptional()
                .HasMaxLength(255);
            Property<DateTime>(x => x.IngresoDocencia)
                .HasColumnName("IngresoDocencia")
                .IsOptional();
            Property<DateTime>(x => x.IngresoEstablecimiento)
                .HasColumnName("IngresoEstablecimiento")
                .IsOptional();
            Property(x => x.Observacion)
                .HasColumnName("Observacion")
                .IsOptional()
                .HasMaxLength(255);

            HasMany<Telefono>(x => x.Telefonos)
                .WithRequired(x => x.PersonalAsociado)
                .HasForeignKey<int>(x => x.IdPersonal);
            HasMany<Inasistencia>(x => x.Inasistencias)
                .WithRequired(x => x.PersonalAsociado)
                .HasForeignKey<int>(x => x.IdPersonal);
            HasMany<Titulo>(x => x.Titulos)
                .WithRequired(x => x.PersonalAsociado)
                .HasForeignKey<int>(x => x.IdPersonal);
            HasMany<Cargo>(x => x.Cargos)
                .WithRequired(x => x.PersonalAsociado)
                .HasForeignKey<int>(x => x.IdPersonal);
        }
    }
}
