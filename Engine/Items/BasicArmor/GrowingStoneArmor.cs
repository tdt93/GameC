using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicArmor
{
    [Serializable]
    class GrowingStoneArmor : Item
    {
        // armor with magic crystals that can grow stronger from the user's magic aura
        public GrowingStoneArmor() : base("item0008") 
        { 
            PublicName = "GrowingStoneArmor";
            GoldValue = 40;
            arMod = 20;
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.ArmorBuff += arMod + currentPlayer.MagicPower / 4;
        }
    }
}
