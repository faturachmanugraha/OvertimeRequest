using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.ViewModels
{
    public class ChangePasswordVM
    {
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [CompareAttribute("NewPassword", ErrorMessage = "Password doesn't not match")]
        public string ConfirmPassword { get; set; }
    }
}
