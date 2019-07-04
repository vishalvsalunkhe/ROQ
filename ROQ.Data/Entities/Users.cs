using ROQ.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Data.Entities
{
    public class Users:BaseEntity
    {
        [Key]
        public long ID { get; set; }
        [Required]
        public string EmpNo { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string EmailID { get; set; }
        public string MobileNo { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }        
        public bool IsPasswordReset { get; set; }
    }
}
