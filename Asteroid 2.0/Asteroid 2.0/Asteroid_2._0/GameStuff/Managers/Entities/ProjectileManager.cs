using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class ProjectileManager : Manager
    {
        public ProjectileManager(Factory parent)
        {
            Initialize(parent);


        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                Projectile projectile = projectiles[i];

                projectile.Update(gameTime);

                if (projectile.hitbox.Bottom < 0 || projectile.hitbox.Top > windowHeight ||
                    projectile.hitbox.Right < 0 || projectile.hitbox.Left > windowWidth)
                {
                    projectiles.Remove(projectile);
                    continue;
                }

                if (projectile.life <= 0)
                {
                    projectiles.Remove(projectile);
                    continue;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < projectiles.Count; i++)
                projectiles[i].Draw(spriteBatch);
        }
    }
}
