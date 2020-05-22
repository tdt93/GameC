using Game.Engine.CharacterClasses;
using Game.Engine.Skills.UpgradedWeaponMoves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class SwordMoveFactory:SkillFactory
    {
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills);
            if (known == null)
            {
                DoubleSlash s1 = new DoubleSlash();
                EnchantedSlash s2 = new EnchantedSlash();
                SwordThrust s3 = new SwordThrust();
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); 
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else if (known.decoratedSkill == null) 
            {
                DoubleSlashDecorator s1 = new DoubleSlashDecorator(known);
                EnchantedSlashDecorator s2 = new EnchantedSlashDecorator(known);
                SwordThrustDecorator s3 = new SwordThrustDecorator(known);
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
                if (skill is DoubleSlash || skill is EnchantedSlash || skill is SwordThrust || skill is DoubleSlashDecorator || skill is EnchantedSlashDecorator || skill is SwordThrustDecorator) return skill;
            }
            return null;
        }

    }
}
