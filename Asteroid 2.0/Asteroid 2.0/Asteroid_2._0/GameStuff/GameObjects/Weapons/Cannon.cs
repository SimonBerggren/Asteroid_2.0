using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class Cannon:Weapon
    {
        float xDiff, yDiff;

        public Cannon(Texture2D tex, Vector2 pos)
            : base(tex, pos)
        {
        }

        public override void Update(GameTime gameTime)
        {
            xDiff = Input.MousePoint().X - position.X;
            yDiff = Input.MousePoint().Y - position.Y;
            rotation = (float)Math.Atan2(yDiff, xDiff);

            base.Update(gameTime);
        }
    }
}
