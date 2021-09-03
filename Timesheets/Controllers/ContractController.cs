using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;
using Timesheets.DAL.Services;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController : ControllerBase
    {
        ContractsService _service;
        public ContractController(ContractsService service)
        {
            _service = service;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _service.GetContractById(id);
            return Ok(result);
        }

        [HttpGet("{id}/invoice")]
        public async Task<ActionResult> GetInvoices([FromRoute] int id)
        {
            var result = await _service.GetInvoices(id);
            return Ok(result);
        }

        [HttpPost("{id}/invoice")]
        public async Task<ActionResult> CreateInvoice([FromRoute] int id)
        {
            var result = await _service.CreateInvoice(id);
            return Ok(result);
        }
    }
}
