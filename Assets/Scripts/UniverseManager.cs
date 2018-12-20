using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Caprica;

/// <summary>
/// This script is responsible for holding the main Galaxy data object,
/// triggering file save/loads or triggering the generation of a new galaxy.
/// Maybe also gets callbacks from end turn button?
/// </summary>
public class UniverseManager : MonoBehaviour {

    private Galaxy galaxy;

    void Start ()
    {
        Generate ();
    }

    void Update ()
    {

    }

    public void Generate ()
    {
        Debug.Log ("UniverseManager::Generate  -- Generating a new Galaxy.");
        galaxy = new Galaxy ();
        galaxy.Generate ();

        // TODO: Tell our visual system to spawn the spawn the graphics.
        ViewManager.Instance.GalaxyVisuals.InitiateVisuals (galaxy);
    }
}
