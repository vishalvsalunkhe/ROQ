using ROQ.Common;
using ROQ.Data;
using ROQ.Data.Entities;
using ROQ.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Repository.Repositories
{
   
    public class LogActionRepository : RepositoryBase<LogAction, ROQDBContext>, ILogActionRepository
    {
        public LogActionRepository(ROQDBContext context) : base(context)
        {

        }
    }
}
