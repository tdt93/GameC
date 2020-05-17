using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Amulet

{
    [Serializable]
    class LuckyCharmAmulet : Item
    {
        public LuckyCharmAmulet() : base("item1161")
        {
            StaMod = 10;
            PrMod = 14;
            GoldValue = 90;
            Name = "item1161";
            PublicName = "LuckyCharm";
            PublicTip = "if health damage is over 70, damage decreased by 30% or you have 20% chance to resist it completely";
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.HealthDmg > 70)
                pack.HealthDmg = 70 * pack.HealthDmg / 100;
            else if (pack.HealthDmg > 70 && Index.RNG(0, 5) == 0)
                pack.HealthDmg = 0;
            return pack;
        }
    }
}
