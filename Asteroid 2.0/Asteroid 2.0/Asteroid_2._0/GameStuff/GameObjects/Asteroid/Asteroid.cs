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
    public class Asteroid : GameObject
    {
        private float rotationSpeed;

        public Asteroid(Texture2D Texture, Vector2 Position, float speedX, float speedY, float RotationSpeed) 
            :base(Texture, Position)
        {
            rotationSpeed = RotationSpeed;
            position = Position;
            speed = new Vector2(speedX, speedY);
            life = 3;
        }

        public override void Update(GameTime gameTime)
        {
            rotation += (speed.X * 0.025f);
            position += speed;
            base.Update(gameTime);
        }
    }
}
