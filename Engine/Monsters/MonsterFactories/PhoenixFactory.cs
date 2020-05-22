using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class PhoenixFactory:MonsterFactory
    {
        // rewritten to avoid permanently blocking passages
        private bool generateNext = true;
        private int encounterNumber = 0; 
        public override Monster Create(int playerLevel)
        {
            encounterNumber++;
            if (generateNext) return new Phoenix(playerLevel + encounterNumber);
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (Index.RNG(0, 10) > 7) generateNext = false;
            if (generateNext) return new Phoenix(0).GetImage();
            else return null;
        }
    }
}
