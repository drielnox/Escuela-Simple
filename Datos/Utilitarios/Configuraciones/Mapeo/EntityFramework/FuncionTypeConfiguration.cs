using EscuelaSimple.Aplicacion.Entidades;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

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
            Property<int>(x => x.IdCargo)
                .HasColumnName("IdCargo")
                .IsRequired();
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
                .WithRequiredDependent(x => x.FuncionAsociada);
            HasRequired<SituacionRevista>(x => x.SituacionDeRevista)
                .WithRequiredDependent(x => x.FuncionAsociada);
        }
    }
}
