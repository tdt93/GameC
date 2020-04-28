using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    [Serializable]
    abstract class Interaction : DisplayItem
    {
        protected GameSession parentSession;
        public Interaction(GameSession ses)
        {
            parentSession = ses;
        }

        // every interaction has to know how to run itself
        public abstract void Run();
    }
}
