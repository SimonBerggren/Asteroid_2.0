using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class MotherShip : Ship
    {
        public MotherShip(Texture2D tex, Vector2 pos)
            : base(tex, pos)
        {
            type = Type.mother;
            
        }
    }
}
