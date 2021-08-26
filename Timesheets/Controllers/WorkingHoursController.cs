using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Models;
using Timesheets.Requests;

namespace Timesheets.Controllers
{
    public class WorkingHoursController : Controller
    {
        Data _data;
        public WorkingHoursController(Data data)
        {
            _data = data;
        }

        //[HttpPost("addOpeningHours")]
        //public ActionResult AddOpeningHours([FromBody] WorkingHoursAddOpeningHours request)
        //{
        //    WorkingHours workingHours = new WorkingHours()
        //    {
        //        IdContract = request.IdContract,
        //        IdEmpl = request.IdEmpl,
        //        Time = TimeSpan.FromSeconds(request.Time)
        //    };
        //    if (_data.WorkingHours.Count == 0)
        //    {
        //        workingHours.Id = 0;
        //    }
        //    else
        //    {
        //        workingHours.Id = _data.WorkingHours.Max(item => item.Id) + 1;
        //    }
        //    _data.WorkingHours.Add(workingHours);
        //    return Ok();
        //}

        //[HttpGet("{id}")]
        //public ActionResult Read([FromRoute] int id)
        //{
        //    WorkingHours workingHours = _data.WorkingHours.Find(item => item.Id == id);
        //    return Ok(workingHours);
        //}

        //[HttpPost("update")]
        //public ActionResult Update([FromBody] WorkingHours workingHours)
        //{
        //    WorkingHours workingHours1 = _data.WorkingHours.Find(item => item.Id == workingHours.Id);
        //    if (workingHours1 != null)
        //    {
        //        workingHours1.IsInvoiceExposed = workingHours.IsInvoiceExposed;
        //        workingHours1.WorkWasPaid = workingHours.WorkWasPaid;
        //    }
        //    return Ok();
        //}

        //[HttpPost("delete")]
        //public ActionResult Delete([FromForm] int id)
        //{
        //    WorkingHours workingHours = _data.WorkingHours.Find(item => item.Id == id);
        //    _data.WorkingHours.Remove(workingHours);
        //    return Ok();
        //}
    }
}
