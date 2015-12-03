using EscuelaSimple.Aplicacion.Entidades;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace EscuelaSimple.Datos.Mapeo.NHibernate
{
    public class CargoMap : ClassMapping<Cargo>
    {
        public CargoMap()
        {
            Table("Cargo");

            Id<int>(x => x.Identificador,
                m =>
                {
                    m.Column("IdCargo");
                    m.Generator(Generators.Identity);
                });

            Property<byte>(x => x.Secuencia,
                m =>
                {
                    m.Column(c =>
                    {
                        c.Name("Secuencia");
                        c.Default(1);
                    });
                    m.NotNullable(true);
                });

            Set<Funcion>(x => x.Funciones,
                cm =>
                {
                    cm.Table("Funcion");
                    cm.Key(k =>
                    {
                        k.Column(c =>
                        {
                            c.Name("IdCargo");
                            c.NotNullable(true);
                        });
                        k.ForeignKey("FK_Cargo_Funcion_1");
                        k.NotNullable(true);
                    });
                    cm.Cascade(Cascade.All);
                },
                m =>
                {
                    m.OneToMany(r =>
                    {
                        r.Class(typeof(Funcion));
                        r.NotFound(NotFoundMode.Exception);
                    });
                });
        }
    }
}