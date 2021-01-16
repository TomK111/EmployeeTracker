using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class PositionDetail
    {
        [Required]
        public int PositionId { get; set; }
        [Required]
        public string PositionTitle { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        [Required]
        public bool IsSupervisor { get; set; }
        [Required]
        public bool IsDirector { get; set; }
        [Required]
        public bool IsExecutive { get; set; }
    }
}
