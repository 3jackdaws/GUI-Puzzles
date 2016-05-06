using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WebcamOnTexture : MonoBehaviour {

	public UnityEngine.UI.RawImage rawimage;
	public InputField saveDir;
	private WebCamTexture webcamTexture;
	private string snapshotSavePath;
	private int captureCount = 0;

	void Start () {
		webcamTexture = new WebCamTexture();
		rawimage.texture = webcamTexture;
		rawimage.material.mainTexture = webcamTexture;
		webcamTexture.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeSnapShot()
	{
		StartCoroutine ("SnapShot");
	}

	IEnumerator SnapShot()
	{
		yield return new WaitForEndOfFrame();

		Texture2D snap = new Texture2D(webcamTexture.width, webcamTexture.height);
		snap.SetPixels(webcamTexture.GetPixels());
		snap.Apply();
		Debug.Log ("Snapshot at " + snapshotSavePath);
		System.IO.File.WriteAllBytes(snapshotSavePath + captureCount.ToString() + ".png", snap.EncodeToPNG());
		captureCount++;
	}

	public void ApplySaveDirChange()
	{
		snapshotSavePath = saveDir.text;
	}

}
