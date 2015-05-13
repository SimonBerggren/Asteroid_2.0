using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    public class Ship : GameObject
    {
        public EventHandler<EventArgs> Event_Fire;
        public EventHandler<EventArgs> Event_Missile;
        public EventHandler<EventArgs> Event_Speed;
        public EventHandler<EventArgs> Event_Explosion;

        public void Fire()
        {
            if (Event_Fire != null)
                Event_Fire(this, new EventArgs());
        }

        public void ShootMissile()
        {
            if (Event_Missile != null && NrOfMissiles > 0)
            {
                Event_Missile(this, new EventArgs());
                NrOfMissiles--;
            }
        }

        public void BoostSpeed()
        {
            if (Event_Speed != null && NrOfSpeeds > 0)
            {
                Event_Speed(this, new EventArgs());
                NrOfSpeeds--;
            }
        }

        public void Explode()
        {
            if (Event_Explosion != null && NrOfExplodes > 0)
            {
                Event_Explosion(this, new EventArgs());
                NrOfExplodes--;
            }
        }

        public int NrOfExplodes;
        public int NrOfSpeeds;
        public int NrOfMissiles;

        public bool IsDead { get; set; }
        public float speedX { get; set; }
        public float speedY { get; set; }

        private Vector2 respawnPosition;

        public Ship(Texture2D Texture, Vector2 Position)
        {
            Initialize(Texture, Position);
            respawnPosition = Position;

            life = 3;

            NrOfExplodes = 0;
            NrOfMissiles = 0;
            NrOfSpeeds = 0;
        }

        public override void Update(GameTime gameTime)
        {
            speed = new Vector2(speedX, speedY);

            position += speed;

            base.Update(gameTime);
        }

        public void Respawn()
        {
            position = respawnPosition;
            IsDead = false;

            NrOfExplodes = 0;
            NrOfMissiles = 0;
            NrOfSpeeds = 0;
        }
    }
}
