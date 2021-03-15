using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace MoscowWheatherApi.Controllers
{
    [ApiController]
    public class WheatherController : ControllerBase
    {/// <summary>
    /// Some text changed
    /// </summary>
        WheatherHub wheatherHub;
        public WheatherController()
        {
            wheatherHub = WheatherHub.getInstance();
        }
        [HttpGet]
        [Route("/Get")]
        public async Task<string> GetWheather()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            return await wheatherHub.GetWheather();
        } 
    }
}
