using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class DragonFactory : MonsterFactory
    {
        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber == 0) // if this is the first time, return a Fire Dragon
            {
                encounterNumber++;
                return new FireDragon(playerLevel + 5);
            }
            else if (encounterNumber == 1) // if this is the second time, return a Death Dragon
            {
                encounterNumber++;
                return new DeathDragon(playerLevel + 6);
            }
            else return null; // no more Dragons to fight
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new FireDragon(0).GetImage();
            else if (encounterNumber == 1) return new DeathDragon(0).GetImage();
            else return null;
        }
    }
}
