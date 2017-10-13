using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GoBackBtn : MonoBehaviour, IPointerClickHandler{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Character_Move.Ch_AnPlay = true;
		GoBack.aa = false;
		GoBack.Tips.SetActive (false);
	}
}
