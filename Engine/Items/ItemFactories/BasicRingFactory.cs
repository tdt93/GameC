using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items.BasicArmor;
using Game.Engine.Items.BasicRing;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class BasicRingFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> basicRing = new List<Item>()
            {
                new HealthRing(),
                new MagicRing(),
                new ArmorRing()
            };
            return basicRing[Index.RNG(0, basicRing.Count)];
        }
        public Item CreateNonMagicItem()
        {
            List<Item> basicRing = new List<Item>()
            {
                new HealthRing(),
                new ArmorRing()
            };
            return basicRing[Index.RNG(0, basicRing.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            List<Item> basicRing = new List<Item>()
            {
                new MagicRing(),
                new ArmorRing()
            };
            return basicRing[Index.RNG(0, basicRing.Count)];
        }
    }
}
