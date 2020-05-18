using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items
{
    [Serializable]
    class MagnificentCape:Item
    {
        public MagnificentCape() : base("item0583")
        {
            PublicName = "Magnificent cape of majestic wind fluttering";
            PublicTip = "A cape, that flutters majestically in battle. It increases magic power by 40%, but decreases stamina by 10%";
            GoldValue = 70;
        }
        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.StaminaBuff += -Convert.ToInt32(0.1* currentPlayer.Stamina);
            currentPlayer.MagicPowerBuff += Convert.ToInt32(0.4 * currentPlayer.MagicPower);
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            pack.CustomText += " The cape flutters majestically";
            return base.ModifyOffensive(pack, otherItems);
        }
    }
}
