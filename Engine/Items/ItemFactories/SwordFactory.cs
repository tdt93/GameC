using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class SwordFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> basicSword = new List<Item>()
            {
                // x3
                new BasicSword(),
                new BasicSword(),
                new BasicSword(),
                // x1
                new CrystalSword(),
                new InfinitySword(),
                new MoonlightSword(),
                new DemonSword(),
                new GreatSword(),
                new Katana(),
                new ButchersSword(),
            };
            return basicSword[Index.RNG(0, basicSword.Count)];
        }
        public Item CreateNonMagicItem()
        {
            List<Item> basicSword = new List<Item>()
            {
                // x3
                new BasicSword(),
                new BasicSword(),
                new BasicSword(),
                // x1
                new CrystalSword(),
                new InfinitySword(),
                new MoonlightSword(),
                new DemonSword(),
                new GreatSword(),
                new Katana(),
                new ButchersSword(),
            };
            return basicSword[Index.RNG(0, basicSword.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            return null;
        }
    }
}
