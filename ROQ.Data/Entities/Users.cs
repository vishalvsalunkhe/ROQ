using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Data.Entities
{
    public class Users
    {
        [Key]
        public long ID { get; set; }
        public string QID { get; set; }
        public string UserName { get; set; }
        public Boolean IsActive { get; set; }
        public string Domain { get; set; }
        public string ArabicName { get; set; }
        public string EnglistName { get; set; }
        public string EmailID { get; set; }
        public string MobileNo { get; set; }
    }
}
