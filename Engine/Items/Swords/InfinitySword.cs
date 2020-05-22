using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Game.Engine.Items
{
    [Serializable]
    class InfinitySword:Sword
    {
        public InfinitySword() : base("item1282")
        {
            StrMod = 8;
            PrMod = 7;
            GoldValue = 50;
            PublicName = "Infinity Sword";
            PublicTip = "Can crit 2 times in one attack. Each crit has 50% chance of occuring and dealing additional damage equal to half of normal damage";
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (Index.RNG(0, 100) < 50)
            {
                pack.HealthDmg = 2 * pack.HealthDmg;
                pack.CustomText = "Critical! Additional (" +  pack.HealthDmg / 2 + " damage)";
            }
            else
            {
                pack.CustomText = "Crit misses!";
            }
            return pack;
        }
    }
}
