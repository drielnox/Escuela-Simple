using EscuelaSimple.Entidad;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EscuelaSimple.Modelo.Mapeo.EntityFramework
{
    public class TipoTelefonoMap : EntityTypeConfiguration<TipoTelefono>
    {
        public TipoTelefonoMap()
        {
            ToTable("TipoTelefono");
            
            HasKey<uint>(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Descripcion).IsRequired();
        }
    }
}
