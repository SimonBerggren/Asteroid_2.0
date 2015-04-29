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
        private Rectangle background;
        private string lifeText, killCountText;
        private Texture2D texture;
        private SpriteFont font;
        public short life, killCount;

        public HUD(Factory parent)
        {
            texture = parent.Textures.blankPic;
            font = parent.Textures.font;
            background = new Rectangle(parent.WindowWidth / 2 - parent.WindowWidth / 3 / 2, parent.WindowHeight - 50, parent.WindowWidth / 3, 50);
            life = 3;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            lifeText = "Life: " + life.ToString();
            killCountText = "Kills: " + killCount.ToString();

            spriteBatch.Draw(texture, background, Color.White);

            spriteBatch.DrawString(font, lifeText, new Vector2(background.X + 10, background.Y), Color.Black);
            spriteBatch.DrawString(font, killCountText, new Vector2(background.X + 10, background.Y + 15), Color.Black);
        }
    }
}
