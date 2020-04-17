using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    // class representing an event (or a chain of events) that will be executed at some map location
    // image interaction means that an image will be displayed in the place of game world image
    // which also means that an image has to be provided
    class ImageInteraction : DisplayItem, IInteraction
    {
        // initialization and internal stuff
        protected GameSession parentSession;
        public ImageInteraction(string name, GameSession ses)
        {
            parentSession = ses;
            Name = name;
            //Name = "imageInteraction" + pid.ToString().PadLeft(4, '0');
        }
        public void Run()
        {
            parentSession.StopMoving();
            RunContent();
            parentSession.StartMoving();
        }

        // content
        protected virtual void RunContent()
        {
            // this is where all events should happen
            // refer to GameSessionPublicLogic for the possible ways of interacting with user and game
        }

    }
}
