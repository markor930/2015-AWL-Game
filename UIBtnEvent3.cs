using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*IPointerClickHandler - OnPointerClick 點擊。
  IPointerEnterHandler - OnPointerEnter 進入。
  IPointerExitHandler - OnPointerExit 離開。
  IPointerDownHandler - OnPointerDown 按下。
  IPointerUpHandler - OnPointerUp 彈起。*/

//將腳本移入所要觸發的button當中，並加入Component(EventSystems)
//在MonoBehaviour後面必須宣告Enter和Exit兩項滑鼠事件處理程序
public class UIBtnEvent3 : MonoBehaviour, 
IPointerEnterHandler, 
IPointerExitHandler, 
IPointerClickHandler {
	
	public static GameObject UIText;
	private float InBtnTime; //宣告滑鼠在按鈕內的時間變數
	
	// Use this for initialization
	void Start () {
		//抓取子物件命名為UIText
		UIText = gameObject.transform.GetChild (0).gameObject;
		gameObject.GetComponent<RectTransform> ().position = new Vector3 (Screen.width / 2 + 145, Screen.height / 2 + 165, 0);
	}
	
	// Update is called once per frame
	void Update () {
		UIText.GetComponent<Text>().text = Game_MainScript.btn_3;
	}
	
	public void OnPointerClick(PointerEventData eventData)
	{

		if(Game_MainScript.DontClick == false)
		{
			Game_MainScript.BtnThreeClick = true;
		}
	}
	
	//滑鼠指針滑入
	public void OnPointerEnter(PointerEventData eventData)
	{
		SoundAnswer.Btn03 = true;
		if(InBtnTime < 0.1f)
		{
			Game_MainScript.TestSound.GetComponent<SoundAnswer> ().enabled = true;
		}
		InBtnTime = Time.time;
	}
	//滑鼠指針滑出
	public void OnPointerExit(PointerEventData eventData)
	{
		SoundAnswer.Btn03 = false;
		Game_MainScript.TestSound.GetComponent<SoundAnswer> ().enabled = false;

		if(SoundAnswer.Btn01 == false && SoundAnswer.Btn02 == false)
		{
			InBtnTime = 0.0f;
		}
	}
}
