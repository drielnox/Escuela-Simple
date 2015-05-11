using EscuelaSimple.Modelos;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using System;

namespace EscuelaSimple.Datos.Mapeo.NHibernate
{
    public class PersonalMap : ClassMapping<Personal>
    {
        public PersonalMap()
        {
            Table("Personal");

            Id<int>(x => x.Identificador,
                m =>
                {
                    m.Access(Accessor.Property);
                    m.Column("IdPersonal");
                    m.Generator(Generators.Identity);
                });

            Property<string>(x => x.Nombre,
                m =>
                {
                    m.Access(Accessor.Property);
                    m.Column("Nombre");
                    m.NotNullable(true);
                });
            Property<string>(x => x.Apellido,
                m =>
                {
                    m.Access(Accessor.Property);
                    m.Column("Apellido");
                    m.NotNullable(true);
                });
            Property<int>(x => x.DNI,
                m =>
                {
                    m.Access(Accessor.Property);
                    m.Column("DNI");
                    m.UniqueKey("UK_Personal_DNI");
                    m.NotNullable(true);
                });
            Property<DateTime>(x => x.FechaNacimiento,
                m =>
                {
                    m.Access(Accessor.Property);
                    m.Column("FechaNacimiento");
                    m.NotNullable(true);
                    m.Type<DateType>();
                });
            Property<string>(x => x.Domicilio,
                m =>
                {
                    m.Access(Accessor.Property);
                    m.Column("Domicilio");
                    m.NotNullable(false);
                });
            Property<string>(x => x.Barrio,
                m =>
                {
                    m.Access(Accessor.Property);
                    m.Column("Barrio");
                    m.NotNullable(false);
                });
            Property<string>(x => x.Localidad,
                m =>
                {
                    m.Access(Accessor.Property);
                    m.Column("Localidad");
                    m.NotNullable(false);
                });
            Property<DateTime?>(x => x.IngresoDocencia,
                m =>
                {
                    m.Access(Accessor.Property);
                    m.Column("IngresoDocencia");
                    m.NotNullable(false);
                    m.Type<DateType>();
                });
            Property<DateTime?>(x => x.IngresoEstablecimiento,
                m =>
                {
                    m.Access(Accessor.Property);
                    m.Column("IngresoEstablecimiento");
                    m.NotNullable(false);
                    m.Type<DateType>();
                });

            Set<Titulo>(x => x.Titulos,
                cm =>
                {
                    cm.Access(Accessor.Property);
                    cm.Table("Titulo");
                    cm.Key(k =>
                    {
                        k.Column(c =>
                        {
                            c.Name("IdPersonal");
                            c.NotNullable(true);
                        });
                        k.ForeignKey("FK_Titulo_Personal_1");
                    });
                    cm.Cascade(Cascade.All);
                },
                m =>
                {
                    m.OneToMany(r =>
                    {
                        r.Class(typeof(Titulo));
                        r.NotFound(NotFoundMode.Exception);
                    });
                });

            Set<Cargo>(x => x.Cargos,
                cm =>
                {
                    cm.Access(Accessor.Property);
                    cm.Table("Cargo");
                    cm.Key(k =>
                    {
                        k.Column(c =>
                        {
                            c.Name("IdPersonal");
                            c.NotNullable(true);
                        });
                        k.ForeignKey("FK_Personal_Cargo_1");
                    });
                    cm.Cascade(Cascade.All);
                },
                m =>
                {
                    m.OneToMany(r =>
                    {
                        r.Class(typeof(Cargo));
                        r.NotFound(NotFoundMode.Exception);
                    });
                });

            Property<string>(x => x.Observacion, m =>
            {
                m.Access(Accessor.Property);
                m.Column("Observacion");
                m.NotNullable(false);
            });

            Set<Telefono>(x => x.Telefonos,
                cm =>
                {
                    cm.Access(Accessor.Property);
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
                },
                m =>
                {
                    m.OneToMany(x =>
                    {
                        x.Class(typeof(Telefono));
                        x.NotFound(NotFoundMode.Exception);
                    });
                });
            Set<Inasistencia>(x => x.Inasistencias,
                cm =>
                {
                    cm.Access(Accessor.Property);
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
                },
                m =>
                {
                    m.OneToMany(x =>
                    {
                        x.Class(typeof(Inasistencia));
                        x.NotFound(NotFoundMode.Exception);
                    });
                });
        }
    }
}