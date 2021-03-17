using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Models
{
    [Table("TB_M_Client")]
    public class Client
    {
        [Key]
        public int ClientID { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Must be filled")]
        public string Location { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
