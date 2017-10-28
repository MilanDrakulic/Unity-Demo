using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour {

	private bool adShown = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!adShown)
		{
			showAd();
		}
	}

	void showAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
			adShown = true;
		}
	}
}
