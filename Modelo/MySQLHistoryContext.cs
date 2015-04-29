using EscuelaSimple.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Migrations.History;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Datos
{
    public class MySQLHistoryContext : HistoryContext
    {
        public MySQLHistoryContext(DbConnection existingConnection, string defaultSchema)
            : base(existingConnection, defaultSchema)
        {

        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HistoryRow>().Property(h => h.MigrationId).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<HistoryRow>().Property(h => h.ContextKey).HasMaxLength(200).IsRequired();
        }
    }
}
