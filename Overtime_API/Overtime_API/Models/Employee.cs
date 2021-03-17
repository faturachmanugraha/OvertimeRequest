using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Models
{
    public class Employee
    {
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }
        public int PositionID { get; set; }
        public string NIKManager { get; set; }
        public int ClientID { get; set; }
        public int DepartmentID { get; set; }
        public int OvertimeID { get; set; }
    }
}
