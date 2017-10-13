﻿using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	// public
	public int windowWidth = 400;
	public int windowHight = 150;
	
	// private
	Rect windowRect ;
	int windowSwitch = 0;
	float alpha = 0;
	
	void GUIAlphaColor_0_To_1 ()
	{
		if (alpha < 1) {
			alpha += Time.deltaTime;
			GUI.color = new Color (1, 1, 1, alpha);
		} 
	}
	
	// Init
	void Awake ()
	{
		windowRect = new Rect ((Screen.width - windowWidth) / 2,(Screen.height - windowHight) / 2,windowWidth,windowHight);
	}
	
	void Update ()
	{
		if (Input.GetKeyDown ("escape")) {
			windowSwitch = 1;
			alpha = 0; // Init Window Alpha Color
		}
	}
	
	void OnGUI ()
	{ 
		//GUI.Box(new Rect((Screen.width - windowWidth) / 2,(Screen.height - windowHight) / 2,windowWidth,windowHight));

		if (windowSwitch == 1) {
			GUIAlphaColor_0_To_1 ();
			windowRect = GUI.Window (0, windowRect, QuitWindow, "QuitWindow");
		}
	}
	
	void QuitWindow (int windowID)
	{
		GUI.Label (new Rect (100, 50, 300, 30), "Are you sure you want to quit game ?");
		
		if (GUI.Button (new Rect (80, 110, 100, 20), "Quit")) {
			Camera_Follow.CamMove = true;
			Monster_Move.Askcount = 0;
			Game_MainScript.AcquireGem = 0;
			Game_MainScript.Begin = false;
			Character_Move.Ch_AnPlay = true;
			Application.LoadLevel(0);
		} 
		if (GUI.Button (new Rect (220, 110, 100, 20), "Cancel")) {
			windowSwitch = 0; 
		} 
		//GUI.DragWindow (); 
	}
}
