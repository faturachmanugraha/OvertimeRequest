using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Overtime_API.Models
{
    [Table("TB_M_Employee")]
    public class Employee
    {
        [Key]
        public string NIK { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please input Number Only")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        public int Salary { get; set; }
        public int PositionID { get; set; }



        public int ClientID { get; set; }
        public int DepartmentID { get; set; }


        [JsonIgnore]
        public virtual OvertimeData OvertimeData { get; set; }
        [JsonIgnore]
        public virtual Position Position { get; set; }
        [JsonIgnore]
        public virtual Client Client { get; set; }
        [JsonIgnore]
        public virtual Department Department { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }


    }
}
