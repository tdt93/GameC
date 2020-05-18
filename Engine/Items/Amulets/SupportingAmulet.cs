using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Amulet
{
    [Serializable]
    class SupportingAmulet : Item
    {
       
        public SupportingAmulet() : base("item1162") 
        {
            StrMod = 15;
            PrMod = 8;
            GoldValue = 80;
            Name = "item1162";
            PublicName = "SupportingAmulet";
            PublicTip = "extra 5 points are added to each statistic when the average of all of them together is smaller than 80" ;
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            if ((currentPlayer.StrengthBuff + currentPlayer.StaminaBuff + currentPlayer.PrecisionBuff + currentPlayer.HealthBuff + currentPlayer.ArmorBuff) / 5 < 80)
                currentPlayer.StrengthBuff += StrMod + 5;
            currentPlayer.StaminaBuff += StaMod + 5;
            currentPlayer.PrecisionBuff += PrMod + 5;
            currentPlayer.HealthBuff += HpMod + 5;
            currentPlayer.ArmorBuff += ArMod + 5; 
     

        }
    }
}
