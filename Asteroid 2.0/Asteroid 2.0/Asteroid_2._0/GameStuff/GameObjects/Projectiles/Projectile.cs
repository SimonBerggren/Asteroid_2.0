using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_2._0
{
    public abstract class Projectile : GameObject
    {
        public Vector2 Direction { set { direction = value; } }
        protected Vector2 direction;
        protected float projectileSpeed;

        public Projectile(Texture2D Texture, Vector2 Position, bool isReverse = false, Vector2 facingDirection = default(Vector2))
        {
            Initialize(Texture, Position);

            if (facingDirection == default(Vector2))
                this.direction = Input.MousePosition() - position;
            else
                direction = facingDirection;

            direction.Normalize();

            if (isReverse)
                direction *= -1;

            this.rotation = (float)Math.Atan2(direction.Y, direction.X);

        }

        public override void Update(GameTime gameTime)
        {
            position += direction * projectileSpeed;

            base.Update(gameTime);
        }
    }
}
