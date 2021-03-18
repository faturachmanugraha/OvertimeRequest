using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Overtime_API.Models
{
    [Table("TB_T_OvertimeApplication")]
    public class OvertimeApplication
    {
        [Key]
        public int OvertimeApplicationID { get; set; }

        [Required(ErrorMessage = "Must be filled")]

        public int OvertimeID { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        public DateTime SubmissionDate { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        public DateTime OvertimeDay { get; set; }

        public int StatusManager { get; set; }
        public int StatusFinance { get; set; }

        [JsonIgnore]
        public virtual ICollection<Activity> Activities { get; set; }
        [JsonIgnore]
        public virtual OvertimeData OvertimeData { get; set; }
    }
}
