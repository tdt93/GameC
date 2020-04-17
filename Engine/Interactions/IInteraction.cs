using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    interface IInteraction
    {
        // every interaction has to know how to run itself
        void Run();
    }
}
