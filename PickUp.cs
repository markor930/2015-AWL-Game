using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter()
	{
		Monster_Move.Askcount += 1;
		Game_MainScript.AcquireGem += 1;

		Monster_Move.ThisMon = null;

		if(Game_MainScript.AcquireGem < 5)
		{
			Game_MainScript.Monster.GetComponent<Monster_Move>().enabled = true;
		}
		Destroy(gameObject);

		Game_MainScript.True_count = 0;
	}
}
