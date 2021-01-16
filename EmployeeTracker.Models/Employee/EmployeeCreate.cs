using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class EmployeeCreate
    {
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string SocialSecurityNumber { get; set; }
        [Required]
        public DateTimeOffset DateOfBirth { get; set; }
        [Required]
        public DateTimeOffset DateOfHire { get; set; }
        public DateTimeOffset? DateOfTermination { get; set; }
    }
}
