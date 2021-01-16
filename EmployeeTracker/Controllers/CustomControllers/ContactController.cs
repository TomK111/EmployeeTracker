using EmployeeTracker.Models;
using EmployeeTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeTracker.Controllers
{
    [Authorize]
    [RoutePrefix("api/Contact")]
    public class ContactController : ApiController
    {
        private ContactService CreateContactService()
        {
            var createService = new ContactService();
            return createService;
        }

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            ContactService contactService = CreateContactService();
            var notes = contactService.GetContacts();
            return Ok(notes);
        }

        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Post(ContactCreate contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateContactService();

            if (!service.CreateContact(contact))
                return InternalServerError();

            return Ok();
        }

        [Route("{PersonnelId}")]
        [HttpGet]
        public IHttpActionResult Get(int PersonnelId)
        {
            ContactService contactService = CreateContactService();
            var contact = contactService.GetContactByPersonnelId(PersonnelId);
            return Ok(contact);
        }

        [Route("AllActive")]
        [HttpGet]
        public IHttpActionResult GetAllActive()
        {
            ContactService contactService = CreateContactService();
            var contact = contactService.GetContactForAllActive();
            return Ok(contact);
        }

        [Route("AllInactive")]
        [HttpGet]
        public IHttpActionResult GetAllInactive()
        {
            ContactService contactService = CreateContactService();
            var contact = contactService.GetContactForAllInactive();
            return Ok(contact);
        }

        [Route("Edit")]
        [HttpPut]
        public IHttpActionResult Put(ContactDetails contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateContactService();

            if (!service.UpdateContact(contact))
                return InternalServerError();

            return Ok();
        }
    }
}
