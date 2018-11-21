using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeGame : MonoBehaviour {

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
	void Start () {
		
	}

	void OnEnable(){

		clock.hour=System.DateTime.Now.Hour;
		clock.minutes=System.DateTime.Now.Minute;
		clock.seconds=System.DateTime.Now.Second;
		clock.rotateSecondAngle = System.DateTime.Now.Second;
	}
	
	void Update()
	{

		if (!GDATA.Instance.isDemo) 
		{
			if (GDATA.Instance.isSignal)
			{
				Attention = GDATA.Instance.Attention;
				Meditation = 0;

				GameLogic ();
				UIupdate ();
			} 
			else 
			{
				gameUI.SetActive (false);
				connectMenu.SetActive (true);
			}

			if (Input.GetKeyDown (KeyCode.Escape)) {
				pauseMenu.SetActive (true);
			}
		}
		else 
		{
			Attention = GDATA.Instance.Attention;
			Meditation = GDATA.Instance.Meditation;
			UIupdate ();
		}
	}

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

	void GameLogic(){

		if(Attention > 65)
			clock.clockSpeed = 0.5f;
		else if (Attention > 75)
			clock.clockSpeed = 0.3f;
		else if (Attention > 85)
			clock.clockSpeed = 0.25f;
		else if (Attention > 90)
			clock.clockSpeed = 0.1f;
		else
			clock.clockSpeed = 1f;
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
