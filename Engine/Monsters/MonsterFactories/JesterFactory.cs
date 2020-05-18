using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class JesterFactory : MonsterFactory
    {
        private int encounterNumber = 0;
        private int roll;
        public void Roll()
        {
            Random RNG = new Random();
            roll = RNG.Next(4);
        }
        public override Monster Create(int playerLevel)
        {
            Roll();
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new Jester(playerLevel);
            }
            if (encounterNumber == 1)
            {
                encounterNumber++;
                if(roll==1)
                {
                    return new Jester(playerLevel);
                }
                else if (roll == 2)
                {
                    return new Bat(playerLevel);
                }
                else if (roll == 3)
                {
                    return new Rat(playerLevel);
                }
                else
                {
                    return new Elementalist(playerLevel);
                }
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0)
            {
                return new Jester(0).GetImage();
            }
            else if (encounterNumber == 1)
            {
                Roll();
                if (roll == 1)
                {
                    return new Jester(0).GetImage();
                }
                else if (roll == 2)
                {
                    return new Bat(0).GetImage();
                }
                else if (roll == 3)
                {
                    return new Rat(0).GetImage();
                }
                else
                {
                    return new Elementalist(0).GetImage();
                }
            }
            else return null;
        }
    }
}
