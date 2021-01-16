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
        [RoutePrefix("api/Position")]
        public class PositionController : ApiController
        {

            private PositionService CreatePositionService()
            {
                var createService = new PositionService();
                return createService;
            }
            [Route("GetAll")]
            [HttpGet]
            public IHttpActionResult Get()
            {
                PositionService positionService = CreatePositionService();
                var positions = positionService.GetPositions();
                return Ok(positions);
            }

            [Route("Create")]
            [HttpPost]
            public IHttpActionResult Post(PositionCreate position)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var service = CreatePositionService();
                if (!service.CreatePosition(position))
                {
                    return InternalServerError();
                }
                return Ok();
            }

            [Route("{PositionId}")]
            [HttpGet]
            public IHttpActionResult GetPositionByPositionId(int PositionId)
            {
                PositionService positionService = CreatePositionService();
                var position = positionService.GetPositionById(PositionId);
                return Ok(position);
            }

            [Route("ByDepartment/{DepartmentId}")]
            [HttpGet]
            public IHttpActionResult GetPositionByDepartmentId(int DepartmentId)
            {
                PositionService positionService = CreatePositionService();
                var position = positionService.GetPositionsByDepartment(DepartmentId);
                return Ok(position);
            }

            [Route("Edit")]
            [HttpPut]
            public IHttpActionResult Put(PositionDetail position)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var service = CreatePositionService();
                if (!service.UpdatePosition(position))
                {
                    return InternalServerError();
                }
                return Ok();
            }
        }
    }
