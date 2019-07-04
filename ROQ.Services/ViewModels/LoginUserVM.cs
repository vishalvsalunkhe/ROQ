using ROQ.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Services.ViewModels
{
    public class LoginUserVM : BaseEntity
    {
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password can not be empty")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}
