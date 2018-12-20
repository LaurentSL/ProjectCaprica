using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Rotates : MonoBehaviour {

    public Vector3 RotationSpeed = new Vector3(0, 30, 0);

	void Update () {
        this.transform.Rotate (RotationSpeed * Time.deltaTime);
	}
}
