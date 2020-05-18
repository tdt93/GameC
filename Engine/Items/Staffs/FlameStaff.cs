using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class FlameStaff:Staff
    {
        public FlameStaff() : base("item0182")
        {
            MgcMod = 50;
            GoldValue = 60;
            PublicTip = "each level is converted into 10 points of health";
            PublicName = "Flame Staff";
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.Health += 10 * currentPlayer.Level;
            currentPlayer.MagicPowerBuff += MgcMod;
        }
    }
}
