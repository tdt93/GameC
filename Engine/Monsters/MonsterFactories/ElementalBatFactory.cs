using Game.Engine;
using Game.Engine.Monsters;
using Game.Engine.Monsters.MonsterFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class ElementalBatFactory : MonsterFactory
    {
		private int encounter, state;
		
		public ElementalBatFactory()
		{
			state = Index.RNG(0, 4);
		}
		
        public override Monster Create(int playerLevel)
        {
            if (state == 0 && encounter==0)
            {
                encounter++;
                return new FireBat(playerLevel);
            }
            else if (state == 1 && encounter==0)
            {
                    encounter++;
                    return new WaterBat(playerLevel);
            }
            else if (state ==2 && encounter==0)
            {
                encounter++;
                return new AirBat(playerLevel);
            }
            else if (state == 3 && encounter==0)
            {
                encounter++;
                return new EarthBat(playerLevel);
            }
            else return null;
        }
        
        public override System.Windows.Controls.Image Hint()
        {
            if (state==0 && encounter== 0) return new FireBat(0).GetImage();
            else if (state==1 && encounter==0) return new WaterBat(0).GetImage();
            else if (state==2 && encounter==0) return new AirBat(0).GetImage();
            else if (state==3 && encounter==0) return new EarthBat(0).GetImage();
            else return null;
        }
    }
}
