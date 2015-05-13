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
        public Ship Ship { get; set; }
        public List<Projectile> Projectiles { get; private set; }
        public List<Asteroid> Asteroids { get; private set; }
        public List<PowerUp> PowerUps { get; private set; }
        public ExplosionManager Explosions { get; private set; }
        public HUD HUD { get; private set; }
        public GameOver GameOver { get; private set; }

        public int WindowWidth { get; private set; }
        public int WindowHeight { get; private set; }

        private AsteroidManager Asteroid_Manager { get; set; }
        private ShipManager Ship_Manager { get; set; }
        private CollisionManager Collision_Manager { get; set; }
        private PowerUpManager PowerUp_Manager { get; set; }
        private ProjectileManager Projectile_Manager { get; set; }
        private GameOverManager GameOver_Manager { get; set; }


        public Factory() { }

        public void Initialize(GameScreen parent)
        {
            WindowWidth = parent.WindowWidth;
            WindowHeight = parent.WindowHeight;

            GameOver = new GameOver(parent.Game_Over);
            Ship = new Ship(Textures.mothership, new Vector2(WindowWidth - Textures.mothership.Width / 2,
                                                             WindowHeight - Textures.mothership.Height / 2));

            Asteroids = new List<Asteroid>();
            Projectiles = new List<Projectile>();
            PowerUps = new List<PowerUp>();

            Explosions = new ExplosionManager(this);
            HUD = new HUD(this);

            Collision_Manager = new CollisionManager(this);
            Asteroid_Manager = new AsteroidManager(this);
            Ship_Manager = new ShipManager(this);
            PowerUp_Manager = new PowerUpManager(this);
            Projectile_Manager = new ProjectileManager(this);
            GameOver_Manager = new GameOverManager(this);

        }

        public void UpdateGameScreen(GameTime gameTime, bool otherScreenHasFocus)
        {
            if (otherScreenHasFocus)
                return;

            Collision_Manager.Update(gameTime);
            Asteroid_Manager.Update(gameTime);
            Ship_Manager.Update(gameTime);
            Projectile_Manager.Update(gameTime);
            PowerUp_Manager.Update(gameTime);
            Explosions.Update(gameTime);
            GameOver_Manager.Update(gameTime);
        }

        public void GetViewPort(Viewport viewPort)
        {
            Collision_Manager.GetViewPort(viewPort);
            Asteroid_Manager.GetViewPort(viewPort);
            Ship_Manager.GetViewPort(viewPort);
            Projectile_Manager.GetViewPort(viewPort);
        }

        public void DrawGameScreen(SpriteBatch spriteBatch)
        {
            Asteroid_Manager.Draw(spriteBatch);
            PowerUp_Manager.Draw(spriteBatch);
            Ship_Manager.Draw(spriteBatch);
            Projectile_Manager.Draw(spriteBatch);
            Explosions.Draw(spriteBatch);
            HUD.Draw(spriteBatch);
        }
    }
}
