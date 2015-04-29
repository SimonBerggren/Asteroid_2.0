using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_2._0
{
    public class ParticleEngine
    {
        private List<Particle> particles = new List<Particle>();
        private List<Texture2D> textures = new List<Texture2D>();
        private Random random = new Random();

        private int totalParticles = 5000;

        public Vector2 EmitterLocationForExplosion { set; get; }
        public ParticleEngine()
        {
            //textures.Add(parent.Texture.RedFire);
            //textures.Add(parent.Texture.YellowFire);
        }

        public void Update()
        {
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Update();
                if (particles[index].TTL <= 0)
                {
                    particles.RemoveAt(index);
                    index--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }
        }
        
        private Particle NewParticle()
        {
            Texture2D texture = textures[random.Next(textures.Count)];
            Vector2 position = EmitterLocationForExplosion;
            Vector2 velocity = new Vector2(
                    3f * (float)(random.NextDouble() * 2 - 1),
                    3f * (float)(random.NextDouble() * 2 - 1));
            velocity = Vector2.Normalize(velocity) * (float)(random.NextDouble() * 3);
            float angle = 0;
            float angularVelocity = 4.1f * (float)(random.NextDouble() * 2 - 1);
            float size = 1;
            int ttl = 1 + random.Next(25);

            return new Particle(texture, position, velocity, angle, angularVelocity, Color.White, size, ttl);
        }

        public void AddParticlesForExplosion()
        {
            for (int i = 0; i < totalParticles; i++)
            {
                particles.Add(NewParticle());
            }
        }
    }
}

