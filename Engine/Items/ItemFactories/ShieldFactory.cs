using Game.Engine.Items.Shield;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class ShieldFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> shield = new List<Item>()
            {
                new TurtleShield(),
                new MirrorShield(),
                new GoldenShield(),
            };
            return shield[Index.RNG(0, shield.Count)];
        }
        public Item CreateNonMagicItem()
        {
            List<Item> shield = new List<Item>()
            {
                new TurtleShield(),
                new MirrorShield(),
                new GoldenShield(),
            };
            return shield[Index.RNG(0, shield.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            List<Item> shield = new List<Item>()
            {
                new TurtleShield(),
                new MirrorShield(),
            };
            return shield[Index.RNG(0, shield.Count)];
        }
    }
}
