using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class MusicVolumeControl : MenuScreen
    {
        float MusicVolume;

        MenuEntry alterMusic;
        MenuEntry goBack;

        public MusicVolumeControl()
            : base("") { }

        public override void LoadContent()
        {
            alterMusic = new MenuEntry("");
            goBack = new MenuEntry("Back");

            goBack.Selected += GoBack;

            MenuEntries.Add(alterMusic);
            MenuEntries.Add(goBack);

            base.LoadContent();
        }

        private void GoBack(object sender, EventArgs e)
        {
            IsExiting = true;
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            if (MusicVolume > 1) MusicVolume = 1;
            if (MusicVolume < 0) MusicVolume = 0;

            alterMusic.Text = "Music: " + (int)(MediaPlayer.Volume * 100) + " %";

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void HandleInput()
        {
            if (Input.Holding(Keys.Left))
            {
                if (MenuEntries[selectedEntry] == alterMusic)
                    MediaPlayer.Volume -= 0.01f;
            }

            else if (Input.Holding(Keys.Right))
            {
                if (MenuEntries[selectedEntry] == alterMusic)
                    MediaPlayer.Volume += 0.01f;
            }

            base.HandleInput();
        }
    }
}
