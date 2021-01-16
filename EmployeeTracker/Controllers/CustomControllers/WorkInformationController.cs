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
    [RoutePrefix("api/WorkInfo")]
    public class WorkInformationController : ApiController
    {
        private WorkInformationService CreateWorkInformationService()
        {

            var informationService = new WorkInformationService();
            return informationService;
        }

        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Post(WorkInformationCreate workinformation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateWorkInformationService();
            if (!service.CreateWorkInformation(workinformation))
                return InternalServerError();

            return Ok();
        }

        [Route("Edit")]
        [HttpPut]
        public IHttpActionResult Put(WorkInformationEdit workinfo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateWorkInformationService();

            if (!service.EditWorkInformation(workinfo))
                return InternalServerError();

            return Ok();
        }

        [Route("Info/{PersonnelId}")]
        [HttpGet]
        public IHttpActionResult GetByPersonnelId(int EmployeeId)
        {
            WorkInformationService infoService = CreateWorkInformationService();
            var info = infoService.GetWorkInformationByEmployeeId(EmployeeId);
            return Ok(info);
        }

        [Route("Department/{EmployeeId}")]
        [HttpGet]
        public IHttpActionResult GetDept(int EmployeeId)
        {
            WorkInformationService infoService = CreateWorkInformationService();
            var info = infoService.GetDepartmentByEmployeeId(EmployeeId);
            return Ok(info);
        }

        [Route("Position/{EmployeeId}")]
        [HttpGet]
        public IHttpActionResult GetPosition(int EmployeeId)
        {
            WorkInformationService infoService = CreateWorkInformationService();
            var info = infoService.GetPositionByEmployeeId(EmployeeId);
            return Ok(info);
        }

        [Route("Employee/{DepartmentId}")]
        [HttpGet]
        public IHttpActionResult GetEmployeeByDepartment(int DepartmentId)
        {
            WorkInformationService infoService = CreateWorkInformationService();
            var info = infoService.GetEmployeeByDepartmentId(DepartmentId);
            return Ok(info);
        }

        //START OF GET ALL

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            WorkInformationService infoService = CreateWorkInformationService();
            var info = infoService.GetWorkInformation();
            return Ok(info);
        }

        [Route("AllSupervisors/{DeptId}")]
        [HttpGet]
        public IHttpActionResult GetAllSupervisorsByDepartment(int DepartmentId)
        {
            WorkInformationService infoService = CreateWorkInformationService();
            var info = infoService.GetAllSupervisorsByDepartment(DepartmentId);
            return Ok(info);
        }

        [Route("AllActive")]
        [HttpGet]
        public IHttpActionResult GetByActive()
        {
            WorkInformationService infoService = CreateWorkInformationService();
            var info = infoService.GetWorkInformationByActive();
            return Ok(info);
        }

        [Route("AllInactive")]
        [HttpGet]
        public IHttpActionResult GetByInactive()
        {
            WorkInformationService infoService = CreateWorkInformationService();
            var info = infoService.GetWorkInformationByInactive();
            return Ok(info);
        }

        [Route("AllDirectors")]
        [HttpGet]
        public IHttpActionResult GetDirectors()
        {
            WorkInformationService infoService = CreateWorkInformationService();
            var info = infoService.GetAllDirectors();
            return Ok(info);
        }

        [Route("AllSupervisors")]
        [HttpGet]
        public IHttpActionResult GetSupervisors()
        {
            WorkInformationService infoService = CreateWorkInformationService();
            var info = infoService.GetAllSupervisors();
            return Ok(info);
        }
        [Route("AllExecutives")]
        [HttpGet]
        public IHttpActionResult GetExecutives()
        {
            WorkInformationService infoService = CreateWorkInformationService();
            var info = infoService.GetAllExecutives();
            return Ok(info);
        }


    }
}
