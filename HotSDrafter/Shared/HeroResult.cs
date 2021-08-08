using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotSDrafter.Shared
{
    public class HeroResult
    {
        /*Talents*/
        public Hero Hero;
        public IEnumerable<HeroWinrate> Matchups;
        public IEnumerable<HeroWinrate> Duos;
        public IEnumerable<MapWinrate> Maps;
        public IEnumerable<TalentWinrate> Talents;

    }
}
