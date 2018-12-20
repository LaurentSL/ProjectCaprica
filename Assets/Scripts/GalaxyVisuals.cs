using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Caprica;

public class GalaxyVisuals : MonoBehaviour {

    private const int MOUSE_BUTTON_LEFT = 0;
    private Camera mainCamera;

    public LayerMask ClickableStarsLayerMask;

    // Index of array is a star type.
    // The prefabs are responsbible for having appearance variety.
    public GameObject[] StarPrefab;

    private Galaxy galaxy;

	void Start () {
        mainCamera = Camera.main;
	}
	
	void Update () {

        if (Input.GetMouseButtonUp(MOUSE_BUTTON_LEFT)) {
            // Mouse was clicked -- is it on a star?

            // TODO: Ignore clicks if over a UI elements

            Ray ray = mainCamera.ScreenPointToRay (Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, ClickableStarsLayerMask)) {
                // We hit something, and that something can ONLY be a clickable star
                ClickableStar clickableStar = hitInfo.collider.GetComponentInParent<ClickableStar> ();

                if (clickableStar == null) {
                    Debug.LogError ("Our star doesn't have a ClickableStar component?");
                    return;
                }

                Debug.Log ("Clicked star: " + clickableStar.name);

                ViewManager.Instance.SystemView.SelectedStar = clickableStar.StarSystem;
                ViewManager.Instance.ShowView (ViewManager.Instance.SystemView);
            }
        }
		
	}

    public void InitiateVisuals (Galaxy galaxy)
    {
        this.galaxy = galaxy;

        for (int i = 0; i < galaxy.GetNumStarSystems(); i++) {
            StarSystem starSystem = galaxy.GetStarSystem (i);

            GameObject starSystemGameObject = Instantiate (
                StarPrefab[starSystem.GetStarTypeIndex()],
                starSystem.Position,    // TODO: Are we gonna want to mult by a scalar?
                Quaternion.identity,
                this.transform
            );

            starSystemGameObject.GetComponent<ClickableStar> ().StarSystem = starSystem;
        }
    }
}
