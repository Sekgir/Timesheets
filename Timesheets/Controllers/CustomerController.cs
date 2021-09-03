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
    public class CustomerController : ControllerBase
    {
        CustomersService _service;

        public CustomerController(CustomersService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] long id)
        {
            Customer result = await _service.GetCustomerById(id);
            return Ok(result);
        }

        [HttpGet("{id}/contracts")]
        public async Task<ActionResult> GetContractsByCustomerId([FromRoute] long id)
        {
            ICollection<Contract> result = await _service.GetContractsByCustomerId(id);
            return Ok(result);
        }

        [HttpPost("{id}/contract")]
        public async Task<ActionResult> CreateContract([FromRoute] long id, [FromForm] int number)
        {
            await _service.CreateContract(id, number);
            return Ok();
        }
        [HttpGet("{id}/invoice")]
        public async Task<ActionResult> GetInvoicesByCustomerId([FromRoute] long id)
        {
            await _service.GetInvoicesByCustomerId(id);
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> CreateCustomer([FromBody] Person person)
        {
            await _service.CreateCustomer(person);
            return Ok();
        }
    }
}
