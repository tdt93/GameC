using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class MoonlightSword:Sword
    {
        public MoonlightSword() : base("item1281")
        {
            StrMod = 10;
            PrMod = 4;
            GoldValue = 30;
            PublicName = "Moonlight Sword";
            PublicTip = "Additional damage based on health";
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.StrengthBuff += StrMod + currentPlayer.Health / 5;
        }
    }
}
