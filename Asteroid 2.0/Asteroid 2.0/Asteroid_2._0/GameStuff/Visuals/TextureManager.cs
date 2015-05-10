using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    public static class Textures
    {
        #region Game Textures

        public static Texture2D asteroid { get; private set; }

        public static Texture2D mothership { get; private set; }
        public static Texture2D fathership { get; private set; }

        public static Texture2D bullet { get; private set; }
        public static Texture2D laser { get; private set; }

        public static Texture2D powerup { get; private set; }

        public static Texture2D cannon { get; private set; }

        public static Texture2D hud { get; private set; }

        public static Texture2D[] PowerUpTextures { get; private set; }

        #endregion

        #region Particles

        public static Texture2D YellowFire { get; private set; }
        public static Texture2D RedFire { get; private set; }

        public static Texture2D ExplosionSheet { get; private set; }

        public static Texture2D blankPic { get; private set; }

        public static SpriteFont font { get; private set; }

        #endregion

        public static void LoadContent(Game Game)
        {
            ContentManager Content = new ContentManager(Game.Services, Game.Content.RootDirectory);

            asteroid = Content.Load<Texture2D>("Asteroid");

            mothership = Content.Load<Texture2D>(@"MotherShip");
            fathership = Content.Load<Texture2D>(@"FatherShip");

            bullet = Content.Load<Texture2D>(@"Bullet");
            laser = Content.Load<Texture2D>(@"Laser");

            cannon = Content.Load<Texture2D>(@"Cannon");

            hud = Content.Load<Texture2D>(@"HUD");

            RedFire = Content.Load<Texture2D>(@"RedFire");
            YellowFire = Content.Load<Texture2D>(@"YellowFire");

            ExplosionSheet = Content.Load<Texture2D>(@"Explosion");

            blankPic = Content.Load<Texture2D>(@"blank");

            font = Content.Load<SpriteFont>(@"menufont");

            PowerUpTextures = new Texture2D[] 
            {
                   Content.Load<Texture2D>(@"Power_Up1"),
                   Content.Load<Texture2D>(@"Power_Up2"),
                   Content.Load<Texture2D>(@"Power_Up3"),
                   Content.Load<Texture2D>(@"Power_Up4"),
                   Content.Load<Texture2D>(@"Power_Up5"),
                   Content.Load<Texture2D>(@"Power_Up6"),
                   Content.Load<Texture2D>(@"Power_Up7"),
                   Content.Load<Texture2D>(@"Power_Up8"),
                   Content.Load<Texture2D>(@"Power_Up9"),
            };

        }
    }
}
