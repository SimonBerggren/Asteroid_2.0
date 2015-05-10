using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Asteroid_2._0
{
    class PowerUpManager : Manager
    {
        public PowerUpManager(Factory parent)
            : base()
        {
            Initialize(parent);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < powerups.Count; i++)
            {
                PowerUp powerup = powerups[i];

                powerup.Update(gameTime);

                if (powerup.life <= 0)
                {
                    powerups.Remove(powerup);
                    ship.ActivatePowerUp(MassiveExplosion);
                    continue;
                }

                if (powerup.hitbox.Top >= windowHeight)
                    powerups.Remove(powerup);
                else if (powerup.hitbox.Right <= 0)
                    powerups.Remove(powerup);
                else if (powerup.hitbox.Left >= windowWidth)
                    powerups.Remove(powerup);
            }

            if (Input.Clicked(Keys.Enter))
                SpawnPowerUp();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (PowerUp PU in powerups)
                PU.Draw(spriteBatch);
        }

        private void SpawnPowerUp()
        {
            powerups.Add(new PowerUp(Textures.PowerUpTextures[random.Next(Textures.PowerUpTextures.Length)], new Vector2(random.Next(50, windowWidth - 50), 50), random.Next(-5, 5), random.Next(1, 5), random.Next(5)));
        }

        public void MassiveExplosion()
        {
            for (int i = 0; i < 100; i++)
            {
                Vector2 velocity = new Vector2(
                    3f * (float)(random.NextDouble() * 2 - 1),
                    3f * (float)(random.NextDouble() * 2 - 1));
                velocity = Vector2.Normalize(velocity) * (float)(random.NextDouble() * 3);

                projectiles.Add(new Bullet(Textures.bullet, ship.position, false, velocity));
            }
        }
    }
}
