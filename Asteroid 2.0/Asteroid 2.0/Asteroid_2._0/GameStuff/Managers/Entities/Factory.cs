using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    public class Factory
    {
        public List<Projectile> Projectiles { get; private set; }
        public List<Asteroid> Asteroids { get; private set; }
        public TextureManager Textures { get; private set; }
        public ExplosionManager Explosions { get; private set; }
        public Ship Ship { get; private set; }
        public HUD HUD { get; private set; }

        public int WindowWidth { get; private set; }
        public int WindowHeight { get; private set; }

        private AsteroidManager Asteroid_Manager { get; set; }
        private ShipManager Ship_Manager { get; set; }
        private CollisionManager Collision_Manager { get; set; }

        public Factory() { }

        public void Initialize(GameScreen parent)
        {
            WindowWidth = parent.WindowWidth;
            WindowHeight = parent.WindowHeight;

            Textures = new TextureManager(parent.ScreenManager.Game);

            Asteroids = new List<Asteroid>();
            Projectiles = new List<Projectile>();
            Explosions = new ExplosionManager(this);
            HUD = new HUD(this);

            Ship = new MotherShip(Textures.mothership, new Vector2(WindowWidth - Textures.mothership.Width / 2,
                                                                   WindowHeight - Textures.mothership.Height / 2));

            Collision_Manager = new CollisionManager(this);

            Asteroid_Manager = new AsteroidManager(this);

            Ship_Manager = new ShipManager(this);
        }

        public void UpdateGameScreen(GameTime gameTime, bool otherScreenHasFocus)
        {
            Asteroid_Manager.HandleTime(otherScreenHasFocus);

            if (otherScreenHasFocus)
                return;

            Collision_Manager.Update(gameTime);

            Asteroid_Manager.Update(gameTime);

            Ship_Manager.Update(gameTime);

            Explosions.Update(gameTime);
        }

        public void DrawGameScreen(SpriteBatch spriteBatch)
        {
            Asteroid_Manager.Draw(spriteBatch);

            Ship_Manager.Draw(spriteBatch);

            Explosions.Draw(spriteBatch);

            HUD.Draw(spriteBatch);
        }
    }
}
