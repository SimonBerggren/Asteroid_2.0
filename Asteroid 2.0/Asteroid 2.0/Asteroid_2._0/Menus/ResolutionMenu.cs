using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class ResolutionMenu : MenuScreen
    {
        MenuEntry highRes;
        MenuEntry mediumRes;
        MenuEntry lowRes;
        MenuEntry fullscreen;
        MenuEntry goBack;

        int oldWidth, oldHeight,
            monitorWidth, monitorHeight;

        public ResolutionMenu()
            : base("")
        {
            SideMenu = true;
        }

        public override void LoadContent()
        {
            monitorWidth = ScreenManager.Graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            monitorHeight = ScreenManager.Graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;

            fullscreen = new MenuEntry("Toggle Fullscreen");
            highRes = new MenuEntry("\nHigh Resolution");
            mediumRes = new MenuEntry("\nMedium Resolution");
            lowRes = new MenuEntry("\nLow Resolution");
            goBack = new MenuEntry("\n\nBack to Options");

            highRes.Selected += SetHighRes;
            mediumRes.Selected += SetMediumRes;
            lowRes.Selected += SetLowRes;
            fullscreen.Selected += SetFullscreen;
            goBack.Selected += GoBack;

            MenuEntries.Add(fullscreen);
            MenuEntries.Add(highRes);
            MenuEntries.Add(mediumRes);
            MenuEntries.Add(lowRes);
            MenuEntries.Add(goBack);
        }

        private void GoBack(object sender, EventArgs e)
        {
            IsExiting = true;
        }

        private void SetFullscreen(object sender, EventArgs e)
        {
            if (!ScreenManager.Graphics.IsFullScreen)
            {
                oldWidth = ScreenManager.Graphics.PreferredBackBufferWidth;
                oldHeight = ScreenManager.Graphics.PreferredBackBufferHeight;

                SetResolution(monitorWidth, monitorHeight);

                ScreenManager.Graphics.ToggleFullScreen();
                IsExiting = true;
            }
            else
            {
                ScreenManager.Graphics.ToggleFullScreen();
                SetResolution(oldWidth, oldHeight);
                IsExiting = true;
            }
        }

        private void SetHighRes(object sender, EventArgs e) { SetResolution(1920, 1080); }
        private void SetMediumRes(object sender, EventArgs e) { SetResolution(1600, 900); }
        private void SetLowRes(object sender, EventArgs e) { SetResolution(1280, 720); }

        private void SetResolution(int width, int height)
        {
            if (!ScreenManager.Graphics.IsFullScreen)
            {
                ScreenManager.Graphics.PreferredBackBufferWidth = width;
                ScreenManager.Graphics.PreferredBackBufferHeight = height;
                ScreenManager.Graphics.ApplyChanges();
                IsExiting = true;
            }
        }
    }
}
