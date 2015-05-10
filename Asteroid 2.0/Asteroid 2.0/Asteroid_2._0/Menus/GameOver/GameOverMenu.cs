using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class GameOverMenu : MenuScreen
    {
        MenuEntry playAgain;
        MenuEntry viewHighScore;
        MenuEntry back;

        public GameOverMenu(string WonOrLost, int Score)
            : base("You " + WonOrLost + "!\nYour Score: " + Score.ToString())
        {

        }

        public override void LoadContent()
        {
            playAgain = new MenuEntry("Play Again");
            viewHighScore = new MenuEntry("HighScores");
            back = new MenuEntry("Back");

            playAgain.Selected += PlayAgain;
            viewHighScore.Selected += ViewHighScore;
            back.Selected += GoBack;

            MenuEntries.Add(playAgain);
            MenuEntries.Add(viewHighScore);
            MenuEntries.Add(back);

            base.LoadContent();
        }

        private void GoBack(object sender, EventArgs e)
        {
            IsExiting = true;
            ScreenManager.AddScreen(new MainMenu());
        }

        private void ViewHighScore(object sender, EventArgs e)
        {
            ScreenManager.AddScreen(new HighScoreMenu());

        }

        private void PlayAgain(object sender, EventArgs e)
        {
            IsExiting = true;
            ScreenManager.AddScreen(new GameScreen());
        }


        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }
        public override void Draw(GameTime gameTime)
        {

            base.Draw(gameTime);
        }
    }
}
