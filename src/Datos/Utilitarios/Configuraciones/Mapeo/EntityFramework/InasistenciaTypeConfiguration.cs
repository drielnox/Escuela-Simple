using EscuelaSimple.Aplicacion.Entidades;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EscuelaSimple.Datos.Utilitarios.Configuraciones.Mapeo.EntityFramework
{
    public class InasistenciaTypeConfiguration : EntityTypeConfiguration<Inasistencia>
    {
        public InasistenciaTypeConfiguration()
        {
            ToTable("Inasistencia");

            HasKey<int>(x => x.Identificador);

            Property<int>(x => x.Identificador)
                .HasColumnName("IdInasistencia")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property<int>(x => x.IdPersonal)
                .HasColumnName("IdPersonal")
                .IsRequired();
            Property(x => x.Motivo)
                .HasColumnName("Articulo")
                .IsRequired()
                .HasMaxLength(255);
            Property<DateTime>(x => x.Desde)
                .HasColumnName("Desde")
                .IsRequired();
            Property<DateTime>(x => x.Hasta)
                .HasColumnName("Hasta")
                .IsRequired();
        }
    }
}
