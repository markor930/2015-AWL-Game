using UnityEngine;
using System.Collections;

public class SoundQuestion : MonoBehaviour {
	public AudioSource Questionaudio;

	//宣告語音陣列
	public AudioClip[] Sound1;
	public AudioClip[] Sound2;
	public AudioClip[] Sound3;
	public AudioClip[] Sound4;

	// Use this for initialization
	void Start()
	{
		gameObject.GetComponent<SoundQuestion> ().enabled = false;

		Questionaudio = gameObject.GetComponent<AudioSource>();
		//Sound = new AudioClip[Game_MainScript.Sound_index];
	}

	void OnEnable () {
		if(Game_MainScript.C_count == 1)
		{
			Questionaudio.clip = Sound1[Game_MainScript.Sound_index];
		}
		else if(Game_MainScript.C_count == 2)
		{
			Questionaudio.clip = Sound2[Game_MainScript.Sound_index];
		}
		else if(Game_MainScript.C_count == 3)
		{
			Questionaudio.clip = Sound3[Game_MainScript.Sound_index];
		}
		else if(Game_MainScript.C_count == 4)
		{
			Questionaudio.clip = Sound4[Game_MainScript.Sound_index];
		}

		Questionaudio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!Questionaudio.isPlaying) 
		{
			SoundAnswer.CheckPlay = true;
		} 
		else 
		{
			SoundAnswer.CheckPlay = false;
		}
	}
}
