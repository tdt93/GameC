using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items
{
    [Serializable]
    class StylisedFlatIron:Sword
    {
        public StylisedFlatIron() : base("item0582")
        {
            PublicName = "Stylised flat iron";
            PublicTip = "Very stylish good price my friend. Original sword medieval reenactment. very sharp. Give 10% more strength";
            GoldValue = 10;
        }
        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            StrMod = Convert.ToInt32(currentPlayer.Strength * 0.1);
        }
    }
}
