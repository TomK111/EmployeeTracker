using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class WorkInformationDetail
    {
        public int? EmployeeId { get; set; }
        public int WorkInformationId { get; set; }
        public int PositionId { get; set; }
        public int ContactId { get; set; }
        public decimal Wage { get; set; }
        public DateTimeOffset? LastReview { get; set; }
        public DateTimeOffset? NextReview { get; set; }
        public bool HasBenefits { get; set; }
        public DateTimeOffset? StartOfBenefits { get; set; }
        public string WorkEmail { get; set; }
        public double VacationDaysAccruedTotal { get; set; }
        public double VacationDaysUsedTotal { get; set; }
        public double VacationDaysAccruedForPeriod { get; set; }
        public double VacationDaysUsedForPeriod { get; set; }
        public double PersonalDaysAccruedTotal { get; set; }
        public double PersonalDaysUsedTotal { get; set; }
        public double PersonalDaysAccruedForPeriod { get; set; }
        public double PersonalDaysUsedForPeriod { get; set; }
        public double SickDaysAccruedTotal { get; set; }
        public double SickDaysUsedTotal { get; set; }
        public double SickDaysAccruedForPeriod { get; set; }
        public double SickDaysUsedForPeriod { get; set; }

    }
}
