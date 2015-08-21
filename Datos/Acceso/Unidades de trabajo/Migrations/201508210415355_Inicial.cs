namespace EscuelaSimple.Datos.Acceso.UnidadesDeTrabajo.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargo",
                c => new
                    {
                        IdCargo = c.Int(nullable: false, identity: true),
                        Secuencia = c.Byte(nullable: false),
                        Personal_Identificador = c.Int(),
                    })
                .PrimaryKey(t => t.IdCargo)
                .ForeignKey("dbo.Personal", t => t.Personal_Identificador)
                .Index(t => t.Personal_Identificador);
            
            CreateTable(
                "dbo.Funcion",
                c => new
                    {
                        IdFuncion = c.Int(nullable: false, identity: true),
                        Toma = c.DateTime(nullable: false),
                        Cese = c.DateTime(),
                        Observacion = c.String(maxLength: 255),
                        Cargo_Identificador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFuncion)
                .ForeignKey("dbo.Cargo", t => t.Cargo_Identificador, cascadeDelete: true)
                .Index(t => t.Cargo_Identificador);
            
            CreateTable(
                "dbo.SituacionRevista",
                c => new
                    {
                        IdSituacionRevista = c.Int(nullable: false, identity: true),
                        Abreviacion = c.String(nullable: false, maxLength: 3),
                        Descripcion = c.String(maxLength: 255),
                        SituacionRevista = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSituacionRevista)
                .ForeignKey("dbo.Funcion", t => t.SituacionRevista)
                .Index(t => t.SituacionRevista);
            
            CreateTable(
                "dbo.Tarea",
                c => new
                    {
                        IdTarea = c.Int(nullable: false, identity: true),
                        Abreviacion = c.String(nullable: false, maxLength: 3),
                        Descripcion = c.String(maxLength: 255),
                        Tarea = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTarea)
                .ForeignKey("dbo.Funcion", t => t.Tarea)
                .Index(t => t.Tarea);
            
            CreateTable(
                "dbo.Inasistencia",
                c => new
                    {
                        IdInasistencia = c.Int(nullable: false, identity: true),
                        Articulo = c.String(nullable: false, maxLength: 255),
                        Desde = c.DateTime(nullable: false),
                        Hasta = c.DateTime(nullable: false),
                        Personal_Identificador = c.Int(),
                    })
                .PrimaryKey(t => t.IdInasistencia)
                .ForeignKey("dbo.Personal", t => t.Personal_Identificador)
                .Index(t => t.Personal_Identificador);
            
            CreateTable(
                "dbo.Personal",
                c => new
                    {
                        IdPersonal = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 255),
                        Apellido = c.String(nullable: false, maxLength: 255),
                        DNI = c.Int(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "UK_Personal_DNI_1",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Domicilio = c.String(maxLength: 255),
                        Barrio = c.String(maxLength: 255),
                        Localidad = c.String(maxLength: 255),
                        IngresoDocencia = c.DateTime(),
                        IngresoEstablecimiento = c.DateTime(),
                        Observacion = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.IdPersonal);
            
            CreateTable(
                "dbo.Telefono",
                c => new
                    {
                        IdTelefono = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        Personal_Identificador = c.Int(),
                    })
                .PrimaryKey(t => t.IdTelefono)
                .ForeignKey("dbo.TipoTelefono", t => t.Tipo)
                .ForeignKey("dbo.Personal", t => t.Personal_Identificador)
                .Index(t => t.Tipo)
                .Index(t => t.Personal_Identificador);
            
            CreateTable(
                "dbo.TipoTelefono",
                c => new
                    {
                        IdTipoTelefono = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.IdTipoTelefono);
            
            CreateTable(
                "dbo.Titulo",
                c => new
                    {
                        IdTitulo = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 255),
                        Personal_Identificador = c.Int(),
                    })
                .PrimaryKey(t => t.IdTitulo)
                .ForeignKey("dbo.Personal", t => t.Personal_Identificador)
                .Index(t => t.Personal_Identificador);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Titulo", "Personal_Identificador", "dbo.Personal");
            DropForeignKey("dbo.Telefono", "Personal_Identificador", "dbo.Personal");
            DropForeignKey("dbo.Telefono", "Tipo", "dbo.TipoTelefono");
            DropForeignKey("dbo.Inasistencia", "Personal_Identificador", "dbo.Personal");
            DropForeignKey("dbo.Cargo", "Personal_Identificador", "dbo.Personal");
            DropForeignKey("dbo.Funcion", "Cargo_Identificador", "dbo.Cargo");
            DropForeignKey("dbo.Tarea", "Tarea", "dbo.Funcion");
            DropForeignKey("dbo.SituacionRevista", "SituacionRevista", "dbo.Funcion");
            DropIndex("dbo.Titulo", new[] { "Personal_Identificador" });
            DropIndex("dbo.Telefono", new[] { "Personal_Identificador" });
            DropIndex("dbo.Telefono", new[] { "Tipo" });
            DropIndex("dbo.Inasistencia", new[] { "Personal_Identificador" });
            DropIndex("dbo.Tarea", new[] { "Tarea" });
            DropIndex("dbo.SituacionRevista", new[] { "SituacionRevista" });
            DropIndex("dbo.Funcion", new[] { "Cargo_Identificador" });
            DropIndex("dbo.Cargo", new[] { "Personal_Identificador" });
            DropTable("dbo.Titulo");
            DropTable("dbo.TipoTelefono");
            DropTable("dbo.Telefono");
            DropTable("dbo.Personal",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "DNI",
                        new Dictionary<string, object>
                        {
                            { "UK_Personal_DNI_1", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.Inasistencia");
            DropTable("dbo.Tarea");
            DropTable("dbo.SituacionRevista");
            DropTable("dbo.Funcion");
            DropTable("dbo.Cargo");
        }
    }
}
