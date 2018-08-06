using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CamSetup : MonoBehaviour {

	public string deviceName;
	WebCamTexture wct;

	// Use this for initialization
	void Start () {
		WebCamDevice[] devices = WebCamTexture.devices;
		deviceName = devices[1].name;
		#if UNITY_IOS
		wct = new WebCamTexture (deviceName,352,288,60); // frame size must not change to avoid crashing
		#elif UNITY_EDITOR
		wct = new WebCamTexture (deviceName,352,288,60);     // frame size must not change to avoid crashing
		#else
		wct = new WebCamTexture (deviceName,352,288,60);
		#endif
		GetComponent<Renderer>().material.mainTexture = wct;
		wct.Play();
	}

	// Update is called once per frame
	void Update () {
		if (!wct.didUpdateThisFrame) {
			return;
		}
		Texture2D frame = new Texture2D(wct.width, wct.height);
		frame.SetPixels(wct.GetPixels());
		byte[] bytes = frame.EncodeToPNG();
		print ("update");
		//MLKitUnity.masterCall (bytes, wct.width, wct.height);
	}

	void OnLowMemory () {
		print ("unloading =====");
		Resources.UnloadUnusedAssets ();
	}

}
