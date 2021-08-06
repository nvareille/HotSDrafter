using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotSDrafter.Shared;
using HotSLogsScrapper;

namespace HotSDrafter.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PickController : ControllerBase
    {
        [HttpGet("BestForMapAndRank")]
        public IEnumerable<HeroResult> BestForMapAndRank(string map, Rank rank)
        {
            Scrapper scrapper = new Scrapper();
            Map m = MapStatic.Maps.FirstOrDefault(i => i.Name == map);
            
            return (scrapper.GetBestPicksForMap(m, rank));
        }
    }
}
