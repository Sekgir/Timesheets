//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Timesheets.DAL.Models;

//namespace Timesheets.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class CustomerController : ControllerBase
//    {
//        Data _data;
//        public CustomerController(Data data)
//        {
//            _data = data;
//        }

//        [HttpGet]
//        public ActionResult GetAll()
//        {
//            return Ok(_data.Customers);
//        }

//        [HttpPost("create")]
//        public ActionResult Create([FromBody] Customer customer)
//        {
//            if (_data.Customers.Count == 0)
//            {
//                customer.Id = 0;
//            }
//            else
//            {
//                customer.Id = _data.Customers.Max(item => item.Id) + 1;
//            }
//            _data.Customers.Add(customer);
//            return Ok();
//        }

//        [HttpGet("{id}")]
//        public ActionResult Read([FromRoute] int id)
//        {
//            Customer customer = _data.Customers.Find(item => item.Id == id);
//            return Ok(customer);
//        }

//        [HttpPost("update")]
//        public ActionResult Update([FromBody] Customer customer)
//        {
//            Customer customer1 = _data.Customers.Find(item => item.Id == customer.Id);
//            if (customer1 != null)
//            {
//                customer1.Lastname = customer.Lastname;
//                customer1.Name = customer.Name;
//                customer1.Patronymic = customer.Patronymic;
//            }
//            return Ok();
//        }

//        [HttpPost("delete")]
//        public ActionResult Delete([FromForm] int id)
//        {
//            Customer customer = _data.Customers.Find(item => item.Id == id);
//            _data.Customers.Remove(customer);
//            return Ok();
//        }
//    }
//}
