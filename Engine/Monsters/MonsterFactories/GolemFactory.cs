using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class GolemFactory:MonsterFactory
    {
        bool isThere = true;
        public override Monster Create(int playerLevel)
        {
            if (isThere)
            {
                isThere = false;
                return new Golem(playerLevel);
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (isThere) { return new Golem(0).GetImage(); }
            else return null;
        }
    }
}
