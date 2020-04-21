using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicArmor
{
    [Serializable]
    class BerserkerArmor : Item
    {
        // special passive: each time you lose health, receive a bonus to physical damage you deal

        private int berserkerBonus;
        public BerserkerArmor() : base("item0007")
        {
            PublicName = "BerserkerArmor";
            GoldValue = 40;
            arMod = 20;
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "stab" || pack.DamageType == "incised")
            {
                pack.HealthDmg = (100 + berserkerBonus / 4) * pack.HealthDmg / 100;
            }
            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            berserkerBonus += pack.HealthDmg;
            return pack;
        }
    }
}
