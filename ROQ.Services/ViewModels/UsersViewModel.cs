using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ROQ.Services.ViewModels
{
   public class UsersViewModel
    {
        public long ID { get; set; }
        public string QID { get; set; }
        [Required(ErrorMessage ="User name can not be empty")]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password can not be empty")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Boolean IsActive { get; set; }
        public string Domain { get; set; }
        public string ArabicName { get; set; }
        public string EnglistName { get; set; }
        public string EmailID { get; set; }
        public string MobileNo { get; set; }
    }
}
