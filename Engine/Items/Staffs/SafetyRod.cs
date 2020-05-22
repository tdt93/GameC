using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Skills;

namespace Game.Engine.Items
{
    [Serializable]
    class SafetyRod:Staff
    {
        private int safeLevel;
        private static int usability = 1;
        public SafetyRod() : base("item0181")
        {
            GoldValue = 500;
            PublicTip = "can save you from an instant death... at least a few times";
            PublicName = "Safety Rod";
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            safeLevel = currentPlayer.Health;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.HealthDmg >= safeLevel)
            {
                pack.HealthDmg = pack.HealthDmg * usability/10;
                usability += 1;
            }
            return pack;
        }
    }
}
