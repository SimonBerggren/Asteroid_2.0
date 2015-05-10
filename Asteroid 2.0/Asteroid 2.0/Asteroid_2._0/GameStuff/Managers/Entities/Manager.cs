using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Asteroid_2._0
{
    abstract class Manager
    {
        protected List<Projectile> projectiles { get; private set; }
        protected ExplosionManager explosions { get; private set; }
        protected List<Asteroid> asteroids { get; private set; }
        protected List<PowerUp> powerups { get; private set; }
        protected int windowHeight { get; private set; }
        protected int windowWidth { get; private set; }
        protected Random random { get; private set; }
        protected Ship ship { get; private set; }
        protected HUD hud { get; private set; }
        protected GameOver gameOver { get; private set; }

        protected Timer difficultyTimer;
        protected Timer asteroidTimer;

        protected void Initialize(Factory parent)
        {
            asteroids = parent.Asteroids;
            projectiles = parent.Projectiles;
            powerups = parent.PowerUps;
            ship = parent.Ship;

            hud = parent.HUD;
            explosions = parent.Explosions;

            windowWidth = parent.WindowWidth;
            windowHeight = parent.WindowHeight;

            gameOver = parent.GameOver;

            random = new Random();
            difficultyTimer = new Timer(5000);
            asteroidTimer = new Timer(2000);
        }

        public void GetViewPort(Viewport viewport)
        {
            windowWidth = viewport.Width;
            windowHeight = viewport.Height;
        }
    }
}
