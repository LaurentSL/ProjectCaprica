using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caprica {

    public class Galaxy {

        private List<StarSystem> StarSystems;

        public Galaxy ()
        {
            StarSystems = new List<StarSystem> ();
        }

        public StarSystem GetStarSystem (int StarSystemID)
        {
            return StarSystems[StarSystemID];
        }

        public int GetNumStarSystems ()
        {
            return StarSystems.Count;
        }

        public void Generate()
        {
            // FIXME: First pass, just make some random stars for us.

            int galaxyWidth = GalaxyConfig.Width / 2;
            for (int i = 0; i < GalaxyConfig.NumStars; i++) {
                StarSystem starSystem = new StarSystem ();
                starSystem.Position = new Vector3 (
                    Random.Range (-galaxyWidth, galaxyWidth),
                    Random.Range (-galaxyWidth, galaxyWidth),
                    0
                    );
                starSystem.Generate ();
                starSystem.Name = "Star " + i.ToString ();
                StarSystems.Add (starSystem);
            }

            Debug.Log ("Num stars generated: " + StarSystems.Count);
        }

        public void Load ()
        {

        }

        public void Save ()
        {

        }
    }
}