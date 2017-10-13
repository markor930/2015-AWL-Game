using UnityEngine;
using System.Collections;

public class Throw_Level : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter()
	{
		if(Game_MainScript.AcquireGem == 5)
		{
			Character_Move.Ch_AnPlay = false;
			Game_MainScript.Character.GetComponent<Character_Move>().Character_An.CrossFade("Wait");

			StartCoroutine(ToNextApp());
		}
	}

	IEnumerator ToNextApp()
	{
		yield return new WaitForSeconds(1.0f);
		AchieveGame.Expand = true;
	}
}
