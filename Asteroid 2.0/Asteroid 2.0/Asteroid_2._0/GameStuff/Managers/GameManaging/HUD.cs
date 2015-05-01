using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    public class HUD
    {
        private Rectangle background1, background2;
        private string lifeText, killCountText;
        private Texture2D texture;
        private SpriteFont font;
        public int life, killCount;
        private float offsetY;
        private float offsetX;

        Ship player;

        public HUD(Factory parent)
        {
            texture = parent.Textures.hud;
            font = parent.Textures.font;

            player = parent.Ship;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            life = player.life;

            lifeText = "Life: " + life.ToString();
            killCountText = "Kills: " + killCount.ToString();
            
            offsetX = 10;
            offsetY = font.MeasureString(lifeText).Y + 5;

            int width = (int)(font.MeasureString(lifeText).X + offsetX);
            int height = (int)font.MeasureString(lifeText).Y;

            background1 = new Rectangle(0, 0, width, height);
            background2 = new Rectangle(0, height, width, height);

            spriteBatch.Draw(texture, background1, Color.White);
            spriteBatch.Draw(texture, background2, Color.White);

            spriteBatch.DrawString(font, lifeText, new Vector2(background1.X + offsetX / 2, background1.Y), Color.Red);
            spriteBatch.DrawString(font, killCountText, new Vector2(background1.X + offsetX / 2, background1.Y + offsetY), Color.Red);
        }
    }
}
