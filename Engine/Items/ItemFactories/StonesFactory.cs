using System;
using System.Collections.Generic;
using Game.Engine.Items.BasicArmor;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class StonesFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> stones = new List<Item>()
            {
                new GoldStone(),
                new AirStone(),
                new AntiMagicHealthStone(),
                new EarthStone(),
                new FireStone(),
                new WaterStone()
            };
            return stones[Index.RNG(0, stones.Count)];
        }
        public Item CreateNonMagicItem()
        {
            List<Item> stones = new List<Item>()
            {
                new GoldStone(),
            };
            return stones[Index.RNG(0, stones.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            List<Item> stones = new List<Item>()
            {
                new GoldStone(),
                new AirStone(),
                new AntiMagicHealthStone(),
                new EarthStone(),
                new FireStone(),
                new WaterStone()
            };
            return stones[Index.RNG(0, stones.Count)];
        }
    }
}
