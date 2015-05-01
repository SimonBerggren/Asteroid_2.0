using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    public class PowerUp : GameObject
    {
        private float rotationSpeed;

        public PowerUp(Texture2D Texture, Vector2 Position, float speedX, float speedY, float RotationSpeed)
        {
            rotationSpeed = RotationSpeed;
            speed = new Vector2(speedX, speedY);
            life = 3;

            Initialize(Texture, Position);
        }

        public override void Update(GameTime gameTime)
        {
            rotation += (speed.X * 0.025f);
            position += speed;
            base.Update(gameTime);
        }
    }
}
