using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]")]
    public class CurrentTimeTableTruncate : Controller
    {

        //   POST api/currenttimetabletruncate
        [HttpPost]
        public ActionResult Delete()
        {
            using (var db = new ClockworkContext())
            {
                db.Database.ExecuteSqlRaw("TRUNCATE TABLE CurrentTimeQuery");
                Console.WriteLine("Data Table Truncated");
            }

            return View("Index");
        }

    }
}
