using EscuelaSimple.Aplicacion.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EscuelaSimple.Datos.Utilitarios.Configuraciones.Mapeo.EntityFramework
{
    public class CargoTypeConfiguration : EntityTypeConfiguration<Cargo>
    {
        public CargoTypeConfiguration()
        {
            ToTable("Cargo");

            HasKey<int>(x => x.Identificador);

            Property<int>(x => x.Identificador)
                .HasColumnName("IdCargo")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property<int>(x => x.IdPersonal)
                .HasColumnName("IdPersonal")
                .IsRequired();
            Property<byte>(x => x.Secuencia)
                .HasColumnName("Secuencia")
                .IsRequired();

            HasMany<Funcion>(x => x.Funciones)
                .WithRequired(x => x.CargoAsociado)
                .HasForeignKey<int>(x => x.IdCargo);
        }
    }
}
