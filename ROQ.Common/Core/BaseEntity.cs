using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Common
{
    public class BaseEntity
    {
        public Boolean IsActive { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }

        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
