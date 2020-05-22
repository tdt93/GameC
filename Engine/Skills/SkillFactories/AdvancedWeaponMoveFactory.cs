using System;
using System.Collections.Generic;
using Game.Engine.Skills.AdvancedWeaponMoves;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class AdvancedWeaponMoveFactory : SkillFactory
    {
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            List<Skill> tmp = new List<Skill>();
            List<Skill> drawn = new List<Skill>();
            AuraOfASword s1 = new AuraOfASword();
            AxeThrow s2 = new AxeThrow();
            EagleEye s3 = new EagleEye();
            if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
            if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
            if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
            foreach (Skill skill in playerSkills) // don't offer skills which the player knows already
            {
                if (skill is AuraOfASword) tmp.Remove(s1);
                if (skill is AxeThrow) tmp.Remove(s2);
                if (skill is EagleEye) tmp.Remove(s3);
            }
            if (tmp.Count == 0) return null;
            return tmp[Index.RNG(0, tmp.Count)];
        }
    }
}
