using EscuelaSimple.Aplicacion.Entidades;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace EscuelaSimple.Datos.Mapeo.NHibernate
{
    public class TipoTelefonoMap : ClassMapping<TipoTelefono>
    {
        public TipoTelefonoMap()
        {
            Table("TipoTelefono");

            Id<int>(x => x.Identificador,
                m =>
                {
                    m.Column("IdTipoTelefono");
                    m.Generator(Generators.Identity);
                });
            Property<string>(x => x.Descripcion,
                m =>
                {
                    m.NotNullable(true);
                });
        }
    }
}
