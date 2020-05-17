using System;
using System.Collections.Generic;
using Game.Engine.Skills.WaterSpells;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class WaterSpellFactory : SkillFactory
    {
        // this factory produces skills from WaterSpells directory
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills); 
            if (known == null) 
            {
                HeavyRain s1 = new HeavyRain();
                OceanWave s2 = new OceanWave();
                TsunamiPunch s3 = new TsunamiPunch();
                
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); 
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; 
            }
            else if (known.decoratedSkill == null) 
            {
                HeavyRainDecorator s1 = new HeavyRainDecorator(known);
                OceanWaveDecorator s2 = new OceanWaveDecorator(known);
                TsunamiPunchDecorator s3 = new TsunamiPunchDecorator(known);
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); 
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
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
                if (skill is HeavyRain || skill is OceanWave || skill is TsunamiPunch || skill is HeavyRainDecorator || skill is OceanWaveDecorator || skill is TsunamiPunchDecorator) return skill;
            }
            return null;
        }

    }
}
