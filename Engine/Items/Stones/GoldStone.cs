using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class GoldStone : Item
    {
        public GoldStone() : base("item0852")
        {
            PublicName = "Gold Stone";
            GoldValue = 50;
            ArMod = 1;
        }
    }
}
