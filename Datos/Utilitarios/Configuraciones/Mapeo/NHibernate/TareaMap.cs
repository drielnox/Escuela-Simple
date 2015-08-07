using EscuelaSimple.Aplicacion.Entidades;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Datos.Mapeo.NHibernate
{
    public class TareaMap : ClassMapping<Tarea>
    {
        public TareaMap()
        {
            Table("Tarea");

            Id<int>(x => x.Identificador,
                m =>
                {
                    m.Column("IdTarea");
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
                    m.Length(50);
                });
        }
    }
}
