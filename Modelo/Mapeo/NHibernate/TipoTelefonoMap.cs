using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using EscuelaSimple.Entidad;

namespace EscuelaSimple.Modelo.Mapeo.NHibernate
{
    public class TipoTelefonoMap : ClassMapping<TipoTelefono>
    {
        public TipoTelefonoMap()
        {
            Table("TipoTelefono");

            Id<uint>(x => x.Id, m =>
            {
                m.Column("IdTipoTelefono");
                m.Generator(Generators.Identity);
            });
            Property<string>(x => x.Descripcion, m =>
            {
                m.NotNullable(true);
            });
        }
    }
}
