using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Skills.SomeSeriousSpells;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class BuffSpellsFactory: SkillFactory
    {
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills); // check what spells from the BasicSpells category are known by the player already
            if (known == null) // no BasicSpells known - we will return one of them
            {
                MagicArrow s1 = new MagicArrow();
                StoneSkin s2 = new StoneSkin();
                Blessing s3 = new Blessing();
                AuraOfTheSword s4 = new AuraOfTheSword();
                
                // only include elligible spells
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; // use Index.RNG for safe random numbers
            }
            else if (known.decoratedSkill == null) // a BasicSpell has been already learned, use decorator to create a combo
            {
                MagicArrowDecorator s1 = new MagicArrowDecorator(known);
                StoneSkinDecorator s2 = new StoneSkinDecorator(known);
                BlessingDecorator s3 = new BlessingDecorator(known);
                AuraOfTheSwordDecorator s4 = new AuraOfTheSwordDecorator(known);

                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else return null; // a combo of BasicSpells has been already learned - this factory doesn't offer double combos so we stop here
        }
        private Skill CheckContent(List<Skill> skills) 
        {
            foreach (Skill skill in skills)
            {
                if (skill is MagicArrow || skill is StoneSkin || skill is Blessing || skill is AuraOfTheSword || skill is MagicArrowDecorator 
                    || skill is StoneSkinDecorator || skill is BlessingDecorator || skill is AuraOfTheSwordDecorator) return skill;
            }
            return null;
        }
    }
}
