using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class IceDragonFactory: MonsterFactory
    {
        //this factory will return egg and when it is cracked will return dragon
        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create(int playerLevel)
        {

            if (encounterNumber == 0) // if this is the first time, return an egg
            {
                encounterNumber++;
                return new IceEgg(playerLevel);
            }
            else if (encounterNumber == 1) // if this is the second time, return a ice dragon
            {
                encounterNumber++;
                return new IceDragon(playerLevel);
            }
            else return null; 

        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new IceEgg(0).GetImage();
            else if (encounterNumber == 1) return new IceDragon(0).GetImage();
            else return null;
        }
    }
}
