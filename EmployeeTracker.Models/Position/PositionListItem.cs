using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class PositionListItem
    {
        public int PositionId { get; set; }
        public string PositionTitle { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool IsSupervisor { get; set; }
        public bool IsDirector { get; set; }
        public bool IsExecutive { get; set; }
    }
}
