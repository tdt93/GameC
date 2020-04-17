using System;
using System.Collections.Generic;
using Game.Engine.Monsters.MonsterFactories;
using Game.Engine.Monsters;

namespace Game.Engine
{
    // container class for an integer matrix that represents game map grid
    // unfortunately there seems to be no simpler way than just hardcoding it for each map image (may be revised in the future... )
    // map codes:
    // 0 - unavailable terrain (the character cannot go there)
    // 1 - normal terrain (walkable, but nothing happens)
    // 1000 - battle with a monster
    // anything else - some event will occur
    class MapMatrix
    {
        private Dictionary<int, MonsterFactory> monDict;
        private int monsters = 5;

        public int[,] Matrix;
        public int Width { get; set; } = 25;
        public int Height { get; set; } = 20;

        public MapMatrix()
        {
            Matrix = new int[Height, Width];
            // make map walkable
            for (int y = 1; y < Height - 1; y++)
            {
                for (int x = 1; x < Width - 1; x++)
                {
                    Matrix[y, x] = 1;
                }
            }
            // decorate with monsters
            Random rng = new Random();
            for (int i = 0; i < monsters; i++)
            {
                int x = rng.Next(8, Width - 1); // 8 is temporary fix
                int y = rng.Next(8, Height - 1);
                Matrix[y, x] = 1000;
            }
            // temporary fixes
            Matrix[1, 3] = 0;
            Matrix[1, 5] = 0;
            Matrix[1, 7] = 0;
            Matrix[2, 3] = 3;
            Matrix[2, 5] = 4;
            Matrix[2, 7] = 2;

            InitializeFactoryList();
        }

        public MapMatrix(string s)
        {
            //a predefined map - for testing purposes, mostly obsolete now
            Matrix = new int[20, 25] {
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,1,1,1,0,0,1,1,0 },
            { 0,0,1,1,1,1,1,1,1,1,1,0,1,1,0,0,0,0,1,0,0,0,0,1,0 },
            { 0,0,1,1,1,0,0,0,1,1,1,0,1,1,1,0,0,1,1,1,0,0,1,1,0 },
            { 0,0,1,1,0,0,0,0,0,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,0 },
            { 0,0,1,1,0,0,0,0,0,1,1,0,1,1,1,1,1,1,1,1,1,0,0,1,0 },
            { 0,0,1,1,0,0,0,0,0,1,1,0,1,1,1,1,1,1,1,1,0,0,0,0,0 },
            { 0,0,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,0,0,1,0 },
            { 0,0,1,1,1,1,1,1,1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,0 },
            { 0,0,1,1,1,1,1,1,1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,0 },
            { 0,0,0,0,0,0,3,0,0,0,0,0,1,1,1,2,1,1,1,1,1,1,1,1,0 },
            { 0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0 },
            { 0,1,1,1,1,1,1,1,1,1,1,1,1,4,1,1,1,1,1,1,1,1,1000,1,0 },
            { 0,1,0,0,1,1,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,1,0 },
            { 0,0,0,0,0,1,0,0,1,1,1,0,0,0,1,1,1,1,1,1,0,0,1,1,0 },
            { 0,1,0,0,1,0,0,0,0,1,1,1,1,1000,1,1,1,1,1,0,0,0,0,1,0 },
            { 0,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,0 },
            { 0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0 },
            { 0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 } };
            InitializeFactoryList();
        }

        private void InitializeFactoryList()
        {
            monDict = new Dictionary<int, MonsterFactory>();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++) 
                {
                    if (Matrix[y, x] == 1000)
                    {
                        monDict.Add(y * Width + x, Index.RandomMonsterFactory());
                    }
                }
            }
        }

        // produce or hint monsters
        public Monster CreateMonster(int x, int y, int playerLevel)
        {
            if (monDict.ContainsKey(y * Width + x) && monDict[y * Width + x] != null)
            {
                return monDict[y * Width + x].Create(playerLevel);
            }
            return null;
        }
        public System.Windows.Controls.Image HintMonsterImage(int x, int y)
        {
            if (monDict.ContainsKey(y * Width + x) && monDict[y * Width + x] != null)
            {
                return monDict[y * Width + x].Hint();
            }
            return null;
        }

    }
}
