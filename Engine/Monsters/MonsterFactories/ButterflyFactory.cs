using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class ButterflyFactory: MonsterFactory
    {
        private int encounterNumber = 0; // ile razy użyliśmy fabryki?
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber == 0) // jeśli to pierwszy raz, to zwracamy Butterfly
            {
                encounterNumber++;
                return new Butterfly(playerLevel);
            }
            else if (encounterNumber == 1) // jeśli to drugi raz, to zwracamy ButterflyEvolved
            {
                encounterNumber++;
                return new ButterflyEvolved(playerLevel);
            }
            else return null; // w przeciwnym razie nie zwracamy kolejnego obiektu
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new Butterfly(0).GetImage();
            else if (encounterNumber == 1) return new ButterflyEvolved(0).GetImage();
            else return null;
        }
    }
}
