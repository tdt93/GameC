﻿using Game.Engine;
using Game.Engine.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class WaterBat: Monster
    {
        public WaterBat(int batLevel)
        {
            Health = 30 + 5 * batLevel;
            Strength = 5 + batLevel;
            Armor = 10;
            Precision = 70;
            MagicPower = 20 + batLevel;
            Stamina = 120;
            XPValue = 50 + batLevel;
            Name = "monster1303";
            BattleGreetings = "It seems you need to experience the power of water!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 16)
            {
                Stamina -= 15;
                return new List<StatPackage>() { new StatPackage("water", 15 + MagicPower, "Bat uses Waterfall! (" + (15 + MagicPower) + " water damage)") };

            }
            else if (Stamina < 16 && Stamina > 0)
            {
                Stamina = -15;
                return new List<StatPackage>() { new StatPackage("water", 40 + MagicPower, "Bat uses Hydro Attack! (" + (40 + MagicPower) + " water damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage("none", 0, "Bat has no energy to attack anymore!") };
            }
        }

    }
}
