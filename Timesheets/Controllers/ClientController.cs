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
    public class ClientController : ControllerBase
    {
        Data _data;
        public ClientController(Data data)
        {
            _data = data;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_data.Clients);
        }

        [HttpPost("create")]
        public ActionResult Create([FromBody] Client client)
        {
            if (_data.Clients.Count == 0)
            {
                client.Id = 0;
            }
            else
            {
                client.Id = _data.Clients.Max(item => item.Id) + 1;
            }
            _data.Clients.Add(client);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult Read([FromRoute] int id)
        {
            Client client = _data.Clients.Find(item => item.Id == id);
            return Ok(client);
        }

        [HttpPost("update")]
        public ActionResult Update([FromBody] Client client)
        {
            Client client1 = _data.Clients.Find(item => item.Id == client.Id);
            if (client1 != null)
            {
                client1.Lastname = client.Lastname;
                client1.Name = client.Name;
                client1.Patronymic = client.Patronymic;
            }
            return Ok();
        }

        [HttpPost("delete")]
        public ActionResult Delete([FromForm] int id)
        {
            Client client = _data.Clients.Find(item => item.Id == id);
            _data.Clients.Remove(client);
            return Ok();
        }
    }
}
