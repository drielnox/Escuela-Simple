using EscuelaSimple.Aplicacion.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EscuelaSimple.Datos.Utilitarios.Configuraciones.Mapeo.EntityFramework
{
    public class TituloTypeConfiguration : EntityTypeConfiguration<Titulo>
    {
        public TituloTypeConfiguration()
        {
            ToTable("Titulo");

            HasKey<int>(x => x.Identificador);

            Property<int>(x => x.Identificador)
                .HasColumnName("IdTitulo")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property<int>(x => x.IdPersonal)
                .HasColumnName("IdPersonal")
                .IsRequired();
            Property(x => x.Descripcion)
                .HasColumnName("Titulo")
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
