using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class DepartmentDetail
    {
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        [Required]
        public int EmployeeCount { get; set; }
    }
}
