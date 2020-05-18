using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class SilverAxe : Axe
    {
        public SilverAxe() : base("item1261")
        {
            StrMod = 50;
            GoldValue = 80;
            PublicName = "Silver Axe";
            PublicTip = "+45 strength points with AntiMagicArmor";
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (otherItems.Contains("item0006") == true)
                pack.StrengthDmg = pack.StrengthDmg + 45;
            return pack;
        }
    }
}
