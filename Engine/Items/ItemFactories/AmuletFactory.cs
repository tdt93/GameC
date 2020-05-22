using System;
using System.Collections.Generic;
using Game.Engine.Items.Amulet;
using Game.Engine.Items.AmuletsAndPotions;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class AmuletFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> amulet = new List<Item>()
            {
                // x2 
                new LuckyCharmAmulet(),
                new LuckyCharmAmulet(),
                new MageDuelistAmulet(),
                new MageDuelistAmulet(),
                new SupportingAmulet(),
                new SupportingAmulet(),
                new AntiPoisonAmulet(),
                new AntiPoisonAmulet(),
                new FireproofAmulet(),
                new FireproofAmulet(),
                // x1
                new AmuletOfHealing(),
                new AmuletOfNegotiation()
            };
            return amulet[Index.RNG(0, amulet.Count)];
        }
        public Item CreateNonMagicItem()
        {
           
            List<Item> amulet = new List<Item>()
            {
                 // x2
                new LuckyCharmAmulet(),
                new LuckyCharmAmulet(),
                new MageDuelistAmulet(),
                new MageDuelistAmulet(),
                new SupportingAmulet(),
                new SupportingAmulet(),
                new AntiPoisonAmulet(),
                new AntiPoisonAmulet(),
                new FireproofAmulet(),
                new FireproofAmulet(),
                 // x1
                 new AmuletOfHealing(),
                 new AmuletOfNegotiation()
            };
            return amulet[Index.RNG(0, amulet.Count)];
        }
        public Item CreateNonWeaponItem()
        {
           
            List<Item> amulet = new List<Item>()
            {
                // x2
				new LuckyCharmAmulet(),
                new SupportingAmulet(),
                new MageDuelistAmulet(),
                new AntiPoisonAmulet(),
                new LuckyCharmAmulet(),
                new SupportingAmulet(),
                new MageDuelistAmulet(),
                new AntiPoisonAmulet(),
                // x1
                new AmuletOfHealing(),
                new AmuletOfNegotiation()
            };
            return amulet[Index.RNG(0, amulet.Count)];
        }
    }
}
