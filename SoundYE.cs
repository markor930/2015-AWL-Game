using UnityEngine;
using System.Collections;

public class SoundYE : MonoBehaviour {
	public AudioSource YEaudio;

	public static bool YesAns = false;
	public static bool ErroAns = false;

	public AudioClip[] YesOrErro;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SoundYE> ().enabled = false;
		
		YEaudio = gameObject.GetComponent<AudioSource>();
	}

	void OnEnable () {

		if(YesAns)
		{
			YEaudio.clip = YesOrErro[0];
		}
		else if(ErroAns)
		{
			YEaudio.clip = YesOrErro[1];
		}
		
		YEaudio.Play ();
	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
