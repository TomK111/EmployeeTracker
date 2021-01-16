using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class GetAllLeadership
    {
        public int WorkInformationId { get; set; }
        public int PositionId { get; set; }
        public int ContactId { get; set; }
        public int? EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PositionTitle { get; set; }
        public string DepartmentName { get; set; }
        public decimal Wage { get; set; }
        public string WorkEmail { get; set; }
    }
}
