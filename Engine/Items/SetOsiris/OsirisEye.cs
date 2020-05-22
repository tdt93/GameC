using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.OsirisArmor
{
    [Serializable]
    class OsirisEye : Item
    {
        //strong, bonus item + very useful with osirissabre/osirisstaff
        public OsirisEye() : base("item0822")
        {
            MgcMod = 10;
            HpMod = 10;
            PrMod = 10;
            ArMod = 10;
            GoldValue = 50;
            PublicTip = "can be combined with OsirisSabre and Osiris Staff for powerful effects";
            PublicName = "OsirisEye";

        }

    }
}
