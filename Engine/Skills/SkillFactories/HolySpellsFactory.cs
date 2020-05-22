using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Skills.HolySpells;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class HolySpellsFactory : SkillFactory
    {
        // this factory produces skills from HolySpells directory
        public Skill CreateSkill(Engine.CharacterClasses.Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills);
            if (known == null)
            {
                Excommunication s1 = new Excommunication();
                IceSpike s2 = new IceSpike();
                Prayer s3 = new Prayer();
                
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); 
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; 
            }
            else if (known.decoratedSkill == null)
            {
                ExcommunicationDecorator s1 = new ExcommunicationDecorator(known);
                IceSpikeDecorator s2 = new IceSpikeDecorator(known);
                PrayerDecorator s3 = new PrayerDecorator(known);
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
                if (skill is Excommunication || skill is Prayer || skill is IceSpike || skill is ExcommunicationDecorator || skill is IceSpikeDecorator || skill is PrayerDecorator) return skill;
            }
            return null;
        }       
    
    }
}
