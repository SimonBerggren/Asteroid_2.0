using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class CollisionManager : Manager
    {
        public CollisionManager(Factory parent)
        {
            Initialize(parent);
        }

        public void Update(GameTime gameTime)
        {
            Asteroid_Collisions();
            Ship_PowerUp_Collisions();
        }

        private void Asteroid_Collisions()
        {
            for (int a = 0; a < asteroids.Count; a++)
            {
                Asteroid asteroid = asteroids[a];
                Ship_Asteroid_Collision(ref asteroid);

                for (int p = 0; p < projectiles.Count; p++)
                {
                    Projectile projectile = projectiles[p];


                    if (asteroid.hitbox.Intersects(projectile.hitbox))
                    {
                        if (ReallyIsColliding(asteroid.matrix, asteroid.texture.Width, asteroid.texture.Height, asteroid.colorArray,
                                            projectile.matrix, projectile.texture.Width, projectile.texture.Height, projectile.colorArray))
                        {
                            asteroid.life -= projectile.life;
                            projectile.life -= projectile.life;
                        }
                    }
                }
            }
        }

        private void Ship_PowerUp_Collisions()
        {
            for (int p = 0; p < powerups.Count; p++)
            {
                PowerUp powerup = powerups[p];

                if (powerup.hitbox.Intersects(ship.hitbox))
                    powerup.life -= powerup.life;
            }
        }

        private void Ship_Asteroid_Collision(ref Asteroid asteroid)
        {
            if (asteroid.hitbox.Intersects(ship.hitbox))
            {
                if (ReallyIsColliding(asteroid.matrix, asteroid.texture.Width, asteroid.texture.Height, asteroid.colorArray,
                                    ship.matrix, ship.texture.Width, ship.texture.Height, ship.colorArray))
                {
                    ship.life -= ship.life;
                    asteroid.life -= asteroid.life;
                }
            }
        }

        private bool ReallyIsColliding(Matrix transformA, int widthA, int heightA, Color[] dataA,
                                     Matrix transformB, int widthB, int heightB, Color[] dataB)
        {
            Matrix transformAToB = transformA * Matrix.Invert(transformB);

            Vector2 stepX = Vector2.TransformNormal(Vector2.UnitX, transformAToB);
            Vector2 stepY = Vector2.TransformNormal(Vector2.UnitY, transformAToB);

            Vector2 yPosInB = Vector2.Transform(Vector2.Zero, transformAToB);

            for (int yA = 0; yA < heightA; yA++)
            {
                Vector2 posInB = yPosInB;

                for (int xA = 0; xA < widthA; xA++)
                {
                    int xB = (int)Math.Round(posInB.X);
                    int yB = (int)Math.Round(posInB.Y);

                    if (0 <= xB && xB < widthB &&
                        0 <= yB && yB < heightB)
                    {
                        Color colorA = dataA[xA + yA * widthA];
                        Color colorB = dataB[xB + yB * widthB];

                        if (colorA.A != 0 && colorB.A != 0)
                        {
                            return true;
                        }
                    }
                    posInB += stepX;
                }
                yPosInB += stepY;
            }
            return false;
        }
    }
}
