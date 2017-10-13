using UnityEngine;
using System.Collections;

public class Monster_Move : MonoBehaviour {

	public Animation Mon_An;

	private bool Mon_Along;
	private bool Mon_Inverse;

	private float Dis;
	private float Ch_PosX;
	private float Monster_Posx;
	private float Monster_PosX;

	private float MoveSpeed = 2.0f;
	private float Mon_Angle = 135.0f;
	private const float FastSpeed = 2.0f;

	public static int Askcount = 0; //問答計數器, 判斷第幾隻怪物

	private GameObject Character;
	public GameObject MonNPC01;
	public GameObject MonNPC02;
	public GameObject MonNPC03;
	public GameObject MonNPC04;
	public GameObject MonNPC05;
	public static GameObject ThisMon;

	void OnEnable()
	{
		Character = GameObject.FindGameObjectWithTag("Player");
		Hp_Monster.Mon_HP = 100;
		Mon_Along = true;
		Mon_Inverse = false;
		
		if(Askcount == 0)
		{
			ThisMon = MonNPC01;
		}
		else if(Askcount == 1)
		{
			ThisMon = MonNPC02;
		}
		else if(Askcount == 2)
		{
			ThisMon = MonNPC03;
		}
		else if(Askcount == 3)
		{
			ThisMon = MonNPC04;
		}
		else if(Askcount == 4)
		{
			ThisMon = MonNPC05;
		}
		
		Mon_An = ThisMon.GetComponentInChildren<Animation>();
		Monster_Posx = ThisMon.transform.position.x;
	}
	
	void Update ()
	{
		ThisMon.SetActive(true);

		Monster_PosX = ThisMon.transform.position.x;
		Ch_PosX = Character.transform.position.x;

		Mon_Function();
	}

	void Mon_Function()
	{
		ThisMon.transform.position = new Vector3(ThisMon.transform.position.x, ThisMon.transform.position.y, -5.5f);

		Dis = Vector3.Distance(ThisMon.transform.position, Character.transform.position);
		if(Dis > 5.0f)
		{
			if(Mon_Along)
			{
				ThisMon.transform.Translate(-MoveSpeed*Time.deltaTime, 0, 0);
				ThisMon.transform.eulerAngles = new Vector3(0, Mon_Angle, 0);

				if (Monster_PosX >= Monster_Posx + 5)
				{
					Mon_Along = false;
					Mon_Inverse = true;
				}
			}
			if (Mon_Inverse)
			{
				ThisMon.transform.Translate(MoveSpeed*Time.deltaTime, 0, 0);
				ThisMon.transform.eulerAngles = new Vector3(0, -Mon_Angle, 0);

				if (Monster_PosX <= Monster_Posx)
				{
					Mon_Along = true;
					Mon_Inverse = false;
				}
			}
		}
		else
		{
			if(Dis > 2.5f)
			{
				Character_Move.Ch_AnPlay = false;
				Character.GetComponent<Character_Move>().Character_An.CrossFade("Wait");

				ThisMon.transform.LookAt(Character.transform.position);
				
				Mon_Along = false;
				Mon_Inverse = false;

				
				if(ThisMon.tag == "Rabbit")
				{
					Mon_An.CrossFade("Jump");
				}
				
				if(Monster_PosX <= Ch_PosX)
				{
					ThisMon.transform.eulerAngles = new Vector3(0, Mon_Angle, 0);
					ThisMon.transform.Translate(-MoveSpeed*Time.deltaTime*FastSpeed, 0, 0);
				}
				else if(Monster_PosX >= Ch_PosX)
				{
					ThisMon.transform.eulerAngles = new Vector3(0, -Mon_Angle, 0);
					ThisMon.transform.Translate(MoveSpeed*Time.deltaTime*FastSpeed, 0, 0);
				}
			}
		}
	}
}
