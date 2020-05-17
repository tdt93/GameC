using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicRing
{
    [Serializable]
    class ArmorRing : Item
    {
        public ArmorRing() : base("item0382")
        {
            PublicName = "ArmorRing";
            PublicTip = "extra 20 % reduction of any damage but it costs you 1 point of your strength";
            GoldValue = 60;
            ArMod = 20;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "fire" || pack.DamageType == "water" || pack.DamageType == "air" || pack.DamageType == "earth" || pack.DamageType == "stab" || pack.DamageType == "cut" || pack.DamageType == "incised")
            {
                pack.HealthDmg = 80 * pack.HealthDmg / 100 ;
            }
            return pack;
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            if (currentPlayer.Strength > 1) currentPlayer.StrengthBuff -= 1;
        }
    }
}
