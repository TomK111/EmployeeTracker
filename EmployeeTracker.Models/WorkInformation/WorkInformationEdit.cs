using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class WorkInformationEdit
    {
        [Required]
        public int? EmployeeId { get; set; }
        [Required]
        public int PositionId { get; set; }
        [Required]
        public decimal Wage { get; set; }
        [Required]
        public string WorkEmail { get; set; }
        [Required]
        public bool HasBenefits { get; set; }
        public DateTimeOffset? StartOfBenefits { get; set; }
        public DateTimeOffset? LastReview { get; set; }

        public DateTimeOffset? NextReview
        {
            get
            {
                if (LastReview.Equals(null))
                {
                    return DateTime.Now.AddDays(30);
                }
                else
                {
                    return LastReview.Value.Date.AddDays(90);
                }
            }
        }
        public double VacationDaysUsedTotal { get; set; }
        public double VacationDaysUsedForPeriod { get; set; }
        public double VacationDaysAccruedForPeriod { get; set; }
        public double VacationDaysAccruedTotal { get; set; }
        public double PersonalDaysUsedTotal { get; set; }
        public double PersonalDaysUsedForPeriod { get; set; }
        public double PersonalDaysAccruedTotal{ get; set; }
        public double PersonalDaysAccruedForPeriod { get; set; }
        public double SickDaysUsedTotal { get; set; }
        public double SickDaysUsedForPeriod { get; set; }
        public double SickDaysAccruedTotal { get; set; }
        public double SickDaysAccruedForPeriod { get; set; }

    }
}
