using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Ghost : Monster
    {
        public Ghost(int ghostAge)
        {
            Health = 40;
            if (ghostAge > 40)
            { 
                Strength = ghostAge - 20; 
            }
            else 
            { 
                Strength = 10; 
            }
            Armor = 0;
            Precision = 20;
            MagicPower = ghostAge;
            Stamina = 40;
            XPValue = 30 + 2 * ghostAge;
            Name = "monster0002";
            BattleGreetings = "It's death time...";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 2;
                return new List<StatPackage>() { new StatPackage("curse", Strength, "Ghost curses you! (" + Strength + " curse damage)")};
            }
            else if (Stamina > 20)
            {
                return new List<StatPackage>() { new StatPackage("fire ball", (Strength - 10), "Ghost strikes you with a ball of fire! ("
                                                 + (Strength - 10) + " fire damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage("none", 0, "Ghost has no energy to attack again!") };
            }
        }
      /*  public override void React(List<StatPackage> packs)
        {

        }*/
    }
}
