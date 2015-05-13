using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Asteroid_2._0
{
    class AsteroidManager : Manager
    {
        private int asteroidSpawnCount = 0;
        private double timer, resetTimer, difficultTimer, resetDifficult;

        public AsteroidManager(Factory parent)
        {
            Initialize(parent);

            timer = resetTimer = 5;
            difficultTimer = resetDifficult = 10;
        }

        public void Update(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;

            if (timer <= 0)
            {
                SpawnAsteroid();
                timer = resetTimer;
            }

            if (timer > 2)
            {
                difficultTimer -= gameTime.ElapsedGameTime.TotalSeconds;

                if (difficultTimer <= 0)
                {
                    timer -= 0.2;
                    difficultTimer = resetDifficult;
                }
            }

            for (int i = 0; i < asteroids.Count; i++)
            {
                Asteroid asteroid = asteroids[i];

                asteroid.Update(gameTime);

                if (asteroid.life <= 0)
                {
                    if (asteroid.type == Type.Big)
                        SpawnSmallAsteroids(asteroid.position);

                    asteroids.Remove(asteroid);
                    explosions.Explode(asteroid.position);
                    hud.killCount++;
                    break;
                }

                if (asteroid.hitbox.Top >= windowHeight)
                {
                    asteroids.Remove(asteroid);
                    break;
                }

                if (asteroid.hitbox.Right > windowWidth || asteroid.hitbox.Left < 0)
                    asteroid.speed.X = -asteroid.speed.X;
            }
        }

        private void SpawnAsteroid()
        {
            if (asteroidSpawnCount == 5 || asteroidSpawnCount == 10 || asteroidSpawnCount == 15 || asteroidSpawnCount == 20)
                asteroids.Add(new Asteroid(Textures.asteroid, new Vector2(random.Next(50, windowWidth - 50), 50), random.Next(-5, 5), random.Next(1, 5), random.Next(5), Type.Big));
            else
                asteroids.Add(new Asteroid(Textures.asteroid, new Vector2(random.Next(50, windowWidth - 50), 50), random.Next(-5, 5), random.Next(1, 5), random.Next(5), Type.Normal));

            asteroidSpawnCount++;
        }

        private void SpawnSmallAsteroids(Vector2 Position)
        {
            for (int i = 0; i < 5; i++)
            {
                asteroids.Add(new Asteroid(Textures.asteroid, Position, random.Next(-5, 5), random.Next(1, 5), random.Next(5), Type.Normal));
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int a = 0; a < asteroids.Count; a++)
            {
                asteroids[a].Draw(spriteBatch);
            }
        }
    }
}
