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
        private double timer;
        public PowerUpManager(Factory parent)
            : base()
        {
            Initialize(parent);

            timer = 5;

            ship.Event_Explosion += MassiveExplosion;
            ship.Event_Missile += Fire_Missile;
            ship.Event_Speed += BoostSpeed;
        }

        public void Update(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;

            if (timer <= 0)
            {
                SpawnPowerUp();
                timer = random.Next(2, 7);
            }

            for (int i = 0; i < powerups.Count; i++)
            {
                PowerUp powerup = powerups[i];

                powerup.Update(gameTime);

                if (powerup.life <= 0)
                {
                    powerup.ActivatePowerUp(ship);
                    powerups.Remove(powerup);
                    continue;
                }

                if (powerup.hitbox.Top >= windowHeight)
                    powerups.Remove(powerup);
                else if (powerup.hitbox.Right <= 0)
                    powerups.Remove(powerup);
                else if (powerup.hitbox.Left >= windowWidth)
                    powerups.Remove(powerup);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (PowerUp PU in powerups)
                PU.Draw(spriteBatch);
        }

        private void SpawnPowerUp()
        {
            int randomPowerUp = random.Next(4);
            switch (randomPowerUp)
            {
                case 1:
                    powerups.Add(new Power_Explosion(Textures.PowerUpTextures[random.Next(Textures.PowerUpTextures.Length)], new Vector2(random.Next(50, windowWidth - 50), 50), random.Next(-5, 5), random.Next(1, 5), random.Next(5)));
                    break;
                case 2:
                    powerups.Add(new Power_Missile(Textures.PowerUpTextures[random.Next(Textures.PowerUpTextures.Length)], new Vector2(random.Next(50, windowWidth - 50), 50), random.Next(-5, 5), random.Next(1, 5), random.Next(5)));
                    break;
                default:
                    powerups.Add(new Power_Speed(Textures.PowerUpTextures[random.Next(Textures.PowerUpTextures.Length)], new Vector2(random.Next(50, windowWidth - 50), 50), random.Next(-5, 5), random.Next(1, 5), random.Next(5)));
                    break;
            }


        }

        private void BoostSpeed(object sender, EventArgs e)
        {
            
        }

        private void MassiveExplosion(object sender, EventArgs e)
        {

        }

        private void Fire_Missile(object sender, EventArgs e)
        {
            if (asteroids.Count <= 0)
                return;

            List<Asteroid> TempList = asteroids;

            TempList.OrderBy<Asteroid, bool>
                (asteroid => asteroid.IsTargeted).ToList<Asteroid>();

            Asteroid ClosestAsteroid = TempList.OrderBy<Asteroid, float>
                (asteroid => Vector2.Distance(asteroid.position, Input.MousePosition())).ToList<Asteroid>()[0];

            if (ClosestAsteroid.IsTargeted == false)
            {
                projectiles.Add(new Missile(Textures.laser, ship.position, ref ClosestAsteroid));
                ClosestAsteroid.IsTargeted = true;
            }
        }
    }
}
