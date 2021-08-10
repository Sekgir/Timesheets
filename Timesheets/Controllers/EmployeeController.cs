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
    public class EmployeeController : ControllerBase
    {
        Data _data;
        public EmployeeController(Data data)
        {
            _data = data;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_data.Employees);
        }

        [HttpPost("create")]
        public ActionResult Create([FromBody] Employee employee)
        {
            if (_data.Employees.Count == 0)
            {
                employee.Id = 0;
            }
            else
            {
                employee.Id = _data.Employees.Max(item => item.Id) + 1;
            }
            _data.Employees.Add(employee);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult Read([FromRoute] int id)
        {
            Employee employee = _data.Employees.Find(item => item.Id == id);
            return Ok(employee);
        }

        [HttpPost("update")]
        public ActionResult Update([FromBody] Employee employee)
        {
            Employee employee1 = _data.Employees.Find(item => item.Id == employee.Id);
            if (employee1 != null)
            {
                employee1.Lastname = employee.Lastname;
                employee1.Name = employee.Name;
                employee1.Patronymic = employee.Patronymic;
                employee1.Salary = employee.Salary;
            }
            return Ok();
        }

        [HttpPost("delete")]
        public ActionResult Delete([FromForm] int id)
        {
            Employee employee = _data.Employees.Find(item => item.Id == id);
            _data.Employees.Remove(employee);
            return Ok();
        }
    }
}
