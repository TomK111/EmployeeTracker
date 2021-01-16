using EmployeeTracker.Data;
using EmployeeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Services
{
    public class EmployeeService
    {
        //Create Personnel
        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity =
                new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    SocialSecurityNumber = model.SocialSecurityNumber,
                    DateOfBirth = model.DateOfBirth,
                    DateOfHire = model.DateOfHire,
                    DateOfTermination = model.DateOfTermination,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.EmployeeDbSet.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get All Personnel
        public IEnumerable<EmployeeListItem> GetEmployee()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .EmployeeDbSet
                    .Select(
                       e =>
                       new EmployeeListItem
                       {
                           EmployeeId = e.EmployeeId,
                           FirstName = e.FirstName,
                           MiddleName = e.MiddleName,
                           LastName = e.LastName,
                           SocialSecurityNumber = e.SocialSecurityNumber,
                           DateOfBirth = e.DateOfBirth,
                           DateOfHire = e.DateOfHire,
                           DateOfTermination = e.DateOfTermination,
                       }
                    );
                return query.ToArray();
            }
        }

        //Get Personnel by ID
        public EmployeeListItem GetEmployeeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .EmployeeDbSet
                    .Single(e => e.EmployeeId == id);
                return new EmployeeListItem
                {
                    EmployeeId = entity.EmployeeId,
                    FirstName = entity.FirstName,
                    MiddleName = entity.MiddleName,
                    LastName = entity.LastName,
                    SocialSecurityNumber = entity.SocialSecurityNumber,
                    DateOfBirth = entity.DateOfBirth,
                    DateOfHire = entity.DateOfHire,
                    DateOfTermination = entity.DateOfTermination
                };
            }
        }

        //Edit Personnel
        public bool UpdateEmployee(EmployeeDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .EmployeeDbSet
                    .Single(e => e.EmployeeId == model.EmployeeId);

                entity.FirstName = model.FirstName;
                entity.MiddleName = model.MiddleName;
                entity.LastName = model.LastName;
                entity.SocialSecurityNumber = model.SocialSecurityNumber;
                entity.DateOfBirth = model.DateOfBirth;
                entity.DateOfHire = model.DateOfHire;
                return ctx.SaveChanges() == 1;
            }
        }

        //Archive Personnel
        public bool ArchiveEmployee(EmployeeArchive model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .EmployeeDbSet
                    .Single(e => e.EmployeeId == model.EmployeeId);

                entity.DateOfTermination = model.DateOfTermination;

                return ctx.SaveChanges() == 1;
            }
        }
        //Get All Active Personnel
        public IEnumerable<EmployeeListItem> GetActiveEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .EmployeeDbSet
                    .Where(e => e.DateOfTermination == null)
                    .Select(
                       e =>
                       new EmployeeListItem
                       {
                           EmployeeId = e.EmployeeId,
                           FirstName = e.FirstName,
                           MiddleName = e.MiddleName,
                           LastName = e.LastName,
                           SocialSecurityNumber = e.SocialSecurityNumber,
                           DateOfBirth = e.DateOfBirth,
                           DateOfHire = e.DateOfHire,
                           DateOfTermination = e.DateOfTermination
                       }
                    );
                return query.ToArray();
            }
        }
        //Get All Inactive Personnel
        public IEnumerable<EmployeeListItem> GetInactiveEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .EmployeeDbSet
                    .Where(e => e.DateOfTermination != null)
                    .Select(
                       e =>
                       new EmployeeListItem
                       {
                           EmployeeId = e.EmployeeId,
                           FirstName = e.FirstName,
                           MiddleName = e.MiddleName,
                           LastName = e.LastName,
                           SocialSecurityNumber = e.SocialSecurityNumber,
                           DateOfBirth = e.DateOfBirth,
                           DateOfHire = e.DateOfHire,
                           DateOfTermination = e.DateOfTermination
                       }
                    );
                return query.ToArray();
            }

        }
    }
}