using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Models;
using Timesheets.DAL.Interfaces;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        IPersonsRepository _repository;
        public PersonsController(IPersonsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult GetPersonById([FromRoute] int id)
        {
            var request = _repository.GetById(id);
            return Ok(request);
        }

        [HttpGet("search")]
        public ActionResult GetPersonByName([FromQuery] string searchTerm)
        {
            var request = _repository.GetByName(searchTerm);
            return Ok(request);
        }

        [HttpGet("skip={skip}&take={take}")]
        public ActionResult GetPersonsList([FromRoute] int skip, [FromRoute] int take)
        {
            var request = _repository.GetList(skip, take);
            return Ok(request);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Person person)
        {
            _repository.Create(person);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody] Person person)
        {
            _repository.Update(person);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
}
