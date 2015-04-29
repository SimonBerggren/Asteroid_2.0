using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    abstract class Weapon : GameObject
    {
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Weapon(Texture2D tex, Vector2 pos)
            : base(tex, pos)
        {
            texture = tex;
            position = pos;
        }
    }
}
