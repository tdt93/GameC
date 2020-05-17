using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class EgyptMonstersFactory : MonsterFactory
    { 
        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber == 0) 
            {
                encounterNumber++;
                return new ArabicSkeleton(playerLevel);
            }
            else if (encounterNumber == 1) 
            {
                encounterNumber++;
                return new AnubisGuard(playerLevel);
            }
            else return null; 
        }
        public override System.Windows.Controls.Image Hint() 
        {
            if (encounterNumber == 0) return new ArabicSkeleton(0).GetImage();
            else if (encounterNumber == 1)
            {
                return new AnubisGuard(0).GetImage();
            }
            else return null;
        }
    }
}
