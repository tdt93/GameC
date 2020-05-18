using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicRing
{
    [Serializable]
    class HealthRing : Item
    {
        public HealthRing() : base("item0381")
        {
            PublicName = "HealthRing";
            PublicTip = "gives you +50 health if you don't have any magic power";
            GoldValue = 60;
            HpMod = 50;
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            if (currentPlayer.MagicPower == 0) currentPlayer.HealthBuff += HpMod;
        }
    }
}
