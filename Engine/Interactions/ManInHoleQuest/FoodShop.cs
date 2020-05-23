using Game.Engine.Items;
using System;
using System.Collections.Generic;

namespace Game.Engine.Interactions
{
    // a special interaction used for buying and selling items

    [Serializable]
    class FoodShop : ConsoleInteraction
    {
        private Item it1, it2, it3;
        public FoodShop(GameSession parentSession) : base(parentSession)
        {
            it1 = Index.RandomClassItem(parentSession.currentPlayer);
            it2 = Index.RandomClassItem(parentSession.currentPlayer);
            it3 = Index.RandomClassItem(parentSession.currentPlayer);
            Name = "interaction0006";
        }
        protected override void RunContent()
        {
            parentSession.SendText("\nPsst!!! Hey kid, want some fruits ? \nI have some of the best fruits in this region.");
            parentSession.SendText("You may press I to see the value of your fruits, B to buy mine or ENTER to leave.");
            parentSession.RemovableItems = true;
            parentSession.ItemSellFlag = true;
            while (true)
            {
                string key = parentSession.GetValidKeyResponse(new List<string>() { "Return", "I", "B" }).Item1;
                if (key == "Return") 
                {
                    parentSession.SendText("Alright, See you again kid!!");
                    break;
                } 
                else if (key == "I") parentSession.ListAllItemsCost();
                else
                {
                    parentSession.SendText("Fresh fruits, hot fruits, get them quick while you still can: ");
                    parentSession.SendText(it1.PublicName + " for " + (it1.GoldValue + 20) + " gold (press 1)");
                    parentSession.SendText(it2.PublicName + " for " + (it2.GoldValue + 20) + " gold (press 2)");
                    parentSession.SendText(it3.PublicName + " for " + (it3.GoldValue + 20) + " gold (press 3)");
                    while (true)
                    {
                        string key2 = parentSession.GetValidKeyResponse(new List<string>() { "Return", "1", "2", "3" }).Item1;
                        if (key2 == "Return")
                        {
                            parentSession.RemovableItems = false;
                            parentSession.ItemSellFlag = false;
                            return;
                        }
                        else if (key2 == "1") SellItem(it1);
                        else if (key2 == "2") SellItem(it2);
                        else if (key2 == "3") SellItem(it3);
                    }
                }
            }
            parentSession.RemovableItems = false;
            parentSession.ItemSellFlag = false;
        }
        protected void SellItem(Item it)  
        {
            if (parentSession.currentPlayer.Gold >= it.GoldValue + 20)
            {
                parentSession.AddThisItem(it);
                parentSession.UpdateStat(8, -1 * it.GoldValue - 20);
            }
            else parentSession.SendText("Sorry, you don't have enough gold to buy this!");
        }
    }
}
