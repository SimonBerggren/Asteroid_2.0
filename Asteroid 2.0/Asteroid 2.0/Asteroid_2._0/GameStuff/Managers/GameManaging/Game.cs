using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Asteroid_2._0
{
    public class AsteroidGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        ScreenManager screenManager;

        public AsteroidGame()
        {
            Content.RootDirectory = "Content";
            
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            screenManager = new ScreenManager(this, graphics);
            Components.Add(screenManager);
            screenManager.AddScreen(new BackgroundScreen());
            screenManager.AddScreen(new MainMenu());
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
