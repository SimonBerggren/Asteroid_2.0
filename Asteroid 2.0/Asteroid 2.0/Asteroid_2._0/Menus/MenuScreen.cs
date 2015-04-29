using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_2._0
{
    abstract class MenuScreen : Screen
    {
        private int selectedEntry = 0;
        private string menuTitle;

        private List<MenuEntry> menuEntries = new List<MenuEntry>();
        protected IList<MenuEntry> MenuEntries
        {
            get { return menuEntries; }
        }

        private float SidebarOffset
        {
            get
            {
                menuEntries.OrderByDescending(m => m.StringWidth);
                return menuEntries[0].StringWidth;
            }
        }

        public MenuScreen(string menuTitle)
        {
            this.menuTitle = menuTitle;

            TransitionOnTime = TimeSpan.FromSeconds(0.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);

        }

        public override void HandleInput()
        {

            if (Input.Clicked(Keys.Up))
            {
                selectedEntry--;

                if (selectedEntry < 0)
                    selectedEntry = menuEntries.Count - 1;
            }

            if (Input.Clicked(Keys.Down))
            {
                selectedEntry++;

                if (selectedEntry >= menuEntries.Count)
                    selectedEntry = 0;
            }

            if (Input.Clicked(Keys.Enter) || Input.LeftClick())
            {
                OnSelectEntry(selectedEntry);
            }
        }

        protected virtual void OnSelectEntry(int entryIndex)
        {
            menuEntries[entryIndex].OnSelectEntry();
        }

        protected virtual void OnCancel()
        {
            ExitScreen();
        }

        protected virtual void UpdateMenuEntryLocations()
        {
            float transitionOffset = (float)Math.Pow(TransitionPosition, 2);

            Vector2 position = new Vector2(0f, 400);

            for (int index = 0; index < menuEntries.Count; index++)
            {
                MenuEntry menuEntry = menuEntries[index];

                if (SideMenu)
                    position.X = ScreenManager.GraphicsDevice.Viewport.Width / 2 /*- menuEntry.Getwidth(this) / 2*/ + SidebarOffset;
                else
                    position.X = ScreenManager.GraphicsDevice.Viewport.Width / 2 - menuEntry.Getwidth(this) / 2;

                if (ScreenState == ScreenState.TransitionOn)
                    position.X -= transitionOffset * 256;
                else
                    position.X += transitionOffset * 512;

                menuEntry.Position = position;

                position.Y += menuEntry.GetHeight(this);
            }
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            for (int index = 0; index < menuEntries.Count; index++)
            {
                bool isSelected = IsActive && (index == selectedEntry);

                menuEntries[index].Update(this, isSelected, gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            UpdateMenuEntryLocations();

            GraphicsDevice graphics = ScreenManager.GraphicsDevice;
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            SpriteFont font = ScreenManager.Font;

            spriteBatch.Begin();

            for (int index = 0; index < menuEntries.Count; index++)
            {
                MenuEntry menuEntry = menuEntries[index];

                bool isSelected = IsActive && (index == selectedEntry);

                menuEntry.Draw(this, isSelected, gameTime);
                float sidebarOffset = menuEntry.StringWidth;
            }

            float transitionOffset = (float)Math.Pow(TransitionPosition, 2);
            Vector2 titlePosition = new Vector2(graphics.Viewport.Width / 2, graphics.Viewport.Height / 2 / 2);
            if (SideMenu)
                titlePosition.X = SidebarOffset + graphics.Viewport.Width / 2;

            Vector2 titleOrigin = font.MeasureString(menuTitle) / 2;
            Color titleColor = new Color(192, 192, 192) * TransitionAlpha;
            float titleScale = 1.25f;

            titlePosition.Y -= transitionOffset * 100;

            spriteBatch.DrawString(font, menuTitle, titlePosition, titleColor, 0, titleOrigin, titleScale, SpriteEffects.None, 0);

            spriteBatch.End();
        }
    }
}
