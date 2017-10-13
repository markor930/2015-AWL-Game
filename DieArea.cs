using UnityEngine;
using System.Collections;

public class DieArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter()
	{
		StartCoroutine (DieOver());
	}

	IEnumerator DieOver()
	{
		yield return new WaitForSeconds (1.0f);
		AchieveGame.Expand = true;
	}
}
