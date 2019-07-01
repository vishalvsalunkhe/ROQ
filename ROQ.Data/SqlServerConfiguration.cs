using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HospitalEstimation.Data
{
    public class SqlServerConfiguration : DbConfiguration
    {
        /// <summary>
        /// configure Entity Framework to use the modified HistoryContext, rather than default one. 
        /// This can be done by leveraging code-based configuration features. 
        /// </summary>
        
        public SqlServerConfiguration()
        {
            SetHistoryContext("System.Data.SqlClient", (conn, schema) => new SqlServerHistoryContext(conn, schema));
        }
}
}
