using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class ThugFactory:MonsterFactory
    {
        private int encounterNumber = 0;

        public override Monster Create(int playerLevel)
        {
            if (encounterNumber == 0)
            {
                int chance = Index.RNG(0, 101);
                if (chance > 60) //40 percent chance for Thug Survivor
                    encounterNumber++;
                else
                    encounterNumber = 2;
                return new Thug(playerLevel);
            }
            else if (encounterNumber == 1)
            {
                encounterNumber++;
                return new ThugSurvivor(playerLevel);
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new Thug(0).GetImage();
            else if (encounterNumber == 1) return new ThugSurvivor(0).GetImage();
            else return null;
        }
    }
}
