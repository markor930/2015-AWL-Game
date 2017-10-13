using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Game_MainScript : MonoBehaviour {

	public Text Q_Title; //Text GUI Componets

	public static GameObject Character; //宣告角色物件
	public static GameObject Monster; //宣告怪物物件
	public GameObject DieObject;
	public GameObject Monster_HP;
	public GameObject GemText;

	public static bool SelectBtn = false; //按鈕開始布林判斷
	public static bool Begin = false; //問答開始布林判斷

	//按鈕選擇布林判斷
	public static bool BtnOneClick = false;
	public static bool BtnTwoClick = false;
	public static bool BtnThreeClick = false;
	public static bool DontClick = false;

	public static int AcquireGem = 0; //獲得寶石

	int[] AWLClass = {1, 2, 3, 4}; //宣告單字類別陣列
	private int C_index; //類別陣列索引
	public static int C_count; //類別陣列數值

	public static float True_count;
	
	//問答陣列
	string [] Humanities = {"地區" ,"觀念" ,"由..組成" ,"上下文、背景" ,"創造","環境" ,"建立","個人、獨特的", "問題", "發生", "時期", "持續、前進", "過程、方法", "部分", "相似", "結構", "變化"}; //0-16
	string [] humChoose = {"area", "concept", "consist", "context", "create", "environment", "establish", "individual", "issue", "occur", "period", "proceed", "process", "section", "similar", "structure", "vary"};

	string [] Business = {"方法、靠近", "評估", "可獲得的", "益處", "契約、縮小", "分配", "經濟", "估計", "出口", "因素", "財政；金融", "收入", "包含、牽涉", "勞工", "百分之一", "需要、要求", "回應、答覆", "部分、部門、（文章）節", "重要的、顯著的"};//0-18
	string [] busChoose = {"approach", "assess", "available", "benefit", "contract", "distribute", "economy", "estimate", "export", "factor", "finance", "income", "involve", "labour", "percent", "require", "respond", "sector", "significant"};

	string [] Legal = {"假設", "權力", "構成", "定義、說明", "明顯的、證據", "識別", "表明、指向", "解釋", "合法的", "立法", "政策、方針", "角色、作用", "明確的、特定的"};//0-12
	string [] legChoose = {"assume", "authority", "constitute", "define", "evident", "identify", "indicate", "interpret", "legal", "legislate", "policy", "role", "specific"};

	string [] Science = {"分析", "資料、數據", "得到、源出於", "公式", "功能", "主要的", "方法", "原則", "研究", "來源", "理論"};//0-10
	string [] sciChoose = {"analyse", "data", "derive", "formula", "function", "major", "method", "principle", "research", "source", "theory"};

	//按鈕亂數索引值
	private int index; 
	private int index_1;
	private int index_2;
	
	//按鈕文字宣告
	public static string btn_1;
	public static string btn_2;
	public static string btn_3;
	
	private int sample; //問題索引取樣按鈕索引值
	private int num; //取樣值暫存空間
	private string word; //宣告Text文字

	public static float MonDamge;
	private float ChDamge;
	private float firstTime; //問答初始時間暫存
	private float LastTime; //答題最後時間暫存
	private float TimeEquation;

	public GameObject Ask_BG; //宣告背景圖示UIImage
	public GameObject Ask_lab; //宣告問答類別標籤

	//宣告按鈕物件
	public GameObject Button1;
	public GameObject Button2;
	public GameObject Button3;

	//宣告Image資料型別(UIBtn)
	private Image ThisBtn;
	private Image OtherBtn1;
	private Image OtherBtn2;

	//宣告Text資料型別(UIBtn)
	private Text thisBtnT;
	private Text otherBtnT1;
	private Text otherBtnT2;

	private Animator BtnAn;

	//宣告聲音
	public static GameObject TestSound;
	public static int Sound_index;
	public static int Voice_index1;
	public static int Voice_index2;
	public static int Voice_index3;

	bool toSum = false;

	// Use this for initialization
	void Start () {

		Ask_BG.SetActive(false);

		Monster = GameObject.FindGameObjectWithTag("NPC");
		Character = GameObject.FindGameObjectWithTag("Player");
		
		TestSound = GameObject.Find ("Test Sound");

		Q_Title = GetComponent<Text>();
		Q_Title.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		GemText.GetComponent<GUIText>().text = AcquireGem + " / " + "5";

		if(Begin)
		{
			ChDamge = 0;
			MonDamge = 0;

			Q_Title.enabled = true; //enabled 顯示GUI

			C_index = Random.Range(0, AWLClass.Length);
			C_count = AWLClass[C_index];

			Test();

			firstTime = Time.time;

			DontClick = false;
		}
		Begin = false; //限制執行亂數為一次

		if(Hp_Monster.Mon_HP == 0)
		{
			Begin = false;

			StartCoroutine(MonsterDead());
			toSum = true;
		}
		else if(Hp_Monster.Mon_HP == 100 && AcquireGem < 5)
		{
			Monster_HP.SetActive(true);
		}

		if(Hp_Character.Ch_HP == 0)
		{
			Begin = false;

			StartCoroutine(GameOver());
		}

		JudgeAns ();
	}

	//測驗函式
	//亂數取索引值
	void Test()
	{
		if(C_count == 1)
		{
			index = Random.Range(0,humChoose.Length);
			if(index == 16)
			{
				index_1 = index - 1;
				index_2 = index - 2;
			}
			else
			{
				index_1 = index + 1;
				index_2 = index + 2;
				
				if(index_2 >= 17)
				{
					index_2 -= 3;
				}
			}
			
			int [] Value = {index,index_1,index_2};
			sample = Random.Range(0,Value.Length);
			
			num = Value[sample];
			word = Humanities[num];

			btn_1 = humChoose[index];
			btn_2 = humChoose[index_1];
			btn_3 = humChoose[index_2];


			Sound_index = num;

			Voice_index1 = index;
			Voice_index2 = index_1;
			Voice_index3 = index_2;
		}
		
		if(C_count == 2)
		{
			index = Random.Range(0,busChoose.Length);
			if(index == 18)
			{
				index_1 = index - 1;
				index_2 = index - 2;
			}
			else
			{
				index_1 = index + 1;
				index_2 = index + 2;
				
				if(index_2 >= 19)
				{
					index_2 -= 3;
				}
			}
			
			int [] Value = {index,index_1,index_2};
			sample = Random.Range(0,Value.Length);
			
			num = Value[sample];
			word = Business[num];

			btn_1 = busChoose[index];
			btn_2 = busChoose[index_1];
			btn_3 = busChoose[index_2];


			Sound_index = num;

			Voice_index1 = index;
			Voice_index2 = index_1;
			Voice_index3 = index_2;
		}
		
		if(C_count == 3)
		{
			index = Random.Range(0,legChoose.Length);
			if(index == 12)
			{
				index_1 = index - 1;
				index_2 = index - 2;
			}
			else
			{
				index_1 = index + 1;
				index_2 = index + 2;
				
				if(index_2 >= 13)
				{
					index_2 -= 3;
				}
			}
			
			int [] Value = {index,index_1,index_2};
			sample = Random.Range(0,Value.Length);
			
			num = Value[sample];
			word = Legal[num];
			
			btn_1 = legChoose[index];
			btn_2 = legChoose[index_1];
			btn_3 = legChoose[index_2];

			Sound_index = num;

			Voice_index1 = index;
			Voice_index2 = index_1;
			Voice_index3 = index_2;
		}
		
		if(C_count == 4)
		{
			index = Random.Range(0,sciChoose.Length);
			if(index == 10)
			{
				index_1 = index - 1;
				index_2 = index - 2;
			}
			else
			{
				index_1 = index + 1;
				index_2 = index + 2;
				
				if(index_2 >= 11)
				{
					index_2 -= 2;
				}
			}
			
			int [] Value = {index,index_1,index_2};
			sample = Random.Range(0,Value.Length);
			
			num = Value[sample];
			word = Science[num];
			
			btn_1 = sciChoose[index];
			btn_2 = sciChoose[index_1];
			btn_3 = sciChoose[index_2];


			Sound_index = num;

			Voice_index1 = index;
			Voice_index2 = index_1;
			Voice_index3 = index_2;
		}

		StartCoroutine (ToSound());
		Q_Title.text = word;
		SelectBtn = true;
	}

	//按鈕選擇與判斷函式
	void JudgeAns()
	{
		if (SelectBtn) 
		{
			Ask_BG.SetActive (true);
			Ask_lab.SetActive(true);
			Button1.SetActive(true);
			Button2.SetActive(true);
			Button3.SetActive(true);

			if (BtnOneClick) 
			{
				ThisBtn = Button1.GetComponent<Image> ();

				LastTime = Time.time;

				if (num == index) 
				{
					Success ();
				} 
				else 
				{
					UnSuccess ();
				}
			}
			
			if (BtnTwoClick) 
			{
				ThisBtn = Button2.GetComponent<Image> ();

				LastTime = Time.time;
				if (num == index_1) 
				{
					Success ();
				} 
				else 
				{
					UnSuccess ();
				}
			}
			
			if (BtnThreeClick) 
			{
				ThisBtn = Button3.GetComponent<Image> ();

				LastTime = Time.time;
				if (num == index_2) 
				{
					Success ();
				} 
				else 
				{
					UnSuccess ();
				}
			}
		}
		else 
		{
			Ask_BG.SetActive(false);
			Ask_lab.SetActive(false);
			Button1.SetActive(false);
			Button2.SetActive(false);
			Button3.SetActive(false);
		}
	}

	//答對函式
	void Success()
	{
		if(Monster_Move.Askcount < 4)
		{
			True_count += 1;
		}

		//即時正確回饋
		ThisBtn.color = new Color32 (77, 255, 255, 255); //RGB32位元組，設定每個RGB的值

		TestSound.GetComponent<SoundQuestion> ().enabled = false;

		SoundYE.YesAns = true;
		TestSound.GetComponent<SoundYE> ().enabled = true;

		BtnOneClick = false;
		BtnTwoClick = false;
		BtnThreeClick = false;

		Character.GetComponent<Character_Move>().Character_An.CrossFade("Attack");
		Monster.GetComponent<Monster_Move>().Mon_An.CrossFade("Damage");

		TimeEquation = LastTime - firstTime;
		if(TimeEquation > 12)
		{
			MonDamge = 1;
		}
		else
		{
			MonDamge = (20.0f - TimeEquation)*3.0f;
		}

		Hp_Monster.Mon_HP -= Mathf.Round(MonDamge); //四捨五入
		StartCoroutine(ReAnswers());
	}
	
	//答錯函式
	void UnSuccess()
	{
		AchieveGame.S_Count -= 3;
		AchieveGame.S_Count -= 1;

		//即時錯誤回饋
		ThisBtn.color = new Color32 (255, 82, 82, 255); //RGB32位元組，設定每個RGB的值

		TestSound.GetComponent<SoundQuestion> ().enabled = false;

		SoundYE.ErroAns = true;
		TestSound.GetComponent<SoundYE> ().enabled = true;

		BtnOneClick = false;
		BtnTwoClick = false;
		BtnThreeClick = false;

		Character.GetComponent<Character_Move>().Character_An.CrossFade("Damage",0.1f);
		Monster.GetComponent<Monster_Move>().Mon_An.CrossFade("Attack");

		TimeEquation = LastTime - firstTime;
		if(TimeEquation < 1.0f)
		{
			ChDamge = Hp_Character.Ch_HP*(50.0f/100.0f);

			AchieveGame.EP -= 2;

		}
		else if(TimeEquation > 8.0f)
		{
			if(TimeEquation > 12.0f)
			{
				ChDamge = Hp_Character.Ch_HP*(50.0f/100.0f);
			}
			else
			{
				ChDamge = Hp_Character.Ch_HP*(TimeEquation*4.0f/100.0f);
			}
			//ChDamge = TimeEquation*4.0f;
		}
		else
		{
			ChDamge = (100.0f - TimeEquation)*0.3f;
		}

		Hp_Character.Ch_HP -= Mathf.Round(ChDamge);

		StartCoroutine(ReAnswers());
	}

	//CrossFadeAlpha：淡入淡出(a, time, 是否執行時間)
	IEnumerator ReAnswers()
	{
		DontClick = true;
		firstTime = 0.0f;
		LastTime = 0.0f;

		//執行動畫停止
		Button1.GetComponent<Animator>().enabled = false;
		Button2.GetComponent<Animator>().enabled = false;
		Button3.GetComponent<Animator>().enabled = false;

		//利用索引值判斷哪個按鈕為正確答案，並給予使用者回饋
		yield return new WaitForSeconds(0.3f);
		if (num == index) 
		{
			ThisBtn = Button1.GetComponent<Image> ();
			OtherBtn1 = Button2.GetComponent<Image> ();
			OtherBtn2 = Button3.GetComponent<Image> ();
			
			thisBtnT = UIBtnEvent1.UIText.GetComponent<Text>();
			otherBtnT1 = UIBtnEvent2.UIText.GetComponent<Text>();
			otherBtnT2 = UIBtnEvent3.UIText.GetComponent<Text>();
		} 
		else if (num == index_1) 
		{
			ThisBtn = Button2.GetComponent<Image> ();
			OtherBtn1 = Button1.GetComponent<Image> ();
			OtherBtn2 = Button3.GetComponent<Image> ();
			
			thisBtnT = UIBtnEvent2.UIText.GetComponent<Text>();
			otherBtnT1 = UIBtnEvent1.UIText.GetComponent<Text>();
			otherBtnT2 = UIBtnEvent3.UIText.GetComponent<Text>();
		}
		else if(num == index_2)
		{
			ThisBtn = Button3.GetComponent<Image> ();
			OtherBtn1 = Button1.GetComponent<Image> ();
			OtherBtn2 = Button2.GetComponent<Image> ();
			
			thisBtnT = UIBtnEvent3.UIText.GetComponent<Text>();
			otherBtnT1 = UIBtnEvent1.UIText.GetComponent<Text>();
			otherBtnT2 = UIBtnEvent2.UIText.GetComponent<Text>();
		}
		ThisBtn.color = new Color32 (77, 255, 255, 255); //將正確答案標示出來

		//0.6秒內角色動畫執行中
		yield return new WaitForSeconds(0.3f);
		Character.GetComponent<Character_Move>().Character_An.CrossFade("Wait");
		Monster.GetComponent<Monster_Move>().Mon_An.CrossFade("Wait");

		yield return new WaitForSeconds(0.4f);
		OtherBtn1.CrossFadeAlpha (0.0f, 0.8f, true);
		OtherBtn2.CrossFadeAlpha (0.0f, 0.8f, true);
		otherBtnT1.CrossFadeAlpha (0.0f, 0.8f, true);
		otherBtnT2.CrossFadeAlpha (0.0f, 0.8f, true);

		yield return new WaitForSeconds(1.2f);
		ThisBtn.CrossFadeAlpha (0.0f, 0.8f, true);
		thisBtnT.CrossFadeAlpha (0.0f, 0.8f, true);

		yield return new WaitForSeconds(0.8f);
		//回復原來的Alpha值
		ThisBtn.CrossFadeAlpha (1.0f, 0.0f, true);
		OtherBtn1.CrossFadeAlpha (1.0f, 0.0f, true);
		OtherBtn2.CrossFadeAlpha (1.0f, 0.0f, true);
		thisBtnT.CrossFadeAlpha (1.0f, 0.0f, true);
		otherBtnT1.CrossFadeAlpha (1.0f, 0.0f, true);
		otherBtnT2.CrossFadeAlpha (1.0f, 0.0f, true);

		Button1.GetComponent<Animator>().enabled = true;
		Button2.GetComponent<Animator>().enabled = true;
		Button3.GetComponent<Animator>().enabled = true;

		Button1.SetActive(false);
		Button2.SetActive(false);
		Button3.SetActive(false);

		//按鈕回復Color
		ThisBtn.color = new Color32 (255, 255, 255, 255); 
		OtherBtn1.color = new Color32 (255, 255, 255, 255);
		OtherBtn2.color = new Color32 (255, 255, 255, 255);

		if(Hp_Monster.Mon_HP >= 1 && Hp_Character.Ch_HP >= 1)
		{
			TimeEquation = 0;
			Begin = true;
		}
	}

	IEnumerator ToSound()
	{
		yield return new WaitForSeconds (0.6f);
		if(SelectBtn)
		{
			TestSound.GetComponent<SoundQuestion> ().enabled = true;

			TestSound.GetComponent<SoundYE> ().enabled = false;
			SoundYE.YesAns = false;
			SoundYE.ErroAns = false;
		}
	}

	IEnumerator MonsterDead()
	{
		Monster.GetComponent<Monster_Move>().Mon_An.CrossFade("Dead");
		Monster.GetComponent<Monster_Move>().enabled = false;

		//必須大等於ReAnswers()的秒數，因為腳本執行還存在Success()的運作
		yield return new WaitForSeconds(0.7f);
		Hp_Monster.Mon_HP = 0.1f;

		yield return new WaitForSeconds(1.0f);
		Monster_Move.ThisMon.SetActive(false);
		Monster_HP.SetActive(false);

		yield return new WaitForSeconds(0.5f);
		Q_Title.enabled = false;
		SelectBtn = false;
		yield return new WaitForSeconds(0.3f);
		Character_Move.Ch_AnPlay = true;

		if(toSum)
		{
			if(True_count >= 7 || True_count <= 0)
			{
				AchieveGame.S_Count += 1;
			}
			else
			{
				float f = Mathf.Pow(True_count,2);
				float SumInt = 100/f;
				AchieveGame.S_Count += SumInt;
				toSum = false;
				print(AchieveGame.S_Count);
				//AchieveGame.S_Count /= 2;
			}
		}
	}

	//遊戲結束
	IEnumerator GameOver()
	{
		DieObject.SetActive (true);
		Character.SetActive (false);

		yield return new WaitForSeconds(2.8f);
		Monster_Move.Askcount = 0;
		AcquireGem = 0;
		ThisBtn.CrossFadeAlpha (0.0f, 0.0f, true);
		OtherBtn1.CrossFadeAlpha (0.0f, 0.0f, true);
		OtherBtn2.CrossFadeAlpha (0.0f, 0.0f, true);
		thisBtnT.CrossFadeAlpha (0.0f, 0.0f, true);
		otherBtnT1.CrossFadeAlpha (0.0f, 0.0f, true);
		otherBtnT2.CrossFadeAlpha (0.0f, 0.0f, true);
		Q_Title.text = "Game Over";
		Character.transform.parent.gameObject.SetActive (false);

		yield return new WaitForSeconds(1.2f);
		SelectBtn = false;
		Q_Title.enabled = false;
		AchieveGame.Expand = true;
		//Character_Move.Ch_AnPlay = true;
		//Application.LoadLevel(1); //跳至Sence 2
	}
}
