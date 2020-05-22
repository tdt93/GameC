using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.AmuletsAndPotions
{
    [Serializable]
    class AmuletOfNegotiation:Item
    {
        public AmuletOfNegotiation():base("item0540")
        {
            PublicName = "AmuletOfNegotiation";
            PublicTip = "If You have less than 50 HP and more than 0, enemy will accept surrender for 200 gold";
            GoldValue = 300;
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            if(currentPlayer.Health <= 50)
            {     
                if(currentPlayer.Gold >= 200)
                {
                    currentPlayer.Gold -= 200;
                    currentPlayer.Stamina = 0;
                }
            }
        }


    }
}
