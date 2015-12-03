using EscuelaSimple.Aplicacion.Entidades;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using System;

namespace EscuelaSimple.Datos.Mapeo.NHibernate
{
    public class FuncionMap : ClassMapping<Funcion>
    {
        public FuncionMap()
        {
            Table("Funcion");

            Id<int>(x => x.Identificador,
                m =>
                {
                    m.Access(Accessor.Property);
                    m.Column("IdFuncion");
                    m.Generator(Generators.Identity);
                });

            ManyToOne<Tarea>(x => x.Tarea,
                m =>
                {
                    m.Column(c =>
                    {
                        c.Name("Tarea");
                    });
                    m.Class(typeof(Tarea));
                    m.Cascade(Cascade.Persist);
                    m.ForeignKey("FK_Funcion_Tarea_1");
                    m.NotNullable(true);
                    m.NotFound(NotFoundMode.Exception);
                });

            Property<DateTime>(x => x.TomaDePosesion,
                m =>
                {
                    m.Column("Toma");
                    m.NotNullable(true);
                    m.Type<DateType>();
                });

            Property<DateTime?>(x => x.CeseDePosesion,
                m =>
                {
                    m.Column("Cese");
                    m.Type<DateType>();
                });

            ManyToOne<SituacionRevista>(x => x.SituacionDeRevista,
                m =>
                {
                    m.Column(c =>
                    {
                        c.Name("SituacionRevista");
                    });
                    m.Class(typeof(SituacionRevista));
                    m.Cascade(Cascade.Persist);
                    m.ForeignKey("FK_Funcion_SituacionRevista_1");
                    m.NotNullable(true);
                    m.NotFound(NotFoundMode.Exception);
                });

            Property<string>(x => x.Observacion,
                m =>
                {
                    m.Column("Observacion");
                    m.Length(255);
                });
        }
    }
}