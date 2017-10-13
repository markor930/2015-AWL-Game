using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class UIImageEven : MonoBehaviour {

	public Sprite [] Fig;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Game_MainScript.C_count == 1)
		{
			gameObject.GetComponent<Image>().sprite = Fig[0];
		}
		else if(Game_MainScript.C_count == 2)
		{
			gameObject.GetComponent<Image>().sprite = Fig[1];
		}
		else if(Game_MainScript.C_count == 3)
		{
			gameObject.GetComponent<Image>().sprite = Fig[2];
		}
		else if(Game_MainScript.C_count == 4)
		{
			gameObject.GetComponent<Image>().sprite = Fig[3];
		}

	}
}
