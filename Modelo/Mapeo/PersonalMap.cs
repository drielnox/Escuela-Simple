using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Olfrad.EscuelaSimple.Entidad;
using NHibernate.Type;

namespace Olfrad.EscuelaSimple.Modelo.Mapeo
{
    public class PersonalMap : ClassMapping<Personal>
    {
        public PersonalMap()
        {
            Table("Personal");

            Id<uint>(x => x.Id, m =>
            {
                m.Column("IdPersonal");
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.Nombre, m =>
            {
                m.Column("Nombre");
                m.NotNullable(true);
            });
            Property<string>(x => x.Apellido, m =>
            {
                m.Column("Apellido");
                m.NotNullable(true);
            });
            Property<uint>(x => x.DNI, m =>
            {
                m.Column("DNI");
                m.UniqueKey("UK_Personal_DNI");
                m.NotNullable(true);
            });
            Property<DateTime>(x => x.FechaNacimiento, m =>
            {
                m.Column("FechaNacimiento");
                m.NotNullable(true);
                m.Type<DateType>();
            });
            Property<string>(x => x.Domicilio, m =>
            {
                m.Column("Domicilio");
            });
            Property<string>(x => x.Localidad, m =>
            {
                m.Column("Localidad");
            });
            Property<DateTime?>(x => x.IngresoDocencia, m =>
            {
                m.Column("IngresoDocencia");
                m.Type<DateType>();
            });
            Property<DateTime?>(x => x.IngresoEstablecimiento, m =>
            {
                m.Column("IngresoEstablecimiento");
                m.Type<DateType>();
            });
            Property<string>(x => x.Titulo, m =>
            {
                m.Column("Titulo");
            });
            Property<string>(x => x.Cargo, m =>
            {
                m.Column("Cargo");
            });
            Property<string>(x => x.SituacionRevista, m =>
            {
                m.Column("SituacionRevista");
            });
            Property<string>(x => x.Observacion, m =>
            {
                m.Column("Observacion");
            });

            Set<Telefono>(x => x.Telefonos,
                cm =>
                {
                    cm.Table("Telefono");
                    cm.Key(k =>
                    {
                        k.Column(c =>
                        {
                            c.Name("IdPersonal");
                            c.NotNullable(true);
                            c.UniqueKey("UK_Telefono_2");
                        });
                        k.ForeignKey("FK_Telefono_Personal_1");
                        k.NotNullable(true);
                    });
                    cm.Cascade(Cascade.All);
                    cm.Lazy(CollectionLazy.Lazy);
                },
                m =>
                {
                    m.OneToMany(x =>
                    {
                        x.Class(typeof(Telefono));
                    });
                });
            Set<Inasistencia>(x => x.Inasistencias,
                cm =>
                {
                    cm.Table("Inasistencia");
                    cm.Key(k =>
                    {
                        k.Column(c =>
                        {
                            c.Name("IdPersonal");
                            c.NotNullable(true);
                        });
                        k.ForeignKey("FK_Inasistencia_Personal_1");
                        k.NotNullable(true);
                    });
                    cm.Cascade(Cascade.All);
                    cm.Lazy(CollectionLazy.Lazy);
                },
                m =>
                {
                    m.OneToMany(x =>
                    {
                        x.Class(typeof(Inasistencia));
                    });
                });
        }
    }
}