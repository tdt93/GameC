﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.HolySpells
{
    [Serializable]
    class Excommunication : Skill
    {
        //  Your enemy's magic power is decreased by 50% of your strongest statistic (1/3 chance) or your weakest statistic(1/3 chance). 

        public Excommunication() : base("Excommunication", 25, 5)
        {
            PublicName = "Your enemy's magic power is decreased by 50% of your strongest statistic (1/3 chance) or your weakest statistic(1/3 chance) ";
        }
        public override List<StatPackage> BattleMove(Engine.CharacterClasses.Player player)
        {
            List<int> myList = new List<int>(); // using a list of all player statistics
            myList.Add(player.MagicPower);
            myList.Add(player.Strength);
            myList.Add(player.Precision);
            myList.Add(player.Stamina);
            myList.Add(player.Health);
            myList.Add(player.Armor);
            myList.Sort();//sorting the list
            StatPackage response = new StatPackage("wind");
            int randomNumber = Index.RNG(0, 3);
            if (randomNumber == 0)//Strongest stat 
            {
                response.MagicPowerDmg = (int)(myList[myList.Count - 1]);
                response.CustomText = "You use Excommunication and decrease your enemies magic power by " + (int)(myList[myList.Count - 1]);
            }
            else if (randomNumber == 1)//weakest 
           {
                int i = 0;
                while(myList[i] == 0)//first stat that is not equal to 0 will be used
                {
                    i++;
                }

                response.MagicPowerDmg = (int)(myList[i]);
                response.CustomText = "You use Excommunication and decrease your enemies magic power by " + (int)(myList[myList.Count - 1]);
            }
            else//miss
            {
                response.DamageType = "none";
                response.MagicPowerDmg = 0;
                response.CustomText = "You try to use Excommunication, but you miss!";
            }
            return new List<StatPackage>() { response };
        }
    
    }
}
