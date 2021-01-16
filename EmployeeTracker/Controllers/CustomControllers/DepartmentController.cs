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
        [RoutePrefix("api/Department")]
        public class DepartmentController : ApiController
        {
            private DepartmentService CreateDepartmentService()
            {
                var createService = new DepartmentService();
                return createService;
            }
            [Route("GetAll")]
            [HttpGet]
            public IHttpActionResult Get()
            {
                DepartmentService departmentService = CreateDepartmentService();
                var depts = departmentService.GetDepartments();
                return Ok(depts);
            }

            [Route("Create")]
            [HttpPost]
            public IHttpActionResult Post(DepartmentCreate department)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var service = CreateDepartmentService();
                if (!service.CreateDepartment(department))
                {
                    return InternalServerError();
                }
                return Ok();
            }

            [Route("{DepartmentId}")]
            [HttpGet]
            public IHttpActionResult Get(int DepartmentId)
            {
                DepartmentService departmentService = CreateDepartmentService();
                var department = departmentService.GetDepartmentById(DepartmentId);
                return Ok(department);
            }

            [Route("Edit")]
            [HttpPut]
            public IHttpActionResult Put(DepartmentDetail dept)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var service = CreateDepartmentService();
                if (!service.UpdateDepartment(dept))
                {
                    return InternalServerError();
                }
                return Ok();
            }
        }
    }
