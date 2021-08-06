using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Xml;
using HotSDrafter.Shared;
using HtmlAgilityPack;

namespace HotSLogsScrapper
{
    public class Scrapper
    {
        public static string BaseURL = "https://www.hotslogs.com/Sitewide/";

        public IEnumerable<HeroResult> GetBestPicksForMap(Map map, Rank rank)
        {
            string url = String.Format("{0}HeroAndMapStatistics?League={1}&Map={2}", BaseURL, (int)rank, map.Name);
            HttpClient client = new HttpClient();
            
            string answer = client.GetStringAsync(url).Result;
            UnformattedData data = UnformattedData.Create(answer, "//tbody/tr");

            IEnumerable<HeroResult> results = data.Then(i =>
            {
                string name = i.Then("td[2]/a")
                    .ExtractAttribute("title")
                    .Replace("&#39;", "'");
                
                return new HeroResult
                {
                    Hero = HeroStatic.Heroes.First(o => o.Name == name),
                    WinRate = i.Then("td[6]").ExtractContent('%')
                };
            });

            return (results);
        }

        private void ExtractArray()
        {

        }
    }
}
