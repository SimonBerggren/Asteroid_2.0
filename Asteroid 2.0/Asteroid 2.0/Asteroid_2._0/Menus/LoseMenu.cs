using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class LoseMenu : MenuScreen
    {
        MenuEntry back;

        public LoseMenu(int score)
            : base("You Lose!\nYour Score: " + score.ToString())
        {

        }

        public override void LoadContent()
        {
            back = new MenuEntry("Back");

            back.Selected += GoBack;

            MenuEntries.Add(back);

            base.LoadContent();
        }

        private void GoBack(Object sender, EventArgs e)
        {
            IsExiting = true;
        }
    }
}
