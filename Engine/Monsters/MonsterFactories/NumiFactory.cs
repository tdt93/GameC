using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class NumiFactory : MonsterFactory
    {
        private int encounterNumber = 0;
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new Numi(playerLevel);
            }
            else if ( encounterNumber == 1)
            {
                encounterNumber++;
                return new Numidex(playerLevel);
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new Numi(0).GetImage();
            else if (encounterNumber == 1) return new Numidex(0).GetImage();
            else return null;
        }
    }
}
