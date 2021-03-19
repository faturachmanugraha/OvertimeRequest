using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Models
{
<<<<<<< Updated upstream
    [Table("TB_M_Limitation")]
=======
    [Table("Tb_T_Limitation")]
>>>>>>> Stashed changes
    public class Limitation
    {
        [Key]
        public int LimitationID { get; set; }

<<<<<<< Updated upstream
        [Required(ErrorMessage = "Must be filled")]
        public string LimitationName { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        public string LimitationValue { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        public int OvertimeApplicationID { get; set; }

        public virtual OvertimeApplication OvertimeApplication { get; set; }
=======
        public string LimitationName { get; set; }

        public int Value { get; set; }
>>>>>>> Stashed changes
    }
}
