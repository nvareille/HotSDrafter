using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotSDrafter.Shared
{
    public class Hero
    {
        public string Name { get; set; }
        public HeroRole[] Roles { get; set; }
        public string ImageUrl { get; set; }

        public Hero() { }

        public Hero(string name, params HeroRole[] roles)
        {
            Name = name;
            Roles = roles;
            ImageUrl = "https://www.hotslogs.com/Images/Heroes/Portraits/" + FormatName() + ".png";
        }

        private string FormatName()
        {
            return (Name
                .Replace(" ", "")
                .Replace("'", "")
                .Replace(".", "")
                .Replace("-", ""));
        }
    }

    public class HeroStatic
    {
        public static Hero[] Heroes = new Hero[]
        {
            new Hero("Abathur", HeroRole.Support),
            new Hero("Alarak", HeroRole.MeleeAssassin),
            new Hero("Alexstrasza", HeroRole.Healer),
            new Hero("Ana", HeroRole.Healer),
            new Hero("Anduin", HeroRole.Healer),
            new Hero("Anub'arak", HeroRole.Tank),
            new Hero("Artanis", HeroRole.Bruiser),
            new Hero("Arthas", HeroRole.Tank, HeroRole.Bruiser),
            new Hero("Auriel", HeroRole.Healer),
            new Hero("Azmodan", HeroRole.RangedAssassin),
            new Hero("Blaze", HeroRole.Tank, HeroRole.Bruiser),
            new Hero("Brightwing", HeroRole.Healer),
            new Hero("Cassia", HeroRole.RangedAssassin),
            new Hero("Chen", HeroRole.Bruiser),
            new Hero("Cho", HeroRole.Tank),
            new Hero("Chromie", HeroRole.RangedAssassin),
            new Hero("D.Va", HeroRole.Bruiser),
            new Hero("Deathwing", HeroRole.Bruiser),
            new Hero("Deckard", HeroRole.Healer),
            new Hero("Dehaka", HeroRole.Bruiser),
            new Hero("Diablo", HeroRole.Tank),
            new Hero("E.T.C.", HeroRole.Tank, HeroRole.Bruiser),
            new Hero("Falstad", HeroRole.RangedAssassin, HeroRole.Bruiser),
            new Hero("Fenix", HeroRole.RangedAssassin),
            new Hero("Gall", HeroRole.RangedAssassin),
            new Hero("Garrosh", HeroRole.Tank),
            new Hero("Gazlowe", HeroRole.Bruiser),
            new Hero("Genji", HeroRole.RangedAssassin),
            new Hero("Greymane", HeroRole.RangedAssassin),
            new Hero("Gul'dan", HeroRole.RangedAssassin),
            new Hero("Hanzo", HeroRole.RangedAssassin),
            new Hero("Hogger", HeroRole.Bruiser),
            new Hero("Illidan", HeroRole.MeleeAssassin, HeroRole.Bruiser),
            new Hero("Imperius", HeroRole.Bruiser, HeroRole.Tank),
            new Hero("Jaina", HeroRole.RangedAssassin),
            new Hero("Johanna", HeroRole.Tank),
            new Hero("Junkrat", HeroRole.RangedAssassin),
            new Hero("Kael'thas", HeroRole.RangedAssassin),
            new Hero("Kel'Thuzad", HeroRole.RangedAssassin),
            new Hero("Kerrigan", HeroRole.MeleeAssassin, HeroRole.Bruiser),
            new Hero("Kharazim", HeroRole.Healer),
            new Hero("Leoric", HeroRole.Bruiser),
            new Hero("Li Li", HeroRole.Healer),
            new Hero("Li-Ming", HeroRole.RangedAssassin),
            new Hero("Lt. Morales", HeroRole.Healer),
            new Hero("Lunara", HeroRole.RangedAssassin),
            new Hero("Lúcio", HeroRole.Healer),
            new Hero("Maiev", HeroRole.MeleeAssassin),
            new Hero("Mal'Ganis", HeroRole.Tank),
            new Hero("Malfurion", HeroRole.Healer),
            new Hero("Malthael", HeroRole.Bruiser),
            new Hero("Medivh", HeroRole.Support),
            new Hero("Mei", HeroRole.Tank),
            new Hero("Mephisto", HeroRole.RangedAssassin),
            new Hero("Muradin", HeroRole.Tank),
            new Hero("Murky", HeroRole.MeleeAssassin, HeroRole.Sololane),
            new Hero("Nazeebo", HeroRole.RangedAssassin, HeroRole.Sololane),
            new Hero("Nova", HeroRole.RangedAssassin),
            new Hero("Orphea", HeroRole.RangedAssassin),
            new Hero("Probius", HeroRole.RangedAssassin, HeroRole.Sololane),
            new Hero("Qhira", HeroRole.MeleeAssassin, HeroRole.Sololane),
            new Hero("Ragnaros", HeroRole.Bruiser),
            new Hero("Raynor", HeroRole.RangedAssassin),
            new Hero("Rehgar", HeroRole.Healer),
            new Hero("Rexxar", HeroRole.Bruiser),
            new Hero("Samuro", HeroRole.MeleeAssassin, HeroRole.Sololane),
            new Hero("Sgt. Hammer", HeroRole.RangedAssassin),
            new Hero("Sonya", HeroRole.Bruiser),
            new Hero("Stitches", HeroRole.Tank),
            new Hero("Stukov", HeroRole.Healer),
            new Hero("Sylvanas", HeroRole.RangedAssassin),
            new Hero("Tassadar", HeroRole.RangedAssassin),
            new Hero("The Butcher", HeroRole.MeleeAssassin, HeroRole.Sololane),
            new Hero("The Lost Vikings", HeroRole.Support, HeroRole.Sololane),
            new Hero("Thrall", HeroRole.Bruiser),
            new Hero("Tracer", HeroRole.RangedAssassin),
            new Hero("Tychus", HeroRole.RangedAssassin),
            new Hero("Tyrael", HeroRole.Tank, HeroRole.Sololane),
            new Hero("Tyrande", HeroRole.Healer),
            new Hero("Uther", HeroRole.Healer, HeroRole.Tank),
            new Hero("Valeera", HeroRole.MeleeAssassin),
            new Hero("Valla", HeroRole.RangedAssassin),
            new Hero("Varian", HeroRole.Bruiser, HeroRole.Tank, HeroRole.MeleeAssassin),
            new Hero("Whitemane", HeroRole.Healer),
            new Hero("Xul", HeroRole.Bruiser),
            new Hero("Yrel", HeroRole.Bruiser),
            new Hero("Zagara", HeroRole.RangedAssassin, HeroRole.Sololane),
            new Hero("Zarya", HeroRole.Support, HeroRole.Sololane),
            new Hero("Zeratul", HeroRole.MeleeAssassin),
            new Hero("Zul'jin", HeroRole.RangedAssassin),
        };
    }
}
