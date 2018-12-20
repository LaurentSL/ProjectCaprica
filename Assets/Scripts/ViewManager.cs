using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour {

    public static ViewManager Instance { get; set; }

    public GalaxyVisuals GalaxyVisuals;
    public SystemView SystemView;

    private void OnEnable () {
        Instance = this;
	}

    private void Update () {

        if (Input.GetKeyUp(KeyCode.Escape)) {
            // TODO
            // Back out of view one step at a time
            // If in the master view (Galaxy), then instead open the game menu.

        }
	}

    public void ShowView (MonoBehaviour viewComponent)
    {
        viewComponent.gameObject.SetActive (true);
    }

    public void HideView (MonoBehaviour viewComponent)
    {
        viewComponent.gameObject.SetActive (false);
    }
}
