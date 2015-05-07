using EscuelaSimple.Modelos;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                    cm.Cascade(Cascade.DeleteOrphans);
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