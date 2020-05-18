using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class SingleUseArmor:Item
    {
        private static bool used = false;
        public SingleUseArmor() : base("item0584")
        {
            PublicName = "Single-use shield (Biodegradable!)";
            PublicTip = "A very fine, if temporary, protection. Deflects 100% of damage from one attack, and stops deflecting anything (permanently)";
            GoldValue = 20;
        }
		public SingleUseArmor(bool value) : base("item0584")
        {
            PublicName = "Single-use shield (Biodegradable!)";
            PublicTip = "A very fine, if temporary, protection. Deflects 100% of damage from one attack, and stops deflecting anything (permanently)";
            GoldValue = 20;
			used = value;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (!used&&pack.HealthDmg!=0)
            {
                pack.ArmorDmg = 0;pack.HealthDmg = 0;pack.MagicPowerDmg = 0;pack.PrecisionDmg = 0;pack.StrengthDmg = 0;
                pack.CustomText = "The shield has absorbed all of the damage. It is now broken";
                PublicName = "(broken)";
                used = true;
            }
            return base.ModifyDefensive(pack, otherItems);
        }
    }
}
