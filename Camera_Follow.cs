using UnityEngine;
using System.Collections;

public class Camera_Follow : MonoBehaviour {
	public static bool CamMove = true;
	public GameObject Character;
	public AudioSource BGaudio ;

	float Ch_x;
	float Ch_y;

	Vector3 vel = Vector3.zero;
	float smoothTime = 0.3f; 

	// Use this for initialization
	void Start () {
		BGaudio = GetComponent<AudioSource>();
		BGaudio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		Ch_x = Character.transform.position.x;
		Ch_y = Character.transform.position.y;

		Vector3 target = new Vector3 (Ch_x + 4, Ch_y + 3, transform.position.z);

		if(CamMove)
		{
			//SmoothDamp：移動到特定目標
			gameObject.transform.position = Vector3.SmoothDamp (gameObject.transform.position, target,ref vel, smoothTime);
		}

		if (Game_MainScript.SelectBtn) 
		{
			BGaudio.volume = 0.1f;
		} 
		else 
		{
			BGaudio.volume = 0.8f;
		}

	}
}
