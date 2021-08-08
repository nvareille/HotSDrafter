using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotSDrafter.Shared
{
    public class DraftAdvice
    {
        public IEnumerable<HeroWinrate> MapPicks { get; set; } = new List<HeroWinrate>();
        public IEnumerable<HeroWinrate> Counters { get; set; } = new List<HeroWinrate>();

        public void Filter(params IEnumerable<Hero>[] toRemove)
        {
            foreach (IEnumerable<Hero> remove in toRemove)
            {
                MapPicks = InnerFilter(MapPicks, remove);
                Counters = InnerFilter(Counters, remove);
            }
        }

        private IEnumerable<HeroWinrate> InnerFilter(IEnumerable<HeroWinrate> result, IEnumerable<Hero> toRemove)
        {
            return (result.Where(i => toRemove.All(o => o.Name != i.Hero.Name)));
        }
    }
}
