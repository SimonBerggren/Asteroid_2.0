using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    public abstract class Ship : GameObject
    {
        public enum Type 
        {
            mother,
            father,
        }

        public Ship(Texture2D tex, Vector2 pos) :base(tex, pos) { }

        public float speedX { get; set; }
        public float speedY { get; set; }
        public Type type { get; protected set; }

        public override void Update(GameTime gameTime)
        {
            speed = new Vector2(speedX, speedY);
            position += speed;

            base.Update(gameTime);
        }
    }
}
