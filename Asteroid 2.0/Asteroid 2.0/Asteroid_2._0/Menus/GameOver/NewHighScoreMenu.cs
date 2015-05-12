
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Asteroid_2._0
{
    class NewHighScoreMenu : MenuScreen
    {
        Texture2D texture;

        MenuEntry back;

        private int score;

        public NewHighScoreMenu(int Score = 1000)
            : base("Write your name")
        {
            score = Score;

        }

        public override void LoadContent()
        {
            texture = ScreenManager.Game.Content.Load<Texture2D>("blank");

            EventInput.EventInput.Initialize(ScreenManager.Game.Window);
            EventInput.EventInput.CharEntered += EventInput_CharEntered;

            back = new MenuEntry("Back");

            back.Selected += GoBack;

            MenuEntries.Add(back);

            base.LoadContent();
        }

        private void EventInput_CharEntered(object sender, EventInput.CharacterEventArgs e)
        {
            if (e.Character == '\b')
            {
                if (nameText.Length > 0)
                    nameText = nameText.Remove(nameText.Length - 1);
            }
            else if (e.Character == (char)13)
            {
                // pressed Enter
                return;
            }
            else
                nameText += e.Character;

        }

        void WriteToHighScore()
        {
            StreamWriter writer = new StreamWriter("HighScores.txt", true);

            string textToWrite = nameText + ':' + Convert.ToString(score);

            writer.WriteLine(textToWrite);

            writer.Close();
        }

        void GoBack(object sender, EventArgs e)
        {
            WriteToHighScore();

            ScreenManager.AddScreen(new HighScoreMenu());

            IsExiting = true;
        }

        private string nameText = "";

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            if (ScreenState != ScreenState.Active || string.IsNullOrWhiteSpace(nameText))
                return;

            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            Vector2 textPos = new Vector2(spriteBatch.GraphicsDevice.Viewport.Width / 2 - Textures.font.MeasureString(nameText).X / 2,
                                          spriteBatch.GraphicsDevice.Viewport.Height / 2 - Textures.font.MeasureString(nameText).Y);

            spriteBatch.Begin();

            spriteBatch.DrawString(Textures.font, nameText, textPos, Color.White);

            spriteBatch.End();

        }
    }
}
