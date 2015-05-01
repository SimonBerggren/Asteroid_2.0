using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    public class Ship : GameObject
    {
        public bool IsDead { get; set; }
        public float speedX { get; set; }
        public float speedY { get; set; }

        private Action powerUp { get; set; }

        private Vector2 respawnPosition;

        public Ship(Texture2D Texture, Vector2 Position)
        {
            Initialize(Texture, Position);
            respawnPosition = Position;

            life = 3;
        }

        public override void Update(GameTime gameTime)
        {
            speed = new Vector2(speedX, speedY);

            position += speed;

            base.Update(gameTime);
        }

        public void ActivatePowerUp(Action PowerUp)
        {
            powerUp = PowerUp;
        }

        public void UsePowerUp()
        {
            if (powerUp != null)
                powerUp();
            powerUp = null;
        }

        public void Respawn()
        {
            position = respawnPosition;
            IsDead = false;
        }
    }
}
