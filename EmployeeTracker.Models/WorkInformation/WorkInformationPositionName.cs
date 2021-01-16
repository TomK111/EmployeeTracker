using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class WorkInformationPositionName
    {
        public string PositionTitle { get; set; }
        public bool IsSupervisor { get; set; }
        public bool IsDirector { get; set; }
        public bool IsExecutive { get; set; }
    }
}
