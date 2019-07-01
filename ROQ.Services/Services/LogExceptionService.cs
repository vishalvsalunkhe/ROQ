using ROQ.Common.Core;
using ROQ.Data.Entities;
using ROQ.Repository.Interfaces;
using ROQ.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Services.Services
{
   
    public class LogExceptionService : ServiceBase<LogException>, ILogExceptionService
    {
        ILogExceptionRepository _ILogExceptionRepository;

        public LogExceptionService(ILogExceptionRepository iLogExceptionRepository) : base(iLogExceptionRepository)
        {
            _ILogExceptionRepository = iLogExceptionRepository;
        }
    }
}
