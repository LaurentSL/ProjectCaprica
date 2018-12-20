using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caprica {

    public class Building {

        // Represents a constructed building on a planet?
        //    Maybe also gets used in the list of building template?

        public string Name;
        private int RequiredProduction;
        private int UnlockedByTechId = -1;

        public delegate void BuildingEndOfTurnFunction (Colony colony, int currentGameTurn, int builtGameTurn);
        event BuildingEndOfTurnFunction EndOfTurnFunction;

        public Building(string Name, int RequiredProduction, int UnlockedByTechId,
            BuildingEndOfTurnFunction EndOfTurnFunction)
        {
            this.Name = Name;
            this.RequiredProduction = RequiredProduction;
            this.UnlockedByTechId = UnlockedByTechId;
            this.EndOfTurnFunction = EndOfTurnFunction;
        }

        public void DoEndOfTurn(Colony colony, int currentGameTurn, int builtGameTurn)
        {
            EndOfTurnFunction (colony, currentGameTurn, builtGameTurn);
        }

        public static class SetupBuildings {

            /// <summary>
            /// This function will instead read a config file with building
            /// parameters + maybe LUA code for end turn logic?
            /// </summary>
            static SetupBuildings ()
            {
                AllBuildings = new Building[] {
                    new Building("Barracks", 100, -1, (c, turn, built) => { Debug.Log("Barracks Turn Processing!"); }),
                };
            }

            public static Building[] AllBuildings;
        }
    }
}
