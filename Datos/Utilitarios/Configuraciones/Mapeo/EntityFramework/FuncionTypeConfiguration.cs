using EscuelaSimple.Aplicacion.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Datos.Utilitarios.Configuraciones.Mapeo.EntityFramework
{
    public class FuncionTypeConfiguration : EntityTypeConfiguration<Funcion>
    {
        public FuncionTypeConfiguration()
        {
            ToTable("Funcion");

            HasKey<int>(x => x.Identificador);

            Property<int>(x => x.Identificador)
                .HasColumnName("IdFuncion")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property<DateTime>(x => x.TomaDePosesion)
                .HasColumnName("Toma")
                .IsRequired();
            Property<DateTime>(x => x.CeseDePosesion)
                .HasColumnName("Cese")
                .IsOptional();
            Property(x => x.Observacion)
                .HasColumnName("Observacion")
                .IsOptional()
                .HasMaxLength(255);

            HasRequired<Tarea>(x => x.Tarea)
                .WithRequiredDependent()
                .Map(x => x.MapKey("Tarea"));
            HasRequired<SituacionRevista>(x => x.SituacionDeRevista)
                .WithRequiredDependent()
                .Map(x => x.MapKey("SituacionRevista"));
        }
    }
}
