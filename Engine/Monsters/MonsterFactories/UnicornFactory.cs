using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class UnicornFactory:MonsterFactory
    {
        private int encounterNumber = 0; 
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new Unicorn(playerLevel + encounterNumber);
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new Unicorn(0).GetImage();
            else return null;
        }
    }
}
