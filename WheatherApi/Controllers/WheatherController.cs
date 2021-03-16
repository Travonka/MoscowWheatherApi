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
    /// Some text changed _2
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
            return await wheatherHub.GetWheather();
        } 
    }
}
