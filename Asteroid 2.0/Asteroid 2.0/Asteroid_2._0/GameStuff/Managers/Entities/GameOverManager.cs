
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
                WaitForRespawn -= (float)gameTime.ElapsedGameTime.TotalSeconds;

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
            asteroids.Clear();
            projectiles.Clear();
            powerups.Clear();
        }
    }
}
