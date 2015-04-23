using EscuelaSimple.Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Modelo.Mapeo.EntityFramework
{
    public class InasistenciaMap : EntityTypeConfiguration<Inasistencia>
    {
        public InasistenciaMap()
        {
            ToTable("Inasistencia");
            
            HasKey<uint>(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Motivo);
            Property(x => x.Desde);
            Property(x => x.Hasta);
        }
    }
}
