using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class BatFactory : MonsterFactory
    {
        private int encounterNumber = 0; 
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber == 0) 
            {
                encounterNumber++;
                int rng = Index.RNG(1, 101);
                if (rng > 25)
                    encounterNumber++;
                return new Bat(playerLevel);
            }
            else if (encounterNumber == 1) 
            {
                encounterNumber++;
                return new VampireKnight(playerLevel);
            }
            else return null; 
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new Bat(0).GetImage();
            else if (encounterNumber == 1) return new VampireKnight(0).GetImage();
            else return null;
        }
    }
}
