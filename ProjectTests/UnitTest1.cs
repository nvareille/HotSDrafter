using System.Linq;
using HotSDrafter.Shared;
using HotSLogsScrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetBestPicksForMap()
        {
            Scrapper scrapper = new Scrapper();

            scrapper.GetBestPicksForMap(MapStatic.Maps.First(), Rank.Gold);
        }


        [TestMethod]
        public void GetBestMatchups()
        {
            Scrapper scrapper = new Scrapper();

            scrapper.DownloadData(HeroStatic.GetWithName("Valla"), Rank.Gold);

            var a = scrapper.GetHeroBestMatchups();
            var b = scrapper.GetHeroDuos();
            var c = scrapper.GetMaps();
            var d = scrapper.GetTalents();
        }
    }
}
