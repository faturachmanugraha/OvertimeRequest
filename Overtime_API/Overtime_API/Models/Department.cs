using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Models
{
    [Table("TB_M_Department")]
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        public string DepartmentName { get; set; }

        public string NIKManager { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
