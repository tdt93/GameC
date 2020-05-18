using System;
using Game.Engine;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items
{

    [Serializable]
    public class InfinityRings : Item
    {
        private double boost = 0.3;
        public InfinityRings() : base("item0642")
        {
            PublicName = "Infinity Rings";
            PublicTip = "boost all your stats (not strength!!!) by 30%";
            GoldValue = 200;    
        }

        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.HealthBuff += (int)(currentPlayer.Health*boost);
            currentPlayer.ArmorBuff += (int)(currentPlayer.Armor * boost);
            currentPlayer.PrecisionBuff += (int)(currentPlayer.Precision * boost);
            currentPlayer.MagicPowerBuff += (int)(currentPlayer.MagicPower * boost);
            currentPlayer.StaminaBuff += (int)(currentPlayer.Stamina * boost);
        }

       
    }

}

