using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Amulet
{
    [Serializable]
    class MageDuelistAmulet : Item
    {
        public MageDuelistAmulet() : base("item1160")
        {
            MgcMod = 20;
            PrMod = 8;
            GoldValue = 80;
            Name = "item1160";
            PublicName = "MagicDuelistAmulet";
            PublicTip = "if you own AntiMagicArmor, you receive an extra bonus to magic attacks";
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (otherItems.Contains("AntiMagicArmor") == true)
                pack.MagicPowerDmg += Index.RNG(1, 9);
            return pack;
        }
    }
    }