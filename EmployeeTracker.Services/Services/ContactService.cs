using EmployeeTracker.Data;
using EmployeeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Services
{
    public class ContactService
    {
        public bool CreateContact(ContactCreate model)
        {
            var entity =
                new
                Contact()
                {
                    EmployeeId = model.EmployeeId,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Address = model.Address
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ContactDbSet.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ContactListItem> GetContacts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .ContactDbSet
                        .Select(
                            e =>
                                new ContactListItem
                                {
                                    EmployeeId = e.EmployeeId,
                                    ContactId = e.ContactId,
                                    PhoneNumber = e.PhoneNumber,
                                    Email = e.Email,
                                    Address = e.Address
                                }
                        );

                return query.ToArray();
            }
        }

        public ContactDetails GetContactByPersonnelId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ContactDbSet
                        .Single(e => e.EmployeeId == id);
                return
                    new ContactDetails
                    {
                        EmployeeId = entity.EmployeeId,
                        ContactId = entity.ContactId,
                        PhoneNumber = entity.PhoneNumber,
                        Email = entity.Email,
                        Address = entity.Address
                    };
            }
        }

        public IEnumerable<ContactListItem> GetContactForAllActive()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .ContactDbSet
                    .Where(e => e.Employee.DateOfTermination == null)
                    .Select(
                    e =>
                    new ContactListItem
                    {
                        EmployeeId = e.EmployeeId,
                        ContactId = e.ContactId,
                        PhoneNumber = e.PhoneNumber,
                        Email = e.Email,
                        Address = e.Address
                    }
                    );
                return query.ToArray();
            }
        }

        public IEnumerable<ContactListItem> GetContactForAllInactive()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .ContactDbSet
                    .Where(e => e.Employee.DateOfTermination != null)
                    .Select(
                    e =>
                    new ContactListItem
                    {
                        EmployeeId = e.EmployeeId,
                        ContactId = e.ContactId,
                        PhoneNumber = e.PhoneNumber,
                        Email = e.Email,
                        Address = e.Address
                    }
                    );
                return query.ToArray();
            }
        }

        public bool UpdateContact(ContactDetails model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ContactDbSet
                        .Single(e => e.EmployeeId == model.EmployeeId);
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;
                entity.Address = model.Address;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}