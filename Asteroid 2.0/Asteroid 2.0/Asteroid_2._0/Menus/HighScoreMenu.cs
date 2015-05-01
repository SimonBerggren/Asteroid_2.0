using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class HighScoreMenu : MenuScreen
    {
        List<Highscore> highScores = new List<Highscore>();

        public HighScoreMenu()
            : base("")
        {
            SideMenu = true;
        }

        public override void LoadContent()
        {
            GetHighScores();
            AddHighScores();
            
            MenuEntry back = new MenuEntry("Back");

            back.Selected += GoBack;

            MenuEntries.Add(back);

            base.LoadContent();
        }

        private void GetHighScores()
        {
            StreamReader reader = new StreamReader("HighScores.txt");

            while (!reader.EndOfStream)
            {
                string[] s = reader.ReadLine().Split(':');
                
                highScores.Add(new Highscore(s[0], int.Parse(s[1])));
            }

            highScores = highScores.OrderByDescending(s => s.score).ToList();
        }

        private void AddHighScores()
        {
            for (int i = 0; i < highScores.Count; i++)
            {
                MenuEntries.Add(new MenuEntry(highScores[i].name + ": " + highScores[i].score.ToString()));
            }
        }

        private void GoBack(object sender, EventArgs e)
        {
            IsExiting = true;
        }

        public override void HandleInput()
        {
            selectedEntry = MenuEntries.Count - 1;


            if (Input.Clicked(Keys.Enter))
                OnSelectEntry(selectedEntry);
        }
    }
}
