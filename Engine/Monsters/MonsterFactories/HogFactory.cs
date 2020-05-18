using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class HogFactory : MonsterFactory
    {
        private int encounterNumber = 0;
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new Hog(playerLevel);
            }
            else if (encounterNumber == 1)
            {
                encounterNumber++;
                return new HolyHog(playerLevel);
            }
            else if (encounterNumber == 2)
            {
                encounterNumber++;
                return new HellHog(playerLevel);
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new Hog(0).GetImage();
            else if (encounterNumber == 1) return new HolyHog(0).GetImage();
            else if (encounterNumber == 2) return new HellHog(0).GetImage();
            else return null;
        }
    }
}
