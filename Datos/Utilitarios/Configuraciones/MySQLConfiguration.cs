using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Datos
{
    public class MySQLConfiguration : DbConfiguration
    {
        public MySQLConfiguration()
        {
            SetHistoryContext("MySql.Data.MySqlClient", (conn, schema) => new MySQLHistoryContext(conn, schema));
        }
    }
}
