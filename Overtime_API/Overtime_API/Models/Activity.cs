using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Overtime_API.Models
{
    [Table("TB_T_Activity")]
    public class Activity
    {
        [Key]
        public int ActivityID { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        public string ActivityDetails { get; set; }

        [Required(ErrorMessage = "Must be filled"), DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{HH:mm:ss}")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Must be filled"), DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{HH:mm:ss}")]
        public DateTime EndTime { get; set; }

        public int AdditionalSalary { get; set; }

        public int OvertimeApplicationID { get; set; }

        [JsonIgnore]
        public virtual OvertimeApplication OvertimeApplication { get; set; }
    }
}
