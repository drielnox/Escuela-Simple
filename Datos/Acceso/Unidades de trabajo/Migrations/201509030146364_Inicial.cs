namespace EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Migrations
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
                        IdPersonal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCargo)
                .ForeignKey("dbo.Personal", t => t.IdPersonal, cascadeDelete: true)
                .Index(t => t.IdPersonal);
            
            CreateTable(
                "dbo.Funcion",
                c => new
                    {
                        IdFuncion = c.Int(nullable: false, identity: true),
                        Toma = c.DateTime(nullable: false),
                        Cese = c.DateTime(),
                        Observacion = c.String(maxLength: 255),
                        IdCargo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFuncion)
                .ForeignKey("dbo.SituacionRevista", t => t.IdFuncion)
                .ForeignKey("dbo.Tarea", t => t.IdFuncion)
                .ForeignKey("dbo.Cargo", t => t.IdCargo, cascadeDelete: true)
                .Index(t => t.IdFuncion)
                .Index(t => t.IdCargo);
            
            CreateTable(
                "dbo.SituacionRevista",
                c => new
                    {
                        IdSituacionRevista = c.Int(nullable: false, identity: true),
                        Abreviacion = c.String(nullable: false, maxLength: 3),
                        Descripcion = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.IdSituacionRevista);
            
            CreateTable(
                "dbo.Tarea",
                c => new
                    {
                        IdTarea = c.Int(nullable: false, identity: true),
                        Abreviacion = c.String(nullable: false, maxLength: 3),
                        Descripcion = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.IdTarea);
            
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
                "dbo.Inasistencia",
                c => new
                    {
                        IdInasistencia = c.Int(nullable: false, identity: true),
                        Articulo = c.String(nullable: false, maxLength: 255),
                        Desde = c.DateTime(nullable: false),
                        Hasta = c.DateTime(nullable: false),
                        IdPersonal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdInasistencia)
                .ForeignKey("dbo.Personal", t => t.IdPersonal, cascadeDelete: true)
                .Index(t => t.IdPersonal);
            
            CreateTable(
                "dbo.Telefono",
                c => new
                    {
                        IdTelefono = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        IdPersonal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTelefono)
                .ForeignKey("dbo.TipoTelefono", t => t.IdTelefono)
                .ForeignKey("dbo.Personal", t => t.IdPersonal, cascadeDelete: true)
                .Index(t => t.IdTelefono)
                .Index(t => t.IdPersonal);
            
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
                        IdPersonal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTitulo)
                .ForeignKey("dbo.Personal", t => t.IdPersonal, cascadeDelete: true)
                .Index(t => t.IdPersonal);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Titulo", "IdPersonal", "dbo.Personal");
            DropForeignKey("dbo.Telefono", "IdPersonal", "dbo.Personal");
            DropForeignKey("dbo.Telefono", "IdTelefono", "dbo.TipoTelefono");
            DropForeignKey("dbo.Inasistencia", "IdPersonal", "dbo.Personal");
            DropForeignKey("dbo.Cargo", "IdPersonal", "dbo.Personal");
            DropForeignKey("dbo.Funcion", "IdCargo", "dbo.Cargo");
            DropForeignKey("dbo.Funcion", "IdFuncion", "dbo.Tarea");
            DropForeignKey("dbo.Funcion", "IdFuncion", "dbo.SituacionRevista");
            DropIndex("dbo.Titulo", new[] { "IdPersonal" });
            DropIndex("dbo.Telefono", new[] { "IdPersonal" });
            DropIndex("dbo.Telefono", new[] { "IdTelefono" });
            DropIndex("dbo.Inasistencia", new[] { "IdPersonal" });
            DropIndex("dbo.Funcion", new[] { "IdCargo" });
            DropIndex("dbo.Funcion", new[] { "IdFuncion" });
            DropIndex("dbo.Cargo", new[] { "IdPersonal" });
            DropTable("dbo.Titulo");
            DropTable("dbo.TipoTelefono");
            DropTable("dbo.Telefono");
            DropTable("dbo.Inasistencia");
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
            DropTable("dbo.Tarea");
            DropTable("dbo.SituacionRevista");
            DropTable("dbo.Funcion");
            DropTable("dbo.Cargo");
        }
    }
}
