using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using EscuelaSimple.Entidad;

namespace EscuelaSimple.Modelo.Mapeo.NHibernate
{
    public class TelefonoMap : ClassMapping<Telefono>
    {
        public TelefonoMap()
        {
            Table("Telefono");

            Id<uint>(x => x.Id, m => 
            {
                m.Column("IdTelefono");
                m.Generator(Generators.Identity);
            });
            ManyToOne<TipoTelefono>(x => x.Tipo, m =>
            {
                m.Column("Tipo");
                m.ForeignKey("FK_Telefono_TipoTelefono_1");
                m.UniqueKey("UK_Telefono_2");
                m.NotNullable(true);
                m.Cascade(Cascade.All);
            });
            Property<uint>(x => x.Numero, m =>
            {
                m.Column("Numero");
                m.UniqueKey("UK_Telefono_2");
                m.NotNullable(true);
            });
        }
    }
}
