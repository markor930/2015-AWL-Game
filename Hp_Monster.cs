using UnityEngine;
using System.Collections;

public class Hp_Monster : MonoBehaviour {
	
	public static float Mon_HP;
	private float MaxHP;
	private float HPWidth;
	
	public GUITexture HPTexture;
	public GUITexture HPBackground;
	public GUIText HPText;

	private Camera MainCamera;
	
	private float Gui_v;
	private float Gui_h = 0.018f;
	private float Gui_Z = 0.1f;

	// Use this for initialization
	void Start () {
		
		Mon_HP = 100;
		MaxHP = Mon_HP;//紀錄最大生命值
		HPText.text = "HP: " + Mon_HP;//顯示生命值文字
		HPWidth = HPTexture.pixelInset.width;//紀錄血條寬度

		
		MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Mon_HP <= 0)
		{
			Mon_HP = 0;
		}
		
		//計算生命值百分比
		float HPRatio = Mathf.Clamp01(Mon_HP/MaxHP);
		//控制血條
		HPTexture.pixelInset = 
			new Rect(HPTexture.pixelInset.x, HPTexture.pixelInset.y, HPWidth*HPRatio, HPTexture.pixelInset.height);
		
		//控制生命值文字
		HPText.text = "HP: " + Mathf.Floor(Mon_HP);
		MHP_Follow();
	}

	void MHP_Follow()
	{
		// WorldToViewportPoint: 將Vector3物件座標(World)轉換為Camera視角的螢幕座標(Viewport)
		Vector3 HP_Position = MainCamera.WorldToViewportPoint(Monster_Move.ThisMon.transform.position);
		//Vector3 HP_Position = MainCamera.ScreenToViewportPoint(Role.transform.position);

		if(Monster_Move.ThisMon.tag == "Rabbit")
		{
			Gui_v = 0.18f;
		}
		else
		{
			Gui_v = 0.1f;
		}

		HPTexture.transform.position = new Vector3(HP_Position.x - Gui_h, HP_Position.y + Gui_v, HP_Position.z + Gui_Z );
		HPBackground.transform.position = new Vector3(HP_Position.x - Gui_h, HP_Position.y + Gui_v, HP_Position.z );
		HPText.transform.position = new Vector3(HP_Position.x - Gui_h, HP_Position.y + Gui_v, HP_Position.z);
	}
}