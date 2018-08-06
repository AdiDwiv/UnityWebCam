using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Authroizer : MonoBehaviour {

	public GameObject suspendedObject;

	// Use this for initialization
	void Start () {
		#if UNITY_IOS || UNITY_WEBPLAYER || UNITY_FLASH
		Application.RequestUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone);
		#endif
		suspendedObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
