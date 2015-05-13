using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    public class Power_Explosion : PowerUp
    {
        public Power_Explosion(Texture2D Texture, Vector2 Position, float SpeedX, float SpeedY, float RotationSpeed)
            : base(Texture, Position, SpeedX, SpeedY, RotationSpeed)
        {

        }
        public override void ActivatePowerUp(Ship ship)
        {
            ship.NrOfExplodes++;
        }
    }
}
