
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Asteroid_2._0
{
    class GameOverManager : Manager
    {
        float WaitForRespawn;
        float ResetRespawn;

        public GameOverManager(Factory parent)
        {
            Initialize(parent);
            WaitForRespawn = ResetRespawn = 2;

        }

        public void Update(GameTime gameTime)
        {
            if (ship.IsDead)
            {
                WaitForRespawn -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                RemoveAsteroids();
            }

            if (WaitForRespawn <= 0)
            {
                WaitForRespawn = ResetRespawn;
                if (ship.life > 0)
                    Reset();
                else
                    gameOver("Lost");
            }
        }

        private void Reset()
        {
            ship.Respawn();
            asteroidTimer = new Timer(2000);
            projectiles.Clear();
            asteroids.Clear();
            powerups.Clear();
        }

        void RemoveAsteroids()
        {
            for (int i = 0; i < asteroids.Count; i++)
            {
                asteroids[i].color *= 0.9f;
            }
        }
    }
}
