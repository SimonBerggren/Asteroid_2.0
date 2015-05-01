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
        MenuEntry options;
        MenuEntry exit;

        GameScreen mainGame;

        public PausMenu(GameScreen MainGame)
            : base("Paused")
        {
            mainGame = MainGame;

            resume = new MenuEntry("Resume");
            options = new MenuEntry("Options");
            exit = new MenuEntry("Exit");

            resume.Selected += ResumeGame;
            options.Selected += Options;
            exit.Selected += ExitGame;

            MenuEntries.Add(resume);
            MenuEntries.Add(options);
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

        private void Options(object sender, EventArgs e)
        {
            ScreenManager.AddScreen(new Options());
        }
    }
}
