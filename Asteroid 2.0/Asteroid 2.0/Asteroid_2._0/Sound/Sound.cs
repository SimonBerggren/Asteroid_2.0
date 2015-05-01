using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    public static class Sound
    {
        public static Song MenuMusic { get; private set; }
        public static Song GameMusic { get; private set; }

        public static void LoadContent(ContentManager Content)
        {
            MenuMusic = Content.Load<Song>("MenuMusic");
            GameMusic = Content.Load<Song>("GameMusic");

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0;
        }
    }
}
