using EmployeeTracker.Data;
using EmployeeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Services
{
    public class DepartmentService
    {
        public bool CreateDepartment(DepartmentCreate model)
        {
            var entity = new Department()
            {
                DepartmentName = model.DepartmentName,
                EmployeeCount = model.EmployeeCount
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.DepartmentDbSet.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DepartmentListItem> GetDepartments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .DepartmentDbSet
                    .Select(
                        e =>
                            new DepartmentListItem
                            {
                                DepartmentId = e.DepartmentId,
                                DepartmentName = e.DepartmentName,
                                EmployeeCount = e.EmployeeCount
                            }
                    );
                return query.ToArray();
            }
        }
        public DepartmentDetail GetDepartmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DepartmentDbSet
                        .Single(e => e.DepartmentId == id);
                return
                    new DepartmentDetail
                    {
                        DepartmentId = entity.DepartmentId,
                        DepartmentName = entity.DepartmentName,
                        EmployeeCount = entity.EmployeeCount,

                    };
            }
        }
        public bool UpdateDepartment(DepartmentDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .DepartmentDbSet
                    .Single(e => e.DepartmentId == model.DepartmentId);
                entity.DepartmentName = model.DepartmentName;
                entity.EmployeeCount = model.EmployeeCount;
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ContactListItem> GetContactByDepartmentId(int departmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .WorkInformationDbSet
                    .Where(e => e.PositionHeld.DepartmentId == departmentId)
                    .Select(
                        e =>
                            new ContactListItem
                            {
                                PhoneNumber = e.Contact.PhoneNumber,
                                Email = e.Contact.Email,
                                Address = e.Contact.Address
                            }
                    );
                return query.ToArray();
            }
        }
    }
}
