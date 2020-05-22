using System;
using System.Collections.Generic;
using Game.Engine.Skills;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    public class ArmorDerivedSpellFactory : SkillFactory
    {
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills); 
            if (known == null) 
            {
                Bloodlust s1 = new Bloodlust();
                Heal s2 = new Heal();
                Rage s3 = new Rage();

                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); 
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; 
            }
            else if (known.decoratedSkill == null) 
            {
                BloodlustDecorator s1 = new BloodlustDecorator(known);
                HealDecorator s2 = new HealDecorator(known);
                RageDecorator s3 = new RageDecorator(known);
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); 
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else return null;
        }
        private Skill CheckContent(List<Skill> skills) 
        {
            foreach (Skill skill in skills)
            {
                if (skill is Bloodlust || skill is Heal || skill is Rage || skill is BloodlustDecorator || skill is HealDecorator || skill is RageDecorator) return skill;
            }
            return null;
        }
    }
}
