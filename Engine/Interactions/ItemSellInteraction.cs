using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    // a special interaction used for selling items
    // if you want a clear example of how to write your own interesting interaction, this is probably NOT the right place 
    class ItemSellInteraction : ConsoleInteraction
    {
        public ItemSellInteraction(GameSession ses) : base(ses) { }
        protected override void RunContent()
        {
            parentSession.SendText("\nWelcome! You may now sell your items by dragging them outside of the item grid.");
            parentSession.SendText("You may also press I to see the value of your items or ENTER to leave.");
            parentSession.RemovableItems = true;
            parentSession.ItemSellFlag = true;
            while(true)
            {
                string key = parentSession.GetValidKeyResponse(new List<string>() { "Return", "I" }).Item1;
                if (key == "Return") break;
                parentSession.ListAllItemsCost();
            }
            parentSession.RemovableItems = false;
            parentSession.ItemSellFlag = false;
        }
    }
}
