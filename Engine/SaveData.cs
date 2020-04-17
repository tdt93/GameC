using System;
using System.Collections.Generic;
using Game.Engine.Items;
using Game.Engine.CharacterClasses;

namespace Game.Engine
{
    // contains all information that has to be saved (and then loaded) in order to restore a game state

    [Serializable]
    public class SaveData
    {
        public int PlayerPosTop, PlayerPosLeft;
        public int[,] MapMatrix;
        public List<int> ItemPositions;
        public List<Item> Items;
        public Player CurrentPlayer;
        //factoriesData
        //moreElements...
        public SaveData(GameSession session)
        {
            // ale te wlasnosci sa prywatne 
            // moze latwiej zaczac od fabryk?
        }
    }
}
