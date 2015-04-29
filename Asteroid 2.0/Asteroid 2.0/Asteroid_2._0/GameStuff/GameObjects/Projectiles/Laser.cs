using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class Laser : Projectile
    {
        public Laser(Texture2D tex, Vector2 position, bool isReverse = false, Vector2 facingDirection = default(Vector2))
            : base(tex, position, isReverse, facingDirection)
        {
            life = 3;
        }
    }
}
