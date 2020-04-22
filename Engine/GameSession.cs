using Game.Display;
using Game.Engine.CharacterClasses;
using Game.Engine.Items;
using Game.Engine.Skills;
using System.Collections.Generic;
using System;
using Game.Engine.Skills.BasicWeaponMoves;
using Game.Engine.Skills.BasicSkills;

namespace Game.Engine
{
    // the "main" class that commands the entire gameflow
    // in this file, only fields and properties are gathered

    [Serializable]
    public partial class GameSession
    {
        private int playerPosTop, playerPosLeft;
        [NonSerialized] private GamePage parentPage;
        private MapMatrix mapMatrix;
        private List<int> itemPositions; // all item positions
        private List<Item> items; // active items only
        [NonSerialized] private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        [NonSerialized] private System.Windows.Forms.Timer timerPlayer = new System.Windows.Forms.Timer();
        public Player currentPlayer { get; set; }
        public bool[] AvailableMoves; // W,S,A,D
        public string CurrentKey { private get; set; }
        public Skill CurrentSelection { private get; set; }
        public bool RemovableItems 
        {
            get { return parentPage.RemovableItems; }
            set { parentPage.RemovableItems = value; }
        }
        public bool ItemSellFlag
        {
            get { return parentPage.ItemSellFlag; }
            set { parentPage.ItemSellFlag = value; }
        }
        public int PlayerPosTop
        {
            get { return playerPosTop; }
            set
            {
                playerPosTop = value;
                UpdateLocations();
            }
        }
        public int PlayerPosLeft
        {
            get { return playerPosLeft; }
            set
            {
                playerPosLeft = value;
                UpdateLocations();
            }
        }
        public GameSession(GamePage parentPage, string playerChoice)
        {
            // core
            this.parentPage = parentPage;
            currentPlayer = new Mage(this);
            if (playerChoice != null) { if (playerChoice.Contains("Warrior")) currentPlayer = new Warrior(this); }
            itemPositions = new List<int>();
            items = new List<Item>();
            parentPage.AddConsoleText("Welcome to the game!");
            RefreshStats();
            // map
            playerPosLeft = 1;
            playerPosTop = 3;
            mapMatrix = new MapMatrix();
            for (int i = 0; i < mapMatrix.Width; i++)
            {
                for (int j = 0; j < mapMatrix.Height; j++)
                {
                    if (mapMatrix.Matrix[j, i] == 1000) // scan rows first
                    {
                        parentPage.AddMonster(j * mapMatrix.Width + i, mapMatrix.HintMonsterImage(i,j), mapMatrix.Width);
                    }
                }
            }
            AvailableMoves = new bool[4];
            UpdateLocations();
            // starting skills and items
            if (playerChoice != null)
            {
                if (playerChoice.Contains("Axe"))
                {
                    ProduceItem("item0003");
                    currentPlayer.Learn(new AxeCut());
                }
                else if (playerChoice.Contains("Sword"))
                {
                    ProduceItem("item0004");
                    currentPlayer.Learn(new SwordSlash());
                }
                else if (playerChoice.Contains("Spear"))
                {
                    ProduceItem("item0002");
                    currentPlayer.Learn(new SpearStab());
                }
                else if (playerChoice.Contains("Fire"))
                {
                    ProduceItem("item0001");
                    currentPlayer.Learn(new FireArrow());
                }
                else if (playerChoice.Contains("Wind"))
                {
                    ProduceItem("item0001");
                    currentPlayer.Learn(new WindGust());
                }
            }      
        }

    }
}
