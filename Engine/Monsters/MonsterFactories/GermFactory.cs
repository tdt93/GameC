using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class GermFactory: MonsterFactory
    {
        // this factory produces only infinity of germs
        // rewritten to avoid permanently blocking passages
        private bool generateNext = true;
        public override Monster Create(int playerLevel)
        {
            if (generateNext) return new GiantGerm(playerLevel);
            return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (Index.RNG(0, 10) > 7) generateNext = false;
            if (generateNext) return new GiantGerm(0).GetImage();
            else return null;
        }
    }
}
    
