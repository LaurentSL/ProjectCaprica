using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caprica {

    public class Config {

        /// TODO:
        /// Values are coded here for now, but the goal
        /// will be to load in from a config that is modable.

        public static int GetInt(string Parameter)
        {
            switch (Parameter) {

                // Total width/height of the range of star positions in Unity world units.
                //case "GALAXY_WIDTH":
                //    return 100;

                case "PLANET_MAX_POPULATION_Tiny":
                    return 4;
                case "PLANET_MAX_POPULATION_Small":
                    return 6;
                case "PLANET_MAX_POPULATION_Medium":
                    return 10;
                case "PLANET_MAX_POPULATION_Large":
                    return 12;
                case "PLANET_MAX_POPULATION_Huge":
                    return 16;

                case "STARSYSTEM_MAX_PLANETS":
                    return 6;

                default:
                    Debug.LogError ("GetInt: No option for " + Parameter);
                    return 0;
            }
        }
    }
}
