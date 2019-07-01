using ROQ.Common.Interface;
using ROQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Services.Interfaces
{
   
    public interface ILogActionService : IService<LogAction>
    {
        long InsertUpdate(LogAction logAction);
    }
}
