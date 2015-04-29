using System;

namespace Asteroid_2._0
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main()
        {
            using (AsteroidGame game = new AsteroidGame())
            {
                game.Run();
            }
        }
    }
#endif
}

