using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class FatherShip : Ship
    {
        public FatherShip(Texture2D tex, Vector2 pos)
            : base(tex, pos)
        {
            this.position = position;
            type = Type.father;
            this.scale = 0.5f;
        }
    }
}
