using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caprica {

    /// <summary>
    ///  This gets filled out by some kind of "New Game" screen
    ///  and is used by the Generate function to tune the game parameters
    ///  Consider reading the defaults from a config file
    /// </summary>
    public static class GalaxyConfig {

        public static int NumPlayers = 8;
        public static int NumStars = 50;
        /// <summary>
        /// Total width/height of the range of star positions in Unity world units.
        /// </summary>
        public static int Width = 100;
    }
}