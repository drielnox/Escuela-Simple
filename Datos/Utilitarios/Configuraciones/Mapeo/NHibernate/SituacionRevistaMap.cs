using EscuelaSimple.Modelos;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Datos.Mapeo.NHibernate
{
    public class SituacionRevistaMap : ClassMapping<SituacionRevista>
    {
        public SituacionRevistaMap()
        {
            Table("SituacionRevista");

            Id<int>(x => x.Identificador,
                m =>
                {
                    m.Column("IdSituacionRevista");
                    m.Generator(Generators.Identity);
                });

            Property<string>(x => x.Abreviacion,
                m =>
                {
                    m.Column("Abreviacion");
                    m.NotNullable(true);
                    m.Length(3);
                });

            Property<string>(x => x.Descripcion,
                m =>
                {
                    m.Column("Descripcion");
                    m.NotNullable(true);
                    m.Length(255);
                });
        }
    }
}
