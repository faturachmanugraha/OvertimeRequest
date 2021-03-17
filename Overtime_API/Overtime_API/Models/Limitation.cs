using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Models
{
    [Table("TB_M_Limitation")]
    public class Limitation
    {
        [Key]
        public int LimitationID { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        public string LimitationName { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        public string LimitationValue { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        public int OvertimeApplicationID { get; set; }

        public virtual OvertimeApplication OvertimeApplication { get; set; }
    }
}
