using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Models;
using Timesheets.DAL.Services;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        EmployeesService _service;
        public EmployeeController(EmployeesService service)
        {
            _service = service;
        }
        [HttpPost("{idEmpl}/task/{idTask}/timesheet")]
        public async Task<ActionResult> AddTime([FromRoute] long idEmpl, [FromRoute] long idTask, [FromBody] double seconds)
        {
            await _service.AddTime(idEmpl, idTask, seconds);
            return Ok();
        }
    }
}
