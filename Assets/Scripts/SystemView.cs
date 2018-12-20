using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Caprica;

public class SystemView : MonoBehaviour {

    public StarSystem SelectedStar;
    public GameObject StarSystem3DContainer;


    void OnEnable () {
        Debug.Log ("SystemView::OnEnable -- " + SelectedStar.Name);

        // Update various UI elements for this system

        // Setup the system render view so we can see planets

	}
	
	void Update () {
		
	}

}
