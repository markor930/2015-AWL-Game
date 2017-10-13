using UnityEngine;
using System.Collections;

public class FloatFloorAn : MonoBehaviour {
	public int ReturnValue = 0;

	public float FloatY;
	public float FloatX;

	private float newFloatY;
	private float newFloatX;

	//public float ConstIn = 0.0f;
	
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		newFloatY = gameObject.transform.position.y;
		newFloatX = gameObject.transform.position.x;
		
		if(ReturnValue == 0)
		{
			gameObject.transform.Translate(0, 0.05f, 0);

			if (newFloatY >= FloatY + 10) 
			{
				ReturnValue = 1;
			}
		}
		
		if(ReturnValue == 1)
		{
			gameObject.transform.Translate(0, -0.05f, 0);

			if (newFloatY <= FloatY)
			{
				ReturnValue = 0;
			}
		}

		if (ReturnValue == 3)
		{
			gameObject.transform.Translate(0.05f, 0, 0);

			if(newFloatX >= FloatX + 10)
			{
				ReturnValue = 4;
			}
		}

		if (ReturnValue == 4)
		{
			gameObject.transform.Translate(-0.05f, 0, 0);
			
			if(newFloatX <= FloatX)
			{
				ReturnValue = 3;
			}
		}
	}
}
