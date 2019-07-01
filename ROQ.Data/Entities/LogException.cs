using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Data.Entities
{
    
    public partial class LogException
    {
        [Key]
        public long ID { get; set; }
        public string ErrorMsg { get; set; }
        public string Method { get; set; }
        public string StackStrace { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> ErrorDate { get; set; }
        //public string ErrorContext { get; set; }
        //public string Source { get; set; }
    }
}

