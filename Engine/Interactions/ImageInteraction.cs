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
    [Serializable]
    abstract class ImageInteraction : Interaction
    {
        // initialization and internal stuff
        public ImageInteraction(GameSession ses) : base(ses) { }
        public override void Run()
        {
            parentSession.StopMoving();
            RunContent();
            parentSession.StartMoving();
        }

        // this is where all events should happen
        // refer to GameSessionPublicLogic for the possible ways of interacting with user and game
        protected abstract void RunContent();

    }
}
