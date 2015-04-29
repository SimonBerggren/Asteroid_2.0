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

        public Projectile(Texture2D tex, Vector2 pos, bool isReverse = false, Vector2 facingDirection = default(Vector2))
            : base(tex, pos)
        {
            this.position = position;
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
            if (hitbox.Bottom <= 0)
                life -= life;

            position += direction * 15;

            base.Update(gameTime);
        }
    }
}
