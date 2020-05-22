using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;
using Game.Engine.Skills.BasicSpells;
using Game.Engine.Skills.BasicSkills;
namespace Game.Engine.Skills.SkillFactories
{
	[Serializable]
    class AdvancedSpellsFactory1 : SkillFactory
    {
       //Modified code from BasicSpellFactory.cs
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills);
            if (known == null)
            {
                Skill s1 = new ForcedLightning();
                Skill s2 = new ConstrainPerson();
                Skill s3 = new LifeDrain();
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; // use Index.RNG for safe random numbers
            }
            else if (known.decoratedSkill == null) // a BasicSpell has been already learned, use decorator to create a combo
            {
                Skill s1 = new ForcedLightningDecorator(known);
                Skill s2 = new ConstrainPersonDecorator(known);
                Skill s3 = new LifeDrainDecorator(known);
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else if (player.Level >= 6) //a double combo for players with lvl over 5
            {
                Skill s1 = new ForcedLightningDecorator(known);
                Skill s2 = new ConstrainPersonDecorator(known);
                Skill s3 = new LifeDrainDecorator(known);
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
                if (skill is ForcedLightning || skill is ConstrainPerson || skill is LifeDrain || skill is ForcedLightningDecorator || skill is ConstrainPersonDecorator || skill is LifeDrainDecorator) return skill;
            }
            return null;
        }
    }
}
