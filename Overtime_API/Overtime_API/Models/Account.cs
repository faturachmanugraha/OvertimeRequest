using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Models
{
    [Table("TB_M_Account")]
    public class Account
    {
        [Key]
        public string NIK { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Must be filled")]
        public string Password { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
    }
}
