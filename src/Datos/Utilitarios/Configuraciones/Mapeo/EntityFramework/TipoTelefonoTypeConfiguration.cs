using EscuelaSimple.Aplicacion.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EscuelaSimple.Datos.Mapeo.EntityFramework
{
    public class TipoTelefonoTypeConfiguration : EntityTypeConfiguration<TipoTelefono>
    {
        public TipoTelefonoTypeConfiguration()
        {
            ToTable("TipoTelefono");

            HasKey<int>(x => x.Identificador);

            Property<int>(x => x.Identificador)
                .HasColumnName("IdTipoTelefono")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Descripcion)
                .HasColumnName("Descripcion")
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
