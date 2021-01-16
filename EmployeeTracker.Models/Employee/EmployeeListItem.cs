using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class EmployeeListItem
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string SocialSecurityNumber { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public DateTimeOffset DateOfHire { get; set; }

        public DateTimeOffset? DateOfTermination { get; set; }
    }
}
