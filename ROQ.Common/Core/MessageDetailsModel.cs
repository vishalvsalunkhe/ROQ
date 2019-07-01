using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Common.Core
{

    public class MessageDetailsModel
    {
        public long UserID { get; set; } //QID
        public string Title { get; set; }
        public string MobileNumber { get; set; }
        public string TextBody { get; set; }
        public string SenderCode { get; set; }
        
    }
}
