using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Data
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Required]
        public string PositionTitle { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        public bool IsSupervisor { get; set; }

        public bool IsDirector { get; set; }

        public bool IsExecutive { get; set; }
    }
}