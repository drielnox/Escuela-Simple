using EscuelaSimple.Modelos;
using EscuelaSimple.Datos.Mapeo.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Data;

namespace EscuelaSimple.Datos
{
    public class NHibernateWrapper
    {
        public static ISession CurrentSession { get; protected set; }
        protected static Configuration Configuration { get; set; }
        protected static ISessionFactory SessionFactory { get; set; }

        static NHibernateWrapper()
        {
            Configuration = ConfigurarNHibernate();
            HbmMapping mapping = GetMappings();
            Configuration.AddDeserializedMapping(mapping, "EscuelaSimple");
            SessionFactory = Configuration.BuildSessionFactory();
            CurrentSession = SessionFactory.OpenSession();
        }

        public static void Close()
        {
            if (CurrentSession != null && CurrentSession.IsOpen)
            {
                CurrentSession.Close();
            }
        }

        protected static Configuration ConfigurarNHibernate()
        {
            Configuration configuration = new Configuration();
            configuration.SessionFactoryName("NHEscuelaSimple");

            configuration.DataBaseIntegration(db =>
            {
                db.ConnectionProvider<DriverConnectionProvider>();
                db.Dialect<MySQL55InnoDBDialect>();
                db.Driver<MySqlDataDriver>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.IsolationLevel = IsolationLevel.ReadCommitted;
                db.ConnectionString = "Server=localhost;Database=escuelasimple;Uid=escuela;Pwd=escuela;";
                db.PrepareCommands = true;
                db.Timeout = 10;
                db.ConnectionReleaseMode = ConnectionReleaseMode.OnClose;
                db.SchemaAction = SchemaAutoAction.Update;
                
                db.LogFormattedSql = true;
                db.LogSqlInConsole = true;
            });

            return configuration;
        }

        protected static HbmMapping GetMappings()
        {
            ConventionModelMapper mapper = new ConventionModelMapper();
            mapper.AddMappings(new[] 
            {
                typeof(PersonalMap),
                typeof(TelefonoMap),
                typeof(InasistenciaMap),
                typeof(TipoTelefonoMap),
            });

            HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            return mapping;
        }

        public static bool ValidateSchema()
        {
            try
            {
                SchemaValidator schemaValidator = new SchemaValidator(Configuration);
                schemaValidator.Validate();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CreateDabataseSchema()
        {
            new SchemaExport(Configuration).Drop(true, true);
            new SchemaExport(Configuration).Create(true, true);
        }

        public static void InsertTestData()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var tipoTel1 = new TipoTelefono() { Descripcion = "Linea" };
                    var tipoTel2 = new TipoTelefono() { Descripcion = "Celular" };
                    var tipoTel3 = new TipoTelefono() { Descripcion = "Fax" };

                    var tel1 = new Telefono() { Numero = 42555896, Tipo = tipoTel1 };
                    var tel2 = new Telefono() { Numero = 1565987926, Tipo = tipoTel2 };
                    var tel3 = new Telefono() { Numero = 48956257, Tipo = tipoTel3 };

                    var inas1 = new Inasistencia() { Motivo = "M43", Desde = new DateTime(2001, 12, 25), Hasta = new DateTime(2001, 12, 30) };
                    var inas2 = new Inasistencia() { Motivo = "A1", Desde = new DateTime(2002, 6, 13), Hasta = new DateTime(2003, 4, 2) };
                    var inas3 = new Inasistencia() { Motivo = "F5", Desde = new DateTime(2010, 7, 21), Hasta = new DateTime(2001, 9, 8) };

                    var pers1 = new Personal() { Nombre = "Pablo", Apellido = "Leiros", DNI = 34624421, FechaNacimiento = new DateTime(1989, 6, 30) };
                    pers1.AgregarTelefono(tel1);
                    pers1.AgregarTelefono(tel2);
                    pers1.AgregarInasistencia(inas1);
                    var pers2 = new Personal() { Nombre = "Jesica", Apellido = "Genovese", DNI = 34517157, FechaNacimiento = new DateTime(1989, 5, 4) };
                    pers2.AgregarTelefono(tel3);
                    pers2.AgregarInasistencia(inas2);
                    pers2.AgregarInasistencia(inas3);

                    Personal pers3 = new Personal()
                    {
                        Apellido = "Giorgetta",
                        Cargo = "MG",
                        DNI = 13456789,
                        Domicilio = "25 de Mayo de 1810 787",
                        FechaNacimiento = new DateTime(1961, 7, 21),
                        IngresoDocencia = new DateTime(1987, 2, 17),
                        IngresoEstablecimiento = new DateTime(1989, 5, 25),
                        Localidad = "Florencio Varela",
                        Nombre = "Mercedes",
                        Observacion = "Esta es una observacion.",
                        SituacionRevista = "Una situacion de revista",
                        Titulo = "Titulo de grado",
                    };
                    pers3.AgregarTelefono(new Telefono()
                    {
                        Numero = 42555896,
                        Tipo = tipoTel1,
                    });
                    pers3.AgregarTelefono(new Telefono()
                    {
                        Numero = 1598875465,
                        Tipo = tipoTel2,
                    });
                    pers3.AgregarInasistencia(new Inasistencia()
                    {
                        Motivo = "A1",
                        Desde = new DateTime(2011, 2, 3),
                        Hasta = new DateTime(2011, 2, 15),
                    });
                    pers3.AgregarInasistencia(new Inasistencia()
                    {
                        Motivo = "A2",
                        Desde = new DateTime(2012, 4, 6),
                        Hasta = new DateTime(2012, 4, 12),
                    });


                    foreach (object item in new object[] { pers1, pers2, pers3 })
                    {
                        session.SaveOrUpdate(item);
                    }

                    transaction.Commit();
                }
            }
        }
    }
}
