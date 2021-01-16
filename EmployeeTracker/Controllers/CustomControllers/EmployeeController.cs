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
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {

        private EmployeeService CreateEmployeeService()
        {
            var personnelService = new EmployeeService();
            return personnelService;
        }
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            EmployeeService employeeService = CreateEmployeeService();
            var allPersonnel = employeeService.GetEmployee();
            return Ok(allPersonnel);
        }

        [Route("{EmployeeId}")]
        [HttpGet]
        public IHttpActionResult GetById(int EmployeeId)
        {
            EmployeeService employeeService = CreateEmployeeService();
            var employeeById = employeeService.GetEmployeeById(EmployeeId);
            return Ok(employeeById);
        }

        [Route("AllActive")]
        [HttpGet]
        public IHttpActionResult GetByActive()
        {
            EmployeeService employeeService = CreateEmployeeService();
            var employeeById = employeeService.GetActiveEmployees();
            return Ok(employeeById);
        }

        [Route("AllInactive")]
        [HttpGet]
        public IHttpActionResult GetByInactive()
        {
            EmployeeService employeeService = CreateEmployeeService();
            var employeeById = employeeService.GetInactiveEmployees();
            return Ok(employeeById);
        }
        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Post(EmployeeCreate employeeById)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateEmployeeService();
            if (!service.CreateEmployee(employeeById))
                return InternalServerError();
            return Ok();
        }
        [Route("Edit")]
        [HttpPut]
        public IHttpActionResult PutUpdate(EmployeeDetail employeeId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateEmployeeService();
            if (!service.UpdateEmployee(employeeId))
                return InternalServerError();
            return Ok();
        }
        [Route("Archive")]
        [HttpPut]
        public IHttpActionResult PutArchive(EmployeeArchive employeeById)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateEmployeeService();
            if (!service.ArchiveEmployee(employeeById))
                return InternalServerError();
            return Ok();
        }

    }
}
