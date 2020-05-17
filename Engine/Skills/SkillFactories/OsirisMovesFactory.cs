using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Skills.OsirisMoves;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class OsirisMovesFactory: SkillFactory
    {
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills); // check what spells from the BasicSpells category are known by the player already
            if (known == null) // no BasicSpells known - we will return one of them
            {
                OsirisCurse s1 = new OsirisCurse();
                MummySpell s2 = new MummySpell();
                NileSplash s3 = new NileSplash();
                // only include elligible spells
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; // use Index.RNG for safe random numbers
            }
            else if (known.decoratedSkill == null) // an OsirisSpell has been already learned, use decorator to create a combo
            {
                OsirisCurseDecorator s1 = new OsirisCurseDecorator(known);
                MummySpellDecorator s2 = new MummySpellDecorator(known);
                NileSplashDecorator s3 = new NileSplashDecorator(known);
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
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
                if (skill is OsirisCurse || skill is MummySpell || skill is NileSplash || skill is OsirisCurseDecorator || skill is MummySpellDecorator || skill is NileSplashDecorator) return skill;
            }
            return null;
        }
    }
}
