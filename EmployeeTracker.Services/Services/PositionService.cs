using EmployeeTracker.Data;
using EmployeeTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Services
{
    public class PositionService
    {
        public bool CreatePosition(PositionCreate model)
        {
            var entity = new Position()
            {
                PositionTitle = model.PositionTitle,
                DepartmentId = model.DepartmentId,
                IsSupervisor = model.IsSupervisor,
                IsDirector = model.IsDirector,
                IsExecutive = model.IsExecutive
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PositionDbSet.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PositionListItem> GetPositions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .PositionDbSet
                    .Select(
                        e =>
                            new PositionListItem
                            {
                                PositionId = e.PositionId,
                                PositionTitle = e.PositionTitle,
                                DepartmentId = e.DepartmentId,
                                DepartmentName = e.Department.DepartmentName,
                                IsSupervisor = e.IsSupervisor,
                                IsDirector = e.IsDirector,
                                IsExecutive = e.IsExecutive
                            }
                    );
                return query.ToArray();
            }
        }
        public IEnumerable<PositionListItem> GetPositionsByDepartment(int departmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .PositionDbSet
                    .Where(e => e.DepartmentId == departmentId)
                    .Select(
                        e =>
                            new PositionListItem
                            {
                                PositionId = e.PositionId,
                                PositionTitle = e.PositionTitle,
                                DepartmentId = e.DepartmentId,
                                DepartmentName = e.Department.DepartmentName,
                                IsSupervisor = e.IsSupervisor,
                                IsDirector = e.IsDirector,
                                IsExecutive = e.IsExecutive
                            }
                    );
                return query.ToArray();
            }
        }
        public PositionDetail GetPositionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PositionDbSet
                        .Single(e => e.PositionId == id);
                return
                    new PositionDetail
                    {
                        PositionId = entity.PositionId,
                        PositionTitle = entity.PositionTitle,
                        DepartmentId = entity.DepartmentId,
                        DepartmentName = entity.Department.DepartmentName,
                        IsSupervisor = entity.IsSupervisor,
                        IsDirector = entity.IsDirector,
                        IsExecutive = entity.IsExecutive,
                    };
            }
        }
        public bool UpdatePosition(PositionDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PositionDbSet
                    .Single(e => e.PositionId == model.PositionId);
                entity.PositionTitle = model.PositionTitle;
                entity.DepartmentId = model.DepartmentId;
                entity.IsSupervisor = model.IsSupervisor;
                entity.IsDirector = model.IsDirector;
                entity.IsExecutive = model.IsExecutive;
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
