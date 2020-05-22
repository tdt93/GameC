using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class DemonSword : Sword
    {
        public DemonSword() : base("item0943")
        {
            StrMod = 75;
            PrMod = 25;
            HpMod = 100;
            GoldValue = 200;
            PublicName = "Demon Sword";
            PublicTip = "Converts half of your strength to your health";
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.HealthBuff += HpMod + currentPlayer.Strength / 2;
        }
    }
}
