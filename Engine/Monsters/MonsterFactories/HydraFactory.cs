using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class HydraFactory : MonsterFactory
    {
        private int encounterNumber = 0;
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new Hydra4(playerLevel);
            }
            else if (encounterNumber == 1)
            {
                encounterNumber++;
                return new Hydra3(playerLevel);
            }
            else if (encounterNumber == 2) 
            {
                encounterNumber++;
                return new Hydra2(playerLevel);
            }
            else if (encounterNumber == 3)
            {
                encounterNumber++;
                return new Hydra1(playerLevel);
            }
            else return null; 
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new Hydra4(0).GetImage();
            else if (encounterNumber == 1) return new Hydra3(0).GetImage();
            else if (encounterNumber == 2) return new Hydra2(0).GetImage();
            else if (encounterNumber == 3) return new Hydra1(0).GetImage();
            else return null;
        }
    }
}
