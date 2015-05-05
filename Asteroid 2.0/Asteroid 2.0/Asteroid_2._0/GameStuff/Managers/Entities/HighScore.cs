
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    class Highscore
    {
        public String name { get; set; }
        public int score { get; set; }

        public Highscore(String Name, int Score)
        {
            name = Name;
            score = Score;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", this.name, this.score);
        }
    }
}
