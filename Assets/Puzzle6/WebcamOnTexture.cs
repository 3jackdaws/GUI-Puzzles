using UnityEngine;
using System.Collections;

public class WebcamOnTexture : MonoBehaviour {

	public UnityEngine.UI.RawImage rawimage;

	void Start () {
		WebCamTexture webcamTexture = new WebCamTexture();
		rawimage.texture = webcamTexture;
		rawimage.material.mainTexture = webcamTexture;
		webcamTexture.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
