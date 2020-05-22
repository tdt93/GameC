﻿using System;
using System.Collections.Generic;
using Game.Engine.Skills.SimpleSkills;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class SimpleSkillsFactory : SkillFactory
    {
        // this factory produces skills from BasicWeaponMoves directory
        // note: since every skill in BasicWeaponMoves is meant for a different weapon, we don't use any combos or decorators here
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            List<Skill> tmp = new List<Skill>();
            HealingFactor s1 = new HealingFactor();
            StoneThrow s2 = new StoneThrow();
            VerbalAbuse s3 = new VerbalAbuse();
            if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
            if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
            if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
            foreach (Skill skill in playerSkills) // don't offer skills which the player knows already
            {
                if (skill is HealingFactor) tmp.Remove(s1);
                if (skill is StoneThrow) tmp.Remove(s2);
                if (skill is VerbalAbuse) tmp.Remove(s3);
            }
            if (tmp.Count == 0) return null;
            return tmp[Index.RNG(0, tmp.Count)];
        }

    }
}
