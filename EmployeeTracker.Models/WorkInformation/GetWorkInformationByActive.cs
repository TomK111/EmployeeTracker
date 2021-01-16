using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class GetWorkInformationByActive
    {
        public int WorkInformationId { get; set; }
        public int PositionId { get; set; }
        public int ContactId { get; set; }
        public decimal Wage { get; set; }
        public DateTimeOffset? StartOfBenefits { get; set; }
        public string WorkEmail { get; set; }
    }
}
