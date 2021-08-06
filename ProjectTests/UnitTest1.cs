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
        public void TestMethod1()
        {
            Scrapper scrapper = new Scrapper();

            scrapper.GetBestPicksForMap(MapStatic.Maps.First(), Rank.Gold);
        }
    }
}
