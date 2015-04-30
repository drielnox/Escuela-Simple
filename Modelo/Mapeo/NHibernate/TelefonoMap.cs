using EscuelaSimple.Modelos;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace EscuelaSimple.Datos.Mapeo.NHibernate
{
    public class TelefonoMap : ClassMapping<Telefono>
    {
        public TelefonoMap()
        {
            Lazy(false);

            Table("Telefono");

            Id<uint>(x => x.Identificador, m => 
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
