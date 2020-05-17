using System;
using System.Collections.Generic;
using Game.Engine.Items.Amulet;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class AmuletFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> amulet = new List<Item>()
            {
                new LuckyCharmAmulet(),
                new MageDuelistAmulet(),
                new SupportingAmulet(),

            };
            return amulet[Index.RNG(0, amulet.Count)];
        }
        public Item CreateNonMagicItem()
        {
           
            List<Item> amulet = new List<Item>()
            {
                 new LuckyCharmAmulet(),
                 new SupportingAmulet()
        };
            return amulet[Index.RNG(0, amulet.Count)];
        }
        public Item CreateNonWeaponItem()
        {
           
            List<Item> amulet = new List<Item>()
            {
				new LuckyCharmAmulet(),
                new SupportingAmulet(),
                new MageDuelistAmulet()
            };
            return amulet[Index.RNG(0, amulet.Count)];
        }
    }
}
