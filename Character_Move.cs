using UnityEngine;
using System.Collections;

public class Character_Move : MonoBehaviour {
	public static bool Ch_AnPlay = true;

	public Animation Character_An;

	private float ForthSpeed = 12.0f;
	private float JumpSpeed = 10.0f;

	public static float Ch_Rotate = 180.0f;
	private float Ch_Angle = 135.0f;

	public GameObject AskBox;

	// Use this for initialization
	void Start() {
		Character_An = GetComponent<Animation>();
		Hp_Character.Ch_HP = 100;
	}

	void Update() {

		gameObject.transform.eulerAngles = new Vector3(0, Ch_Rotate, 0);
		gameObject.transform.position = new Vector3(transform.position.x,transform.position.y,-5.5f);

		if(Ch_AnPlay)
		{
			AskBox.SetActive(false);
			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
			{
				Character_An.CrossFade("Walk");
			}
			else
			{
				Character_An.CrossFade("Wait");
			}
			
			if(Input.GetKey(KeyCode.D))
			{
				gameObject.transform.eulerAngles = new Vector3(0, Ch_Angle, 0);
				gameObject.transform.Translate(-ForthSpeed*Time.deltaTime, 0 , 0);
				Ch_Rotate = Ch_Angle;
			}
			else if(Input.GetKey(KeyCode.A))
			{
				gameObject.transform.eulerAngles = new Vector3(0, -Ch_Angle, 0);
				gameObject.transform.Translate(ForthSpeed*Time.deltaTime, 0 , 0);
				Ch_Rotate = -Ch_Angle;
			}
			
			if(Input.GetKey(KeyCode.Space))
			{
				gameObject.transform.Translate(0, JumpSpeed*Time.deltaTime, 0, Space.Self);
			}
		}
		else
		{
			if(Game_MainScript.AcquireGem < 5 && GoBack.aa == false)
			{
				AskBox.SetActive(true);
			}
		}
	}
}
