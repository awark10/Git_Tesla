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
	
	void Update()
	{

		if (!GDATA.Instance.isDemo) 
		{
			if (GDATA.Instance.isSignal)
			{
				Attention = GDATA.Instance.Attention;
				Meditation = GDATA.Instance.Meditation;

				GameLogic ();
				UIupdate ();
			} 
			else 
			{
				gameUI.SetActive (false);
				connectMenu.SetActive (true);
			}

			if (Input.GetKeyDown (KeyCode.Escape)) {
				//pauseMenu.SetActive (true);
			}
		}
		else 
		{
			Attention = GDATA.Instance.Attention;
			Meditation = GDATA.Instance.Meditation;
			UIupdate ();
		}
	}

	void GameLogic(){

		//if()

		clock.clockSpeed = 0.5f;
	}

	void UIupdate(){

		attText.text = "" + Attention+"%";
		medText.text = "" + Meditation+"%";

		tmpAtSliderVal = Mathf.Lerp(tmpAtSliderVal, Attention, Time.deltaTime * 5);
		tmpMedSliderVal = Mathf.Lerp(tmpMedSliderVal, Meditation, Time.deltaTime * 5);
		attSlImage.fillAmount = tmpAtSliderVal / 100;
		medSlImage.fillAmount = tmpMedSliderVal / 100;
	}
}
