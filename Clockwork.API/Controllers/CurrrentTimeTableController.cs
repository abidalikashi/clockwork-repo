using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]")]
    public class CurrentTimeTableController : Controller
    {
        //   GET api/currenttimetable
        [HttpGet]
        public IActionResult GetTable()
        {
            List<JObject> records = new List<JObject>();
            dynamic json = new JObject();

            using (var db = new ClockworkContext())
            {
                 json = db.CurrentTimeQueries.ToList<CurrentTimeQuery>();
                Console.WriteLine("Data Table Requested");
            }
            return Ok(json);
        }

    }
}
