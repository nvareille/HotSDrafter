using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotSDrafter.Shared
{
    public class Map
    {
        public string Name { get; set; }

        public Map() { }

        public Map(string name)
        {
            Name = name;
        }
    }

    public class MapStatic
    {
        public static Map[] Maps =
        {
            new Map("Alterac Pass"),
            new Map("Battlefield of Eternity"),
            new Map("Braxis Holdout"),
            new Map("Cursed Hollow"),
            new Map("Dragon Shire"),
            new Map("Garden of Terror"),
            new Map("Hanamura Temple"),
            new Map("Infernal Shrines"),
            new Map("Sky Temple"),
            new Map("Tomb of the Spider Queen"),
            new Map("Towers of Doom"),
            new Map("Volskaya Foundry"),
            new Map("Warhead Junction")
        };

        public static Map GetWithName(string name)
        {
            return (Maps.First(i => i.Name == name));
        }
    }
}
