using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class BackgroundScreen : Screen
    {
        SpriteBatch spriteBatch;
        Texture2D backgroundTex;

        float One = -1080, 
              Two = 0, 
              Three = 1080;

        public BackgroundScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(0.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
        }

        public override void LoadContent()
        {
            spriteBatch = ScreenManager.SpriteBatch;
            backgroundTex = ScreenManager.Game.Content.Load<Texture2D>("Background");
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            One++;
            Two++;
            Three++;

            if (One >= 1080)
                One = -1080;

            if (Two >= 1080)
                Two = -1080;

            if (Three >= 1080)
                Three = -1080;

            base.Update(gameTime, otherScreenHasFocus, false);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(backgroundTex, new Vector2(0, One), Color.White);
            spriteBatch.Draw(backgroundTex, new Vector2(0, Two), Color.White);
            spriteBatch.Draw(backgroundTex, new Vector2(0, Three), Color.White);

            spriteBatch.End();
        }
    }
}
