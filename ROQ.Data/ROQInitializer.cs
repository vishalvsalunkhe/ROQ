//using Microsoft.AspNet.Identity.EntityFramework;
using ROQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Data
{
    public class ROQInitializer : IDatabaseInitializer<ROQDBContext>
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
                //  "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{0}' AND table_name = '__MigrationHistory'",
                //  "Scouts"));

                //// if MigrationHistory table is not there (which is the case first time we run) - create it
                //if (migrationHistoryTableExists.FirstOrDefault() == 0)
                //{
                //    context.Database.Delete();
                //    context.Database.Create();
                //}
            }
        }

        protected void Seed(ROQDBContext context)
        {
            



        }
    }
}
