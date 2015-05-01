
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class Missile : Projectile
    {
        Asteroid target;

        public Missile(Texture2D Texture, Vector2 Position, ref Asteroid Target)
            : base(Texture, Position, false, default(Vector2))
        {
            life = 10;

            target = Target;
            projectileSpeed = 10;

            direction = Target.position - position;

            direction.Normalize();

            rotation = (float)Math.Atan2(direction.Y, direction.X);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (target.life <= 0)
                return;

            if (life <= 0)
                target.IsTargeted = false;


            direction = target.position - position;

            direction.Normalize();

            rotation = (float)Math.Atan2(direction.Y, direction.X);


        }
    }
}
