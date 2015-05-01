using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class Options : MenuScreen
    {
        MenuEntry back;
        MenuEntry changeResolution;
        MenuEntry soundcontrol;

        public Options()
            : base("Options") { }

        public override void LoadContent()
        {
            changeResolution = new MenuEntry("Change Resolution");
            soundcontrol = new MenuEntry("Sound");
            back = new MenuEntry("Back");

            soundcontrol.Selected += SoundControl;
            changeResolution.Selected += ChangeResolution;
            back.Selected += GoBack;

            MenuEntries.Add(changeResolution);
            MenuEntries.Add(soundcontrol);
            MenuEntries.Add(back);
        }

        private void GoBack(object sender, EventArgs e)
        {
            IsExiting = true;
        }

        private void ChangeResolution(object sender, EventArgs e)
        {
            ScreenManager.AddScreen(new ResolutionMenu());
        }

        private void SoundControl(object sender, EventArgs e)
        {
            ScreenManager.AddScreen(new MusicVolumeControl());
        }
    }
}
