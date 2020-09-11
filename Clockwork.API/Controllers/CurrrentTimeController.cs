using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;
using Newtonsoft.Json.Linq;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]")]
    public class CurrentTimeController : Controller
    {
        // GET api/currenttime
        [HttpGet]
        public IActionResult Get()
        {
            var utcTime = DateTime.UtcNow;
            var serverTime = DateTime.Now;
            var ip = this.HttpContext.Connection.RemoteIpAddress.ToString();
           // string [] result = new string[4];

            var returnVal = new CurrentTimeQuery
            {
                UTCTime = utcTime,
                ClientIp = ip,
                Time = serverTime       
            };
            string[] result = { returnVal.UTCTime.ToString(), returnVal.ClientIp, returnVal.Time.ToString(), "Json Array Returned" };

            using (var db = new ClockworkContext())
            {
                db.CurrentTimeQueries.Add(returnVal);
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                foreach (var CurrentTimeQuery in db.CurrentTimeQueries)
                {
                    Console.WriteLine(" - {0}", CurrentTimeQuery.UTCTime);
                }
            }

            return Ok(result);
        }

    }
}
