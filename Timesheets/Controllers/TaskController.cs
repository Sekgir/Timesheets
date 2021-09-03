using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Services;

namespace Timesheets.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        TasksService _service;

        public TaskController(TasksService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask(DAL.Models.Task task)
        {
            await _service.CreateTask(task);
            return Ok();
        }
    }
}
