using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Overtime_API.Models
{
    [Table("TB_T_AccountRole")]
    public class AccountRole
    {
        public string AccountNIK { get; set; }
        public int RoleID { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }
        
    }
}
