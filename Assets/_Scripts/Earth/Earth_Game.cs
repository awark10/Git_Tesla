using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earth_Game : MonoBehaviour {


	ThinkGearController controller;
	public Earth_light light;
	// ParticleSystem particle;
	//Transform transform;
	#region

	[Header("UI elements")]

	//public GameObject connectLoader;
	// public GameObject backGr;
	public GameObject gameUI;
	public GameObject connectMenu;

	public Text levelText;
	//public Text downTimeText;
	public Text attText;
	public Text medText;
	public Image attSlImage;
	public Image medSlImage;
	// public GameObject startMenu;
	//public Image conImage;
	// public Button connect;
	// public Slider MedSlider;
	// public Slider AtSlider;
	#endregion
	[Header("Signal Elements")]
	// [Range(0, 200)]
	public static int PoorSignal;
	public static float indexSignalIcons = 1;
	private bool enableAnimation = false;
	private float animationInterval = 0.06f;
	[Header("Received Values")]
	[Range(0, 100)]
	public int Attention = 0;
	[Range(0, 100)]
	public int Meditation = 0;

	private float x = 50;
	private float tmpMedSliderVal = 0;
	private float tmpAtSliderVal = 0;
	private bool timerIsActive;

	[Header("Statistics")]
	public float fullTime;
	public float statGameTime = 0;
	public float statMedTime = 0;
	// public float statMed50Time = 0;
	public float statMed60Time = 0;
	public float statMed80Time = 0;
	public float statMedLevel = 0;
	public static int tmpStat = 0;
	public string statStr = "";
	[Header("Game Level Elements")]
	public int gameLevel = 0;
	public float downCounter = 0;
	public float gameTime = 0;


	// Initialization
	void Start()
	{
		controller = GameObject.Find("ThinkGear").GetComponent<ThinkGearController>();
		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;

		levelText.text = "";
		//downTimeText.text = "";
	}


	void Update()
	{

		if (!GamesMenu.demo)
		{ 
			if (ThinkGearController.Instance.poorSignalStatus == 0) 
			{
				StopGame ();
				connectMenu.SetActive (true);
				gameUI.SetActive (false);
			} 
			else 
			{
				Attention = ThinkGearController.Instance.Attention;
				Meditation = ThinkGearController.Instance.Meditation;

				GameLogic();
				UIupdate();
			}
		}
	}


	void GameLogic()
	{

		// Game start

		if (Meditation >= 50 && Attention >= 50) {
		
			gameTime += Time.deltaTime;

			// Level 1
			if (gameLevel == 0 && Meditation >= 50 && Attention >= 50)
			{
				gameLevel = 1;
				levelText.text = "Level 1";
				downCounter = 7;
			}
			else if (gameLevel == 1 && gameTime < 7)
			{
				if (Meditation < 50 || Attention < 50) 
					StopGame();
			}
			else if (gameLevel == 1 && gameTime >= 7)
			{
				if (Meditation >= 60 && Attention >= 60) 
					light.lightShow(); // next level will start
				else 
				{
					light.lightShow();
					StopGame();
				}
			}

			// Level 2
			if (gameLevel == 1 && Meditation >= 60 && Attention >= 60 && gameTime >= 7)
			{
				gameLevel = 2;
				levelText.text = "Level 2";
				downCounter = 7;
			}
			else if (gameLevel == 2 && gameTime < 14)
			{
				if (Meditation < 60 || Attention < 60) 
					StopGame();
			}
			else if (gameLevel == 2 && gameTime > 14)
			{
				if (Meditation >= 70 && Attention >= 70) 
					light.lightShow(); // next level will start
				else 
				{
					light.lightShow();
					StopGame();
				}
			}

			// Level 3
			if (gameLevel == 2 && Meditation >= 70 && Attention >= 70 && gameTime >= 14)
			{

				gameLevel = 3;
				levelText.text = "Level 3";

				downCounter = 7;
			}
			else if (gameLevel == 3 && gameTime < 21)
			{
				if (Meditation < 70 || Attention < 70) 
					StopGame();
			}
			else if (gameLevel == 3 && gameTime >= 21)
			{
				if (Meditation >= 80 && Attention >= 80) 
					light.lightShow(); // next level will start
				else 
				{
					light.lightShow();
					StopGame();
				}
			}

			// Level 4
			if (gameLevel == 3 && Meditation >= 80 && Attention >= 80 && gameTime >= 21)
			{

				gameLevel = 4;
				levelText.text = "";

			}
			else if (gameLevel == 4 && Meditation < 70 && gameTime < 38)
			{

				gameTime = 20;

			}
			else if (gameLevel == 4 && Meditation >= 70 && gameTime >= 28)
			{
				light.lightShow();
				gameTime = 28;
			}

		} else 
			StopGame();

	}

	void UIupdate()
	{

		attText.text = "" + Attention+"%";
		medText.text = "" + Meditation+"%";

		if (gameLevel != 0 && gameLevel != 4)
		{
			downCounter -= Time.deltaTime;
			int td = (int)downCounter;
			//downTimeText.text = "" + td;

		} else
			//downTimeText.text = "";


		tmpAtSliderVal = Mathf.Lerp(tmpAtSliderVal, Attention, Time.deltaTime * 5);
		tmpMedSliderVal = Mathf.Lerp(tmpMedSliderVal, Meditation, Time.deltaTime * 5);
		attSlImage.fillAmount = tmpAtSliderVal / 100;
		medSlImage.fillAmount = tmpMedSliderVal / 100;

	}

	void StopGame()
	{
		gameTime = 0;
		gameLevel = 0;
		levelText.text = "";
		float t = Mathf.Lerp(255f, 0f, Time.deltaTime);
		
		//downTimeText.text = "";
	}




	void OnUpdateAttention(int value)
	{ 
		Attention = ThinkGearController.Instance.Attention;
	}
	void OnUpdateMeditation(int value)
	{
		Meditation = ThinkGearController.Instance.Meditation;
	}
}
