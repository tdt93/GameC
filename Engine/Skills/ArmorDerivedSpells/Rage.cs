﻿using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
    [Serializable]
    public class Rage : Skill
    {
        public Rage() : base("Rage", 2, 1)
        {
            PublicName = "Rage: damages you for 10 and converts it to strength";
            RequiredItem = "GrowingStoneArmor";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("health");
            player.Health -= 10;
            player.Strength += 10;
            response.CustomText="You used Rage! (health decreased to "+player.Health+" strength increased to "+player.Strength+")";
            return new List<StatPackage>() { response };
        }
    }
}
