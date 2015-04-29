using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class MainMenu:MenuScreen
    {
        public MainMenu()
            : base("Main Menu")
        {

        }

        public override void LoadContent()
        {
            MenuEntry playGame = new MenuEntry("Play Game");
            MenuEntry options = new MenuEntry("Options");
            MenuEntry exit = new MenuEntry("Exit Game");

            options.Selected += OptionsSelected;
            playGame.Selected += PlayGame;
            exit.Selected += ExitGame;

            MenuEntries.Add(playGame);
            MenuEntries.Add(options);
            MenuEntries.Add(exit);
        }

        void OptionsSelected(object sender, EventArgs e)
        {
            ScreenManager.AddScreen(new Options());
        }

        void PlayGame(object sender, EventArgs e)
        {
            ScreenManager.AddScreen(new GameScreen());
            IsExiting = true;
        }

        void ExitGame(object sender, EventArgs e)
        {
            ScreenManager.Graphics.IsFullScreen = false;
            ScreenManager.Game.Exit();
        }
    }
}
