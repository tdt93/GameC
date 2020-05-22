using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class ElvenRingFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> rings = new List<Item>()
            {
                new Nenya(),
                new Narya(),
                new Vilya()
            };
            return rings[Index.RNG(0, rings.Count)];
        }
        public Item CreateNonMagicItem()
        {

            return null;
        }
        public Item CreateNonWeaponItem()
        {
          
            List<Item> rings = new List<Item>()
            {
                new Nenya(),
                new Narya(),
                new Vilya()
            };
            return rings[Index.RNG(0, rings.Count)];
        }
    }
}
