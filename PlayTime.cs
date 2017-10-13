using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayTime : MonoBehaviour {
	public static bool isPlaytime;
	private float PlayTimer;
	private string ColckTime;

	// Use this for initialization
	void Start () {
		PlayTimer = 0.0f;
		isPlaytime = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlaytime) 
		{
			PlayTimer += Time.deltaTime;

		}

		TimeSpan timeSpan = TimeSpan.FromSeconds(PlayTimer);
		if(PlayTimer > 360.0f)
		{
			ColckTime = string.Format ("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
		}
		else if (PlayTimer > 60.0f) 
		{
			ColckTime = string.Format ("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
		} 
		else 
		{
			ColckTime = string.Format ("{0:D2}", timeSpan.Seconds);
		}

		gameObject.GetComponent<Text> ().text = "Time: " + ColckTime + " s";
	
	}
}
