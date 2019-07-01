using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Data
{
    public class SqlServerInitializer : IDatabaseInitializer<ROQDBContext>
    {
        public void InitializeDatabase(ROQDBContext context)
        {
            if (!context.Database.Exists())
            {
                // if database did not exist before - create it
                context.Database.Create();
            }
            else
            {
                // query to check if MigrationHistory table is present in the database 
                //var migrationHistoryTableExists = ((IObjectContextAdapter)context).ObjectContext.ExecuteStoreQuery<int>(
                //string.Format(
                //  "select * from sys.tables where name = '{0}'",
                //  "__MigrationHistory"));

                //// if MigrationHistory table is not there (which is the case first time we run) - create it
                //if (migrationHistoryTableExists.FirstOrDefault() == 0)
                //{
                //    context.Database.Delete();
                //    context.Database.Create();
                //}
            }
        }
    }
}
