using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class EmployeeArchive
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public DateTimeOffset? DateOfTermination { get; set; }
    }
}
