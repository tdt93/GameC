using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class Katana : Sword
    {
        public Katana() : base("item0942")
        {
            StrMod = 30;
            PrMod = 150;
            GoldValue = 60;
            PublicName = "Katana";
            PublicTip = "Very fast, precise sword. Converts 1/3 of your precision to strength";
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.StrengthBuff += StrMod + currentPlayer.Precision / 3;
        }
    }
}
