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
                new CrystalSword(),
                new InfinitySword(),
                new MoonlightSword(),
                new BasicSword()
            };
            return basicSword[Index.RNG(0, basicSword.Count)];
        }
        public Item CreateNonMagicItem()
        {
            List<Item> basicSword = new List<Item>()
            {
                new CrystalSword(),
                new InfinitySword(),
                new MoonlightSword(),
                new BasicSword()
            };
            return basicSword[Index.RNG(0, basicSword.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            return null;
        }
    }
}
