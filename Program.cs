using System;

namespace Defend_your_home
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (BaseGame game = new BaseGame())
            {
                game.Run();
            }
        }
    }
#endif
}

