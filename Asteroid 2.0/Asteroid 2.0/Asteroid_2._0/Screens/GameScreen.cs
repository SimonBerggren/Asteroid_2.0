using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Asteroid_2._0
{
    public class GameScreen : Screen
    {
        public int WindowWidth { get; private set; }

        public int WindowHeight { get; private set; }

        private SpriteBatch spriteBatch { get; set; }

        private Factory factory { get; set; }

        public GameScreen()
            : base() { }

        public override void LoadContent()
        {
            spriteBatch = new SpriteBatch(ScreenManager.GraphicsDevice);

            WindowHeight = ScreenManager.GraphicsDevice.Viewport.Height;
            WindowWidth = ScreenManager.GraphicsDevice.Viewport.Width;

            factory = new Factory();

            factory.Initialize(this);
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            factory.UpdateGameScreen(gameTime, otherScreenHasFocus);

            if (Input.Clicked(Keys.Escape))
                ScreenManager.AddScreen(new PausMenu(this));

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            factory.DrawGameScreen(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
