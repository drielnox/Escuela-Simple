using EscuelaSimple.Aplicacion.Entidades;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EscuelaSimple.Datos.Mapeo.EntityFramework
{
    public class InasistenciaConfiguracion : EntityTypeConfiguration<Inasistencia>
    {
        public InasistenciaConfiguracion()
        {
            ToTable("Inasistencia");
            
            HasKey<int>(x => x.Identificador);

            Property<int>(x => x.Identificador).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Motivo);
            Property<DateTime>(x => x.Desde);
            Property<DateTime>(x => x.Hasta);
        }
    }
}
