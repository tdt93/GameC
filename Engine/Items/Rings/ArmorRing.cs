using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicRing
{
    [Serializable]
    class ArmorRing : Item
    {
        public ArmorRing() : base("item0382")
        {
            PublicName = "ArmorRing";
            PublicTip = "extra 20 % reduction of any damage but -10 strength";
            GoldValue = 60;
            ArMod = 20;
            StrMod = -10;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            pack.HealthDmg = 80 * pack.HealthDmg / 100;
            return pack;
        }
    }
}
