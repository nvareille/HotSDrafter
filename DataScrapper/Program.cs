using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using HotSDrafter.Shared;
using HotSLogsScrapper;
using Newtonsoft.Json;
using SkromTaskPool;

namespace DataScrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero[] heroes = HeroStatic.Heroes;
            Rank[] ranks = new[]
            {
                Rank.Bronze,
                Rank.Silver,
                Rank.Gold,
                Rank.Platinum,
                Rank.Diamond,
                Rank.Master
            };

            TaskPool TaskPool = new TaskPool(10);
            
            HeroResult[][] results = new HeroResult[ranks.Length][];

            foreach (Rank rank in ranks)
            {
                results[(int)rank] = new HeroResult[heroes.Length];
            }

            int countRank = 0;

            foreach (Rank rank in ranks)
            {
                int countHero = 0;

                foreach (Hero hero in heroes)
                {
                    TaskPool.AddTask((h, hCount, r) =>
                    {
                        Console.WriteLine(@"Getting {0} Rank {1}", hero.Name, r);

                        Scrapper scrapper = new Scrapper();
                        HeroResult result = new HeroResult();

                        scrapper.DownloadData(h, r);

                        result.Hero = hero;
                        result.Matchups = scrapper.GetHeroBestMatchups();
                        result.Duos = scrapper.GetHeroDuos();
                        result.Maps = scrapper.GetMaps();
                        result.Talents = scrapper.GetTalents();

                        results[(int)r][hCount] = result;

                        return (Task.Delay(4000));
                    }, hero, countHero, rank);

                    ++countHero;
                }
                ++countRank;
            }


            

            TaskPool.Run().Wait();

            string data = JsonConvert.SerializeObject(results, Formatting.Indented);
            File.WriteAllText("output.json", data);
        }
    }
}
