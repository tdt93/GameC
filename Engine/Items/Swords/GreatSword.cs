using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class GreatSword : Sword
    {
        public GreatSword() : base("item0940")
        {
            GoldValue = 150;
            PublicName = "Great Sword";
            PublicTip = "Doubles your strength";
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.StrengthBuff += StrMod + currentPlayer.Strength;
        }
    }
}
