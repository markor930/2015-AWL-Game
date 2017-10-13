using UnityEngine;
using System.Collections;

public class Ch_DieScript : MonoBehaviour {
	
	public GameObject Dead_Ch;

	Vector3 Pos;
	Quaternion Rot;

	// Use this for initialization
	void Start () {

		Pos = Game_MainScript.Character.transform.position;
		Rot = Game_MainScript.Character.transform.rotation;

		Instantiate(Dead_Ch, Pos, Rot);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
