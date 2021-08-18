using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        Data _data;
        public InvoiceController(Data data)
        {
            _data = data;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_data.Invoices);
        }

        [HttpPost("IssueAnInvoice")]
        public ActionResult IssueAnInvoice([FromBody] Invoice invoice)
        {
            if (_data.Invoices.Count == 0)
            {
                invoice.Id = 0;
            }
            else
            {
                invoice.Id = _data.Invoices.Max(item => item.Id) + 1;
            }
            Contract contract = _data.Contracts.Find(item => item.Id == invoice.IdContract);
            if (contract == null)
            {
                return NotFound();
            }
            invoice.Price = 0;
            if (contract.WorkingHours != null && contract.WorkingHours.Count > 0)
            {
                foreach (var workingHours in contract.WorkingHours)
                {
                    Employee employee = _data.Employees.Find(item => item.Id == workingHours.IdEmpl);
                    invoice.Price += workingHours.Time.TotalHours * employee.Salary;
                }
                contract.WorkingHours = null;
            }
            _data.Invoices.Add(invoice);
            return Ok(invoice);
        }

        [HttpGet("{id}")]
        public ActionResult Read([FromRoute] int id)
        {
            Invoice invoice = _data.Invoices.Find(item => item.Id == id);
            return Ok(invoice);
        }
    }
}
