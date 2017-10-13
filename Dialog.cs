using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -5.5f);
	}

	void OnTriggerEnter()
	{
		StartCoroutine(BeginTime());
	}

	IEnumerator BeginTime()
	{
		yield return new WaitForSeconds(0.5f);
		Game_MainScript.Monster.GetComponent<Monster_Move>().Mon_An.CrossFade("Wait");
		Game_MainScript.Begin = true;

	}
}
