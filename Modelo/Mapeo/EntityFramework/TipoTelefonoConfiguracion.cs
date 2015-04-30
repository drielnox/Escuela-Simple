using EscuelaSimple.Modelos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EscuelaSimple.Datos.Mapeo.EntityFramework
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
