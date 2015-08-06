using EscuelaSimple.Datos;
using EscuelaSimple.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace EscuelaSimple.Datos
{
    public class EscuelaSimpleContext : DbContext
    {
        public DbSet<Personal> Personal { get; set; }

        static EscuelaSimpleContext()
        {
            Database.SetInitializer<EscuelaSimpleContext>(null);
        }

        public EscuelaSimpleContext() 
            : base("MySQLConx")
        {
            
        }

        public new IDbSet<T> Set<T>()
            where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            IEnumerable<Type> tiposARegistrar = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => !string.IsNullOrWhiteSpace(x.Namespace))
                .Where(x => x.BaseType != null)
                .Where(x => x.BaseType.IsGenericType)
                .Where(x => x.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (Type tipo in tiposARegistrar)
            {
                dynamic confInstancia = Activator.CreateInstance(tipo);
                modelBuilder.Configurations.Add(confInstancia);
            }    

            base.OnModelCreating(modelBuilder);
        }
    }
}
