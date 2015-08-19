using EscuelaSimple.Aplicacion.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Datos.Utilitarios.Configuraciones.Mapeo.EntityFramework
{
    public class TareaTypeConfiguration : EntityTypeConfiguration<Tarea>
    {
        public TareaTypeConfiguration()
        {
            ToTable("Tarea");

            HasKey<int>(x => x.Identificador);

            Property<int>(x => x.Identificador)
                .HasColumnName("IdTarea")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Abreviacion)
                .HasColumnName("Abreviacion")
                .IsRequired()
                .HasMaxLength(3);
            Property(x => x.Descripcion)
                .HasColumnName("Descripcion")
                .IsOptional()
                .HasMaxLength(255);
        }
    }
}
