using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Models
{
    [Table("TB_T_OvertimeData")]
    public class OvertimeData
    {
        [Key]
        public int OvertimeID { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        public string NIK { get; set; }




        public virtual ICollection<OvertimeApplication> OvertimeApplication { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
