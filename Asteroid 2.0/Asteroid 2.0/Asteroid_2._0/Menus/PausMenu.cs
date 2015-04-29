using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class PausMenu : MenuScreen
    {
        MenuEntry resume;
        MenuEntry exit;

        GameScreen mainGame;

        public PausMenu(GameScreen MainGame)
            : base("Paused")
        {
            mainGame = MainGame;

            resume = new MenuEntry("Resume Game");
            exit = new MenuEntry("Exit Game");

            resume.Selected += ResumeGame;
            exit.Selected += ExitGame;

            MenuEntries.Add(resume);
            MenuEntries.Add(exit);

            IsPopup = true;
        }

        private void ResumeGame(object sender, EventArgs e)
        {
            IsExiting = true;
        }

        private void ExitGame(object sender, EventArgs e)
        {
            ScreenManager.AddScreen(new MainMenu());
            ScreenManager.RemoveScreen(mainGame);
            IsExiting = true;
        }
    }
}
