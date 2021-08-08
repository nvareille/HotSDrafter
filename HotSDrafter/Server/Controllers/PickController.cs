using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotSDrafter.Server.Services;
using HotSDrafter.Shared;
using HotSLogsScrapper;

namespace HotSDrafter.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PickController : ControllerBase
    {
        private DraftService Drafter;

        public PickController(DraftService drafter)
        {
            Drafter = drafter;
        }

        [HttpGet("BestForMapAndRank")]
        public IEnumerable<HeroWinrate> BestForMapAndRank(string map, Rank rank)
        {
            Scrapper scrapper = new Scrapper();
            Map m = MapStatic.Maps.FirstOrDefault(i => i.Name == map);

            return (scrapper.GetBestPicksForMap(m, rank));
        }

        [HttpGet("Advise/{map}/{rank}/{team1}/{team2}/{bans}")]
        public DraftAdvice Advise(string map, Rank rank, string team1, string team2, string bans)
        {
            DraftAdvice advice = new DraftAdvice();

            IEnumerable<Hero> ally = GetHeroes(team1);
            IEnumerable<Hero> ennemy = GetHeroes(team2);
            IEnumerable<Hero> bansList = GetHeroes(bans);

            advice.MapPicks = Drafter.GetBestPicksForRankAndMap(rank, MapStatic.GetWithName(map))
                .OrderByDescending(i => i.WinRate);

            if (ennemy.Any())
            {
                advice.Counters = Drafter.GetBestCounter(ennemy, rank)
                    .OrderByDescending(i => i.WinRate);
            }

            advice.Filter(ally, ennemy, bansList);

            return (advice);
        }

        [HttpGet("Matchups/{rank}/{hero}/{team2}")]
        public IEnumerable<HeroWinrate> GetMatchups(Rank rank, string hero, string team2)
        {
            return (Drafter.GetHeroMatchup(rank, HeroStatic.GetWithName(hero), GetHeroes(team2)));
        }

        private IEnumerable<Hero> GetHeroes(string team)
        {
            return (team.Split(';')
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .Select(HeroStatic.GetWithName));
        }
    }
}
