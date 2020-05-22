using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items.OsirisArmor;


namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class OsirisFactory : ItemFactory
    {
        // produce items from OsirisArmor directory
        public Item CreateItem()
        {
            List<Item> osirisArmor = new List<Item>()
            {
                new OsirisEye(),
                new OsirisSabre(),
                new OsirisStaff(),
            };
            return osirisArmor[Index.RNG(0, osirisArmor.Count)];
        }
        public Item CreateNonMagicItem() //Osiris Staff only works for magic users
        {
            
            List<Item> osirisArmor = new List<Item>()
            {
                new OsirisEye(),
                new OsirisSabre(),
              
            };
            return osirisArmor[Index.RNG(0, osirisArmor.Count)];
        }
        public Item CreateNonWeaponItem() //Osiris Sabre only works for physical damage dealers
        {
            
            List<Item> osirisArmor = new List<Item>()
            {
                new OsirisEye(),
                new OsirisStaff(),
              
            };
            return osirisArmor[Index.RNG(0, osirisArmor.Count)];
        }
    }
}
