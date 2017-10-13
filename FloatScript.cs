using UnityEngine;
using System.Collections;

public class FloatScript : MonoBehaviour {
	public static bool FloatTOCh = false;

	GameObject Character;

	int ReturnValue;
	public float FloatY;
	private float newFloatY;
	//public float ConstIn = 0.0f;

	void Start () {
		gameObject.GetComponent<FloatScript>().enabled = true;

		Character = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		newFloatY = gameObject.transform.position.y;
		
		if(ReturnValue == 0)
		{
			gameObject.transform.Translate(0, 0.04f, 0);

			if(FloatTOCh)
			{
				Character.transform.position = 
					new Vector3(Character.transform.position.x, gameObject.transform.position.y, -5.5f);

				if(Input.GetKey(KeyCode.Space))
				{
					Character.transform.position = 
						new Vector3(Character.transform.position.x, gameObject.transform.position.y + 1, -5.5f);
				}
			}

			if (newFloatY >= FloatY + 10) 
			{
				ReturnValue = 1;
			}
		}
		
		if(ReturnValue == 1)
		{
			gameObject.transform.Translate(0, -0.04f, 0);

			if(FloatTOCh)
			{
				Character.transform.position = 
					new Vector3(Character.transform.position.x, gameObject.transform.position.y, -5.5f);

				if(Input.GetKey(KeyCode.Space))
				{
					Character.transform.position = 
						new Vector3(Character.transform.position.x, gameObject.transform.position.y + 1, -5.5f);
				}
			}
			
			if (newFloatY <= FloatY)
			{
				ReturnValue = 0;
			}
		}
	}

	void OnCollisionStay()
	{
		gameObject.GetComponent<FloatScript>().enabled = true;
		gameObject.GetComponent<FloatFloorAn>().enabled = false;
		FloatTOCh = true;
	}

	void OnCollisionExit()
	{
		gameObject.GetComponent<FloatScript>().enabled = false;
		gameObject.GetComponent<FloatFloorAn>().enabled = true;
		FloatTOCh = false;
	}
}
