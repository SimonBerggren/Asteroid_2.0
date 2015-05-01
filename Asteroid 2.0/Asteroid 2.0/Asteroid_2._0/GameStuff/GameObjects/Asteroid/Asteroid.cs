using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Asteroid_2._0
{
    public enum Type
    {
        Normal,
        Big
    }

    public enum HealthState
    {
        Full = 3,
        Medium = 2,
        Low = 1,
    }

    public class Asteroid : GameObject
    {
        private float rotationSpeed;

        public Type type;

        public bool IsTargeted { get; set; }

        private HealthState health;

        public Asteroid(Texture2D Texture, Vector2 Position, float speedX, float speedY, float RotationSpeed, Type ThisType)
        {
            SetScale(ThisType);

            Initialize(Texture, Position);

            rotationSpeed = RotationSpeed;
            speed = new Vector2(speedX, speedY);
            life = 3;
        }

        private void SetScale(Type ThisType)
        {
            type = ThisType;

            switch (type)
            {
                case Type.Normal:
                    scale = 1;
                    break;
                case Type.Big:
                    scale = 2;
                    break;
            }
        }

        protected override void Initialize(Texture2D Texture, Vector2 Position)
        {
            texture = Texture;
            position = Position;
            sourceRec = new Rectangle(0, 0, Texture.Width / 3, Texture.Height);
            hitbox = new Rectangle((int)position.X, (int)position.Y, sourceRec.Width * (int)scale, sourceRec.Height * (int)scale);
            origin = new Vector2(sourceRec.Width / 2, sourceRec.Height / 2);
            rotation = 0;
            spriteEffects = SpriteEffects.None;
            color = Color.White;
            colorArray = new Color[texture.Width * texture.Height];
            texture.GetData(colorArray);
        }

        public override void Update(GameTime gameTime)
        {
            rotation += (speed.X * 0.025f);
            position += speed;

            health = (HealthState)Enum.ToObject(typeof(HealthState), life);

            switch (health)
            {
                case HealthState.Full:
                    sourceRec.X = 0;
                    break;
                case HealthState.Medium:
                    sourceRec.X = 50;
                    break;
                case HealthState.Low:
                    sourceRec.X = 100;
                    break;
            }

            hitbox = new Rectangle((int)(position.X - origin.X * scale),
                                   (int)(position.Y - origin.Y * scale),
                                    sourceRec.Width * (int)scale,
                                    sourceRec.Height * (int)scale);

            matrix = Matrix.CreateTranslation(new Vector3(-origin, 0.0f)) *
                     Matrix.CreateScale(scale) *
                     Matrix.CreateRotationZ(rotation) *
                     Matrix.CreateTranslation(new Vector3(position, 0.0f));

        }
    }
}
