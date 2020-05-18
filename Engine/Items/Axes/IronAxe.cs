using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class IronAxe : Axe
    {
        public IronAxe() : base("item1260")
        {
            StrMod = 25;
            GoldValue = 30;
            PublicName = "Iron Axe";
            PublicTip = "+30 strength points with SteelArmor";
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (otherItems.Contains("item0005") == true)
                pack.StrengthDmg = pack.StrengthDmg + 30;
            return pack;
        }
    }
}
