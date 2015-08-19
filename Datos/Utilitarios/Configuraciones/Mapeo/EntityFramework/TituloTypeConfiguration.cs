using EscuelaSimple.Aplicacion.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

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
            Property(x => x.Descripcion)
                .HasColumnName("Titulo")
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
