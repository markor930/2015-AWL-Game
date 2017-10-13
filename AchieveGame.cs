using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AchieveGame : MonoBehaviour {
	public static bool Expand;

	public GameObject OverText;
	public GameObject OverPanel;

	public static float S_Count;
	public static float EP;

	private float S_Totle;
	private float Scores;

	// Use this for initialization
	void Start () {
		Expand = false;

		S_Count = 0;
		EP = 0;

		gameObject.GetComponent<Text> ().enabled = false;

		OverPanel.SetActive (false);
		OverText.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Expand) 
		{
			OverPanel.SetActive (true);

			Camera_Follow.CamMove = false;

			S_Totle = S_Count + EP;

			PlayTime.isPlaytime = false;

			if(S_Totle > 100)
			{
				S_Totle = 100;
			}

			StartCoroutine(Results());
		} 
		else 
		{
			Scores = 0;
		}
	}

	IEnumerator Results()
	{
		yield return new WaitForSeconds(2.5f);
		OverText.SetActive (true);
		gameObject.GetComponent<Text> ().enabled = true;

		yield return new WaitForSeconds(0.5f);
		gameObject.GetComponent<Text> ().text = Scores.ToString();

		if(Scores == S_Totle)
		{
			Scores = S_Totle;

			yield return new WaitForSeconds(2.0f);
			Camera_Follow.CamMove = true;
			Monster_Move.Askcount = 0;
			Game_MainScript.AcquireGem = 0;
			Character_Move.Ch_AnPlay = true;

			Application.LoadLevel(0); //Main
		}
		else
		{
			Scores += 1;
		}
	}
}
