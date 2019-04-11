using UnityEngine;
using UnityEngine.UI;

public class Earth_Game : MonoBehaviour {

	GDATA data;

	#region
	[Header("UI elements")]
	public Earth_light light;
    public Nikolo_Tesla_animationController tesla;
    public GameObject gameUI;
    public Earth_Statistic_P1 earthStat;

    public Text levelText,currLvlText;
	public Text attText;
	public Text medText;
	public Image attSlImage;
	public Image medSlImage;

	#endregion
	[Header("Received Values")]
	[Range(0, 100)]
	public int Attention = 0;
	[Range(0, 100)]
	public int Meditation = 0;

	private float tmpMedSliderVal = 0;
	private float tmpAtSliderVal = 0;

	[Header("Game Level Elements")]
	public int gameLevel = 0;
	public float gameTime = 0;

	[Header("TASK BAR RES")]
	public Sprite meditationIcon; 
	public Sprite attentionIcon;
	public Image  iconPad;
	public Slider sliderTask;
    public Image taskSliderImage;

	// Initialization
	void Start()
	{
		data = GDATA.Instance.GetComponent<GDATA>();

		gameLevel = 1;

		sliderTask.value = 0;
		iconPad.sprite = attentionIcon;
		levelText.text = "> 30 during 15 sec";
        currLvlText.text = "Level "+ gameLevel;
        levelText.color = Color.gray;
		iconPad.color = Color.gray; 
		 
	}

	void Update()
	{
		data.normalize ();

		Attention = data.Attention;
		Meditation = data.Meditation;
		UIupdate ();
		GameLogic ();
	}


