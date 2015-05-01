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
        Timer difficultyTimer = new Timer(5000);
        Timer timer = new Timer(2000);
        private int asteroidSpawnCount = 0;

        public AsteroidManager(Factory parent)
        {
            Initialize(parent);

            timer.Start();
            difficultyTimer.Start();

            timer.Elapsed += SpawnAsteroid;
            difficultyTimer.Elapsed += FasterSpawning;
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < asteroids.Count; i++)
            {
                Asteroid asteroid = asteroids[i];

                asteroid.Update(gameTime);

                if (asteroid.life <= 0)
                {
                    if (asteroid.type == Type.Big)
                        AsteroidDies(asteroid);

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

        private void FasterSpawning(Object source, ElapsedEventArgs e)
        {
            if (timer.Interval > 300)
                timer.Interval -= 100;
        }

        private void SpawnAsteroid(Object source, ElapsedEventArgs e)
        {
            if (asteroidSpawnCount == 5 || asteroidSpawnCount == 10 || asteroidSpawnCount == 15 || asteroidSpawnCount == 20)
            asteroids.Add(new Asteroid(textures.asteroid, new Vector2(random.Next(50, windowWidth - 50), 50), random.Next(-5, 5), random.Next(1, 5), random.Next(5), Type.Big));
            else
                asteroids.Add(new Asteroid(textures.asteroid, new Vector2(random.Next(50, windowWidth - 50), 50), random.Next(-5, 5), random.Next(1, 5), random.Next(5), Type.Normal));

            asteroidSpawnCount++;
        }

        private void AsteroidDies(Asteroid Asteroid)
        {

            for (int i = 0; i < 5; i++)
            {
                asteroids.Add(new Asteroid(textures.asteroid, Asteroid.position, random.Next(-5, 5), random.Next(1, 5), random.Next(5), Type.Normal));
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int a = 0; a < asteroids.Count; a++)
            {
                asteroids[a].Draw(spriteBatch);
            }
        }

        public void HandleTime(bool Paused)
        {
            if (!Paused)
            {
                timer.Start();
                difficultyTimer.Start();
            }
            else
            {
                timer.Stop();
                difficultyTimer.Stop();
            }
        }
    }
}
