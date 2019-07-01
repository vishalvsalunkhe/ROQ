using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Data.Entities
{
   
    public partial class LogAction
    {
        [Key]
        public long ID { get; set; }
        public string ObjectType { get; set; }
        public string MethodName { get; set; }
        public string RecordType { get; set; }
        public string RecordMessage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
