using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemViewCameraTextureScript : MonoBehaviour {

    public Camera SystemCamera;

    private RenderTexture SystemViewTexture;

	void Start () {
        // This script should be on the same gameObject as the image/sprite

        RectTransform rt = GetComponent<RectTransform> ();
        SystemViewTexture = new RenderTexture ((int)rt.rect.width, (int)rt.rect.height, 16);
        SystemCamera.targetTexture = SystemViewTexture;

        //Sprite sprite = Sprite.Create ();

        RawImage rawImage = GetComponent<RawImage> ();
        rawImage.texture = SystemViewTexture;
    }
	
	void Update () {
		
	}
}
