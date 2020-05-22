using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class SpiderFactory : MonsterFactory
    {
        private int a = 0;
        public override Monster Create(int playerLevel)
        {
            if (a == 0)
            {
                a++;
                return new Spider(playerLevel);
            }
            
            else if (a == 1)
            {
                a++;
                return new Spider(playerLevel);
            }

            else if (a == 2)
            {
                a++;
                return new Tarantula(playerLevel);
            }

            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (a == 0) return new Spider(0).GetImage();
            
            else if (a == 1) return new Spider(0).GetImage();

            else if (a == 2) return new Tarantula(0).GetImage();

            else return null;
        }

    }
}
