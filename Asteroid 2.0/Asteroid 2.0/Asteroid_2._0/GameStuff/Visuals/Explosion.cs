using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Asteroid_2._0
{
    #region ExplosionManager

    class Explosion
    {
        private Texture2D texture;
        private Vector2 position, origin;
        private float time;

        public Rectangle sourceRec;
        public bool isFinnished;

        public Explosion(Texture2D Texture, Vector2 Position)
        {
            texture = Texture;
            position = Position;
            sourceRec = new Rectangle(0, 0, Texture.Width / 5, Texture.Height / 5);
            origin = new Vector2(Texture.Width / 5 / 2, Texture.Height / 5 / 2);
        }

        public void Update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.Milliseconds;

            if (time >= 20)
            {
                sourceRec.X += sourceRec.Width;

                if (sourceRec.X == sourceRec.Width * 5 - sourceRec.Width)
                {
                    if (sourceRec.Y == sourceRec.Height * 5 - sourceRec.Height)
                        isFinnished = true;
                    else
                        sourceRec.Y += sourceRec.Height;
                    sourceRec.X = 0;
                }

                time = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRec, Color.White, 0, origin, 2, SpriteEffects.None, 1);
        }
    }

    public class ExplosionManager
    {
        private Texture2D texture;

        private List<Explosion> explosions;

        public ExplosionManager(Factory Factory)
        {
            texture = Factory.Textures.ExplosionSheet;
            explosions = new List<Explosion>();
        }

        public void Explode(Vector2 Position)
        {
            explosions.Add(new Explosion(texture, Position));
        }

        public void Update(GameTime gameTime)
        {
            for (int index = 0; index < explosions.Count; index++)
            {
                explosions[index].Update(gameTime);

                if (explosions[index].isFinnished)
                    explosions.RemoveAt(index--);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int index = 0; index < explosions.Count; index++)
                explosions[index].Draw(spriteBatch);
        }
    }

    #endregion
}
