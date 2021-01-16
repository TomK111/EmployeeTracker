using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class DepartmentCreate
    {
        [Required]
        public string DepartmentName { get; set; }
        public int EmployeeCount { get; set; }
    }
}
