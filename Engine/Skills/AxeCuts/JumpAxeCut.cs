﻿using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.SkillWeaponMoves
{
    [Serializable]
    class JumpAxeCut : Skill
    {
        public JumpAxeCut() : base("Jump Axe Cut", 20, 2)
        {
            PublicName = "Jump Axe Cut: a chance equal to your Precission stat to make 1,5 times bigger damage";
            RequiredItem = "Axe";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("cut");
            Random rnd = new Random();
            if (rnd.Next(0, 100) < player.Precision)
            {
                response.HealthDmg = (int)(1.5 * player.Strength);
                response.CustomText = "You use Jump Axe Cut! (" + (int)(1.5 * player.Strength) + " stab damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "You try to use Jump Axe Cut but you miss!";
            }
            return new List<StatPackage>() { response };
        }
    }
}
