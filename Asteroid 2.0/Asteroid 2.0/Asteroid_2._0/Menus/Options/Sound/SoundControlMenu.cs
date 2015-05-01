using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class SoundControlMenu : MenuScreen
    {
        MenuEntry goBack;
        MenuEntry musicVolume;

        public SoundControlMenu()
            : base("")
        {
            
        }

        public override void LoadContent()
        {
            goBack = new MenuEntry("Go Back");
            musicVolume = new MenuEntry("Volume");

            goBack.Selected += GoBack;
            musicVolume.Selected += VolumeControl;

            MenuEntries.Add(goBack);
            MenuEntries.Add(musicVolume);
        }

        private void GoBack(object sender, EventArgs e)
        {
            IsExiting = true;
        }

        private void VolumeControl(object sender, EventArgs e)
        {
            ScreenManager.AddScreen(new MusicVolumeControl());
        }
    }
}
