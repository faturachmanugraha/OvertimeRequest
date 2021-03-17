using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Models
{
    public class Limitation
    {
        public int LimitationID { get; set; }
        public string LimitationName { get; set; }
        public string LimitationValue { get; set; }
        public int OvertimeApplicationID { get; set; }
    }
}
