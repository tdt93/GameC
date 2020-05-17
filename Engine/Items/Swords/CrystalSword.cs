using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class CrystalSword:Sword
    {
        private int precisionBonus;
        public CrystalSword() : base("item1283")
        {
            StrMod = 15;
            PrMod = 10;
            GoldValue = 25;
            PublicName = "Crystal Sword";
            PublicTip = "Increases precision while recieving damage";
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            pack.PrecisionDmg = (100 + precisionBonus / 5) * pack.PrecisionDmg / 100;
            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            precisionBonus += pack.HealthDmg;
            
            return pack;
        }
    }
}
