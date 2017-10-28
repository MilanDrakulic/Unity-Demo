using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsScript : MonoBehaviour {

	private bool transactionOccured = true;
	private bool customEventOccured = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transactionOccured)
		{
			registerTransaction();
		}

		if (customEventOccured)
		{
			registerCustomEvent();
		}
	}

	void registerTransaction()
	{
		Analytics.Transaction("dummy", 0.1m, "rsd");
		Analytics.SetUserBirthYear(2002);
		Analytics.SetUserGender(Gender.Male);
		transactionOccured = false;
	}

	void registerCustomEvent()
	{
		Dictionary<string, object> arguments = new Dictionary<string, object>()
		{
			{ "age", 15 },
			{ "name", "Lane"}
		};
		Analytics.CustomEvent("HelloWorld", arguments);
		customEventOccured = false;
	}
}
