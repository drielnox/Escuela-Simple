using EscuelaSimple.Aplicacion.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace EscuelaSimple.Datos.Mapeo.EntityFramework
{
    public class TelefonoTypeConfiguration : EntityTypeConfiguration<Telefono>
    {
        public TelefonoTypeConfiguration()
        {
            ToTable("Telefono");

            HasKey<int>(x => x.Identificador);

            Property<int>(x => x.Identificador)
                .HasColumnName("IdTelefono")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property<int>(x => x.IdPersonal)
                .HasColumnName("IdPersonal")
                .IsRequired();
            Property<int>(x => x.Numero)
                .HasColumnName("Numero")
                .IsRequired();

            HasRequired<TipoTelefono>(x => x.Tipo)
                .WithRequiredDependent(x => x.TelefonoAsociado);
        }
    }
}
