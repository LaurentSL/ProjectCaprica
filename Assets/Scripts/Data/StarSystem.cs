using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caprica {

    public class StarSystem {

        private Planet[] planets;

        private int max_planets;

        private const int MIN_STAR_TYPE = -2;
        private const int MAX_STAR_TYPE = 2;

        /// <summary>
        /// 0 = Yellow ;
        /// Positive = older, less rich ;
        /// Negative = younger, less hab
        /// </summary>
        public int StarType { get; private set; }

        public StarSystemGraphic StarSystemGraphic;

        public string Name;

        public Vector3 Position;

        public StarSystem ()
        {
            max_planets = Config.GetInt ("STARSYSTEM_MAX_PLANETS");
            planets = new Planet[max_planets];
        }

        public Planet GetPlanet (int PlanetIndex)
        {
            return planets[PlanetIndex];
        }

        /// <summary>
        /// TODO:
        /// Galatic age / richness info? Or maybe we get told what kind of
        /// star to generate? Especially for player starting planets?
        /// </summary>
        public void Generate (int starType = 0)
        {
            this.StarType = starType;
            GeneratePlanets ();
        }

        private void GeneratePlanets ()
        {
            // Generate 0 to MAX_PLANETS, weighting planet class based on
            // StarType + distance from the Sun

            // The StarType might also influence the likelihood of  number
            // of planets

            float planetChance = 0.50f;
            for (int i = 0; i < max_planets; i++) {
                if (Random.Range (0f, 1f) > planetChance) {
                    // Make a planet!
                    Planet planet = new Planet {
                        Name = GeneratePlanetName (i),
                        PlanetSize = GeneratePlanetSize (i)
                    };
                    planets[i] = planet;
                }
            }
        }

        private string GeneratePlanetName (int position)
        {
            // TODO: Make awesome
            return Name + " " + (position + 1).ToString ();
        }

        private PlanetSize GeneratePlanetSize (int position)
        {
            //int size_max = System.Enum.GetValues (typeof (PlanetSize)).Length;
            int size_max = (int) PlanetSize.COUNT;
            return (PlanetSize) System.Enum.GetValues (typeof (PlanetSize)).GetValue (Random.Range (0, size_max));
        }

        private PlanetType GeneratePlanetType (int position)
        {
            // Tweak this based on star type and galaxy settings
            float goldilocksRange = 0.5f;

            float distance = (float) position / (float) max_planets;
            float distanceSquared = distance * distance;

            float gasGiantWeight = Mathf.Lerp (0f, 1f, distance);
            float goldilocksWeight = Mathf.Lerp (1f, 0f, 2f * Mathf.Abs (goldilocksRange - distance));

            // Cool suns should have goldilocks closer to the sun
            // Hot suns should have it further

            float allWeights = gasGiantWeight + goldilocksWeight;
            float randomValue = Random.Range (0, allWeights);

            if (randomValue<gasGiantWeight) {
                // TODO
                return PlanetType.GasGiant;
            }
            randomValue -= gasGiantWeight;

            if (randomValue< goldilocksWeight) {
                // TODO
                return PlanetType.Continental;
            }
            randomValue -= goldilocksWeight;

            // If we get here, it's because we rolled in the asteroid weight
            return PlanetType.Asteroid;
        }

        public void Load ()
        {

        }

        public void Save ()
        {

        }

        /// <summary>
        /// Weird hacky function to convert from -2..+2 range to a 0..4 range
        /// </summary>
        /// <returns></returns>
        public int GetStarTypeIndex ()
        {
            return StarType - MIN_STAR_TYPE;
        }
    }
}
