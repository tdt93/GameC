using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using Game.Engine.Interactions;

namespace Game.Display
{
    // utility class - prepare display details for Interaction objects
    class ImageInteractionScene
    {
        protected GamePage parentPage;
        protected ImageInteraction interaction;
        protected Image imgSetup;
        public ImageInteractionScene(ImageInteraction inter, GamePage parent)
        {
            interaction = inter;
            parentPage = parent;
        }
        public virtual void SetupDisplay()
        { 
            // initialize display elements
            imgSetup = interaction.GetImage();
            if(imgSetup != null)
            {
                imgSetup.Stretch = Stretch.Fill;
                parentPage.PageGrid.Children.Add(imgSetup);
                Grid.SetColumn(imgSetup, 0);
                Grid.SetRow(imgSetup, 0);
                Grid.SetRowSpan(imgSetup, 2);
            }
        }
        public virtual void EndDisplay()
        {
            // clean up
            if(imgSetup != null) parentPage.PageGrid.Children.Remove(imgSetup);
        }

    }
}