    void GameLogic()
	{
		// Level 1
		if(gameLevel == 1 && Attention >= 25 && gameTime < 20)
		{
			gameTime += Time.deltaTime;
			sliderTask.value = gameTime;
			sliderTask.maxValue = 20;
			 
			iconPad.sprite = attentionIcon;
			iconPad.color = Color.red; 
			levelText.text = "> 25 during 20 sec";
			levelText.color = Color.red;
            taskSliderImage.color = Color.red;
        }
		else if(gameLevel == 1 && Attention < 25 && gameTime < 20)
		{
			gameTime = 0;
			iconPad.color = Color.gray; 
			levelText.color = Color.gray;
            taskSliderImage.color = Color.gray;
        }
		else if(gameLevel == 1 && Attention >= 25 && gameTime >= 20)
		{
			light.lightShow();
			gameLevel = 2;
            currLvlText.text = "Level " + gameLevel;
            gameTime = 0;
			iconPad.sprite = meditationIcon;
			levelText.text = "> 20 during 20 sec";
            earthStat.Balls();

        }

		// Level 2
		if(gameLevel == 2 && Meditation >= 20 && gameTime < 15)
		{
			gameTime += Time.deltaTime;
			sliderTask.value = gameTime;
			sliderTask.maxValue = 15;

			iconPad.sprite = meditationIcon;
			iconPad.color = Color.green; 
			levelText.text = "> 20 during 15 sec";
			levelText.color = Color.green;
            taskSliderImage.color = Color.green;
        }
		else if(gameLevel == 2 && Meditation < 20 && gameTime < 15)
		{
			gameTime = 0;
			
			iconPad.color = Color.gray; 
			levelText.color = Color.gray;
            taskSliderImage.color = Color.gray;
        }
		else if(gameLevel == 2 && Meditation >= 20 && gameTime >= 15)
		{
			light.lightShow();
			gameLevel = 3;
            currLvlText.text = "Level " + gameLevel;
            gameTime = 0;

			iconPad.sprite = meditationIcon;
			levelText.text = "> 30 during 10 sec";
            earthStat.Balls();
        }

		// Level 3
		if(gameLevel == 3 && Meditation >= 30 && gameTime < 10)
		{
			gameTime += Time.deltaTime;
			sliderTask.value = gameTime;
			sliderTask.maxValue = 10;

			iconPad.sprite = meditationIcon;
			iconPad.color = Color.green; 
			levelText.text = "> 30 during 10 sec";
			levelText.color = Color.green;
            taskSliderImage.color = Color.green;
        }
		else if(gameLevel == 3 && Meditation < 30 && gameTime < 10)
		{
			gameTime = 0;
			iconPad.color = Color.gray; 
			levelText.color = Color.gray;
            taskSliderImage.color = Color.gray;
        }
		else if(gameLevel == 3 && Meditation >= 30 && gameTime >= 10)
		{
			light.lightShow();
			gameLevel = 4;
            currLvlText.text = "Level " + gameLevel;
            gameTime = 0;

			iconPad.sprite = attentionIcon;
			levelText.text = "> 35 during 15 sec";
            earthStat.Balls();
        }

		// Level 4
		if(gameLevel == 4 && Attention >= 35 && gameTime < 15)
		{
			gameTime += Time.deltaTime;
			sliderTask.value = gameTime;
			sliderTask.maxValue = 15;
			
			iconPad.sprite = attentionIcon;
			iconPad.color = Color.red; 
			levelText.text = "> 35 during 15 sec";
			levelText.color = Color.red;
			taskSliderImage.color = Color.red;
		}
		else if(gameLevel == 4 && Attention < 35 && gameTime < 15)
		{
			gameTime = 0;
			 
			iconPad.color = Color.gray; 
			levelText.color = Color.gray;
			taskSliderImage.color = Color.gray;
		}
		else if(gameLevel == 4 && Attention >= 35 && gameTime >= 15)
		{
			light.lightShow();
			gameLevel = 5;
            currLvlText.text = "Level " + gameLevel;
            gameTime = 0;

			iconPad.sprite = meditationIcon;
			levelText.text = "> 40 during 15 sec";
            earthStat.Balls();
        }
				
		// Level 5
		if(gameLevel == 5 && Meditation >= 40 && gameTime < 15)
		{
			gameTime += Time.deltaTime;
			sliderTask.value = gameTime;
			sliderTask.maxValue = 15;
			 

			iconPad.sprite = meditationIcon;
			iconPad.color = Color.green; 
			levelText.text = "> 40 during 15 sec";
			levelText.color = Color.green;
			taskSliderImage.color = Color.green;
		}
		else if(gameLevel == 5 && Meditation < 40 && gameTime < 15)
		{
			gameTime = 0;
			 
			iconPad.color = Color.gray; 
			levelText.color = Color.gray;
			taskSliderImage.color = Color.gray;
		}
		else if(gameLevel == 5 && Meditation >= 40 && gameTime >= 15)
		{
			light.lightShow();
			gameLevel = 6;
            currLvlText.text = "Level " + gameLevel;
            gameTime = 0;

			iconPad.sprite = attentionIcon;
			levelText.text = "> 50 during 10 sec";
            earthStat.Balls();
        }

		// Level 6
		if(gameLevel == 6 && Attention >= 50 && gameTime < 10)
		{
			gameTime += Time.deltaTime;
			sliderTask.value = gameTime;
			sliderTask.maxValue = 10;
			 

			iconPad.sprite = attentionIcon;
			iconPad.color = Color.red; 
			levelText.text = "> 50 during 10 sec";
			levelText.color = Color.red;
			taskSliderImage.color = Color.red;
		}
		else if(gameLevel == 6 && Attention < 50 && gameTime < 10)
		{
			gameTime = 0;
			 
			iconPad.color = Color.gray; 
			levelText.color = Color.gray;
			taskSliderImage.color = Color.gray;
		}
		else if(gameLevel == 6 && Attention >= 50 && gameTime >= 10)
		{
			light.lightShow();
			gameLevel = 7;
            currLvlText.text = "Level " + gameLevel;
            gameTime = 0;

			iconPad.sprite = attentionIcon;
			levelText.text = "> 60 during 10 sec";
            earthStat.Balls();
        }

		// Level 7
		if(gameLevel == 7 && Attention >= 60 && gameTime < 10)
		{
			gameTime += Time.deltaTime;
			sliderTask.value = gameTime;
			sliderTask.maxValue = 10;
			 

			iconPad.sprite = attentionIcon;
			iconPad.color = Color.red; 
			levelText.text = "> 60 during 10 sec";
			levelText.color = Color.red;
			taskSliderImage.color = Color.red;
		}
		else if(gameLevel == 7 && Attention < 60 && gameTime < 10)
		{
			gameTime = 0;
			 
			iconPad.color = Color.gray; 
			levelText.color = Color.gray;
			taskSliderImage.color = Color.gray;
		}
		else if(gameLevel == 7 && Attention >= 60 && gameTime >= 10)
		{
			light.lightShow();
			gameLevel = 8;
            currLvlText.text = "Level " + gameLevel;
            gameTime = 0;

			iconPad.sprite = meditationIcon;
			levelText.text = "> 60 during 12 sec";
            earthStat.Balls();
        }
        // Level 8
        if (gameLevel == 8 && Meditation >= 60 && gameTime < 12)
        {
            gameTime += Time.deltaTime;
            sliderTask.value = gameTime;
            sliderTask.maxValue = 12;


            iconPad.sprite = meditationIcon;
            iconPad.color = Color.green;
            levelText.text = "> 60 during 12 sec";
            levelText.color = Color.green;
            taskSliderImage.color = Color.green;
        }
        else if (gameLevel == 8 && Meditation < 60 && gameTime < 12)
        {
            gameTime = 0;

            iconPad.color = Color.gray;
            levelText.color = Color.gray;
            taskSliderImage.color = Color.gray;
        }
        else if (gameLevel == 8 && Meditation >= 60 && gameTime >= 12)
        {
            light.lightShow();
            gameLevel = 9;
            currLvlText.text = "Level " + gameLevel;
            gameTime = 0;

            iconPad.sprite = attentionIcon;
            levelText.text = "> 75 during 15 sec";
            earthStat.Balls();
        }

        // Level 9
        if (gameLevel == 9 && Attention >= 75 && gameTime < 15)
        {
            gameTime += Time.deltaTime;
            sliderTask.value = gameTime;
            sliderTask.maxValue = 15;


            iconPad.sprite = attentionIcon;
            iconPad.color = Color.red;
            levelText.text = "> 75 during 15 sec";
            levelText.color = Color.red;
            taskSliderImage.color = Color.red;
        }
        else if (gameLevel == 9 && Attention < 75 && gameTime < 15)
        {
            gameTime = 0;

            iconPad.color = Color.gray;
            levelText.color = Color.gray;
            taskSliderImage.color = Color.gray;
        }
        else if (gameLevel == 9 && Attention >= 75 && gameTime >= 15)
        {
            light.lightShow();
            gameLevel = 10;
            currLvlText.text = "Level " + gameLevel;
            gameTime = 0;

            iconPad.sprite = meditationIcon;
            levelText.text = "> 80 during 15 sec";
            earthStat.Balls();
        }
        // Level 10
        if (gameLevel == 10 && Meditation >= 80 && gameTime < 15)
        {
            gameTime += Time.deltaTime;
            sliderTask.value = gameTime;
            sliderTask.maxValue = 15;


            iconPad.sprite = meditationIcon;
            iconPad.color = Color.green;
            levelText.text = "> 80 during 15 sec";
            levelText.color = Color.green;
            taskSliderImage.color = Color.green;
        }
        else if (gameLevel == 10 && Meditation < 80 && gameTime < 15)
        {
            gameTime = 0;

            iconPad.color = Color.gray;
            levelText.color = Color.gray;
            taskSliderImage.color = Color.gray;
        }
        else if (gameLevel == 10 && Meditation >= 80 && gameTime >= 15)
        {
            light.lightShow();
            gameLevel = 10;
            currLvlText.text = "Level " + gameLevel;
            gameTime = 0;

            iconPad.sprite = meditationIcon;
            levelText.text = "> 80 during 15 sec";
            earthStat.Balls();
        }
        //	tesla.Moving();
    }

	void UIupdate()
	{
		attText.text = "" + Attention+"%";
		medText.text = "" + Meditation+"%";

		tmpAtSliderVal = Mathf.Lerp(tmpAtSliderVal, Attention, Time.deltaTime * 5);
		tmpMedSliderVal = Mathf.Lerp(tmpMedSliderVal, Meditation, Time.deltaTime * 5);
		attSlImage.fillAmount = tmpAtSliderVal / 100;
		medSlImage.fillAmount = tmpMedSliderVal / 100;
	}
}
