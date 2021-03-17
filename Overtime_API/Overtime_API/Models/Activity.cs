using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Models
{
    public class Activity
    {
        public int ActivityID { get; set; }
        public string ActivityDetails { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AdditionalSalary { get; set; }
    }
}
