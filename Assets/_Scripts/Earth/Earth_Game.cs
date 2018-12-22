using UnityEngine;
using UnityEngine.UI;

public class Earth_Game : MonoBehaviour {

	GDATA data;

	#region
	[Header("UI elements")]
	public Earth_light light;
    public Nikolo_Tesla_animationController tesla;
    public GameObject gameUI;
	

	public Text levelText;
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
		levelText.color = Color.gray;
		iconPad.color = Color.gray; 
		 
	}

	void Update()
	{
		Attention = data.Attention;
		Meditation = data.Meditation;

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//ShowPauseMenu();
		}

		UIupdate ();
		GameLogic ();
	}


    void GameLogic()
	{
		// Level 1
		if(gameLevel == 1 && Attention >= 30 && gameTime < 15)
		{
			gameTime += Time.deltaTime;
			sliderTask.value = gameTime;
			sliderTask.maxValue = 15;
			 
			iconPad.sprite = attentionIcon;
			iconPad.color = Color.red; 
			levelText.text = "> 30 during 15 sec";
			levelText.color = Color.red;
            taskSliderImage.color = Color.red;
        }
		else if(gameLevel == 1 && Attention < 30 && gameTime < 15)
		{
			gameTime = 0;
			iconPad.color = Color.gray; 
			levelText.color = Color.gray;
            taskSliderImage.color = Color.gray;
        }
		else if(gameLevel == 1 && Attention >= 30 && gameTime >= 15)
		{
			light.lightShow();
			gameLevel = 2;
			gameTime = 0;
			iconPad.sprite = meditationIcon;
			levelText.text = "> 20 during 20 sec";
		}

		// Level 2
		if(gameLevel == 2 && Meditation >= 20 && gameTime < 20)
		{
			gameTime += Time.deltaTime;
			sliderTask.value = gameTime;
			sliderTask.maxValue = 20;

			iconPad.sprite = meditationIcon;
			iconPad.color = Color.green; 
			levelText.text = "> 20 during 20 sec";
			levelText.color = Color.green;
            taskSliderImage.color = Color.green;
        }
		else if(gameLevel == 2 && Meditation < 20 && gameTime < 20)
		{
			gameTime = 0;
			
			iconPad.color = Color.gray; 
			levelText.color = Color.gray;
            taskSliderImage.color = Color.gray;
        }
		else if(gameLevel == 2 && Meditation >= 20 && gameTime >= 20)
		{
			light.lightShow();
			gameLevel = 3;
			gameTime = 0;

			iconPad.sprite = meditationIcon;
			levelText.text = "> 40 during 15 sec";
		}

		// Level 3
		if(gameLevel == 3 && Meditation >= 40 && gameTime < 15)
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
		else if(gameLevel == 3 && Meditation < 40 && gameTime < 15)
		{
			gameTime = 0;
			iconPad.color = Color.gray; 
			levelText.color = Color.gray;
            taskSliderImage.color = Color.gray;
        }
		else if(gameLevel == 3 && Meditation >= 40 && gameTime >= 15)
		{
			light.lightShow();
			gameLevel = 4;
			gameTime = 0;

			iconPad.sprite = attentionIcon;
			levelText.text = "> 50 during 20 sec";
		}

		// Level 4
		if(gameLevel == 4 && Attention >= 50 && gameTime < 20)
		{
			gameTime += Time.deltaTime;
			sliderTask.value = gameTime;
			sliderTask.maxValue = 20;
			 

			iconPad.sprite = attentionIcon;
			iconPad.color = Color.red; 
			levelText.text = "> 50 during 20 sec";
			levelText.color = Color.red;
			taskSliderImage.color = Color.red;
		}
		else if(gameLevel == 4 && Attention < 50 && gameTime < 20)
		{
			gameTime = 0;
			 
			iconPad.color = Color.gray; 
			levelText.color = Color.gray;
			taskSliderImage.color = Color.gray;
		}
		else if(gameLevel == 4 && Attention >= 50 && gameTime >= 20)
		{
			light.lightShow();
			gameLevel = 5;
			gameTime = 0;

			iconPad.sprite = meditationIcon;
			levelText.text = "> 60 during 15 sec";
		}
				
		// Level 5
		if(gameLevel == 5 && Meditation >= 60 && gameTime < 15)
		{
			gameTime += Time.deltaTime;
			sliderTask.value = gameTime;
			sliderTask.maxValue = 15;
			 

			iconPad.sprite = meditationIcon;
			iconPad.color = Color.green; 
			levelText.text = "> 60 during 15 sec";
			levelText.color = Color.green;
			taskSliderImage.color = Color.green;
		}
		else if(gameLevel == 5 && Meditation < 60 && gameTime < 15)
		{
			gameTime = 0;
			 
			iconPad.color = Color.gray; 
			levelText.color = Color.gray;
			taskSliderImage.color = Color.gray;
		}
		else if(gameLevel == 5 && Meditation >= 60 && gameTime >= 15)
		{
			light.lightShow();
			gameLevel = 6;
			gameTime = 0;

			iconPad.sprite = attentionIcon;
			levelText.text = "> 75 during 10 sec";
		}

		// Level 6
		if(gameLevel == 6 && Attention >= 75 && gameTime < 10)
		{
			gameTime += Time.deltaTime;
			sliderTask.value = gameTime;
			sliderTask.maxValue = 10;
			 

			iconPad.sprite = attentionIcon;
			iconPad.color = Color.red; 
			levelText.text = "> 75 during 10 sec";
			levelText.color = Color.red;
			taskSliderImage.color = Color.red;
		}
		else if(gameLevel == 6 && Attention < 75 && gameTime < 10)
		{
			gameTime = 0;
			 
			iconPad.color = Color.gray; 
			levelText.color = Color.gray;
			taskSliderImage.color = Color.gray;
		}
		else if(gameLevel == 6 && Attention >= 75 && gameTime >= 10)
		{
			light.lightShow();
			gameLevel = 7;
			gameTime = 0;

			iconPad.sprite = meditationIcon;
			levelText.text = "> 80 during 15 sec";
		}

		// Level 7
		if(gameLevel == 7 && Meditation >= 70 && gameTime < 15)
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
		else if(gameLevel == 7 && Meditation < 80 && gameTime < 15)
		{
			gameTime = 0;
			 
			iconPad.color = Color.gray; 
			levelText.color = Color.gray;
			taskSliderImage.color = Color.gray;
		}
		else if(gameLevel == 7 && Meditation >= 80 && gameTime >= 15)
		{
			light.lightShow();
			gameLevel = 7;
			gameTime = 0;

			iconPad.sprite = meditationIcon;
			levelText.text = "> 80 during 15 sec";
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
