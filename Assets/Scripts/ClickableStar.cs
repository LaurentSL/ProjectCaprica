using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Caprica;

public class ClickableStar : MonoBehaviour {

    public StarSystem StarSystem;

    private void Start ()
    {
        GetComponentInChildren<TextMeshProUGUI> ().text = StarSystem.Name;
    }

}
