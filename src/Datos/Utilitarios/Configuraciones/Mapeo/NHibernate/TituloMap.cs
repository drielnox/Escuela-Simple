using EscuelaSimple.Aplicacion.Entidades;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace EscuelaSimple.Datos.Mapeo.NHibernate
{
    public class TituloMap : ClassMapping<Titulo>
    {
        public TituloMap()
        {
            Table("Titulo");

            Id<int>(x => x.Identificador,
                m =>
                {
                    m.Column("IdTitulo");
                    m.Generator(Generators.Identity);
                });

            Property<string>(x => x.Descripcion,
                m =>
                {
                    m.Column("Titulo");
                    m.NotNullable(true);
                    m.Length(255);
                });
        }
    }
}
