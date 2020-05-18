using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class DiamondAxe : Axe
    {
        public DiamondAxe() : base("item1262")
        {
            StrMod = 80;
            GoldValue = 120;
            PublicName = "Diamond Axe";
            PublicTip = "+60 strength points with BerserkerArmor";
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (otherItems.Contains("item0007") == true)
                pack.StrengthDmg = pack.StrengthDmg + 60;
            return pack;
        }
    }
}
