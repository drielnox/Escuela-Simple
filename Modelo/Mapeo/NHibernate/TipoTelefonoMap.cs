using EscuelaSimple.Entidad;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

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
