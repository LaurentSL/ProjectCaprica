using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caprica {

    public class Planet {

        public PlanetGraphic PlanetGraphic;

        public string Name;

        /// <summary>
        /// Index 
        /// </summary>
        public readonly int PlanetIndex;

        public PlanetType PlanetType;

        public PlanetSize PlanetSize;

        public PlanetRichness PlanetRichness;

        private List<PlanetTrait> planetTraits;

        public Colony Colony;
    }
}
