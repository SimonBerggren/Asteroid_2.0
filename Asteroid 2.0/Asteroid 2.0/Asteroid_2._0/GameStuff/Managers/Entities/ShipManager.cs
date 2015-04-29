using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class ShipManager : Manager
    {
        public ShipManager(Factory parent)
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
                    projectiles.Remove(projectile);
            }

            ship.Update(gameTime);

            HandleInput();
            Fire();
        }

        private void HandleInput()
        {
            float xDiff = Input.MousePoint().X - ship.position.X;
            float yDiff = Input.MousePoint().Y - ship.position.Y;
            Vector2 facingDirection = new Vector2(xDiff, yDiff);
            facingDirection.Normalize();
            ship.rotation = (float)Math.Atan2(yDiff, xDiff);
            float distance = Vector2.Distance(ship.position, Input.MousePosition());

            ship.speedX = facingDirection.X * (distance / 20);
            ship.speedY = facingDirection.Y * (distance / 20);
        }

        private void Fire()
        {
            if (Input.LeftClick())
            {
                switch (ship.type)
                {
                    case Ship.Type.mother:
                        projectiles.Add(new Bullet(textures.bullet, ship.position));
                        break;
                    case Ship.Type.father:
                        projectiles.Add(new Laser(textures.laser, ship.position));
                        break;
                }
            }

            if (Input.RightClick())
            {
                switch (ship.type)
                {
                    case Ship.Type.mother:
                        projectiles.Add(new Bullet(textures.bullet, ship.position, true));
                        break;
                    case Ship.Type.father:
                        projectiles.Add(new Laser(textures.laser, ship.position, true));
                        break;
                }
            }

            if (Input.Clicked(Keys.Space))
                Cheat();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Projectile B in projectiles)
                B.Draw(spriteBatch);

            ship.Draw(spriteBatch);
        }

        private void Cheat()
        {
            for (int i = 0; i < 100; i++)
            {
                Vector2 velocity = new Vector2(
                    3f * (float)(random.NextDouble() * 2 - 1),
                    3f * (float)(random.NextDouble() * 2 - 1));
                velocity = Vector2.Normalize(velocity) * (float)(random.NextDouble() * 3);

                projectiles.Add(new Bullet(textures.bullet, ship.position, false, velocity));
            }
        }
    }
}
