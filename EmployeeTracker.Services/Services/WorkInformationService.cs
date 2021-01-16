using EmployeeTracker.Data;
using EmployeeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Services
{
    public class WorkInformationService
    {
        public bool CreateWorkInformation(WorkInformationCreate model)
        {
            EmployeeService ps = new EmployeeService();
            int model1 = (int)model.EmployeeId;
            EmployeeListItem varA = ps.GetEmployeeById(model1);
            var entity = new WorkInformation()
            {
                EmployeeId = model.EmployeeId,
                PositionId = model.PositionId,
                ContactId = model.ContactId,
                Wage = model.Wage,
                WorkEmail = model.WorkEmail,
                LastReview = model.LastReview,
                StartOfBenefits = varA.DateOfHire.AddDays(90),
                VacationDaysAccruedTotal = model.VacationDaysAccruedTotal,
                VacationDaysUsedTotal = model.VacationDaysUsedTotal,
                VacationDaysAccruedForPeriod = model.VacationDaysAccruedForPeriod,
                VacationDaysUsedForPeriod = model.VacationDaysUsedForPeriod,
                PersonalDaysAccruedTotal = model.PersonalDaysAccruedTotal,
                PersonalDaysUsedTotal = model.PersonalDaysUsedTotal,
                PersonalDaysAccruedForPeriod = model.PersonalDaysAccruedForPeriod,
                PersonalDaysUsedForPeriod = model.PersonalDaysUsedForPeriod,
                SickDaysAccruedTotal = model.SickDaysAccruedTotal,
                SickDaysUsedTotal = model.SickDaysUsedTotal,
                SickDaysAccruedForPeriod = model.SickDaysAccruedForPeriod,

                SickDaysUsedForPeriod = model.SickDaysUsedForPeriod



            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.WorkInformationDbSet.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool EditWorkInformation(WorkInformationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.WorkInformationDbSet.Single(e => e.EmployeeId == model.EmployeeId);
                entity.PositionId = model.PositionId;
                entity.Wage = model.Wage;
                entity.WorkEmail = model.WorkEmail;
                entity.LastReview = model.LastReview;
                entity.NextReview = model.NextReview;
                entity.HasBenefits = model.HasBenefits;
                entity.StartOfBenefits = model.StartOfBenefits;
                entity.VacationDaysUsedTotal += model.VacationDaysUsedTotal;
                entity.VacationDaysUsedForPeriod += model.VacationDaysUsedForPeriod;
                entity.PersonalDaysUsedTotal += model.PersonalDaysUsedTotal;
                entity.PersonalDaysUsedForPeriod += model.PersonalDaysUsedForPeriod;
                entity.SickDaysUsedTotal += model.SickDaysUsedTotal;
                entity.SickDaysUsedForPeriod += model.SickDaysUsedForPeriod;
                entity.VacationDaysAccruedTotal += model.VacationDaysAccruedTotal;
                entity.VacationDaysAccruedForPeriod += model.VacationDaysAccruedForPeriod;
                entity.PersonalDaysAccruedTotal += model.PersonalDaysAccruedTotal;
                entity.PersonalDaysAccruedForPeriod += model.PersonalDaysAccruedForPeriod;
                entity.SickDaysAccruedTotal += model.SickDaysAccruedTotal;
                entity.SickDaysAccruedForPeriod += model.SickDaysAccruedForPeriod;
                return ctx.SaveChanges() == 1;
            }
        }
        public WorkInformationDetail GetWorkInformationByEmployeeId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.WorkInformationDbSet.Single(e => e.EmployeeId == id);
                return new WorkInformationDetail
                {
                    EmployeeId = entity.EmployeeId,
                    WorkInformationId = entity.WorkInformationId,
                    PositionId = entity.PositionId,
                    ContactId = entity.ContactId,
                    Wage = entity.Wage,
                    LastReview = entity.LastReview,
                    NextReview = entity.NextReview,
                    HasBenefits = entity.HasBenefits,
                    StartOfBenefits = entity.StartOfBenefits,
                    WorkEmail = entity.WorkEmail,
                    VacationDaysAccruedTotal = entity.VacationDaysAccruedTotal,
                    VacationDaysUsedTotal = entity.VacationDaysUsedTotal,
                    VacationDaysAccruedForPeriod = entity.VacationDaysAccruedForPeriod,
                    VacationDaysUsedForPeriod = entity.VacationDaysUsedForPeriod,
                    PersonalDaysAccruedTotal = entity.PersonalDaysAccruedTotal,
                    PersonalDaysUsedTotal = entity.PersonalDaysUsedTotal,
                    PersonalDaysAccruedForPeriod = entity.PersonalDaysAccruedForPeriod,
                    PersonalDaysUsedForPeriod = entity.PersonalDaysUsedForPeriod,
                    SickDaysAccruedTotal = entity.SickDaysAccruedTotal,
                    SickDaysUsedTotal = entity.SickDaysUsedTotal,
                    SickDaysAccruedForPeriod = entity.SickDaysAccruedForPeriod,
                    SickDaysUsedForPeriod = entity.SickDaysUsedForPeriod
                };
            }
        }
        public WorkInformationDepartmentName GetDepartmentByEmployeeId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.WorkInformationDbSet.Single(e => e.EmployeeId == id);
                return new WorkInformationDepartmentName
                {
                    DepartmentName = entity.PositionHeld.Department.DepartmentName
                };
            }
        }
        public WorkInformationPositionName GetPositionByEmployeeId(int id)
        {
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity = ctx.WorkInformationDbSet.Single(e => e.EmployeeId == id);
                    return new WorkInformationPositionName
                    {
                        PositionTitle = entity.PositionHeld.PositionTitle,
                        IsSupervisor = entity.PositionHeld.IsSupervisor,
                        IsDirector = entity.PositionHeld.IsDirector,
                        IsExecutive = entity.PositionHeld.IsDirector
                    };
                }
            }
        }
        public IEnumerable<WorkInformationListItem> GetEmployeeByDepartmentId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.WorkInformationDbSet.Where(e => e.PositionHeld.DepartmentId == id)
                    .Select(e => new WorkInformationListItem
                    {
                        EmployeeId = e.EmployeeId,
                        WorkInformationId = e.WorkInformationId,
                        PositionId = e.PositionId,
                        ContactId = e.ContactId,
                        Wage = e.Wage,
                        WorkEmail = e.WorkEmail,
                        FirstName = e.Employee.FirstName,
                        LastName = e.Employee.LastName,
                        PositionTitle = e.PositionHeld.PositionTitle,
                        DepartmentName = e.PositionHeld.Department.DepartmentName
                    }
                    );

                return query.ToArray();
            }
        }
        public IEnumerable<WorkInformationListItem> GetAllSupervisorsByDepartment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.WorkInformationDbSet.Where(e => e.PositionHeld.IsSupervisor == true && e.PositionHeld.DepartmentId == id)
                    .Select(e => new WorkInformationListItem
                    {
                        WorkInformationId = e.WorkInformationId,
                        PositionId = e.PositionId,
                        ContactId = e.ContactId,
                        EmployeeId = e.EmployeeId,
                        FirstName = e.Employee.FirstName,
                        LastName = e.Employee.LastName,
                        PositionTitle = e.PositionHeld.PositionTitle,
                        DepartmentName = e.PositionHeld.Department.DepartmentName,
                        Wage = e.Wage,
                        WorkEmail = e.WorkEmail,
                    }
                    );
                return query.ToArray();
            }
        }

        // START OF GET ALL
        public IEnumerable<WorkInformationListItem> GetWorkInformation()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.WorkInformationDbSet.Select(e => new WorkInformationListItem
                {
                    EmployeeId = e.EmployeeId,
                    WorkInformationId = e.WorkInformationId,
                    PositionId = e.PositionId,
                    ContactId = e.ContactId,
                    Wage = e.Wage,
                    WorkEmail = e.WorkEmail,
                    FirstName = e.Employee.FirstName,
                    LastName = e.Employee.LastName,
                    PositionTitle = e.PositionHeld.PositionTitle,
                    DepartmentName = e.PositionHeld.Department.DepartmentName,
                }
                    );

                return query.ToArray();
            }
        }


        public IEnumerable<GetWorkInformationByActive> GetWorkInformationByActive()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.WorkInformationDbSet.Where(e => e.Employee.DateOfTermination == null)
                    .Select(e => new GetWorkInformationByActive
                    {
                        WorkInformationId = e.WorkInformationId,
                        PositionId = e.PositionId,
                        ContactId = e.ContactId,
                        Wage = e.Wage,
                        StartOfBenefits = e.StartOfBenefits,
                        WorkEmail = e.WorkEmail,
                    }
                    );

                return query.ToArray();
            }
        }
        public IEnumerable<GetWorkInformationByActive> GetWorkInformationByInactive()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.WorkInformationDbSet.Where(e => e.Employee.DateOfTermination != null)
                    .Select(e => new GetWorkInformationByActive
                    {
                        WorkInformationId = e.WorkInformationId,
                        PositionId = e.PositionId,
                        ContactId = e.ContactId,
                        Wage = e.Wage,
                        StartOfBenefits = e.StartOfBenefits,
                        WorkEmail = e.WorkEmail,
                    }
                    );

                return query.ToArray();
            }
        }
        public IEnumerable<GetAllLeadership> GetAllDirectors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.WorkInformationDbSet.Where(e => e.PositionHeld.IsDirector == true)
                    .Select(e => new GetAllLeadership
                    {
                        WorkInformationId = e.WorkInformationId,
                        PositionId = e.PositionId,
                        ContactId = e.ContactId,
                        EmployeeId = e.EmployeeId,
                        FirstName = e.Employee.FirstName,
                        LastName = e.Employee.LastName,
                        PositionTitle = e.PositionHeld.PositionTitle,
                        DepartmentName = e.PositionHeld.Department.DepartmentName,
                        Wage = e.Wage,
                        WorkEmail = e.WorkEmail,
                    }
                    );
                return query.ToArray();
            }
        }
        public IEnumerable<GetAllLeadership> GetAllSupervisors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.WorkInformationDbSet.Where(e => e.PositionHeld.IsSupervisor == true)
                    .Select(e => new GetAllLeadership
                    {
                        WorkInformationId = e.WorkInformationId,
                        PositionId = e.PositionId,
                        ContactId = e.ContactId,
                        EmployeeId = e.EmployeeId,
                        FirstName = e.Employee.FirstName,
                        LastName = e.Employee.LastName,
                        PositionTitle = e.PositionHeld.PositionTitle,
                        DepartmentName = e.PositionHeld.Department.DepartmentName,
                        Wage = e.Wage,
                        WorkEmail = e.WorkEmail,
                    }
                    );
                return query.ToArray();
            }
        }
        public IEnumerable<GetAllLeadership> GetAllExecutives()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.WorkInformationDbSet.Where(e => e.PositionHeld.IsExecutive == true)
                    .Select(e => new GetAllLeadership
                    {
                        WorkInformationId = e.WorkInformationId,
                        PositionId = e.PositionId,
                        ContactId = e.ContactId,
                        EmployeeId = e.EmployeeId,
                        FirstName = e.Employee.FirstName,
                        LastName = e.Employee.LastName,
                        PositionTitle = e.PositionHeld.PositionTitle,
                        DepartmentName = e.PositionHeld.Department.DepartmentName,
                        Wage = e.Wage,
                        WorkEmail = e.WorkEmail,
                    }
                    );
                return query.ToArray();
            }
        }

    }
}