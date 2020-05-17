using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicRing
{
    class MagicRing : Item
    {
        public MagicRing() : base("item0383")
        {
            PublicName = "MagicRing";
            PublicTip = "each 5 points of your strength are converted into 1 point of bonus magic power but it costs you 1 point of your armor";
            GoldValue = 50;
        }

        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            if ( currentPlayer.Armor > 1) currentPlayer.ArmorBuff -= 1;
            currentPlayer.MagicPower += currentPlayer.Strength / 5;
        }
    }
}
