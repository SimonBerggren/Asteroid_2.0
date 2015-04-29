using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class MenuEntry
    {
        private float selectionFade;
        private Vector2 position;

        ScreenManager screenManager;
        SpriteBatch spriteBatch;
        SpriteFont font;

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public event EventHandler<EventArgs> Selected;

        protected internal virtual void OnSelectEntry()
        {
            if (Selected != null)
                Selected(this, new EventArgs());
        }

        public int StringWidth
        {
            get
            {
                if (font != null)
                    return (int)font.MeasureString(text).X;
                else
                    return 0;
            }
        }

        public MenuEntry(string text)
        {
            this.text = text;
        }


        public virtual int Getwidth(MenuScreen screen)
        {
            return (int)screen.ScreenManager.Font.MeasureString(text).X;
        }

        public virtual int GetHeight(MenuScreen screen)
        {
            return (int)screen.ScreenManager.Font.LineSpacing;
        }

        public virtual void Update(MenuScreen menuScreen, bool isSelected, GameTime gameTime)
        {
            float fadeSped = (float)gameTime.ElapsedGameTime.TotalSeconds * 4;

            if (isSelected)
                selectionFade = Math.Min(selectionFade + fadeSped, 1);
            else
                selectionFade = Math.Max(selectionFade - fadeSped, 0);
        }

        public virtual void Draw(MenuScreen screen, bool isSelected, GameTime gameTime)
        {
            Color color = isSelected ? Color.Yellow : Color.White;

            double time = gameTime.TotalGameTime.TotalSeconds;

            //float pulsate = (float)Math.Sin(time * 6) + 1;
            //float scale = 1 + pulsate * 0.05f * selectionFade;
            float scale = 1;
            color *= screen.TransitionAlpha;

            screenManager = screen.ScreenManager;
            spriteBatch = screenManager.SpriteBatch;
            font = screenManager.Font;
            
            Vector2 origin = new Vector2(0, font.LineSpacing / 2);

            spriteBatch.DrawString(font, text, position, color, 0, origin, scale, SpriteEffects.None, 0);
        }
    }
}
