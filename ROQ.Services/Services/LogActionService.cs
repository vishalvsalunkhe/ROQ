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

    public class LogActionService : ServiceBase<LogAction>, ILogActionService
    {
        ILogActionRepository _ILogActionRepository;

        public LogActionService(ILogActionRepository iLogActionRepository) : base(iLogActionRepository)
        {
            _ILogActionRepository = iLogActionRepository;
        }


        public long InsertUpdate(LogAction logAction)
        {
            long Id = 0;
            try
            {
                _ILogActionRepository.Add(logAction);
                _ILogActionRepository.Save();

            }
            catch (Exception )
            {
                throw;
            }
            return Id;
        }
    }
}
