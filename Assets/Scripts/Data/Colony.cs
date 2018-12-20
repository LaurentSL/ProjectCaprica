using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caprica {

    public class Colony {

        public Planet Planet;

        private int population { get { return popFarmers + popWorkers + popScientists; } }
        private int popFarmers;
        private int popWorkers;
        private int popScientists;

        // Normally zero, unless you get automated factories
        int flatProduction;
        // PlanetRichness / 2 + 1
        int productionPerWorker;

        //List<Building> BuiltBuildings;
        List<int> BuiltBuildingIndexes;
        List<int> BuildingBuiltTurn;

        public int TotalProductionPerTurn()
        {
            return flatProduction + productionPerWorker * popWorkers;
        }

        public void DoEndOfTurn ()
        {
            // For each built building, call their end of turn update and
            // pass the value of the turn number it was built on
        }

        public int MaxPopulation ()
        {
            int p = Config.GetInt ("PLANET_MAX_POPULATION_" + Planet.PlanetSize.ToString ());

            // TODO
            // Is our species Subterreranian, or have some other bonus to pop cap?
            //    Could be from a tech too, for example MpO2's "City"?
            //    Could be from a building, like Biospheres?
            //    Could be from a planet's special trait?

            return p;
        }
    }
}
