using System;

namespace cruisin_asu {
    static class Main {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args) {
            using (Game game = new Game()) {
                game.Run();
            }
        }
    }
}

