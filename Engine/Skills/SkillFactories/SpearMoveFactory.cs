using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;
using Game.Engine.Skills.AdvancedWeaponTechniques;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class SpearMoveFactory : SkillFactory
    {
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills);
            if (known == null)
            {
                SpearThrow s1 = new SpearThrow();
                Whirl s2 = new Whirl();
                RollAndBackStab s3 = new RollAndBackStab();
                
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1);
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else if (known.decoratedSkill == null)
            {
                SpearThrowDecorator s1 = new SpearThrowDecorator(known);
                WhirlDecorator s2 = new WhirlDecorator(known);
                RollAndBackStabDecorator s3 = new RollAndBackStabDecorator(known);
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
                if (skill is SpearThrow || skill is Whirl || skill is RollAndBackStab || skill is SpearThrowDecorator || skill is WhirlDecorator || skill is RollAndBackStabDecorator) 
                return skill;
            }
            return null;
        }
    }
}
