using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotSDrafter.Shared;

namespace HotSDrafter.Server.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class StaticController : ControllerBase
    {
        [HttpGet("Heroes")]
        public IEnumerable<Hero> Heroes()
        {
            return (HeroStatic.Heroes);
        }

        [HttpGet("Maps")]
        public IEnumerable<Map> Maps()
        {
            return (MapStatic.Maps);
        }
    }
}
