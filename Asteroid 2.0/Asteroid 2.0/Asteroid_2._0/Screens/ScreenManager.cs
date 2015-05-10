using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Asteroid_2._0
{

    public class ScreenManager : DrawableGameComponent
    {
        private List<Screen> screens = new List<Screen>();
        private List<Screen> screensToUpdate = new List<Screen>();

        private bool isInitialized;

        private SpriteBatch spriteBatch;
        private GraphicsDeviceManager graphics;
        private SpriteFont font;

        public GraphicsDeviceManager Graphics
        {
            get { return graphics; }
        }
        
        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }

        public SpriteFont Font
        {
            get { return font; }
        }

        public ScreenManager(Game game, GraphicsDeviceManager graphics)
            : base(game)
        {
            this.graphics = graphics;
        }

        public override void Initialize()
        {
            base.Initialize();
            isInitialized = true;
        }

        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;

            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>(@"menufont");
            Sound.LoadContent(Content);
            Textures.LoadContent(Game);

            foreach (Screen screen in screens)
            {
                screen.LoadContent();
            }
        }

        protected override void UnloadContent()
        {
            foreach (Screen screen in screens)
            {
                screen.UnloadContent();
            }
        }

        public override void Update(GameTime gameTime)
        {
            Input.Update();

            screensToUpdate.Clear();

            foreach (Screen screen in screens)
            {
                screensToUpdate.Add(screen);
            }

            bool otherScreenHasFocus = !Game.IsActive;
            bool coveredByOtherScreen = false;


            while (screensToUpdate.Count > 0)
            {
                Screen screen = screensToUpdate[screensToUpdate.Count - 1];

                screensToUpdate.RemoveAt(screensToUpdate.Count - 1);

                screen.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

                if(screen.ScreenState == ScreenState.TransitionOn ||
                    screen.ScreenState == ScreenState.Active)
                {
                    if (!otherScreenHasFocus)
                    {
                        screen.HandleInput();

                        otherScreenHasFocus = true;
                    }

                    if (!screen.IsPopup && !screen.SideMenu)
                        coveredByOtherScreen = true;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (Screen screen in screens)
            {
                if (screen.ScreenState == ScreenState.Hidden)
                    continue;

                screen.Draw(gameTime);
            }
        }

        public void RemoveScreen(Screen screen)
        {
            if (isInitialized)
                screen.UnloadContent();

            screens.Remove(screen);
            screensToUpdate.Remove(screen);
        }

        public void AddScreen(Screen screen)
        {
            screen.ScreenManager = this;
            screen.IsExiting = false;
            
            if (isInitialized)
                screen.LoadContent();

            screens.Add(screen);
        }
    }
}
