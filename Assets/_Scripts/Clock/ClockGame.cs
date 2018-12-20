using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockGame: MonoBehaviour {

	public Clock clock;

	public GameObject gameUI;
	public GameObject connectMenu;
	public GameObject pauseMenu;

	public Text attText;
	public Text medText;
	public Image attSlImage;
	public Image medSlImage;

	[Header("Received Values")]
	[Range(0, 100)]
	public int Attention = 0;
	[Range(0, 100)]
	public int Meditation = 0;

	private float tmpMedSliderVal = 0;
	private float tmpAtSliderVal = 0;

	// Use this for initialization
	/*void Start () {
		
	}*/

	void OnEnable(){

		clock.hour=System.DateTime.Now.Hour;
		clock.minutes=System.DateTime.Now.Minute;
		clock.seconds=System.DateTime.Now.Second;
		clock.rotateSecondAngle = System.DateTime.Now.Second;
	}
	
	void Update()
	{
		Attention = CONNECTOR.Instance.Attention;
		Meditation = 0;

		GameLogic ();
		UIupdate ();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPauseMenu();
        }
    }

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        gameUI.SetActive(false);
    }


	public float lock90;
	void GameLogic(){

	 	if (Attention > 90) 
		{
			lock90+=Time.deltaTime;
			if (lock90 > 7) 
				clock.clockSpeed = -1f;
			else 
				clock.clockSpeed = 0.2f;
		}
		else if (Attention > 85)
			clock.clockSpeed = 0.4f;
		else if (Attention > 75)
			clock.clockSpeed = 0.6f;
		else if (Attention > 65)
			clock.clockSpeed = 0.8f;
		else
			clock.clockSpeed = 1f;

		if(Attention<90)
			lock90 = 0;
	}

	void UIupdate() {

		attText.text = "" + Attention+"%";
		medText.text = "" + Meditation+"%";

		tmpAtSliderVal = Mathf.Lerp(tmpAtSliderVal, Attention, Time.deltaTime * 5);
		tmpMedSliderVal = Mathf.Lerp(tmpMedSliderVal, Meditation, Time.deltaTime * 5);
		attSlImage.fillAmount = tmpAtSliderVal / 100;
		medSlImage.fillAmount = tmpMedSliderVal / 100;

		clock.UpdateLogic ();
	}
}
