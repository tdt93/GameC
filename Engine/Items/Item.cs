using System;
using Game.Engine;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items
{
    // a class representing a generic item
    [Serializable]
    public abstract class Item : DisplayItem
    {
        protected int hpMod, strMod, arMod, prMod, mgcMod, staMod; // statistic buffs
        public string PublicName { get; protected set; } // the name to be displayed in game
        public int GoldValue { get; protected set; } 
        public virtual bool IsAxe { get; protected set; } = false;
        public virtual bool IsSword { get; protected set; } = false;
        public virtual bool IsSpear { get; protected set; } = false;
        public virtual bool IsStaff { get; protected set; } = false;
        public Item(string name)
        {
            Name = name;
            hpMod = 0;
        }
        public virtual void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            // by default, simply add item statistics to player statistics
            // can be overriden to include more complicated item mechanics (conditionals, randomness... )
            currentPlayer.HealthBuff += hpMod;
            currentPlayer.StrengthBuff += strMod;
            currentPlayer.ArmorBuff += arMod;
            currentPlayer.PrecisionBuff += prMod;
            currentPlayer.MagicPowerBuff += mgcMod;
            currentPlayer.StaminaBuff += staMod;
        }
        public virtual StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            // by default, do not include any specific offensive bonuses for player attacks
            return pack;
        }
        public virtual StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            // by default, do not include any specific defensive bonuses for player receiving an attack
            return pack;
        }

    }
}
