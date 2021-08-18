using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Requests;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController : ControllerBase
    {
        Data _data;
        public ContractController(Data data)
        {
            _data = data;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_data.Contracts);
        }

        [HttpPost("create")]
        public ActionResult Create([FromForm] int number)
        {
            Contract contract = new Contract() { Number = number };
            if (_data.Contracts.Count == 0)
            {
                contract.Id = 0;
            }
            else
            {
                contract.Id = _data.Contracts.Max(item => item.Id) + 1;
            }
            _data.Contracts.Add(contract);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult Read([FromRoute] int id)
        {
            Contract contract = _data.Contracts.Find(item => item.Id == id);
            return Ok(contract);
        }

        [HttpPost("addOpeningHours")]
        public ActionResult AddOpeningHours([FromBody] ContractAddOpeningHoursRequest request)
        {
            Contract contract = _data.Contracts.Find(item => item.Id == request.IdContract);
            if (contract == null)
            {
                return NotFound();
            }
            if (contract.WorkingHours == null)
            {
                contract.WorkingHours = new List<WorkingHours>() { new WorkingHours() { IdEmpl = request.IdEmpl, Time = TimeSpan.FromSeconds(request.Time) } };
                return Ok();
            }
            WorkingHours workingHours = contract.WorkingHours.Find(item => item.IdEmpl == request.IdEmpl);
            if (workingHours == null)
            {
                contract.WorkingHours.Add(new WorkingHours() { IdEmpl = request.IdEmpl, Time = TimeSpan.FromSeconds(request.Time) });
            }
            else
            {
                workingHours.Time = workingHours.Time.Add(TimeSpan.FromSeconds(request.Time));
            }
            return Ok();
        }

        [HttpPost("delete")]
        public ActionResult Delete([FromForm] int id)
        {
            Contract contract = _data.Contracts.Find(item => item.Id == id);
            _data.Contracts.Remove(contract);
            return Ok();
        }
    }
}
