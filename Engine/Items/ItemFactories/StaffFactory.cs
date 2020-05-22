using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class StaffFactory:ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> Staff = new List<Item>()
            {
                new FlameStaff(),
                new SafetyRod(),
                new WindStaff()
            };
            return Staff[Index.RNG(0, Staff.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            List<Item> Staff = new List<Item>()
            {
                new FlameStaff(),
                new SafetyRod(),
                new WindStaff()
            };
            return Staff[Index.RNG(0, Staff.Count)];
        }
        public Item CreateNonMagicItem() { return null; }
    }
}
