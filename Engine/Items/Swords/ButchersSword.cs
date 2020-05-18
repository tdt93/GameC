using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class ButchersSword:Sword
    {
        public ButchersSword() : base("item0620")
        {
            StrMod = 50;
            PrMod = 20;
            GoldValue = 120;
            PublicName = "Butcher's Sword";
            PublicTip = "A lot of animal souls screams from this sword (30% chance for additional damage)";
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (Index.RNG(0,101)<30)
            {
                pack.HealthDmg += 50; 
            }
            return pack;
        }
    }
}
