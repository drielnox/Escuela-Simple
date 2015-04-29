using EscuelaSimple.Entidad;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EscuelaSimple.Modelo.Mapeo.EntityFramework
{
    public class TipoTelefonoConfiguracion : EntityTypeConfiguration<TipoTelefono>
    {
        public TipoTelefonoConfiguracion()
        {
            ToTable("TipoTelefono");
            
            HasKey<uint>(x => x.Identificador);

            Property(x => x.Identificador).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Descripcion).IsRequired();
        }
    }
}
