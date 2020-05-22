using Game.Engine.CharacterClasses;
using Game.Engine.Skills.MoreSpells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class AdvancedSpellsFactory2 : SkillFactory
    {
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills);
            if (known == null) 
            {
                Healing s1 = new Healing();
                StrengthTheft s2 = new StrengthTheft();
                ArmorDestruction s3 = new ArmorDestruction();

                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; 
            }
            else if (known.decoratedSkill == null)
            {
                HealingDecorator s1 = new HealingDecorator(known);
                StrengthTheftDecorator s2 = new StrengthTheftDecorator(known);
                ArmorDestructionDecorator s3 = new ArmorDestructionDecorator(known);
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
                if (skill is Healing || skill is StrengthTheft || skill is ArmorDestruction || skill is HealingDecorator || skill is StrengthTheftDecorator || skill is ArmorDestructionDecorator) return skill;
            }
            return null;
        }
    }
}
