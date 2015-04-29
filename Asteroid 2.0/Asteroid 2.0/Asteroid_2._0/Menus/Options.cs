using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class Options : MenuScreen
    {
        MenuEntry back;
        MenuEntry changeResolution;

        public Options()
            : base("Options")
        {

        }

        public override void LoadContent()
        {
            back = new MenuEntry("Back to Main Menu");
            changeResolution = new MenuEntry("Change Resolution");

            back.Selected += GoBack;
            changeResolution.Selected += ChangeResolution;

            MenuEntries.Add(changeResolution);
            MenuEntries.Add(back);
        }

        private void GoBack(object sender, EventArgs e)
        {
            IsExiting = true;
        }

        private void ChangeResolution(object sender, EventArgs e)
        {
            ScreenManager.AddScreen(new ResolutionMenu());
        }
    }
}
