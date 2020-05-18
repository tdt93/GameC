using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.AmuletsAndPotions
{
    [Serializable]
    class AmuletOfHealing:Item
    {
        public AmuletOfHealing() : base("item0542")
        {
            PublicName = "AmuletOfHealing";
            PublicTip = "After you get any damage, receive 10 HP back.";
            GoldValue = 300;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if(pack.HealthDmg>0) pack.HealthDmg = pack.HealthDmg - 10;
            return pack;
        }
    }
}
