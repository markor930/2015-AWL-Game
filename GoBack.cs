using UnityEngine;
using System.Collections;

public class GoBack : MonoBehaviour {
	public GameObject Role;
	public GameObject tips;
	public static GameObject Tips;
	public static bool aa = false;

	// Use this for initialization
	void Start () {
		//Tips = GameObject.FindGameObjectWithTag ("Tips");
		Tips = tips;
		Tips.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter()
	{
		//Role.transform.eulerAngles = new Vector3(0, -135, 0);
		Character_Move.Ch_Rotate = -135.0f;
		Role.transform.Translate (1, 0, 0);
		Role.GetComponent<Character_Move>().Character_An.CrossFade("Wait");

		Character_Move.Ch_AnPlay = false;
		//Role.GetComponent<Character_Move> ().AskBox.SetActive (false);
		aa = true;
		Tips.SetActive (true);

	}
}
