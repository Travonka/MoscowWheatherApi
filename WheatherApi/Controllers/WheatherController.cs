using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace MoscowWheatherApi.Controllers
{
    [ApiController]
    public class WheatherController : ControllerBase
    {
        WheatherHub wheatherHub;
        public WheatherController()
        {
            wheatherHub = WheatherHub.getInstance();
        }
        [HttpGet]
        [Route("/Get")]
        public string GetWheather()
        {   
            return wheatherHub.GetWheather();
        }
    }
}
