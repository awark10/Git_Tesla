using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacGame : MonoBehaviour {

	GDATA data;

	public AudioSource DeltaPlayer;
	public AudioSource ThetaPlayer;
	public AudioClip deltaClip;
	public AudioClip ThetaClip;

	void Start () {

		DeltaPlayer = GetComponent<AudioSource> ();
		//ThetaPlayer = GetComponent<AudioSource> ();
		data = GDATA.Instance.GetComponent<GDATA>();

		DeltaPlayer.clip = deltaClip;
		DeltaPlayer.time = 0f;
		DeltaPlayer.Play ();
		DeltaPlayer.SetScheduledEndTime(AudioSettings.dspTime + (3 - 0));


		//ThetaPlayer.clip = ThetaClip;
		//ThetaPlayer.time = 7f;
		//ThetaPlayer.Play ();
		//ThetaPlayer.SetScheduledEndTime(AudioSettings.dspTime + (10 - 7));
	}
	
	void Update () 
	{

		gameLogic ();
		UIupdate ();

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//ShowPauseMenu();
		}
	}

	void gameLogic ()
	{
		if (data.isNewAttention) 
		{


			data.isNewAttention = false;
		}

		if (data.isNewMeditation) 
		{

			data.isNewMeditation = false;
		}

		if (data.isNewDelta) 
		{
			if (data.Delta > 0 && data.Delta < 15) 
			{
				
			}
			if (data.Delta > 15 && data.Delta < 30) 
			{

			}
			if (data.Delta > 30 && data.Delta < 45) 
			{

			}
			if (data.Delta > 45 && data.Delta < 60) 
			{

			}
			if (data.Delta > 60 && data.Delta < 75) 
			{

			}
			if (data.Delta > 75 && data.Delta < 90) 
			{

			}
			if (data.Delta > 90 && data.Delta < 100) 
			{

			}

			data.isNewDelta = false;
		}

		if (data.isNewTheta) 
		{


			data.isNewTheta = false;
		}
	}

	void UIupdate()
	{
		
	}
}
