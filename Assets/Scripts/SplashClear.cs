using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashClear : MonoBehaviour {

	GameObject splashCanvas;

	// Use this for initialization
	void Start () {
		splashCanvas = GameObject.Find("SplashCanvas");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump"))
			ClearSplash();

	}

	void ClearSplash()
	{
		splashCanvas.SetActive(false);
	}

	void ShowSplash()
	{
		splashCanvas.SetActive(true);
	}
}
