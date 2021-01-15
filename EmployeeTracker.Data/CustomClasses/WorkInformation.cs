using EmployeeTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Data
{
    public class WorkInformation
    {
        [Key]
        public int WorkInformationId { get; set; }
        public int? EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }
        public int ContactId { get; set; }
        [ForeignKey(nameof(ContactId))]
        public virtual Contact Contact { get; set; }
        public int PositionId { get; set; }
        [ForeignKey(nameof(PositionId))]
        public virtual Position PositionHeld { get; set; }
        public decimal Wage { get; set; }
        public bool HasBenefits { get; set; }
        public DateTimeOffset? StartOfBenefits { get; set; }
        public string WorkEmail { get; set; }
        public DateTimeOffset? LastReview { get; set; }
        public DateTimeOffset? NextReview { get; set; }
        public double VacationDaysAccruedLifetime { get; set; }
        public double VacationDaysUsedLifetime { get; set; }
        public double VacationDaysAccruedForPeriod { get; set; }
        public double VacationDaysUsedForPeriod { get; set; }
        public double PersonalDaysAccruedLifetime { get; set; }
        public double PersonalDaysUsedLifetime { get; set; }
        public double PersonalDaysAccruedForPeriod { get; set; }
        public double PersonalDaysUsedForPeriod { get; set; }
        public double SickDaysAccruedLifetime { get; set; }
        public double SickDaysUsedLifetime { get; set; }
        public double SickDaysAccruedForPeriod { get; set; }
        public double SickDaysUsedForPeriod { get; set; }
    }
}