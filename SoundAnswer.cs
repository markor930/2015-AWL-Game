using UnityEngine;
using System.Collections;

public class SoundAnswer : MonoBehaviour {

	public static bool Btn01 = false;
	public static bool Btn02 = false;
	public static bool Btn03 = false;
	public static bool CheckPlay = false;

	public AudioSource Answeraudio; 

	//宣告語音陣列
	public AudioClip[] Voice1;
	public AudioClip[] Voice2;
	public AudioClip[] Voice3;
	public AudioClip[] Voice4;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SoundAnswer> ().enabled = false;
		
		Answeraudio = gameObject.GetComponent<AudioSource>();
	}

	void OnEnable()
	{
		if(CheckPlay && !Answeraudio.isPlaying)
		{
			if(Game_MainScript.C_count == 1)
			{
				if(Btn01)
				{
					Answeraudio.clip = Voice1[Game_MainScript.Voice_index1];
				}
				else if(Btn02)
				{
					Answeraudio.clip = Voice1[Game_MainScript.Voice_index2];
				}
				else if(Btn03)
				{
					Answeraudio.clip = Voice1[Game_MainScript.Voice_index3];
				}
				
			}
			else if(Game_MainScript.C_count == 2)
			{
				if(Btn01)
				{
					Answeraudio.clip = Voice2[Game_MainScript.Voice_index1];
				}
				else if(Btn02)
				{
					Answeraudio.clip = Voice2[Game_MainScript.Voice_index2];
				}
				else if(Btn03)
				{
					Answeraudio.clip = Voice2[Game_MainScript.Voice_index3];
				}
			}
			else if(Game_MainScript.C_count == 3)
			{
				if(Btn01)
				{
					Answeraudio.clip = Voice3[Game_MainScript.Voice_index1];
				}
				else if(Btn02)
				{
					Answeraudio.clip = Voice3[Game_MainScript.Voice_index2];
				}
				else if(Btn03)
				{
					Answeraudio.clip = Voice3[Game_MainScript.Voice_index3];
				}
			}
			else if(Game_MainScript.C_count == 4)
			{
				if(Btn01)
				{
					Answeraudio.clip = Voice4[Game_MainScript.Voice_index1];
				}
				else if(Btn02)
				{
					Answeraudio.clip = Voice4[Game_MainScript.Voice_index2];
				}
				else if(Btn03)
				{
					Answeraudio.clip = Voice4[Game_MainScript.Voice_index3];
				}
			}

			Answeraudio.Play ();

			if(SoundYE.ErroAns || SoundYE.YesAns)
			{
				Answeraudio.Stop();
				gameObject.GetComponent<SoundAnswer> ().enabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
