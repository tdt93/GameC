using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;
using Game.Engine.Skills.SkillWeaponMoves;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class AxeCutFactory : SkillFactory
    {
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills);
            if (known == null) 
            {
                DoubleAxeCut s1 = new DoubleAxeCut();
                JumpAxeCut s2 = new JumpAxeCut();
                TornadoAxeCut s3 = new TornadoAxeCut();
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); 
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else if (known.decoratedSkill == null)
            {
                DoubleAxeCutDecorator s1 = new DoubleAxeCutDecorator(known);
                JumpAxeCutDecorator s2 = new JumpAxeCutDecorator(known);
                TornadoAxeCutDecorator s3 = new TornadoAxeCutDecorator(known);
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
                if (skill is DoubleAxeCut || skill is DoubleAxeCutDecorator || skill is JumpAxeCut || skill is JumpAxeCutDecorator || skill is TornadoAxeCut || skill is TornadoAxeCutDecorator) return skill;
            }
            return null;
        }
    }
}
