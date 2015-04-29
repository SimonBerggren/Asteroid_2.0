using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    public abstract class GameObject
    {
        public Rectangle hitbox { get; protected set; }
        public Texture2D texture { get; protected set; }
        public Vector2 origin { get; protected set; }
        protected Rectangle sourceRec { get; set; }
        public Vector2 position { get; protected set; }
        protected Color color { get; set; }
        protected float scale { get; set; }
        public float rotation { get; set; }
        protected SpriteEffects spriteEffects { get; set; }
        public Vector2 speed;
        public int life { get; set; }
        public Matrix matrix { get; protected set; }

        public Color[] colorArray { get; protected set; }

        public virtual void Update(GameTime gameTime)
        {
            hitbox = new Rectangle((int)(position.X - origin.X), 
                                   (int)(position.Y - origin.Y), 
                                   texture.Width, texture.Height);

                matrix = Matrix.CreateTranslation(new Vector3(-origin, 0.0f)) *
                         Matrix.CreateScale(scale) *
                         Matrix.CreateRotationZ(rotation) *
                         Matrix.CreateTranslation(new Vector3(position, 0.0f));
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, color, rotation, origin, scale, spriteEffects, 1);
        }

        public GameObject(Texture2D Texture, Vector2 Position)
        {
            texture = Texture;
            position = Position;
            hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            origin = new Vector2(hitbox.Width / 2, hitbox.Height / 2);
            sourceRec = new Rectangle(0, 0, hitbox.Width, hitbox.Height);
            scale = 1;
            rotation = 0;
            spriteEffects = SpriteEffects.None;
            color = Color.White;
            colorArray = new Color[texture.Width * texture.Height];
            texture.GetData(colorArray);
        }
    }
}