using EscuelaSimple.Modelos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EscuelaSimple.Datos.Mapeo.EntityFramework
{
    public class TelefonoConfiguracion : EntityTypeConfiguration<Telefono>
    {
        public TelefonoConfiguracion()
        {
            ToTable("Telefono");
                
            HasKey<uint>(x => x.Identificador);

            Property(x => x.Identificador).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Numero);

            HasRequired<TipoTelefono>(x => x.Tipo).WithRequiredDependent();
        }
    }
}
