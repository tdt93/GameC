using System;
using Game.Engine;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items
{

    [Serializable]
    public class MageRing : Item
    {
        private double mgcBoost = 0.2;
        public MageRing() : base("item0641")
        {
            PublicName = "Mage Ring";
            PublicTip = "extra 20% chance of boosting MagicDmg by 20%";
            GoldValue = 150;
            MgcMod = 70;
            StaMod = 70;
        }

        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (Game.Engine.Index.RNG(0, 100) < 20)
            {
                pack.MagicPowerDmg = pack.MagicPowerDmg + (int)(pack.MagicPowerDmg*mgcBoost);
            }
            return pack;
        }
    }

}

