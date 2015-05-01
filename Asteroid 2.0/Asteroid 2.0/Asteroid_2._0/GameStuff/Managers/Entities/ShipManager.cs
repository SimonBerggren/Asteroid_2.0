﻿using Microsoft.Xna.Framework;
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
        private bool ableToFire = true;
        private float timer, resettimer;

        public ShipManager(Factory parent)
        {
            Initialize(parent);
            timer = 1f;
            resettimer = 1f;
        }

        public void Update(GameTime gameTime)
        {
            if (ship.IsDead)
                return;

            ship.Update(gameTime);

            Manage_Movement();

            if (ableToFire)
                Manage_Fire();

            if (!ableToFire)
                timer -= 0.1f;
            if (timer <= 0)
            {
                timer = resettimer;
                ableToFire = true;
            }
        }

        private void Manage_Movement()
        {
            float xDiff = Input.MousePoint().X - ship.position.X;
            float yDiff = Input.MousePoint().Y - ship.position.Y;

            Vector2 facingDirection = new Vector2(xDiff, yDiff);
            facingDirection.Normalize();

            ship.rotation = (float)Math.Atan2(yDiff, xDiff);
            float distance = Vector2.Distance(ship.position, Input.MousePosition());

            ship.speedX = facingDirection.X * (distance / 50);
            ship.speedY = facingDirection.Y * (distance / 50);
        }

        private void Manage_Fire()
        {
            if (Input.HoldingLeft())
            {
                projectiles.Add(new Bullet(textures.bullet, ship.position));
                ableToFire = false;
            }

            if (Input.HoldingRight())
            {
                projectiles.Add(new Bullet(textures.bullet, ship.position, true));
                ableToFire = false;
            }

            if (Input.Clicked(Keys.Space))
                Fire_Missile();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(!ship.IsDead)
            ship.Draw(spriteBatch);
        }

        private void Fire_Missile()
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
                projectiles.Add(new Missile(textures.laser, ship.position, ref ClosestAsteroid));
                ClosestAsteroid.IsTargeted = true;
            }
            else
                return;
        }
    }
}
