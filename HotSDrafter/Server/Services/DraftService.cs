using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HotSDrafter.Shared;
using Newtonsoft.Json;

namespace HotSDrafter.Server.Services
{
    public class DraftService
    {
        public HeroResult[][] Results;

        public DraftService()
        {
            string data = File.ReadAllText("draft.json");

            Results = JsonConvert.DeserializeObject<HeroResult[][]>(data);
        }

        private IEnumerable<HeroResult> FilterAvailableResults(Rank rank)
        {
            return (Results[(int)rank].Where(i => i != null));
        }

        public IEnumerable<HeroWinrate> GetBestPicksForRankAndMap(Rank rank, Map map)
        {
            IEnumerable<HeroWinrate> results = FilterAvailableResults(rank).Select(i =>
            {
                MapWinrate m = i.Maps.FirstOrDefault(o => o.Map.Name == map.Name) ?? new MapWinrate
                {
                    Map = map,
                    WinRate = 0
                };

                return (new HeroWinrate
                {
                    Hero = i.Hero,
                    WinRate = m.WinRate
                });
            });

            return (results);
        }

        public IEnumerable<HeroWinrate> GetHeroMatchup(Rank rank, Hero hero, IEnumerable<Hero> heroes)
        {
            HeroResult heroResult = FilterAvailableResults(rank).FirstOrDefault(i => i.Hero.Name == hero.Name);
            IEnumerable<HeroWinrate> matchups = heroResult.Matchups.Where(i => heroes.Any(o => o.Name == i.Hero.Name));

            return (matchups.OrderByDescending(i => i.WinRate));
        }

        public IEnumerable<HeroWinrate> GetBestCounter(IEnumerable<Hero> heroes, Rank rank)
        {
            Dictionary<string, float> scores = new Dictionary<string, float>();
            IEnumerable<HeroResult> availables = FilterAvailableResults(rank);

            foreach (Hero hero in heroes)
            {
                IEnumerable<HeroWinrate> counters = availables.Select(i =>
                {
                    HeroWinrate matchup = i.Matchups.FirstOrDefault(o => o.Hero.Name == hero.Name);
                    
                    return new HeroWinrate
                    {
                        Hero = i.Hero,
                        WinRate = matchup != null ? matchup.WinRate / heroes.Count() : 0
                    };
                })
                .Where(i => i != null);

                foreach (HeroWinrate heroWinrate in counters)
                {
                    if (!scores.ContainsKey(heroWinrate.Hero.Name))
                        scores.Add(heroWinrate.Hero.Name, heroWinrate.WinRate);
                    else
                        scores[heroWinrate.Hero.Name] += heroWinrate.WinRate;
                }
            }

            return (scores.Select(i => new HeroWinrate
            {
                Hero = HeroStatic.GetWithName(i.Key),
                WinRate = i.Value
            }));
        }
    }
}
