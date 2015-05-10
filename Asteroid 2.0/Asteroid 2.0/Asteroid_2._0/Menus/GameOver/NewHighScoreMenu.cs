
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_2._0
{
    class NewHighScoreMenu : MenuScreen
    {
        bool Clicked = false;

        Keys[] keysPressed;

        Texture2D texture;

        MenuEntry back;

        public NewHighScoreMenu()
            : base("Write your name")
        {

            
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            keysPressed = Input.PressedKeys();

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
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
            text += e.Character;
        }

        void GoBack(object sender, EventArgs e)
        {
            IsExiting = true;
        }



        private Color color = new Color(0, 0, 0, 0);
        private Rectangle fadingRect;
        private string text = "";

        public override void Draw(GameTime gameTime)
        {
            fadingRect = new Rectangle(0, 0, ScreenManager.SpriteBatch.GraphicsDevice.Viewport.Width,
                                           ScreenManager.SpriteBatch.GraphicsDevice.Viewport.Height);

            color *= 1.1f;


            ScreenManager.SpriteBatch.Begin();
            ScreenManager.SpriteBatch.Draw(texture, fadingRect, color);
            ScreenManager.SpriteBatch.DrawString(Textures.font, text, Vector2.Zero, Color.White );
            ScreenManager.SpriteBatch.End();

            base.Draw(gameTime); 
        }
    }
}
