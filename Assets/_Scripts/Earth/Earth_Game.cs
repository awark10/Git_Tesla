using UnityEngine;
using UnityEngine.UI;

public class Earth_Game : MonoBehaviour {

	#region
	[Header("UI elements")]
	public Earth_light light;
    public Nikolo_Tesla_animationController tesla;
    public GameObject gameUI;
	public GameObject connectMenu;
	public GameObject pauseMenu;

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


	// Initialization
	void Start()
	{
		levelText.text = "> 50 during 15 sec";
		levelText.color = Color.gray;
		iconPad.color = Color.gray; 
		//downTimeText.text = "";
	}

	void Update()
	{
		Attention = CONNECTOR.Instance.Attention;
		Meditation = CONNECTOR.Instance.Meditation;

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ShowPauseMenu();
		}

		UIupdate ();
		GameLogic ();
	}

	public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        gameUI.SetActive(false);
    }

    void GameLogic()
	{

			// Level 1
			if (gameLevel == 0 && Meditation >= 50)
			{
				gameLevel = 1;
				iconPad.sprite = meditationIcon;
				iconPad.color = Color.white; 
				levelText.text = "> 50 during 15 sec";
				levelText.color = Color.white;
			}
			else if (gameLevel == 1 && gameTime < 7)
			{
				gameTime += Time.deltaTime;
				sliderTask.value = (float)gameTime;

				if (Meditation < 50) { 
					gameTime = 0;
					gameLevel = 0;
					levelText.color = Color.gray;
                   // Nikolo_Tesla_animationController.moving = true;
                }

            }
			else if (gameLevel == 1 && gameTime >= 7)
			{
				if (Meditation >= 60 && Attention >= 60) 
					light.lightShow(); // next level will start
				else 
				{
					light.lightShow();
					//StopGame();
                    tesla.Moving();
                }
			}

			// Level 2
			if (gameLevel == 1 && Meditation >= 60 && Attention >= 60 && gameTime >= 7)
			{
				gameLevel = 2;
				iconPad.sprite = meditationIcon;
				levelText.text = "> 50 during 15 sec";		
			}
			else if (gameLevel == 2 && gameTime < 14)
			{
                if (Meditation < 60 || Attention < 60)
                {
                   // StopGame();
                    tesla.Moving();
                }
			}
			else if (gameLevel == 2 && gameTime > 14)
			{
				if (Meditation >= 70 && Attention >= 70) 
					light.lightShow(); // next level will start
				else 
				{
					light.lightShow();
					//StopGame();
				}
			}

			// Level 3
			if (gameLevel == 2 && Meditation >= 70 && Attention >= 70 && gameTime >= 14)
			{

				gameLevel = 3;
				levelText.text = "Level 3";

			}
			else if (gameLevel == 3 && gameTime < 21)
			{
				if (Meditation < 70 || Attention < 70)
                {
                   // StopGame();
                    tesla.Moving();
                }
            }
			else if (gameLevel == 3 && gameTime >= 21)
			{
				if (Meditation >= 80 && Attention >= 80) 
					light.lightShow(); // next level will start
				else 
				{
					light.lightShow();
					//StopGame();
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
