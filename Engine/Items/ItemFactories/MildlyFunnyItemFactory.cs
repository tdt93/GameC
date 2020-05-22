using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;
using Game.Engine.Items.BasicArmor;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class MildlyFunnyItemFactory:ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> unfunnyItems = new List<Item>()
            {
                new MagnificentCape(),
                new StylisedFlatIron(),
                new MagiciansCan(),
                new SingleUseArmor(false)

            };
            return unfunnyItems[Index.RNG(0, unfunnyItems.Count)];
        }
        public Item CreateNonMagicItem()
        {
            return CreateItem();
        }
        public Item CreateNonWeaponItem()
        {           
            List<Item> unfunnyItems = new List<Item>()
            {
                new MagnificentCape(),                
                new SingleUseArmor(false)
            };
            return unfunnyItems[Index.RNG(0, unfunnyItems.Count)];
        }
    }
}
