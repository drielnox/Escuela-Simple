using EscuelaSimple.Aplicacion.Entidades;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace EscuelaSimple.Datos.Mapeo.NHibernate
{
    public class TelefonoMap : ClassMapping<Telefono>
    {
        public TelefonoMap()
        {
            Table("Telefono");

            Id<int>(x => x.Identificador,
                m =>
                {
                    m.Access(Accessor.Property);
                    m.Column("IdTelefono");
                    m.Generator(Generators.Identity);
                });

            Property<int>(x => x.Numero,
                m =>
                {
                    m.Column("Numero");
                    m.UniqueKey("UK_Telefono_2");
                    m.NotNullable(true);
                });

            ManyToOne<TipoTelefono>(x => x.Tipo,
                m =>
                {
                    m.Column(c =>
                    {
                        c.Name("Tipo");
                        c.NotNullable(true);
                    });
                    m.ForeignKey("FK_Telefono_TipoTelefono_1");
                    m.UniqueKey("UK_Telefono_2");
                    m.NotNullable(true);
                    m.Cascade(Cascade.Persist);
                });
        }
    }
}
