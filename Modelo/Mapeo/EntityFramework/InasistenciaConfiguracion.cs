using EscuelaSimple.Modelos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EscuelaSimple.Datos.Mapeo.EntityFramework
{
    public class InasistenciaConfiguracion : EntityTypeConfiguration<Inasistencia>
    {
        public InasistenciaConfiguracion()
        {
            ToTable("Inasistencia");
            
            HasKey<uint>(x => x.Identificador);

            Property(x => x.Identificador).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Motivo);
            Property(x => x.Desde);
            Property(x => x.Hasta);
        }
    }
}
