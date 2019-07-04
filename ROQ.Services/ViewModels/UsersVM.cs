using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ROQ.Common;

namespace ROQ.Services.ViewModels
{
    public class UsersVM : LoginUserVM
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "User name can not be empty")]
        [Display(Name = "User Name")]

        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }
        [Display(Name = "Mobile")]
        public string MobileNo { get; set; }
        [Display(Name = "Emp Number")]
        public string EmpNo { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Display(Name = "DOB")]
        public DateTime BirthDate { get; set; }
        // [Display(Name = "User Name")]
        public bool IsPasswordReset { get; set; }
    }
}
