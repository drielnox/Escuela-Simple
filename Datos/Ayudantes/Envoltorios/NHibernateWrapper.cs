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
        public static ISession SesionActual { get; protected set; }
        protected static Configuration Configuration { get; set; }
        protected static ISessionFactory SessionFactory { get; set; }

        static NHibernateWrapper()
        {
            log4net.Config.XmlConfigurator.Configure();
            Configuration = ConfigurarNHibernate();
            HbmMapping mapping = GetMappings();
            Configuration.AddDeserializedMapping(mapping, "EscuelaSimple");
            SessionFactory = Configuration.BuildSessionFactory();
            SesionActual = SessionFactory.OpenSession();
        }

        public static void Close()
        {
            if (SesionActual != null && SesionActual.IsOpen)
            {
                SesionActual.Close();
            }
        }

        protected static Configuration ConfigurarNHibernate()
        {
            Configuration configuration = new Configuration();
            configuration.SessionFactoryName("NHEscuelaSimple");

            configuration.DataBaseIntegration(db =>
            {
                db.ConnectionProvider<DriverConnectionProvider>();
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.IsolationLevel = IsolationLevel.ReadCommitted;
                db.ConnectionString = Properties.Settings.Default.LocalDB;
                db.PrepareCommands = true;
                db.Timeout = 5;
                db.ConnectionReleaseMode = ConnectionReleaseMode.OnClose;
                db.SchemaAction = SchemaAutoAction.Update;

                // Comentado por que log4net ya hace esta tarea.
                //db.LogFormattedSql = true;
                //db.LogSqlInConsole = true;
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
                typeof(CargoMap),
                typeof(FuncionMap),
                typeof(TareaMap),
                typeof(SituacionRevistaMap),
                typeof(TituloMap)
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

        public static void InsertBaseData()
        {
            using (ISession sesion = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = sesion.BeginTransaction())
                {
                    var tipoTel1 = new TipoTelefono() { Descripcion = "Linea" };
                    var tipoTel2 = new TipoTelefono() { Descripcion = "Celular" };
                    var tipoTel3 = new TipoTelefono() { Descripcion = "Fax" };
                }
            }
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

                    var tar1 = new Tarea() { Abreviacion = "MG", Descripcion = "Maestra de Grado" };
                    var tar2 = new Tarea() { Abreviacion = "DIR", Descripcion = "Director" };
                    var tar3 = new Tarea() { Abreviacion = "VD", Descripcion = "Vicedirector" };
                    var tar4 = new Tarea() { Abreviacion = "SEC", Descripcion = "Secreatario" };

                    var sit1 = new SituacionRevista() { Abreviacion = "TIT", Descripcion = "Titular" };
                    var sit2 = new SituacionRevista() { Abreviacion = "SUP", Descripcion = "Suplente" };
                    var sit3 = new SituacionRevista() { Abreviacion = "AUX", Descripcion = "Auxiliar" };
                    var sit4 = new SituacionRevista() { Abreviacion = "TII", Descripcion = "Titular Interino" };
                    var sit5 = new SituacionRevista() { Abreviacion = "TIP", Descripcion = "Titular Provisional" };
                    var sit6 = new SituacionRevista() { Abreviacion = "TMP", Descripcion = "Temporario" };

                    var fnc1 = new Funcion() { Tarea = tar1, TomaDePosesion = new DateTime(2001, 5, 13), SituacionDeRevista = sit1 };
                    var fnc2 = new Funcion() { Tarea = tar1, TomaDePosesion = new DateTime(2004, 8, 5), SituacionDeRevista = sit2 };
                    var fnc3 = new Funcion() { Tarea = tar3, TomaDePosesion = new DateTime(1998, 11, 1), SituacionDeRevista = sit1 };

                    var tit1 = new Titulo() { Descripcion = "Tecnico Superior en Electromecanica" };
                    var tit2 = new Titulo() { Descripcion = "Bachiller en Bienes y Servicios" };
                    var tit3 = new Titulo() { Descripcion = "Licenciatura en Kinesiologia" };
                    var tit4 = new Titulo() { Descripcion = "Ingeniero Hidraulico" };

                    var car1 = new Cargo();
                    car1.AgregarFuncion(fnc1);
                    car1.AgregarFuncion(fnc2);
                    var car2 = new Cargo();
                    car2.AgregarFuncion(fnc3);

                    var pers1 = new Personal() { Nombre = "Pablo", Apellido = "Leiros", DNI = 34624421, FechaNacimiento = new DateTime(1989, 6, 30) };
                    pers1.AgregarTelefono(tel1);
                    pers1.AgregarTelefono(tel2);
                    pers1.AgregarInasistencia(inas1);
                    pers1.AgregarCargo(car1);
                    pers1.AgregarCargo(car2);
                    pers1.AgregarTitulo(tit1);
                    pers1.AgregarTitulo(tit3);
                    var pers2 = new Personal() { Nombre = "Jesica", Apellido = "Genovese", DNI = 34517157, FechaNacimiento = new DateTime(1989, 5, 4) };
                    pers2.AgregarTelefono(tel3);
                    pers2.AgregarInasistencia(inas2);
                    pers2.AgregarInasistencia(inas3);
                    pers2.AgregarTitulo(tit2);
                    pers2.AgregarTitulo(tit4);

                    foreach (object item in new object[] { pers1, pers2 })
                    {
                        session.Save(item);
                    }

                    transaction.Commit();
                }
            }
        }
    }
}
