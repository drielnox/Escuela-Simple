using EscuelaSimple.Entidad;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using System;

namespace EscuelaSimple.Modelo.Mapeo.NHibernate
{
    public class InasistenciaMap : ClassMapping<Inasistencia>
    {
        public InasistenciaMap()
        {
            Table("Inasistencia");

            Id<uint>(x => x.Id, m => 
            {
                m.Column("IdInasistencia");
                m.Generator(Generators.Identity);
            });
            Property<string>(x => x.Motivo, m =>
            {
                m.Column("Articulo");
                m.NotNullable(true);
            });
            Property<DateTime>(x => x.Desde, m =>
            {
                m.Column("Desde");
                m.NotNullable(true);
                m.Type<DateType>();
            });
            Property<DateTime>(x => x.Hasta, m =>
            {
                m.Column("Hasta");
                m.NotNullable(true);
                m.Type<DateType>();
            });
        }
    }
}
