using EscuelaSimple.Entidad;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace EscuelaSimple.Modelo.Mapeo.EntityFramework
{
    public class PersonalMap : EntityTypeConfiguration<Personal>
    {
        public PersonalMap()
        {
            ToTable("Personal");

            HasKey<uint>(x => x.Id);

            Property<uint>(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nombre).IsRequired();
            Property(x => x.Apellido).IsRequired();
            Property<uint>(x => x.DNI).IsRequired().HasColumnAnnotation("UK_Personal_DNI_1", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
            Property<DateTime>(x => x.FechaNacimiento).IsRequired();
            Property(x => x.Domicilio).IsOptional();
            Property(x => x.Localidad).IsOptional();
            Property<DateTime>(x => x.IngresoDocencia).IsOptional();
            Property<DateTime>(x => x.IngresoEstablecimiento).IsOptional();
            Property(x => x.Titulo).IsOptional();
            Property(x => x.Cargo).IsOptional();
            Property(x => x.SituacionRevista).IsOptional();
            Property(x => x.Observacion).IsOptional();

            HasRequired(x => x.Telefonos).WithMany();
            HasRequired(x => x.Inasistencias).WithMany();
        }
    }
}
