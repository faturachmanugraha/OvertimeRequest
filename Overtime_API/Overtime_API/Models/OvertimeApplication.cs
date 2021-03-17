using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Models
{
    public class OvertimeApplication
    {
        public int OvertimeApplicationID { get; set; }
        public string NIK { get; set; }
        public int ActivityID { get; set; }
        public DateTime SubmissionDate { get; set; }
        public DateTime OvertimeDay { get; set; }
        public int StatusManager { get; set; }
        public int StatusFinance { get; set; }
    }
}
