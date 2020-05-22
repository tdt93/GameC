using Game.Engine.CharacterClasses;
using Game.Engine.Skills.BasicSkills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class AdvancedSpellsFactory3 : SkillFactory
    {
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills); 
            if (known == null) 
            {
                SoulEater s1 = new SoulEater();
                PoisonTornado s2 = new PoisonTornado();
                WaterBlast s3 = new WaterBlast();
                // only include elligible spells
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; // use Index.RNG for safe random numbers
            }
            else if (known.decoratedSkill == null) 
            {
                SoulEaterDecorator s1 = new SoulEaterDecorator(known);
                PoisonTornadoDecorator s2 = new PoisonTornadoDecorator(known);
                WaterBlastDecorator s3 = new WaterBlastDecorator(known);
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else return null;
        }
        private Skill CheckContent(List<Skill> skills) // wrapper method for checking
        {
            foreach (Skill skill in skills)
            {
                if (skill is SoulEater || skill is PoisonTornado || skill is WaterBlast || skill is SoulEaterDecorator || skill is PoisonTornadoDecorator || skill is WaterBlastDecorator) return skill;
            }
            return null;
        }
    }
}
